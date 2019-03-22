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
    public class UserInfoManager : GenericManagerBase<UserInfo>, IUserInfoManager
    {
        /// <summary>
        /// 根据用户id查询用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserInfoDto GetUserInfoByUserId(int userId)
        {
            UserInfo user = this.CurrentRepository.GetByKey(userId);
            return user.ToModel();
        }
    }
}
