using Dscf.PostLoanGlobal;
using Dscf.PostLoan.CarLoanBLL;
using Dscf.PostLoan.CreditLoanBLL;
using Dscf.PostLoan.LoanAfterBLL;
using Dscf.PostLoan.LoanAfterBLL.DscfLoanAfterService;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dscf.PostLoan.AuthCenterBLL;
using Dscf.PostLoan.Web.Helper;
using Dscf.Settlement.Model;

namespace Dscf.PostLoan.Web.Controllers
{
    public class OverdueCustomerController : BaseController
    {
        #region 属性
        public DictionaryBLL DictionaryBLL { get; set; }

        public CreditLoanInfoBLL CreditLoanInfoBLL { get; set; }

        public CarLoanOrderProductBLL CarLoanOrderProductBLL { get; set; }

        public FileEntityBLL FileEntityBLL { get; set; }

        public DeductPayApplyBLL DeductPayApplyBLL { get; set; }

        public CollectionInfoBLL CollectionInfoBLL { get; set; }

        public OperaterInfoBLL OperaterInfoBLL { get; set; }

        public CreditLoanProductOrderBLL CreditLoanProductOrderBLL { get; set; }

        public CarDeductProgressBLL CarDeductProgressBLL { get; set; }
        public CreditLoanDeductProgressBLL CreditLoanDeductProgressBLL { get; set; }

        #endregion

        /// <summary>
        /// 逾期客户页面-信用借款
        /// </summary>
        /// <returns></returns>
        public ActionResult CreditOverdueList()
        {
            ViewBag.IsAssign = Helper.LoginInfoHelper.Operater().RoleList.Select(role => role.Id).Contains(RoleUtil.CollectionSupervisor);
            int[] roleIdArr = new int[] { RoleUtil.CreditLoanCollectorRole };
            ViewBag.CollectorRole = OperaterInfoBLL.GetCollectorListByRole(roleIdArr);
            return View("CreditOverdueList");
        }

