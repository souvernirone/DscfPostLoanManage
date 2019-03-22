/*******************************************************
*类名称：ImagesManager
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/7 16:29:34
*说明：
*更新备注：
**********************************************************/

using Dscf.CarLoan.Domain;
using Dscf.Common.Manager.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.CarLoan.Dao;

namespace Dscf.CarLoan.Manager.Implement
{
    //图片信息
    public class ImagesManager : GenericManagerBase<Images>, IImagesManager
    {
        public IImagesRepository ImagesRepository { get; set; }
        public bool UpdateImageById(int key)
        {
            var image = this.Entities.Where(img => img.ImgId == key).FirstOrDefault();
            image.IsDelete = 1;
            return this.ImagesRepository.Update(image, true) > 0 ? true : false;
        }
    }
}
