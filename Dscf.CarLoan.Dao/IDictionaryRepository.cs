using Dscf.CarLoan.Domain;
using Dscf.Common.Dao;
/*******************************************************
*类名称：IDictionaryRepository
*版本号：V1.0.0.0
*作者：Administrator
*CLR版本：4.0.30319.36264
*创建时间：2017/3/31 17:46:22
*说明：
*更新备注：
**********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dao
{
    public interface IDictionaryRepository : IRepository<Dictionary>
    {
        string GetDictMemoByType(string dictKey, int? dictValue);
    }
}
