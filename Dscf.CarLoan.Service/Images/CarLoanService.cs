/*******************************************************
*类名称：CarLoanService
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/7 16:40:07
*说明：
*更新备注：
**********************************************************/

using Dscf.CarLoan.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dscf.CarLoan.Dto.Extension;
using Dscf.CarLoan.Dto;
using Dscf.CarLoan.Manager;

namespace Dscf.CarLoan.Service
{
    public partial class CarLoanService : ICarLoanContract
    {
        public IImagesManager ImagesManager { get; set; }

        public bool InsertImages(ImagesDto dto)
        {
            var images = dto.ToEntity();
            int rowCount = this.ImagesManager.Insert(images);
            return rowCount > 0 ? true : false;
        }

        public bool DeleteImages(int key)
        {
            int rowCount = this.ImagesManager.Delete(key);
            return rowCount > 0 ? true : false;
        }
        public ImagesDto[] GetImages(int key)
        {
            var list = this.ImagesManager.Entities.Where(img => img.CurrentId == key && img.IsDelete == 0).OrderByDescending(img => img.ImgId).ToList();
            return list.Select(img => img.ToModel()).ToArray();
        }
        public bool DelImgFalse(int key)
        {
            return ImagesManager.UpdateImageById(key);
        }
    }
}
