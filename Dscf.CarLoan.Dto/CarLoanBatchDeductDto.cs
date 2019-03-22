using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    [DataContract]
    public class CarLoanBatchDeductDto
    {
        [DataMember]
        public int? OrderId { get; set; }

        [DataMember]
        public string SignCity { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public int OrderType { get; set; }
        [DataMember]
        public DateTime? LobbyTime { get; set; }
        [DataMember]
        public string LicensePlate { get; set; }

        [DataMember]
        public decimal? Amount { get; set; }

        [DataMember]
        public int? IsExtension { get; set; }

        [DataMember]
        public decimal? MonthRepay { get; set; }
        [DataMember]
        public DateTime? RepayDate { get; set; }
        [DataMember]
        public int? RepayId { get; set; }
        [DataMember]
        public int? PeriodOrder { get; set; }

        [DataMember]
        public DateTime? RemindDate { get; set; }
        [DataMember]
        public int? IsRemind { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string CodeName { get; set; }
        [DataMember]
        public int? PaymentType { get; set; }

    }
}
