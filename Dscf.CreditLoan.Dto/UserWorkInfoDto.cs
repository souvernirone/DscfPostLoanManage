using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    [DataContract]
    public class UserWorkInfoDto
    {
        /// <summary>
        /// UserId
        /// </summary>
        [DataMember]
        public int UserId { get; set; }

        /// <summary>
        /// CompanyName
        /// </summary>
        [DataMember]
        public string CompanyName { get; set; }

        /// <summary>
        /// Dept
        /// </summary>
        [DataMember]
        public string Dept { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        [DataMember]
        public string Position { get; set; }

        /// <summary>
        /// WorkEmail
        /// </summary>
        [DataMember]
        public string WorkEmail { get; set; }

        /// <summary>
        /// WorkCity
        /// </summary>
        [DataMember]
        public int? WorkCity { get; set; }

        /// <summary>
        /// CompanyAddress
        /// </summary>
        [DataMember]
        public string CompanyAddress { get; set; }


        /// <summary>
        /// EnterCompanyDate
        /// </summary>
        [DataMember]
        public DateTime? EnterCompanyDate { get; set; }

        /// <summary>
        /// CompanyTel
        /// </summary>
        [DataMember]
        public string CompanyTel { get; set; }

        /// <summary>
        /// CertifyName
        /// </summary>
        [DataMember]
        public string CertifyName { get; set; }

        /// <summary>
        /// CertifyRelation
        /// </summary>
        [DataMember]
        public string CertifyRelation { get; set; }

        /// <summary>
        /// CertifyTel
        /// </summary>
        [DataMember]
        public string CertifyTel { get; set; }

        /// <summary>
        /// CertifyName2
        /// </summary>
        [DataMember]
        public string CertifyName2 { get; set; }

        /// <summary>
        /// CertifyRelation2
        /// </summary>
        [DataMember]
        public string CertifyRelation2 { get; set; }

        /// <summary>
        /// CertifyTel2
        /// </summary>
        [DataMember]
        public string CertifyTel2 { get; set; }
    }
}
