using Dscf.PostLoanGlobal;
using Dscf.PostLoan.AuthCenterBLL;
using Dscf.PostLoan.LoanAfterBLL;
using Dscf.PostLoan.LoanAfterBLL.DscfLoanAfterService;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dscf.PostLoan.Web.Controllers
{
    public class CollectionInfoController : BaseController
    {
        public DictionaryBLL DictionaryBLL { get; set; }

        public FileEntityBLL FileEntityBLL { get; set; }

        public CollectionInfoBLL CollectionInfoBLL { get; set; }


        //
        // GET: /CollectionInfo/
        public ActionResult Create(int orderId, int orderType)
        {
            AuthCenterBLL.DscfACService.DictionaryDto[] linkPersonTypeArray;
            var statusArray = DictionaryBLL.GetDictListByKey(DictUtil.CollectionStatusKey);
            ViewBag.SelCollectionStatus = statusArray.Select(status => new SelectListItem
            {
                Text = status.DictMemo,
                Value = status.DictValue.ToString()
            });
            if (orderType == 1)
            {
                linkPersonTypeArray = DictionaryBLL.GetDictListByKey(DictUtil.CreditLinkPersonTypeKey);
            }
            else
            {
                linkPersonTypeArray = DictionaryBLL.GetDictListByKey(DictUtil.CarLinkPersonTypeKey);
            }
            ViewBag.SelLinkPersonType = linkPersonTypeArray.Select(status => new SelectListItem
            {
                Text = status.DictMemo,
                Value = status.DictValue.ToString()
            });

            ViewBag.OrderId = orderId;
            ViewBag.OrderType = orderType;

            return View();
        }

        [HttpPost]
        public JsonResult Create(CollectionInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var dto = AutoMapper.Mapper.Map<CollectionInfoViewModel, LoanAfterBLL.DscfLoanAfterService.CollectionInfoDto>(model);
                dto.CreateOptId = Helper.LoginInfoHelper.Operater().Id;
                dto.CreateTime = DateTime.Now;

                //上传资料列表
                IList<FileEntityDto> upFileList = new List<FileEntityDto>();
                foreach (var file in model.CollectionFileList)
                {
                    var upFileMsg = new LoanAfterBLL.DscfLoanAfterService.UpFileMessage()
                    {
                        IsImage = FileUtil.IsImage(file.InputStream),
                        OriginalFileName = file.FileName,
                        FileStream = file.InputStream,
                    };
                    var upFileResultMsg = FileEntityBLL.UpLoadFile(upFileMsg);
                    if (upFileResultMsg.IsSuccess)
                    {
                        var fileEntity = AutoMapper.Mapper.Map<UpFileResultMessage, FileEntityDto>(upFileResultMsg);
                        fileEntity.FileSize = file.ContentLength;
                        fileEntity.CreateOptId = Helper.LoginInfoHelper.Operater().Id; ;
                        fileEntity.CreateTime = DateTime.Now;
                        fileEntity.IsEnable = true;
                        upFileList.Add(fileEntity);
                    }
                }

                dto.UpFileList = upFileList.ToArray();
                var isSuccess = CollectionInfoBLL.InsertCollectionInfoAndUpFile(dto);
                if (isSuccess)
                {
                    return Json(new ResultMessage(true, "保存催收信息成功"), JsonRequestBehavior.AllowGet);
                }
                return Json(new ResultMessage(false, "保存失败，请您联系管理员！"), JsonRequestBehavior.AllowGet);

            }
            return Json(new ResultMessage(false, "验证失败，请您检查数据完整性！"));
        }

        /// <summary>
        /// 删除催收信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public JsonResult DelCollectionInfo(int id)
        {
            var boolean = CollectionInfoBLL.DelCollectionInfo(id, Helper.LoginInfoHelper.Operater().Id);
            var ReturnMsg = boolean ? "操作成功" : "操作失败";
            var result = new ResultMessage(boolean, ReturnMsg);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateCollectionInfo(CollectionInfoViewModel model)
        {
            LoanAfterBLL.DscfLoanAfterService.CollectionInfoDto collectionInfo;
            var dto = AutoMapper.Mapper.Map<CollectionInfoViewModel, LoanAfterBLL.DscfLoanAfterService.CollectionInfoDto>(model);
            dto.LastOperateId = Helper.LoginInfoHelper.Operater().Id; ;
            var boolean = CollectionInfoBLL.UpdateCollectionInfo(dto, out collectionInfo);
            var ReturnMsg = boolean ? "操作成功" : "操作失败";
            var result = new ResultMessage(boolean, ReturnMsg, collectionInfo);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}