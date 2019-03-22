using Dscf.Common.Manager;
using Dscf.CreditLoan.Domain;
using Dscf.CreditLoan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Manager
{
    public interface IBankInfoManager : IGenericManager<BankInfo>
    {
        /// <summary>
        /// 根据银行名称查询银行信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        BankInfoDto GetBankInfoByName(string name);
    }
}
