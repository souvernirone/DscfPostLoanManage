using Dscf.CarLoan.Contract;
using Dscf.CarLoan.Dto;
using Dscf.CarLoan.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Service
{
    public partial class CarLoanService:ICarLoanContract
    {
        public IUserInfoManager UserInfoManager { get; set; }

        public CarUserInfoDto[] QueryUserInfoList()
        {
           return UserInfoManager.QueryUserInfoList();
        }
    }
}
