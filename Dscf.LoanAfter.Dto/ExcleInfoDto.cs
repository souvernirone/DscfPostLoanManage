using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Dto
{
    [DataContract]
    public class ExcleInfoDto
    {
        /// <summary>
        /// ProductId
        /// </summary>
        [DataMember]
        public int ProductId { get; set; }

        /// <summary>
        /// ProductName
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// ProductType
        /// </summary>
        [DataMember]
        public int ProductType { get; set; }

    }
}
