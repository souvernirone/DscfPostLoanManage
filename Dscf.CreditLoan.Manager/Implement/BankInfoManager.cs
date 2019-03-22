using Dscf.Common.Manager.Implement;
using Dscf.CreditLoan.Domain;
using Dscf.CreditLoan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.CreditLoan.Dto.Extension;
using Dscf.CreditLoan.Dao;
using Dscf.PostLoanGlobal;

namespace Dscf.CreditLoan.Manager.Implement
{
    public class BankInfoManager : GenericManagerBase<BankInfo>, IBankInfoManager
    {
        /// <summary>
        /// 根据银行名称查询银行信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BankInfoDto GetBankInfoByName(string name)
        {
            var bank = this.CurrentRepository.Entities.Where(b => b.BankName == name).FirstOrDefault();
            return bank.ToModel();
        }
    }
}
