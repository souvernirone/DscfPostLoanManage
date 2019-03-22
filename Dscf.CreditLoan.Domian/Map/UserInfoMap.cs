using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain.Map
{
    public class UserInfoMap : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap()
        {
            ToTable("T_UserInfo");
            HasKey(u=> u.UserId);

            HasOptional(u => u.UserFamilyInfo).WithOptionalPrincipal();

            HasOptional(u => u.UserWorkInfo).WithOptionalPrincipal();
        }
    }
}
