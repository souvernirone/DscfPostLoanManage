using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain.Map
{
    public class LoanMonthRepayMap : EntityTypeConfiguration<LoanMonthRepay>
    {
        public LoanMonthRepayMap()
        {
            ToTable("T_LoanMonthRepay");
            HasKey(repay => repay.RepayId);
        }
    }
}
