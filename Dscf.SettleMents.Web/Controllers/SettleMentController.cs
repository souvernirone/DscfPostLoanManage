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

namespace Dscf.SettleMents.Web.Controllers
{
    public class SettleMentController : BaseController
    {
        public LoginInfoHelper LoginInfoHelper { get; set; }
        public OperaterInfoBLL OperaterInfoBLL { get; set; }
        public CreditLoanInfoBLL CreditLoanInfoBLL { get; set; }
        public CarLoanOrderProductBLL CarLoanOrderProductBLL { get; set; }
        public DeductPayApplyBLL DeductPayApplyBLL { get; set; }
        public CarDeductProgressBLL CarDeductProgressBLL { get; set; }

        public CreditLoanDeductProgressBLL CreditLoanDeductProgressBLL { get; set; }
        //
        // GET: /SettleMent/

        /// <summary>
        /// 综合查询页面
        /// </summary>
        /// <returns></returns>
        public ActionResult SettleMentList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            int[] roles = OperaterInfoBLL.GetRoleIdsById(LoginInfoHelper.Operater().Id);//根据登录人ID获取所属角色
            if (roles.Contains(RoleUtil.SettlementPersonnel))
            {
                list.Add(new SelectListItem() { Text = "信贷订单", Value = "1", Selected = true });
                list.Add(new SelectListItem() { Text = "车贷订单", Value = "2" });
            }
            ViewData["custromType"] = list.AsEnumerable();
            return View();
        }
        public ActionResult CreditOrCarLoanInfoDetails(int orderType, int orderId)
        {
            ViewData["orderType"] = orderType;
            ViewData["orderId"] = orderId;
            return View();
        }
        /// <summary>
        /// 借款信息分布视图显示
        /// </summary>
        /// <param name="orderType"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult LoanInfo(int orderType, int orderId)
        {
            switch (orderType)
            {
                case 1:
                    LoanSearchViewModels loanSearchViewModels = new LoanSearchViewModels() { OrderId = orderId.ToString(), OptId = LoginInfoHelper.Operater().Id, PageSize = 10, PageNum = 1 };
                    Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.LoanInfoDto loaninfo = CreditLoanInfoBLL.GetPageLoanInfoList(loanSearchViewModels).CurrentPageItems.ToList()[0];
                    Dscf.Settlement.Model.PartialLoanInfoViewModel model = AutoMapper.Mapper.Map<Dscf.Settlement.Model.PartialLoanInfoViewModel>(loaninfo);
                    return PartialView("_PartialLoanInfo", model);
                default:
                    var carLoan = CarLoanOrderProductBLL.GetLoanProductOrderInfoByOrderId(orderId);
                    Dscf.Settlement.Model.PartialLoanInfoViewModel models = AutoMapper.Mapper.Map<Dscf.Settlement.Model.PartialLoanInfoViewModel>(carLoan);
                    return PartialView("_PartialLoanInfo", models);
            }
        }

        [ChildActionOnly]
        public ActionResult PaymentInfo(int orderType, int orderId)
        {
            return PartialView("_PartialPaymentInfo");
        }

        [ChildActionOnly]
        public ActionResult DeductionInfo(int orderType, int orderId)
        {
            DeductProgressInfo[] deductList;
            if (orderType == LoanOrderUtil.CarTypeKey)
            {
                deductList = CarDeductProgressBLL.GetDeductList(orderId);
            }
            else
            {
                deductList = CreditLoanDeductProgressBLL.GetDeductList(orderId);
            }
            return PartialView("_PartialDeductionInfo", deductList);
        }
        /// <summary>
        /// 债权信息车贷显示分布视图
        /// </summary>
        /// <param name="orderType"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult CarClaimsInfo(int orderType, int orderId)
        {
            var loanOrderDetailDto = CarLoanOrderProductBLL.GetLoanProductOrderDetail(orderId);
            if (loanOrderDetailDto != null)
            {
                var claimsInfoTotal = CarLoanOrderProductBLL.GenerateCarClaimsInfo(loanOrderDetailDto);
                return PartialView("_PartialCarClaimsInfo", claimsInfoTotal);
            }
            return PartialView("_PartialCarClaimsInfo", null);
        }
        /// <summary>
        /// 债权信息信贷显示分布视图
        /// </summary>
        /// <param name="orderType"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult CreditClaimsInfo(int orderType, int orderId)
        {
            var loanOrderDetailDto = CreditLoanInfoBLL.GetLoanProductOrderDetail(orderId);
            if (loanOrderDetailDto != null)
            {
                var claimsInfoTotal = CreditLoanInfoBLL.GenerateCreditClaimsInfo(loanOrderDetailDto);
                return PartialView("_PartialCreditClaimsInfo", claimsInfoTotal);
            }
            return PartialView("_PartialCreditClaimsInfo", null);
        }
        /// <summary>
        /// 综合查询分页信息
        /// </summary>
        /// <param name="loanSearchViewModel"></param>
        /// <returns></returns>
        public JsonResult GetPageLoanInfoList(LoanSearchViewModels loanSearchViewModel)
        {
            loanSearchViewModel.OptId = LoginInfoHelper.Operater().Id;
            switch (loanSearchViewModel.OrderType)
            {
                case "1":
                    var datas = CreditLoanInfoBLL.GetPageLoanInfoList(loanSearchViewModel);//信贷
                    datas.CurrentPageItems.ToList().ForEach(vm => vm.OrderType = 1);
                    var result = new ResultMessage(true, "加载信息成功", datas.TotalItemCount, datas);
                    return Json(result, JsonRequestBehavior.AllowGet);
                default:
                    var orderList = CarLoanOrderProductBLL.SelectLoanProductOrderList(loanSearchViewModel);//车贷
                    orderList.CurrentPageItems.ToList().ForEach(vm => vm.OrderType = 2);
                    var results = new ResultMessage(true, "加载信息成功", orderList.TotalItemCount, orderList);
                    return Json(results, JsonRequestBehavior.AllowGet);
            }
        }

    }
}