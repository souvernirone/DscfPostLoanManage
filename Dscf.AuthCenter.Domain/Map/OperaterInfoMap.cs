using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Domain.Map
{
    public class OperaterInfoMap : EntityTypeConfiguration<OperaterInfo>
    {
        public OperaterInfoMap()
        {

            ToTable("T_OperaterInfo");
            HasKey(opt => opt.Id);
           

            HasMany(opt => opt.RoleList).WithMany().Map(map =>
            {
                map.ToTable("T_OptRole");
                map.MapLeftKey("OptId");
                map.MapRightKey("RoleId");
            });

            HasMany(opt => opt.OptDeptList).WithOptional().HasForeignKey(od=>od.OptId);

            HasRequired(opt => opt.DepartmentInfo).WithMany().HasForeignKey(od => od.DepartmentId);
        }
    }
}
