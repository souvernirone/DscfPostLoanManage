using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain.Map
{
    public class CarLoanConfigMap : EntityTypeConfiguration<CarLoanConfig>
    {
        public CarLoanConfigMap()
        {
            ToTable("T_CarLoanConfig");
            HasKey(cc => cc.ConfigId);
        }
    }
}
