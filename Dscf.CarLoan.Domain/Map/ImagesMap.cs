/*******************************************************
*类名称：ImagesMap
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/7 16:25:46
*说明：
*更新备注：
**********************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain.Map
{
    public class ImagesMap : EntityTypeConfiguration<Images>
    {
        public ImagesMap()
        {
            ToTable("T_Images");
            HasKey(img => img.ImgId);
        }
    }
}
