using Dscf.PostLoanGlobal;
using Dscf.PostLoan.CarLoanBLL;
using Dscf.PostLoan.CreditLoanBLL;
using Dscf.PostLoan.LoanAfterBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dscf.PostLoan.AuthCenterBLL;
using Dscf.PostLoan.LoanAfterBLL.DscfLoanAfterService;
using Dscf.PostLoan.Web.Helper;

namespace Dscf.PostLoan.Web.Controllers
{
    public class RepayRemindController : BaseController
    {
        public CreditLoanInfoBLL CreditLoanInfoBLL { get; set; }

        public CarLoanOrderProductBLL CarLoanOrderProductBLL { get; set; }

        public RepayRemindBLL RepayRemindBLL { get; set; }

        public DictionaryBLL DictionaryBLL { get; set; }

        public CarLoanExtensionApplyBLL CarLoanExtensionApplyBLL { get; set; }

        public CarLoanMonthRepayBLL CarLoanMonthRepayBLL { get; set; }

        public CreditLoan_MonthRepayBLL CreditLoan_MonthRepayBLL { get; set; }

        public CreditLoanProductOrderBLL CreditLoanProductOrderBLL { get; set; }


        /// <summary>
        /// 还款提醒-信用借款列表
        /// </summary>
        /// <returns></returns>
        public ActionResult CreditRemindList()
        {
            ViewBag.CreditCount = CreditLoanProductOrderBLL.GetIsRemindCount(Helper.LoginInfoHelper.Operater().Id);

            return View("CreditRemindList");
        }

        /// <summary>
        /// 还款提醒-车辆借款列表
        /// </summary>
        /// <returns></returns>
        public ActionResult CarRemindList()
        {
            ViewBag.LongCarCount = CarLoanOrderProductBLL.GetIsRemindCount(true, Helper.LoginInfoHelper.Operater().Id);
            ViewBag.ShortCarCount = CarLoanOrderProductBLL.GetIsRemindCount(false, Helper.LoginInfoHelper.Operater().Id);
            return View("CarRemindList");
        }

        public ActionResult CreditRemindDetail(int orderId, int repayId)
        {
            var creditRemidDetailDto = CreditLoanInfoBLL.GetCreditRemindDetail(orderId, repayId);
            var repayRemindList = RepayRemindBLL.GetRepayRemindListByKey(repayId, 1).ToList();
            var repayRemindTypeList = DictionaryBLL.GetDictListByKey(DictUtil.RemindTypeKey).ToList();
            foreach (var remind in repayRemindList)
            {
                remind.RemindTypeName = repayRemindTypeList.Where(a => a.DictValue == remind.RemindType).FirstOrDefault().DictMemo;
            }
            ViewBag.repayRemindList = repayRemindList;
            ViewBag.dlRepayRemindType = repayRemindTypeList;
            return View(creditRemidDetailDto);
        }

        /// <summary>
        /// 车贷还款提醒详细信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="repayId"></param>
        /// <returns></returns>
        public ActionResult CarRemindDetail(int orderId, int repayId)
        {
            var catRemidDetailDto = CarLoanOrderProductBLL.GetCarRemindDetail(orderId, repayId);
            var repayRemindList = RepayRemindBLL.GetRepayRemindListByKey(repayId, 2).ToList();
            var repayRemindTypeList = DictionaryBLL.GetDictListByKey(DictUtil.RemindTypeKey).ToList();
            foreach (var remind in repayRemindList)
            {
                remind.RemindTypeName = repayRemindTypeList.Where(a => a.DictValue == remind.RemindType).FirstOrDefault().DictMemo;
            }
            ViewBag.repayRemindList = repayRemindList;
            ViewBag.dlRepayRemindType = repayRemindTypeList;
            return View(catRemidDetailDto);
        }

        /// <summary>
        /// 车贷还款提醒短期展期页面
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="repayId"></param>
        /// <returns></returns>
        public ActionResult CarRemindExtensionDetail(int orderId, int repayId)
        {
            var catRemidDetailDto = CarLoanOrderProductBLL.GetCarRemindDetail(orderId, repayId);
            return View(catRemidDetailDto);
        }

