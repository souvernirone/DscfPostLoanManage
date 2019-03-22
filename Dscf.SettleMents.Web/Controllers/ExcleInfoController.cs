using Dscf.PostLoan.AuthCenterBLL;
using Dscf.SettleMents.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dscf.PostLoanGlobal;
using Dscf.PostLoan.CarLoanBLL;
using Dscf.PostLoan.CreditLoanBLL;
using Dscf.PostLoan.LoanAfterBLL;
using Dscf.Settlement.Model;
using Dscf.PostLoan.Model;
using System.Data;
using Dscf.PostLoan.LoanAfterBLL.DscfLoanAfterService;

namespace Dscf.SettleMents.Web.Controllers
{
    public class ExcleInfoController : BaseController
    {
        public RepayRemindBLL RepayRemindBLL { get; set; }
        public DictionaryBLL DictionaryBLL { get; set; }
        public CreditLoanExcleInfoBLL CreditExcleInfoBLL { get; set; }
        public CarLoanExcleInfoBLL CarExcleInfoBLL { get; set; }
        public ExcleInfoBLL ExcleInfoBLL { get; set; }
        public CreditLoanDeptInfoBLL CreditLoanDeptInfoBLL { get; set; }
        public ACDeptInfoBLL ACDeptInfoBLL { get; set; }
        public OperaterInfoBLL OperaterInfoBLL { get; set; }
        //
        // GET: /ExcleInfo/
        public ActionResult ExportExcle()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            int[] roles = OperaterInfoBLL.GetRoleIdsById(LoginInfoHelper.Operater().Id);//根据登录人ID获取所属角色
            if (roles.Contains(RoleUtil.SettlementPersonnel))
            {
                list.Add(new SelectListItem() { Text = "信贷订单", Value = "1", Selected = true });
                list.Add(new SelectListItem() { Text = "车贷订单", Value = "2" });
            }
            List<SelectListItem> list2 = new List<SelectListItem>();
            list2.Add(new SelectListItem() { Text = "全部", Value = "0", Selected = true });

            List<SelectListItem> list3 = new List<SelectListItem>();
            list3.Add(new SelectListItem() { Text = "逾期", Value = "0", Selected = true });
            list3.Add(new SelectListItem() { Text = "已还款", Value = "1" });
            list3.Add(new SelectListItem() { Text = "还一部分", Value = "2" });

            List<SelectListItem> list4 = new List<SelectListItem>();
            list4.Add(new SelectListItem() { Text = "是", Value = "1", Selected = true });
            list4.Add(new SelectListItem() { Text = "否", Value = "0" });

            List<SelectListItem> list5 = new List<SelectListItem>();
            list5.Add(new SelectListItem() { Text = "全部", Value = "", Selected = true });

            List<SelectListItem> list6 = new List<SelectListItem>();
            list6.Add(new SelectListItem() { Text = "新客户", Value = "1", Selected = true });
            list6.Add(new SelectListItem() { Text = "老客户", Value = "2", Selected = true });
            list6.Add(new SelectListItem() { Text = "展期客户", Value = "3", Selected = true });

            ViewData["productType"] = list.AsEnumerable();
            ViewData["cityName"] = list2.AsEnumerable();
            ViewData["statusName"] = list3.AsEnumerable();
            ViewData["collectStatusName"] = list4.AsEnumerable();
            ViewData["common"] = list5.AsEnumerable();
            ViewData["customerType"] = list6.AsEnumerable();

            return View();
        }

        public void FinancialExportExcle(FinancialExportExcleViewModel model)
        {
            if (model.ProductType == LoanOrderUtil.CreditTypeKey || model.ProductType == 0)//信贷
            {
                CreditExcleInfoBLL.GetFinancialExportExcle(model);
            }
            if (model.ProductType == LoanOrderUtil.CarTypeKey || model.ProductType == 0)//车贷
            {
                CarExcleInfoBLL.GetFinancialExportExcle(model);
            }
        }
        /// <summary>
        /// 逾期违约的Excle导出
        /// </summary>
        /// <param name="model"></param>
        public void OverdueExportExcle(OverdueExportExcleViewModel model)
        {
            ExcleInfoBLL.OverdueExportExcle(model);
        }

        #region 获取城市信息
        /// <summary>
        /// 获取城市信息
        /// </summary>
        /// <param name="productTypeId"></param>
        /// <returns></returns>
        public JsonResult GetCityNameListOfproductTypeId(int productTypeId = 0)
        {
            DeptViewModel[] deptViewModelArray = null;
            switch (productTypeId)
            {
                case 1:
                    deptViewModelArray = CreditLoanDeptInfoBLL.GetSupportDeptList();
                    break;
                default:
                    deptViewModelArray = ACDeptInfoBLL.GetChildDeptListByDeptID(DeptUtil.CarLoanBUKey);
                    break;
            }
            return Json(new ResultMessage(true, "加载信息成功", deptViewModelArray == null ? 0 : deptViewModelArray.Count(), deptViewModelArray), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 获取产品名称
        /// <summary>
        /// 获取产品名称
        /// </summary>
        /// <param name="productTypeId"></param>
        /// <returns></returns>
        public JsonResult GetProductNameListOfproductTypeId(int productTypeId = 0)
        {
            var proList = ExcleInfoBLL.GetLoanAfterProduct(ProductUtil.FinancialType, productTypeId).ToList();
            return Json(new ResultMessage(true, "加载信息成功", proList.Count, proList), JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}