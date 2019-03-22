using Dscf.SettleMents.Web.DscfBIService;
using Dscf.SettleMents.Web.Filter;
using Dscf.SettleMents.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dscf.SettleMents.Web.Controllers
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