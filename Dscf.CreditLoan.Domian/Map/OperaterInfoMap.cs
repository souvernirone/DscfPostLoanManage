using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain.Map
{
    public class OperaterInfoMap : EntityTypeConfiguration<OperaterInfo>
    {
        public OperaterInfoMap()
        {
            ToTable("T_OperaterInfo");
            HasKey(t => t.OptId);

            HasMany(opt => opt.OperatorRoleList).WithOptional().HasForeignKey(or => or.OptId);

            HasRequired(opt => opt.DepartmentInfo).WithMany().HasForeignKey(opt=>opt.DepId);
        }
    }
}
