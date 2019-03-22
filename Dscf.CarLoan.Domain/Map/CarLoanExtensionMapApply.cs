using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain.Map
{
    public class CarLoanExtensionApplyMap : EntityTypeConfiguration<CarLoanExtensionApply>
    {
        public CarLoanExtensionApplyMap()
        {
            ToTable("T_CarLoanExtensionApply");
            HasKey(ex => ex.ExtensionId);
        }
    }
}
