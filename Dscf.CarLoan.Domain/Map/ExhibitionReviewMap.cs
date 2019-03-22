/*******************************************************
*类名称：ExhibitionReviewMap
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/7 10:45:11
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
    public class ExhibitionReviewMap : EntityTypeConfiguration<ExhibitionReview>
    {
        public ExhibitionReviewMap()
        {
            ToTable("T_ExhibitionReview");
            HasKey(review => review.Id);
        }

    }
}
