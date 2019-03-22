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
    public interface IUserInfoManager : IGenericManager<UserInfo>
    {
        /// <summary>
        /// 根据用户id查询用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserInfoDto GetUserInfoByUserId(int userId);
    }
}
