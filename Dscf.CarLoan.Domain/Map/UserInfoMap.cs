using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain.Map
{
    public class UserInfoMap : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoMap()
        {

            ToTable("T_UserInfo");
            HasKey(user => user.UserInfoId);

            HasOptional(user => user.UserWorkInfo).WithOptionalPrincipal();

        }
    }
}
