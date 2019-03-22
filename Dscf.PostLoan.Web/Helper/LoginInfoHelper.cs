using Dscf.PostLoanGlobal;
using Dscf.PostLoan.Web.DscfBIService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dscf.PostLoan.Web.Helper
{
    public class LoginInfoHelper
    {
        /// <summary>
        /// 得到存储的Cookie信息
        /// </summary>
        /// <returns></returns>
        public static OperaterEntity Operater()
        {
            try
            {
                var request = HttpContext.Current.Request;
                HttpCookie optCookie = request.Cookies["OperaterInfo"];

                string jsonOperatorCookie = optCookie.Value;
                using (DscfBIServerConractClient client = new DscfBIServerConractClient())
                {
                    return client.GetOperaterInfoByCookie(jsonOperatorCookie, PlatformUtil.PostLoanPlat);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 操作员可访问平台
        /// </summary>
        /// <returns></returns>
        public static IList<PlatformEntity> GetAccessPlatformList()
        {
            try
            {
                var request = HttpContext.Current.Request;
                HttpCookie optCookie = request.Cookies["OperaterInfo"];

                string jsonOperatorCookie = optCookie.Value;
                using (DscfBIServerConractClient client = new DscfBIServerConractClient())
                {
                    return client.SelectAccessPlatformListByCookie(jsonOperatorCookie);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 操作员在当前平台可访问菜单列表
        /// </summary>
        /// <returns></returns>
        public static IList<MenuEntity> GetCurrentMenuList()
        {
            var request = HttpContext.Current.Request;
            HttpCookie optCookie = request.Cookies["OperaterInfo"];

            string jsonOperatorCookie = optCookie.Value;
            try
            {
                using (DscfBIServerConractClient client = new DscfBIServerConractClient())
                {
                    return client.GetPlatformMenuListByOptId(jsonOperatorCookie, PlatformUtil.PostLoanPlat);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}