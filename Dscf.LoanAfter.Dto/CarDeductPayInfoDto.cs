using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Dto
{
    [DataContract]
    public class CarDeductPayInfoDto
    {
        [DataMember]
        public int? Id { get; set; }
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
        public int? StatusId { get; set; }
        [DataMember]
        public string StatusName { get; set; }
        [DataMember]
        public decimal? Amount { get; set; }
        [DataMember]
        public int? PayWay { get; set; }

        [DataMember]
        public string PayWayName { get; set; }
        [DataMember]
        public int? IsExtension { get; set; }



    }
}
