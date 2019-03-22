using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain.Map
{
    public class DeductProgressMap : EntityTypeConfiguration<DeductProgress>
    {
        public DeductProgressMap()
        {
            ToTable("T_DeductProgress");
            HasKey(cc => cc.DeductId);
        }
    }
}
