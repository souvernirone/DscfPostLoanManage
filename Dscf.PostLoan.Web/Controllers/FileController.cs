using Dscf.PostLoanGlobal;
using Dscf.PostLoan.CarLoanBLL;
using Dscf.PostLoan.CarLoanBLL.DscfCarLoanService;
using Dscf.PostLoan.LoanAfterBLL;
using Dscf.PostLoan.LoanAfterBLL.DscfLoanAfterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dscf.PostLoan.Web.Controllers
{
    public class FileController : BaseController
    {
        public FileEntityBLL FileEntityBLL { get; set; }

        public CarLoanImagesBLL CarLoanImagesBLL { get; set; }

        [HttpPost]
        public JsonResult UpFile(HttpPostedFileBase file, int key, int photoType)
        {
            var upFileMsg = new LoanAfterBLL.DscfLoanAfterService.UpFileMessage()
            {
                IsImage = true,
                OriginalFileName = file.FileName,
                FileStream = file.InputStream,
                ThumbWidth = 110,
                ThumbHeight = 110
            };

            var upFileResultMsg = FileEntityBLL.UpLoadFile(upFileMsg);

            if (upFileResultMsg.IsSuccess)
            {
                var imagesDto = new ImagesDto()
                {
                    ImgPath = upFileResultMsg.FilePath,
                    ThumPath = upFileResultMsg.ThumbPath,
                    ImgFixd = upFileResultMsg.FileSuffix,
                    ImgName = string.Format("{0}{1}", upFileResultMsg.SaveFileName, upFileResultMsg.FileSuffix),
                    ImgType = photoType,
                    CurrentId = key,
                    CreateTime = DateTime.Now,
                    OperateId = -1,
                    IsDelete = 0,
                    IsEnable = 1,
                };


                bool isSuccess = CarLoanImagesBLL.InsertImages(imagesDto);
                if (isSuccess)
                {
                    return Json(new ResultMessage(true, "保存文件成功！"));
                }
            }

            return Json(new ResultMessage(false, "保存文件失败，请您联系管理员！"));
        }
    }
}