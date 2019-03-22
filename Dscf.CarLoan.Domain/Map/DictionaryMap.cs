/*******************************************************
*类名称：DictionaryMap
*版本号：V1.0.0.0
*作者：Administrator
*CLR版本：4.0.30319.36264
*创建时间：2017/3/31 17:45:34
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
    public class DictionaryMap : EntityTypeConfiguration<Dictionary>
    {
        public DictionaryMap()
        {
            ToTable("T_Dictionary");
            HasKey(dict => dict.DictId);
        }
    }
}
