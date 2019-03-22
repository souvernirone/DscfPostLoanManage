using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Domain.Map
{
    public class RepayRemindMap : EntityTypeConfiguration<RepayRemind>
    {
        public RepayRemindMap()
        {
            ToTable("T_RepayRemind");
            HasKey(remind => remind.RemindId);
        }
    }
}
