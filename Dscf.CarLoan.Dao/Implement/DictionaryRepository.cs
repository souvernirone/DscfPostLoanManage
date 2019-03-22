using Dscf.CarLoan.Domain;
using Dscf.Common.Dao.Implement;
/*******************************************************
*类名称：DictionaryRepository
*版本号：V1.0.0.0
*作者：Administrator
*CLR版本：4.0.30319.36264
*创建时间：2017/3/31 17:46:47
*说明：
*更新备注：
**********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dao.Implement
{
    public class DictionaryRepository : RepositoryBase<Dictionary>, IDictionaryRepository
    {
        public string GetDictMemoByType(string dictKey, int? dictValue)
        {
            var dict=this.Entities.Where(d => d.DictKey == dictKey && d.DictValue == dictValue).FirstOrDefault();
            return dict == null ? string.Empty : dict.DictMemo;
        }
    }
}
