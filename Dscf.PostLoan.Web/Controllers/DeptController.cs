using Dscf.PostLoanGlobal;
using Dscf.PostLoan.AuthCenterBLL;
using Dscf.PostLoan.AuthCenterBLL.DscfACService;
using Dscf.PostLoan.CreditLoanBLL;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dscf.PostLoan.Web.Controllers
{
    public class DeptController : Controller
    {
        public ACDeptInfoBLL ACDeptInfoBLL { get; set; }

        public CreditLoanDeptInfoBLL CreditLoanDeptInfoBLL { get; set; }


        [ChildActionOnly]
        public ActionResult DeptCityList(string type)
        {
            DeptViewModel[] deptViewModelArray;
            switch (type)
            {
                case "CarLoan":
                    deptViewModelArray = ACDeptInfoBLL.GetChildDeptListByDeptID(DeptUtil.CarLoanBUKey);
                    break;
                default:
                    deptViewModelArray = CreditLoanDeptInfoBLL.GetSupportDeptList();
                    break;
            }
            ViewBag.Type = type;
            return PartialView("_PartialDeptCity", deptViewModelArray);
        }
    }
}