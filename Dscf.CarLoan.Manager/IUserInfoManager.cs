using Dscf.CarLoan.Domain;
using Dscf.CarLoan.Dto;
using Dscf.Common.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Manager
{
    public interface IUserInfoManager : IGenericManager<UserInfo>
    {
        CarUserInfoDto[] QueryUserInfoList();
    }
}
