using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    [DataContract]
    public class BankInfoDto
    {
        /// <summary>
        /// BankInfoId
        /// </summary>
        [DataMember]
        public int BankInfoId { get; set; }

        /// <summary>
        /// BankName
        /// </summary>
        [DataMember]
        public string BankName { get; set; }

        /// <summary>
        /// BankCode
        /// </summary>
        [DataMember]
        public string BankCode { get; set; }        

    }
}
