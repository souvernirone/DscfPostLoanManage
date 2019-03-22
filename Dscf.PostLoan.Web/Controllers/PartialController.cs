using Dscf.PostLoan.Web.DscfBIService;
using Dscf.PostLoan.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dscf.PostLoan.Web.Controllers
{
    [ChildActionOnly]
    public class PartialController : Controller
    {
        //
        // GET: /Partial/
        public ActionResult TopNav()
        {
            var operCookie = LoginInfoHelper.Operater();
            ViewBag.OptName = operCookie.Name;
            //int optId = operCookie.Id;
            var platformList = LoginInfoHelper.GetAccessPlatformList();
            return PartialView(platformList);
        }

        /// <summary>
        /// 局部视图-左侧导航菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult Menu()
        {
            
            var platformList = LoginInfoHelper.GetCurrentMenuList().OrderBy(item=>item.Sort);
            return PartialView(platformList);
        }
    }
}