using Dscf.CarLoan.Dao;
using Dscf.CarLoan.Domain;
using Dscf.Common.Manager.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Manager.Implement
{
    //T_UserWorkInfo
    public class UserWorkInfoManager : GenericManagerBase<UserWorkInfo>, IUserWorkInfoManager
    {
        public UserWorkInfoManager(IUserWorkInfoRepository repository)
        {
            this.CurrentRepository = repository;
        }
    }
}
