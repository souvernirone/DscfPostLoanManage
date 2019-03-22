using Dscf.CarLoan.Domain;
using Dscf.CarLoan.Dto;
using Dscf.Common.Manager.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Manager.Implement
{
    public class UserInfoManager : GenericManagerBase<UserInfo>, IUserInfoManager
    {
        public CarUserInfoDto[] QueryUserInfoList()
        {
            var userInfoList = this.CurrentRepository.Entities.ToList();
            return userInfoList.Select(u => new CarUserInfoDto { Name = u.Name }).ToArray();
        }
    }
}
