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

namespace Dscf.SettleMents.Web.Controllers
{
    public class DeductionController : BaseController
    {
        public DeductPayApplyBLL DeductPayApplyBLL { get; set; }
        public CreditLoanInfoBLL CreditLoanInfoBLL { get; set; }
        public CreditLoanProductOrderBLL CreditLoanProductOrderBLL { get; set; }
        public CreditLoanDeductProgressBLL CreditLoanDeductProgressBLL { get; set; }
        public CarLoanOrderProductBLL CarLoanOrderProductBLL { get; set; }
        public CarDeductProgressBLL CarDeductProgressBLL { get; set; }
        public CarLoanMonthRepayBLL CarLoanMonthRepayBLL { get; set; }
        public CreditLoan_MonthRepayBLL CreditLoan_MonthRepayBLL { get; set; }
        //
        // GET: /Deduction/

        #region 页面

        #region 信贷列表页

        public ActionResult CreditDeductionList()
        {
            return View();
        }

        #endregion

        #region 信贷详情页面

        /// <summary>
        /// 信贷扣款页面
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public ActionResult CreditDeductClaims(int orderId, int approvalStatus, int orderState, int payWay)
        {
            ViewBag.OrderType = LoanOrderUtil.CreditTypeKey;
            CreditClaimsInfoTotal creditClaimsInfoTotal;
            creditClaimsInfoTotal = CreditLoanInfoBLL.GenerateCreditClaimsInfo(CreditLoanInfoBLL.GetLoanProductOrderDetail(orderId));
            var DeductPayApplyAndFile = DeductPayApplyBLL.GetDeductPayApplyAndFile(creditClaimsInfoTotal.OrderId, LoanOrderUtil.CreditTypeKey);
            if (approvalStatus == 4 && payWay == 1)
            {
                ViewBag.deductProgress = CreditLoanDeductProgressBLL.GetDeductList(orderId).FirstOrDefault();
            }
            ViewBag.DeductPayApplyAndFile = DeductPayApplyAndFile;
            return View("CreditDeductClaims", creditClaimsInfoTotal);
        }
        #endregion

        #region 批量扣款页面
        /// <summary>
        /// 批量扣款扣页面
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="periodOrder"></param>
        /// <returns></returns>
        public ActionResult CreditBatchDeductClaims(int orderId, int orderState)
        {
            List<Loan_MonthRepayViewModel> Loan_MonthRepayViewList = CreditLoan_MonthRepayBLL.GetLoan_MonthRepayInfoByorderID(orderId).ToList();
            ViewBag.Loan_MonthRepayViewList = Loan_MonthRepayViewList;//月还信息
            Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.CreditCriticalAmountListDto CreditCriticalAmountListDto =
                CreditLoanInfoBLL.GetCriticalAmountList(1, 10, orderId).CurrentPageItems.ToList().FirstOrDefault();//借款详情
            return View(CreditCriticalAmountListDto);
        }
        #endregion

        #endregion

        #region 操作

        #region 划扣信息操作

