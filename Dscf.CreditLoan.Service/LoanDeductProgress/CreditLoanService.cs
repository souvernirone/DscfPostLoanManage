using Dscf.CreditLoan.Contract;
using Dscf.CreditLoan.Dto;
using Dscf.CreditLoan.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Service
{
    public partial class CreditLoanService : ICreditLoanContract
    {
        public ILoanDeductProgressManager LoanDeductProgressManager { get; set; }

        public LoanDeductProgressDto[] GetDeductList(int orderId)
        {
            return LoanDeductProgressManager.GetDeductList(orderId);
        }

    }
}
