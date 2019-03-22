using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain.Map
{
    public class OperatorRoleMap : EntityTypeConfiguration<OperatorRole>
    {
        public OperatorRoleMap()
        {
            ToTable("T_OperatorRole");
            HasKey(t => new { t.OptId, t.RoleId });
        }
    }
}