        /// <summary>
        /// 划扣信息操作
        /// </summary>
        /// <param name="deductModel"></param>
        /// <returns></returns>
        public JsonResult UpdateApplyStatusByKey(DeductViewModel deductModel)
        {
            var operatorId = Helper.LoginInfoHelper.Operater().Id;
            bool boolean = DeductPayApplyBLL.UpdateApplyStatusByKey(deductModel, operatorId);
            var ReturnMsg = boolean ? "操作成功" : "操作失败";
            var result = new ResultMessage(boolean, ReturnMsg);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加批量划扣
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="status"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public JsonResult AddADeductProgressByKey(IList<string> idAndPeriods)
        {
            var operatorId = Helper.LoginInfoHelper.Operater().Id;
            Boolean boolean = CreditLoanDeductProgressBLL.DeductinfoFailedAddAll(idAndPeriods, operatorId);
            var ReturnMsg = boolean ? "操作成功" : "操作失败";
            var result = new ResultMessage(boolean, ReturnMsg);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加批量划扣
        /// </summary>
        /// <returns></returns>
        public JsonResult AddADeductProgress()
        {
            var operatorId = Helper.LoginInfoHelper.Operater().Id;
            Boolean boolean = CreditLoanDeductProgressBLL.DeductinfoFailedAddAll(operatorId);
            var ReturnMsg = boolean ? "操作成功" : "操作失败";
            var result = new ResultMessage(boolean, ReturnMsg);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 获取信贷划扣信息

        #region 获取信贷划扣(单笔)

        /// <summary>
        /// 获取信贷划扣信息
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonResult GetDeductThroughList(int pageNum = 1, int pageSize = 10)
        {
            var datas = DeductPayApplyBLL.SelectCreditDeductOrderList(pageNum, pageSize);
            var result = new ResultMessage(true, "加载信息成功", datas.TotalItemCount, datas);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 获取信贷划扣(批量)

        /// <summary>
        /// 获取信贷划扣信息批量
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonResult GetDeductCriticalityThroughList(int pageNum = 1, int pageSize = 10)
        {
            var datas = CreditLoanInfoBLL.GetCriticalAmountList(pageNum, pageSize);
            var result = new ResultMessage(true, "加载信息成功", datas.TotalItemCount, datas);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #endregion

        #endregion

        #region CarLoanRegion

        public ActionResult CarDeductionList()
        {
            ViewBag.Day = DateTime.Now.Day;
            return View();
        }

        public JsonResult GetCarPageDeductApplyList(int pageNum = 1, int pageSize = 10)
        {
            var datas = DeductPayApplyBLL.SelectCarDeductOrderList(pageNum, pageSize, LoanOrderUtil.CarTypeKey);
            var result = new ResultMessage(true, "加载信息成功", datas.TotalItemCount, datas);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPageCarLoanBatchDeductList(int pageNum = 1, int pageSize = 10)
        {
            var datas = CarLoanOrderProductBLL.GetPageCarLoanBatchDeductList(pageNum, pageSize);
            var result = new ResultMessage(true, "加载信息成功", datas.TotalItemCount, datas);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CarDeductClaims(int orderId, int isExtension, int payWay)
        {
            if (isExtension == 0)
            {
                var loanOrderDetailDto = CarLoanOrderProductBLL.GetLoanProductOrderDetail(orderId);
                var claimsInfoTotal = CarLoanOrderProductBLL.GenerateCarClaimsInfo(loanOrderDetailDto);
                var deductPayApplyAndFile = DeductPayApplyBLL.GetDeductPayApplyAndFile(loanOrderDetailDto.OrderId, LoanOrderUtil.CarTypeKey);
                ViewBag.DeductPayApplyAndFile = deductPayApplyAndFile;
                ViewBag.PayWay = payWay;
                return View("CarDeductClaims", claimsInfoTotal);
            }
            else
            {
                var deductPayApplyAndFile = DeductPayApplyBLL.GetDeductPayApplyAndFile(orderId, LoanOrderUtil.CarTypeKey);
                ViewBag.DeductPayApplyAndFile = deductPayApplyAndFile;
                ViewBag.PayWay = payWay;
                var carLoan = CarLoanOrderProductBLL.GetLoanProductExtensionOrderByOrderId(orderId);
                return View("CarExtensionDeductClaims", carLoan);
            }
        }
        public ActionResult CarDeductClaimsDetail(int orderId, int statusId, int isExtension, int payWay)
        {
            if (isExtension == 0)
            {
                var loanOrderDetailDto = CarLoanOrderProductBLL.GetLoanProductOrderDetail(orderId);
                var claimsInfoTotal = CarLoanOrderProductBLL.GenerateCarClaimsInfo(loanOrderDetailDto);
                var deductPayApplyAndFile = DeductPayApplyBLL.GetDeductPayApplyAndFile(loanOrderDetailDto.OrderId, LoanOrderUtil.CarTypeKey);
                ViewBag.DeductPayApplyAndFile = deductPayApplyAndFile;
                if (statusId == DeductPayUtil.FailedDebit && payWay == DeductPayUtil.DeductApply)
                {
                    ViewBag.deductProgress = CarDeductProgressBLL.GetDeductList(orderId).FirstOrDefault();
                }
                return View("CarDeductClaimsDetail", claimsInfoTotal);
            }
            else
            {
                var deductPayApplyAndFile = DeductPayApplyBLL.GetDeductPayApplyAndFile(orderId, LoanOrderUtil.CarTypeKey);
                ViewBag.DeductPayApplyAndFile = deductPayApplyAndFile;
                ViewBag.PayWay = payWay;
                var carLoan = CarLoanOrderProductBLL.GetLoanProductExtensionOrderByOrderId(orderId);
                return View("CarExtensionDeductClaimsDetail", carLoan);
            }
        }
        /// <summary>
        /// 车贷批量划扣-扣
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="RepayId"></param>
        /// <param name="codeName"></param>
        /// <returns></returns>
        public ActionResult CarBatchDeductClaims(int orderId, int RepayId, string codeName)
        {
            ViewBag.MonthRepay = CarLoanMonthRepayBLL.GetLoanMonthRepayInfoByOrderId(orderId).Where(repay => repay.RepayId == RepayId).FirstOrDefault();
            var carLoan = CarLoanOrderProductBLL.GetLoanProductOrderInfoByOrderId(orderId);
            if (codeName.Contains("失败"))
            {
                ViewBag.deductProgress = CarDeductProgressBLL.GetDeductList(orderId).FirstOrDefault();
            }
            return View("CarBatchDeductClaims", carLoan);
        }
        /// <summary>
        /// 车贷批量划扣-查
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="RepayId"></param>
        /// <param name="codeName"></param>
        /// <returns></returns>
        public ActionResult CarBatchDeductClaimsDetail(int orderId, int RepayId, string codeName)
        {
            ViewBag.MonthRepay = CarLoanMonthRepayBLL.GetLoanMonthRepayInfoByOrderId(orderId).Where(repay => repay.RepayId == RepayId).FirstOrDefault();
            var carLoan = CarLoanOrderProductBLL.GetLoanProductOrderInfoByOrderId(orderId);
            if (codeName.Contains("失败"))
            {
                ViewBag.deductProgress = CarDeductProgressBLL.GetDeductList(orderId).FirstOrDefault();
            }
            return View("CarBatchDeductClaimsDetail", carLoan);
        }
        /// <summary>
        /// 查询车贷月还信息列表
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public JsonResult QueryCarRepayList(int orderId)
        {
            var data = CarLoanMonthRepayBLL.GetLoanMonthRepayInfoByOrderId(orderId);
            ResultMessage result = new ResultMessage(true, "查询车贷订单的月还信息成功!", data);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddCarDeductProgressByKey(IList<string> idAndPeriods)
        {
            var operatorId = Helper.LoginInfoHelper.Operater().Id;
            Boolean boolean = CarDeductProgressBLL.AddCarDeductProgressByKey(idAndPeriods, operatorId);
            var ReturnMsg = boolean ? "操作成功" : "操作失败";
            var result = new ResultMessage(boolean, ReturnMsg);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddBatchCarDeductProgress()
        {
            var datas = CarLoanOrderProductBLL.GetCarLoanBatchDeductList();
            IList<string> idAndPeriods = new List<string>();
            foreach (var data in datas)
            {
                idAndPeriods.Add(data.OrderId + "," + data.RepayId);
            }
            return AddCarDeductProgressByKey(idAndPeriods);
        }
        #endregion

    }
}
