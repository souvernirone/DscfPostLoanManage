using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain.Map
{
    public class Loan_MonthRepayMap : EntityTypeConfiguration<Loan_MonthRepay>
    {
        public Loan_MonthRepayMap()
        {
            ToTable("T_Loan_MonthRepay");
            HasKey(dept => dept.RepayId);
        }
    }
}
