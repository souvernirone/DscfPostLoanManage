using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain.Map
{
    public class CarLoanExtensionMap : EntityTypeConfiguration<CarLoanExtension>
    {
        public CarLoanExtensionMap()
        {
            ToTable("T_CarLoanExtension");
            HasKey(ex => ex.ExtensionId);
        }
    }
}
