using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Domain.Map
{
    public class OptDeptMap : EntityTypeConfiguration<OptDept>
    {
        public OptDeptMap()
        {
            ToTable("T_OptDept");
            HasKey(od => od.Id);
        }
    }
}
