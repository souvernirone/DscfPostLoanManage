using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain
{
    public class LoanDeductProgress
    {

        public int DeductId { get; set; }

        public int? LoanOrderId { get; set; }

        public int? RepayPeriod { get; set; }

        public DateTime? PlanDeductDate { get; set; }

        public DateTime? ActualDeductDate { get; set; }

        public decimal? PlanDeductAmount { get; set; }

        public decimal? ActualDeductAmount { get; set; }

        public int? DeductCount { get; set; }

        public string IsDeductSucess { get; set; }

        public int? DeductOptId { get; set; }

        public DateTime? OperateDate { get; set; }

        public string ReqSn { get; set; }

        public string BackFeedCode { get; set; }

        public string Code { get; set; }

        public string SN { get; set; }

        public string Result { get; set; }

        public int? IsResult { get; set; }

        public int? RepayId { get; set; }

        public Guid? DeductGuid { get; set; }

        public int? ProductType { get; set; }

        public int? IsPaymentType { get; set; }

        public int? ApplyId { get; set; }




    }
}
