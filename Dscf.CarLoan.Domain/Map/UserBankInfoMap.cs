using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain.Map
{
    public class UserBankInfoMap : EntityTypeConfiguration<UserBankInfo>
    {
        public UserBankInfoMap()
        {
            ToTable("T_UserBankInfo");
            HasKey(userBank => userBank.UserBankId);
        }
    }
}
