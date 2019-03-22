/*******************************************************
*类名称：IDictionaryManager
*版本号：V1.0.0.0
*作者：Administrator
*CLR版本：4.0.30319.36264
*创建时间：2017/3/31 17:49:29
*说明：
*更新备注：
**********************************************************/

using Dscf.CarLoan.Domain;
using Dscf.Common.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Manager
{
    public interface IDictionaryManager : IGenericManager<Dictionary>
    {
        string GetDictMemoByType(string dictKey, int? dictValue);
    }
}
