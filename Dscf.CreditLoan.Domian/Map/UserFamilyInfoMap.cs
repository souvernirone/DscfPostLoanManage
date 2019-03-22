using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain.Map
{
    public class UserFamilyInfoMap : EntityTypeConfiguration<UserFamilyInfo>
    {
        public UserFamilyInfoMap()
        {
            ToTable("T_UserFamilyInfo");
            HasKey(userfamily => userfamily.UserId);
            
            Property(userfamily => userfamily.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
