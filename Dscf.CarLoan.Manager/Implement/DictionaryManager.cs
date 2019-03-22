/*******************************************************
*类名称：DictionaryManager
*版本号：V1.0.0.0
*作者：Administrator
*CLR版本：4.0.30319.36264
*创建时间：2017/3/31 17:51:56
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

namespace Dscf.CarLoan.Manager.Implement
{
    public class DictionaryManager : GenericManagerBase<Dictionary>, IDictionaryManager
    {
        public string GetDictMemoByType(string dictKey, int? dictValue)
        {
            return this.CurrentRepository.Entities.Where(d => d.DictKey == dictKey && d.DictValue == dictValue).FirstOrDefault().DictMemo;
        }
    }
}
