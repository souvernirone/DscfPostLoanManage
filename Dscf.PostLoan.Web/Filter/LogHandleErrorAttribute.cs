using Dscf.PostLoanGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dscf.PostLoan.Web.Filter
{
    public class LogHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception exception = filterContext.Exception;
            if (filterContext.ExceptionHandled == true || filterContext.IsChildAction)
            {
                return;
            }


            HttpException httpException = new HttpException(null, exception);
            LogHelper.WriteLog(typeof(LogHandleErrorAttribute), httpException);

            filterContext.ExceptionHandled = true;
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                var result = new ResultMessage(false, exception.Message);
                filterContext.Result = new JsonResult() { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            else
            {

                ViewDataDictionary dict = new ViewDataDictionary();
                dict.Add("ErrorMessage", exception.Message);
                filterContext.Result = new ViewResult() { ViewName = "Error", ViewData = dict };
            }

        }
    }
}