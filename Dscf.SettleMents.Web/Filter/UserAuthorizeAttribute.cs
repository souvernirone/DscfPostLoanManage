using Dscf.PostLoanGlobal;
using Dscf.SettleMents.Web.DscfBIService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dscf.SettleMents.Web.Filter
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var UnUserAuthorizeAction = filterContext.ActionDescriptor.GetCustomAttributes(typeof(UnUserAuthorizeAttribute), true);
            if (UnUserAuthorizeAction.Any())
            {
                return;
            }

            Uri uri = filterContext.HttpContext.Request.Url;
            var request = HttpContext.Current.Request;

            HttpCookie optCookie = request.Cookies["OperaterInfo"];

            if (optCookie == null)
            {
                SetHttpContext(filterContext, EnumJsonResult.NotLogin, "未登录");
                return;
            }

            AuthOptRequest authOptRequest = new AuthOptRequest()
            {
                OptCookie = optCookie.Value,
                PlatformId = PlatformUtil.SettleMentPlat,
                IsAjax = filterContext.HttpContext.Request.IsAjaxRequest(),//是否是ajax请求
                AccessPath = uri.AbsolutePath == "/" ? "/Home/Index" : uri.AbsolutePath,//请求路径
                IPAddress = IPHelper.GetHostAddress(),
                Browser = filterContext.HttpContext.Request.Browser.Browser,
                ScreenResolution = request.Browser.ScreenPixelsWidth.ToString() + "*" + request.Browser.ScreenPixelsHeight.ToString()
            };

            using (DscfBIServerConractClient client = new DscfBIServerConractClient())
            {
                client.Open();
                AuthResult result = client.AuthOperaterIsLicit(authOptRequest);

                //未登录、重新登录、Cookie解密出错
                if (result.AuthStatus == EnumAuthStatus.NoLogin || result.AuthStatus == EnumAuthStatus.AgainLogin || result.AuthStatus == EnumAuthStatus.DecryptError)
                {
                    SetHttpContext(filterContext, EnumJsonResult.NotLogin, "未登录");
                }
                //认证用户没有权限
                else if (result.AuthStatus == EnumAuthStatus.NoPermission)
                {
                    SetHttpContext(filterContext, EnumJsonResult.NoAccess, "您没有权限执行此操作");
                }
            }
        }


        private void SetHttpContext(AuthorizationContext filterContext, EnumJsonResult result, string msg)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var data = new ResultMessage(false, msg);
                filterContext.Result = new JsonResult() { Data = data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {
                if (result == EnumJsonResult.NotLogin)
                {
                    filterContext.Result = new RedirectResult(string.Format("/Account/LogIn?ReturnUrl={0}", filterContext.HttpContext.Request.Url.OriginalString));
                }
                else
                {
                    filterContext.Result = new ViewResult() { ViewName = "NoAccess" };
                }
            }
        }

    }
}