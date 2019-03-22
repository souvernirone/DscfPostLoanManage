using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    [DataContract]
    public class UserFamilyInfoDto
    {
        /// <summary>
        /// UserId
        /// </summary>
        [DataMember]
        public int UserId { get; set; }

        /// <summary>
        /// IsHaveChild
        /// </summary>
        [DataMember]
        public bool? IsHaveChild { get; set; }


        /// <summary>
        /// LinealKinName
        /// </summary>
        [DataMember]
        public string LinealKinName { get; set; }

        /// <summary>
        /// LineaKinRelation
        /// </summary>
        [DataMember]
        public string LineaKinRelation { get; set; }

        /// <summary>
        /// LineaKinPhone
        /// </summary>
        [DataMember]
        public string LineaKinPhone { get; set; }


        /// <summary>
        /// OtherLinkManName
        /// </summary>
        [DataMember]
        public string OtherLinkManName { get; set; }

        /// <summary>
        /// OtherLinkManRel
        /// </summary>
        [DataMember]
        public string OtherLinkManRel { get; set; }

        /// <summary>
        /// OtherLinkManPhone
        /// </summary>
        [DataMember]
        public string OtherLinkManPhone { get; set; }

        /// <summary>
        /// EmergLinkManName1
        /// </summary>
        [DataMember]
        public string EmergLinkManName1 { get; set; }

        /// <summary>
        /// EmergLinkManRel1
        /// </summary>
        [DataMember]
        public string EmergLinkManRel1 { get; set; }

        /// <summary>
        /// EmergLinkManPhone1
        /// </summary>
        [DataMember]
        public string EmergLinkManPhone1 { get; set; }

        /// <summary>
        /// EmergLinkManName2
        /// </summary>
        [DataMember]
        public string EmergLinkManName2 { get; set; }

        /// <summary>
        /// EmergLinkManRel2
        /// </summary>
        [DataMember]
        public string EmergLinkManRel2 { get; set; }

        /// <summary>
        /// EmergLinkManPhone2
        /// </summary>
        [DataMember]
        public string EmergLinkManPhone2 { get; set; }

    }
}
