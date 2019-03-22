using Dscf.PostLoanGlobal;
using Dscf.PostLoan.CarLoanBLL;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dscf.PostLoan.Web.Controllers
{
    public class ReconsiderController : BaseController
    {

        public CarLoanExhibitionReviewBLL CarLoanExhibitionReviewBLL { get; set; }

        public CarLoanOrderProductBLL CarLoanOrderProductBLL { get; set; }

        public CarLoanImagesBLL CarLoanImagesBLL { get; set; }
        //
        // GET: /Reconsider/
        public ActionResult Detail(int orderId)
        {
            var loanDetail = CarLoanOrderProductBLL.GetLoanProductOrderInfoByOrderId(orderId);
            var exhibitionReview = CarLoanExhibitionReviewBLL.GetExhibitionReviewDto(orderId);
            if (exhibitionReview != null)
            {
                ViewBag.StoreOption = exhibitionReview.Memo;
                ViewBag.imgWraps = CarLoanImagesBLL.GetImages(exhibitionReview.Id);
            }
            return View(loanDetail);
        }


        [HttpPost]
        public JsonResult Submit(ExhibitionViewModel viewModel)
        {
            CarLoanBLL.DscfCarLoanService.ExhibitionReviewDto reviewDto;

            var isSuccess = CarLoanExhibitionReviewBLL.SubmitExhibitionReview(viewModel, out reviewDto, Helper.LoginInfoHelper.Operater().Id);

            if (isSuccess)
            {
                return Json(new ResultMessage() { ReturnType = true, ReturnMsg = "保存成功", ReturnData = reviewDto }, JsonRequestBehavior.DenyGet);
            }
            return Json(new ResultMessage() { ReturnType = false, ReturnMsg = "保存失败,请您联系管理员" }, JsonRequestBehavior.DenyGet);
        }

        [HttpPost]
        public JsonResult Save(ExhibitionViewModel viewModel)
        {

            CarLoanBLL.DscfCarLoanService.ExhibitionReviewDto reviewDto;

            var isSuccess = CarLoanExhibitionReviewBLL.InsertExhibitionReview(viewModel, out reviewDto, Helper.LoginInfoHelper.Operater().Id);

            if (isSuccess)
            {
                return Json(new ResultMessage() { ReturnType = true, ReturnMsg = "保存成功", ReturnData = reviewDto }, JsonRequestBehavior.DenyGet);
            }
            return Json(new ResultMessage() { ReturnType = false, ReturnMsg = "保存失败,请您联系管理员" }, JsonRequestBehavior.DenyGet);
        }
        /// <summary>
        /// 删除车贷短期展期复议图片
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult DelImg(int Id)
        {
            var boolean = CarLoanImagesBLL.DelImgFalse(Id);
            if (boolean)
            {
                return Json(new ResultMessage() { ReturnType = boolean, ReturnMsg = "删除成功" }, JsonRequestBehavior.DenyGet);
            }
            else
            {
                return Json(new ResultMessage() { ReturnType = boolean, ReturnMsg = "删除失败，请您联系管理员" }, JsonRequestBehavior.DenyGet);
            }
        }
    }
}