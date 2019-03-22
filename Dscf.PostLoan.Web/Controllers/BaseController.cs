using Dscf.PostLoanGlobal;
using Dscf.PostLoan.Web.DscfBIService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dscf.PostLoan.Web.Filter;
using Dscf.PostLoan.Web.Helper;

namespace Dscf.PostLoan.Web.Controllers
{
    [UserAuthorize(Order = 999)]
    public abstract class BaseController : Controller
    {
        public BaseController()
        {
            HttpCookie optCookie = System.Web.HttpContext.Current.Request.Cookies["OperaterInfo"];
            if (optCookie != null)
            {
                using (DscfBIServerConractClient client = new DscfBIServerConractClient())
                {
                    ViewBag.LoginUserName = LoginInfoHelper.Operater().Name;
                }
            }
        }
    }
}