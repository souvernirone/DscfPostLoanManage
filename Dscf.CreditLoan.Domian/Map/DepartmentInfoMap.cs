using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain.Map
{
    public class DepartmentInfoMap : EntityTypeConfiguration<DepartmentInfo>
    {
        public DepartmentInfoMap()
        {
            ToTable("T_DepartmentInfo");
            HasKey(dept => dept.DepId);
        }
    }
}
