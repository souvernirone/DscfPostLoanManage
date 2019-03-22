using Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.Settlement.Model;

namespace Dscf.PostLoan.CreditLoanBLL
{
    public class CreditLoanBackInfoBLL
    {
        /// <summary>
        /// 根据银行名称查询银行信息
        /// </summary>
        /// <param name="name">银行名称</param>
        /// <returns></returns>
        public BankInfoDto GetBankInfoByName(string name)
        {
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                BankInfoDto bankInfoDto = client.GetBankInfoByName(name);
                return bankInfoDto;
            }
        }

    }
}
