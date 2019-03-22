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
        public IUserInfoManager UserInfoManager { get; set; }

        /// <summary>
        /// 根据用户id查询用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserInfoDto GetUserInfoByUserId(int userId)
        {
            return UserInfoManager.GetUserInfoByUserId(userId);
        }
    }
}
