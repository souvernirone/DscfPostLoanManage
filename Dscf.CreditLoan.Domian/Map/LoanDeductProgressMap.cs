using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain.Map
{
    public class LoanDeductProgressMap : EntityTypeConfiguration<LoanDeductProgress>
    {
        public LoanDeductProgressMap()
        {
            ToTable("T_Loan_DeductProgress");
            HasKey(cc => cc.DeductId);
        }
    }
}