        /// <summary>
        /// 获取信贷 逾期客户 分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonResult GetPageOverdueList(int pageNum = 1, int pageSize = 10)
        {
            var datas = CreditLoanInfoBLL.GetPageOverdueList(pageNum, pageSize, LoginInfoHelper.Operater().Id);
            var result = new ResultMessage(true, "加载信息成功", datas.TotalItemCount, datas);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 逾期客户页面-车辆借款
        /// </summary>
        /// <returns></returns>
        public ActionResult CarOverdueList()
        {
            ViewBag.IsAssign = Helper.LoginInfoHelper.Operater().RoleList.Select(role => role.Id).Contains(RoleUtil.CollectionSupervisor);
            int[] roleIdArr = new int[] { RoleUtil.CarLoanCollectorRole };
            ViewBag.CollectorRole = OperaterInfoBLL.GetCollectorListByRole(roleIdArr);
            return View("CarOverdueList");
        }

        /// <summary>
        /// 获取 车辆借款 逾期客户 分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonResult GetPageCarOverdueList(int pageNum = 1, int pageSize = 10, bool isLongLoan = true)
        {
            var datas = CarLoanOrderProductBLL.GetPageCarOverdueList(pageNum, pageSize, isLongLoan, LoginInfoHelper.Operater().Id);
            var result = new ResultMessage(true, "加载信息成功", datas.TotalItemCount, datas);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 车贷逾期详细信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public ActionResult CarOverdueDetail(int orderId)
        {
            var loanOrderDetailDto = CarLoanOrderProductBLL.GetLoanProductOrderDetail(orderId);
            return View(loanOrderDetailDto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public ActionResult CreditOverdueDetail(int orderId)
        {
            var loanOrderDetailDto = CreditLoanInfoBLL.GetLoanProductOrderDetail(orderId);
            return View(loanOrderDetailDto);
        }


        [ChildActionOnly]
        public ActionResult CreditClaimsInfo(CreditLoanBLL.DscfCreditLoanService.LoanOrderDetailDto orderDetail)
        {
            var claimsInfoTotal = CreditLoanInfoBLL.GenerateCreditClaimsInfo(orderDetail);
            var DeductPayApplyAndFile = DeductPayApplyBLL.GetDeductPayApplyAndFile(orderDetail.OrderId, LoanOrderUtil.CreditTypeKey);
            ViewBag.DeductPayApplyAndFile = DeductPayApplyAndFile;

            return PartialView("_PartialCreditClaimsInfo", claimsInfoTotal);
        }


        [ChildActionOnly]
        public ActionResult CarClaimsInfo(CarLoanBLL.DscfCarLoanService.CarLoanOrderDetailDto orderDetail)
        {
            var claimsInfoTotal = CarLoanOrderProductBLL.GenerateCarClaimsInfo(orderDetail);
            var deductPayApplyAndFile = DeductPayApplyBLL.GetDeductPayApplyAndFile(orderDetail.OrderId, LoanOrderUtil.CarTypeKey);
            ViewBag.DeductPayApplyAndFile = deductPayApplyAndFile;
            return PartialView("_PartialCarClaimsInfo", claimsInfoTotal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult DeductPayApply(DeductPayApplyViewModel model)
        {
            if (ModelState.IsValid)
            {

                var upFileMsg = new LoanAfterBLL.DscfLoanAfterService.UpFileMessage()
                {
                    IsImage = true,
                    OriginalFileName = model.PayImage.FileName,
                    FileStream = model.PayImage.InputStream,
                };

                var upFileResultMsg = FileEntityBLL.UpLoadFile(upFileMsg);

                if (upFileResultMsg.IsSuccess)
                {
                    var dto = AutoMapper.Mapper.Map<DeductPayApplyViewModel, LoanAfterBLL.DscfLoanAfterService.DeductPayApplyDto>(model);
                    dto.CreateOptId = Helper.LoginInfoHelper.Operater().Id;
                    dto.CreateTime = DateTime.Now;
                    dto.ApprovalStatus = DeductPayUtil.ApprovalPending;

                    var fileEntity = AutoMapper.Mapper.Map<UpFileResultMessage, FileEntityDto>(upFileResultMsg);
                    fileEntity.FileSize = model.PayImage.ContentLength;
                    fileEntity.CreateOptId = Helper.LoginInfoHelper.Operater().Id; ;
                    fileEntity.CreateTime = DateTime.Now;
                    fileEntity.IsEnable = true;
                    fileEntity.Remark = model.Remark;
                    dto.FileEntity = fileEntity;

                    bool isSuccess = DeductPayApplyBLL.AddDeductPayApply(dto);
                    if (isSuccess)
                    {
                        bool boolean = false;
                        switch (model.OrderType)
                        {
                            case 1:
                                {
                                    boolean = CreditLoanProductOrderBLL.UpdateCollectStatus(model.OrderId, DeductPayUtil.OrderCollectSubmitApproved, Helper.LoginInfoHelper.Operater().Id);
                                    break;
                                }
                            default:
                                {
                                    boolean = CarLoanOrderProductBLL.UpdateCollectStatus(model.OrderId, DeductPayUtil.OrderCollectSubmitApproved, Helper.LoginInfoHelper.Operater().Id);
                                    break;
                                }
                        }
                        if (boolean)
                        {
                            return Json(new ResultMessage(true, "保存划扣申请、线下支付信息成功！"));
                        }
                    }
                }

                return Json(new ResultMessage(false, "保存还款文件失败，请您联系管理员！"));
            }
            return Json(new ResultMessage(false, "验证失败，请您检查数据完整性！"));
        }

        /// <summary>
        /// 催收信息
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult CollectionInfo(int orderId, int orderType)
        {
            ViewBag.OrderId = orderId;
            ViewBag.OrderType = orderType;
            List<AuthCenterBLL.DscfACService.DictionaryDto> dicLinkPersonTypeList;
            var collectionInfoDtoList = CollectionInfoBLL.GetCollectionInfoByKey(orderId, orderType).ToList();
            DeductProgressInfo[] deductProgressDtoList;
            switch (orderType)
            {
                case 1: { deductProgressDtoList = CreditLoanDeductProgressBLL.GetDeductList(orderId).Where(deduct => deduct.ApplyId != null).ToArray(); break; }
                case 2: { deductProgressDtoList = CarDeductProgressBLL.GetDeductList(orderId).Where(deduct => deduct.ApplyId != null).ToArray(); break; }
                default: { deductProgressDtoList = null; break; }
            }





            var dicCollectStaList = DictionaryBLL.GetDictListByKey(DictUtil.CollectionStatusKey).ToList();
            if (orderType == 1)
            {
                dicLinkPersonTypeList = DictionaryBLL.GetDictListByKey(DictUtil.CreditLinkPersonTypeKey).ToList();
            }
            else
            {
                dicLinkPersonTypeList = DictionaryBLL.GetDictListByKey(DictUtil.CarLinkPersonTypeKey).ToList();
            }
            var operaterList = new AuthCenterBLL.DscfACService.AuthCenterContractClient().GetOperaterInfoLists().ToList();
            foreach (var collectionInfoDto in collectionInfoDtoList)
            {
                collectionInfoDto.CollectionStatusName = dicCollectStaList.Where(dic => dic.DictValue == collectionInfoDto.CollectionStatus).FirstOrDefault().DictMemo;
                collectionInfoDto.LinkPersonTypeName = dicLinkPersonTypeList.Where(dic => dic.DictValue == collectionInfoDto.LinkPersonType).FirstOrDefault().DictMemo;
                collectionInfoDto.OptName = operaterList.Where(oper => oper.Id == collectionInfoDto.CreateOptId).FirstOrDefault() == null ? null : operaterList.Where(oper => oper.Id == collectionInfoDto.CreateOptId).FirstOrDefault().Name;
            }
            ViewBag.collectionInfoDtoList = collectionInfoDtoList;
            ViewBag.dlCollectionStatus = dicCollectStaList;
            ViewBag.dlLinkPersonTypeList = dicLinkPersonTypeList;
            ViewBag.deductProgressDtoList = deductProgressDtoList;
            return PartialView("_PartialCollectionInfo");
        }

        /// <summary>
        /// 修改订单表的催收人
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public JsonResult UpdateLoanProductOrderReminder(int orderId, int deptOptId, int orderType)
        {
            if (orderType == 1)
            {
                bool boolean = CreditLoanProductOrderBLL.UpdateReminder(orderId, deptOptId);
                return Json(new ResultMessage(boolean));
            }
            else
            {
                bool boolean = CarLoanOrderProductBLL.UpdateReminder(orderId, deptOptId);
                return Json(new ResultMessage(boolean));
            }
        }

    }
}