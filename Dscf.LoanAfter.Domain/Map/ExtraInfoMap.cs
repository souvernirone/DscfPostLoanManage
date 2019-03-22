/*******************************************************
*类名称：ExtraInfoMap
*版本号：V1.0.0.0
*作者：Administrator
*CLR版本：4.0.30319.36264
*创建时间：2017/4/1 10:55:35
*说明：
*更新备注：
**********************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Domain.Map
{
    public class ExtraInfoMap : EntityTypeConfiguration<ExtraInfo>
    {
        public ExtraInfoMap()
        {
            ToTable("T_ExtraInfo");
            HasKey(extra => extra.Id);
        }
    }
}
