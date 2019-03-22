using Dscf.PostLoanGlobal;
using Dscf.PostLoan.LoanAfterBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dscf.PostLoan.CreditLoanBLL;
using Dscf.PostLoan.CarLoanBLL;
using Dscf.PostLoan.Model;

namespace Dscf.PostLoan.Web.Controllers
{
    /// <summary>
    /// 划扣审批
    /// </summary>
    public class ApprovalController : BaseController
    {
        public CreditLoanInfoBLL CreditLoanInfoBLL { get; set; }
        public DeductPayApplyBLL DeductPayApplyBLL { get; set; }

        public CarLoanOrderProductBLL CarLoanOrderProductBLL { get; set; }

        public CreditLoanProductOrderBLL CreditLoanProductOrderBLL { get; set; }
        //
        // GET: /Approval/
        public ActionResult List()
        {
            return View();
        }

        public JsonResult GetDeductApprovalList(int pageNum = 1, int pageSize = 10)
        {
            var datas = DeductPayApplyBLL.GetDeductPayList(pageNum, pageSize);
            var result = new ResultMessage(true, "加载信息成功", datas.TotalItemCount, datas);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreditClaimsDetail(int orderId)
        {
            ViewBag.OrderType = LoanOrderUtil.CreditTypeKey;
            CreditClaimsInfoTotal creditClaimsInfoTotal;
            creditClaimsInfoTotal = CreditLoanInfoBLL.GenerateCreditClaimsInfo(CreditLoanInfoBLL.GetLoanProductOrderDetail(orderId));
            var DeductPayApplyAndFile = DeductPayApplyBLL.GetDeductPayApplyAndFile(creditClaimsInfoTotal.OrderId, LoanOrderUtil.CreditTypeKey);
            if (DeductPayApplyAndFile.PayWay == DeductPayUtil.DeductApply)
            {
                DeductPayApplyAndFile.PayWayName = "申请划扣";
            }
            else if (DeductPayApplyAndFile.PayWay == DeductPayUtil.PayOffline)
            {
                DeductPayApplyAndFile.PayWayName = "线下支付";
            }
            else if (DeductPayApplyAndFile.PayWay == DeductPayUtil.CarDisposal)
            {
                DeductPayApplyAndFile.PayWayName = "车辆处置";
            }
            ViewBag.DeductPayApplyAndFile = DeductPayApplyAndFile;
            return View("CreditClaimsDetail", creditClaimsInfoTotal);
        }
        public ActionResult CarClaimsDetail(int orderId)
        {
            ViewBag.OrderType = LoanOrderUtil.CarTypeKey;
            CarClaimsInfoTotal carClaimsInfoTotal;
            carClaimsInfoTotal = CarLoanOrderProductBLL.GenerateCarClaimsInfo(CarLoanOrderProductBLL.GetLoanProductOrderDetail(orderId));
            var deductPayApplyAndFile = DeductPayApplyBLL.GetDeductPayApplyAndFile(carClaimsInfoTotal.OrderId, LoanOrderUtil.CarTypeKey);
            if (deductPayApplyAndFile.PayWay == DeductPayUtil.DeductApply)
            {
                deductPayApplyAndFile.PayWayName = "申请划扣";
            }
            else if (deductPayApplyAndFile.PayWay == DeductPayUtil.PayOffline)
            {
                deductPayApplyAndFile.PayWayName = "线下支付";
            }
            else if (deductPayApplyAndFile.PayWay == DeductPayUtil.CarDisposal)
            {
                deductPayApplyAndFile.PayWayName = "车辆处置";
            }
            ViewBag.DeductPayApplyAndFile = deductPayApplyAndFile;
            return View("CarClaimsDetail", carClaimsInfoTotal);

        }
        public JsonResult UpdateApplyStatusByKey(int orderId, int orderType, int status, string reason)
        {
            var operatorId = Helper.LoginInfoHelper.Operater().Id;
            bool boolean = DeductPayApplyBLL.UpdateApplyStatusByKey(orderId, orderType, status, operatorId, reason);
            if (boolean)
            {
                switch (orderType)
                {
                    case 1:
                        {
                            boolean = CreditLoanProductOrderBLL.UpdateCollectStatus(orderId, status, Helper.LoginInfoHelper.Operater().Id);
                            break;
                        }
                    default:
                        {
                            boolean = CarLoanOrderProductBLL.UpdateCollectStatus(orderId, status, Helper.LoginInfoHelper.Operater().Id);
                            break;
                        }
                }
            }
            var ReturnMsg = boolean ? "操作成功" : "操作失败";
            var result = new ResultMessage(boolean, ReturnMsg);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateApplyStatusBatch(IList<string> idAndTypes, int status, string reason)
        {
            if (idAndTypes == null)
            {
                idAndTypes = new List<string>();
            }
            var operatorId = Helper.LoginInfoHelper.Operater().Id;
            var creditOrderIds = new List<int>();
            var carOrderIds = new List<int>();
            foreach (var idAndType in idAndTypes)
            {
                if (idAndType.Contains(",1"))
                {
                    creditOrderIds.Add(Convert.ToInt32(idAndType.Remove(idAndType.LastIndexOf(","))));
                }
                else if (idAndType.Contains(",2"))
                {
                    carOrderIds.Add(Convert.ToInt32(idAndType.Remove(idAndType.LastIndexOf(","))));
                }
            }
            bool boolean = DeductPayApplyBLL.UpdateApplyStatusBatch(creditOrderIds.ToArray(), carOrderIds.ToArray(), status, operatorId, reason);
            if (boolean)
            {
                CreditLoanProductOrderBLL.UpdateCollectStatusBatch(creditOrderIds.ToArray(), status, Helper.LoginInfoHelper.Operater().Id);
                CarLoanOrderProductBLL.UpdateCollectStatusBatch(carOrderIds.ToArray(), status, Helper.LoginInfoHelper.Operater().Id);
            }
            var ReturnMsg = boolean ? "操作成功" : "操作失败";
            var result = new ResultMessage(boolean, ReturnMsg);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}