        /// <summary>
        /// 获取信贷还款提醒分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonResult GetPageCreditRemindList(int pageNum = 1, int pageSize = 10)
        {
            var datas = CreditLoanInfoBLL.GetPageRepayRemindList(pageNum, pageSize, Helper.LoginInfoHelper.Operater().Id);
            var result = new ResultMessage(true, "加载信息成功", datas.TotalItemCount, datas);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取车辆借款还款提醒分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isLongLoan"></param>
        /// <returns></returns>
        public JsonResult GetPageCarRemindList(int pageNum = 1, int pageSize = 10, bool isLongLoan = true)
        {
            var datas = CarLoanOrderProductBLL.GetPageRepayRemindList(pageNum, pageSize, isLongLoan, Helper.LoginInfoHelper.Operater().Id);
            var result = new ResultMessage(true, "加载信息成功", datas.TotalItemCount, datas);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 修改信贷提醒状态
        /// </summary>
        /// <param name="repayId"></param>
        /// <param name="isRemind"></param>
        /// <returns></returns>
        public JsonResult UpdateCreditRemind(int repayId, bool isRemind)
        {
            var boolean = CreditLoanInfoBLL.UpdateCreditRemind(repayId, isRemind);
            var result = new ResultMessage(boolean, "更改状态成功！");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改车贷提醒还款状态
        /// </summary>
        /// <param name="repayId"></param>
        /// <param name="isRemind"></param>
        /// <returns></returns>
        public JsonResult UpdateCarRemind(int repayId, int isRemind)
        {
            var opertatorId = Helper.LoginInfoHelper.Operater().Id;
            var boolean = CarLoanMonthRepayBLL.UpdateCarRemind(repayId, isRemind, opertatorId);
            var result = new ResultMessage(boolean, "更改状态成功！");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 添加信、车贷提醒
        /// </summary>
        /// <param name="repayId"></param>
        /// <param name="remindContent"></param>
        /// <param name="repayRemindType"></param>
        /// <returns></returns>
        public JsonResult AddRepayRemind(int repayId, string remindContent, int? repayRemindType, int orderType)
        {
            var optEntity = LoginInfoHelper.Operater();
            RepayRemindDto dto;
            var boolean = RepayRemindBLL.AddRepayRemind(repayId, remindContent, repayRemindType, orderType, optEntity.Id, out dto);
            if (boolean && orderType == LoanOrderUtil.CarTypeKey)
            {
                CarLoanOrderProductBLL.UpdateCarRemind(repayId, RemindType.AlreadyRemind, optEntity.Id);
            }
            else if (boolean && orderType == LoanOrderUtil.CreditTypeKey)
            {
                CreditLoan_MonthRepayBLL.UpdateCreditRemind(repayId, true);
            }
            var ReturnMsg = boolean ? "操作成功" : "操作失败";
            dto.OptName = optEntity.Name;
            var result = new ResultMessage(boolean, ReturnMsg, dto);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 修改信、车贷还款提醒
        /// </summary>
        /// <returns></returns>
        public JsonResult EditRepayRemind(int remindId, string remindContent, int? repayRemindType)
        {
            var optEntity = LoginInfoHelper.Operater();
            RepayRemindDto dto;
            var boolean = RepayRemindBLL.EditRepayRemind(remindId, remindContent, repayRemindType, optEntity.Id, out dto);
            var ReturnMsg = boolean ? "操作成功" : "操作失败";
            var result = new ResultMessage(boolean, ReturnMsg, dto);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取提醒列表
        /// </summary>
        /// <param name="repayId"></param>
        /// <returns></returns>
        public JsonResult GetRepayRemindList(int repayId, int orderType)
        {
            var pageRepayRemindList = RepayRemindBLL.GetRepayRemindListByKey(repayId, orderType).ToList();
            var repayRemindList = DictionaryBLL.GetDictListByKey("RepayRemindType").ToList();
            foreach (var remind in pageRepayRemindList)
            {
                remind.RemindTypeName = repayRemindList.Where(a => a.DictValue == remind.RemindType).FirstOrDefault().DictMemo;
            }
            var result = new ResultMessage(true, "", pageRepayRemindList.Count(), pageRepayRemindList);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        ///// <summary>
        ///// 获取提醒列表
        ///// </summary>
        ///// <param name="repayId"></param>
        ///// <returns></returns>
        //public JsonResult GetRepayRemindList(int repayId, int orderType)
        //{
        //    var pageRepayRemindList = RepayRemindBLL.GetRepayRemindListByKey(repayId, orderType).ToList();
        //    var repayRemindList = DictionaryBLL.GetDictListByKey("RepayRemindType").ToList();
        //    foreach (var remind in pageRepayRemindList)
        //    {
        //        remind.RemindTypeName = repayRemindList.Where(a => a.DictValue == remind.RemindType).FirstOrDefault().DictMemo;
        //    }
        //    var result = new ResultMessage(true, "", pageRepayRemindList.Count(), pageRepayRemindList);
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        /// <summary>
        /// 删除信、车贷提醒（单一）
        /// </summary>
        /// <param name="remindId"></param>
        /// <returns></returns>
        public JsonResult DelRepayRemind(int remindId)
        {
            var boolean = RepayRemindBLL.DelRepayRemind(remindId);
            var ReturnMsg = boolean ? "操作成功" : "操作失败";
            var result = new ResultMessage(boolean, ReturnMsg, remindId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 添加贷款展期申请
        /// </summary>
        /// <param name="loanProductOrerId"></param>
        /// <param name="derationAmount"></param>
        /// <param name="extensionMemo"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        public JsonResult AddLoanExtensionApply(int loanProductOrerId, decimal? derationAmount, string extensionMemo, int orderType, int repayID)
        {
            var boolean = false;
            var operatorId = Helper.LoginInfoHelper.Operater().Id;
            switch (orderType)
            {
                case 2:
                    {
                        CarLoanExtensionApplyBLL.AddLoanExtensionApply(loanProductOrerId, derationAmount, extensionMemo, operatorId);
                        boolean = CarLoanMonthRepayBLL.UpdateCarRemind(repayID, RemindType.LaunchExtension, operatorId);
                        var result = new ResultMessage(boolean);
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                default:
                    {
                        var result = new ResultMessage(false);
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
            }
        }
    }
}