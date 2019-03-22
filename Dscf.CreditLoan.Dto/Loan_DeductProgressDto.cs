using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    public class Loan_DeductProgressDto
    {
        public int? LoanOrderId { get; set; }

        public string Code { get; set; }

        public string Result { get; set; }

        public int? ProductType { get; set; }

        public int? DeductOptId { get; set; }

        public string BackFeedCode { get; set; }
    }
}
