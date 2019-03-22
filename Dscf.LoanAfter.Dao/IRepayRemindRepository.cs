using Dscf.Common.Dao;
using Dscf.LoanAfter.Domain;
using Dscf.LoanAfter.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Dao
{
    //T_RepayRemind
    public interface IRepayRemindRepository : IRepository<RepayRemind>
    {
        List<RepayRemindDto> GetRepayRemindListByKeys(int productName, string timeBegin, string timeEnd);
    }
}
