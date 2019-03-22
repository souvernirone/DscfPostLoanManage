using Dscf.CreditLoan.Contract;
using Dscf.CreditLoan.Dto;
using Dscf.CreditLoan.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Service
{
    public partial class CreditLoanService : ICreditLoanContract
    {
        public IBankInfoManager BankInfoManager { get; set; }

        /// <summary>
        /// 根据银行名称查询银行信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BankInfoDto GetBankInfoByName(string name)
        {
            return BankInfoManager.GetBankInfoByName(name);
        }
    }
}
