using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain.Map
{
    public class UserWorkInfoMap : EntityTypeConfiguration<UserWorkInfo>
    {
        public UserWorkInfoMap()
        {
            ToTable("T_UserWorkInfo");
            HasKey(work => work.UserId);
            Property(userWork => userWork.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
