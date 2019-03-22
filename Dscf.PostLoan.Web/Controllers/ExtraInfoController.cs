using Dscf.PostLoanGlobal;
using Dscf.PostLoan.LoanAfterBLL;
using Dscf.PostLoan.LoanAfterBLL.DscfLoanAfterService;
using Dscf.PostLoan.Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dscf.PostLoan.Web.Controllers
{
    public class ExtraInfoController : BaseController
    {
        public ExtraInfoBLL ExtraInfoBLL { get; set; }
        //
        // GET: /ExtraInfo/
        public ActionResult ExtraInfoTab(int orderId, int orderType, int shrinkId)
        {
            var optEntity = LoginInfoHelper.Operater();

            ViewBag.OrderId = orderId;
            ViewBag.OrderType = orderType;
            ViewBag.ShrinkId = shrinkId;
            ViewBag.CurrentOperaterId = optEntity.Id;

            var extraInfoArray = ExtraInfoBLL.GetExtraInfoListByOrder(orderId, orderType);
            return PartialView("_PartialExtraInfoTab", extraInfoArray);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Create(ExtraInfoDto model)
        {
            var optEntity = LoginInfoHelper.Operater();
            ExtraInfoDto extraInfo;

            model.CreateOptId = optEntity.Id;
            model.CreateTime = DateTime.Now;
            model.IsDeleted = false;
            model.IsEnable = true;

            var boolean = ExtraInfoBLL.InsertExtraInfo(model, out extraInfo);

            extraInfo.CreateOptName = optEntity.Name;

            var returnMsg = boolean ? "操作成功" : "操作失败";
            var result = new ResultMessage(boolean, returnMsg, extraInfo);
            return Json(result);
        }

        [HttpPost]
        public JsonResult Edit(ExtraInfoDto model)
        {
            var optEntity = LoginInfoHelper.Operater();
            ExtraInfoDto extraInfo;

            model.LastOperateId = optEntity.Id;
            model.LastUpdateTime = DateTime.Now;
            var boolean = ExtraInfoBLL.UpdateExtraInfo(model, out extraInfo);

            var returnMsg = boolean ? "操作成功" : "操作失败";
            extraInfo.CreateOptName = optEntity.Name;

            var result = new ResultMessage(boolean, returnMsg, extraInfo);
            return Json(result);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var boolean = ExtraInfoBLL.DelExtraInfo(id);
            var ReturnMsg = boolean ? "操作成功" : "操作失败,请您联系管理员";
            var result = new ResultMessage(boolean, ReturnMsg);
            return Json(result);
        }
    }
}