using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    [DataContract]
    public class LoanDeductProgressDto
    {
        [DataMember]
        public int DeductId { get; set; }
        [DataMember]

        public int? LoanOrderId { get; set; }
        [DataMember]
        public int? RepayPeriod { get; set; }
        [DataMember]
        public DateTime? PlanDeductDate { get; set; }
        [DataMember]
        public DateTime? ActualDeductDate { get; set; }
        [DataMember]
        public decimal? PlanDeductAmount { get; set; }
        [DataMember]
        public decimal? ActualDeductAmount { get; set; }
        [DataMember]
        public int? DeductCount { get; set; }
        [DataMember]
        public string IsDeductSucess { get; set; }
        [DataMember]
        public int? DeductOptId { get; set; }
        [DataMember]
        public DateTime? OperateDate { get; set; }
        [DataMember]
        public string ReqSn { get; set; }
        [DataMember]
        public string BackFeedCode { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string SN { get; set; }
        [DataMember]
        public string Result { get; set; }
        [DataMember]
        public int? IsResult { get; set; }
        [DataMember]
        public int? RepayId { get; set; }
        [DataMember]
        public Guid DeductGuid { get; set; }
        [DataMember]
        public int? ProductType { get; set; }

        [DataMember]
        public int? IsPaymentType { get; set; }
        [DataMember]
        public string DeductOptName { get; set; }

        [DataMember]
        public int? ApplyId { get; set; }

        [DataMember]
        public string PaymentTypeName { get; set; }

    }
}
