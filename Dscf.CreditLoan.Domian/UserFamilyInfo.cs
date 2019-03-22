using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain
{
    /// <summary>
    /// 家庭信息
    /// </summary>
    public class UserFamilyInfo
    {

        /// <summary>
        /// UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// MaritalStatus
        /// </summary>
        public int? MaritalStatus { get; set; }

        /// <summary>
        /// IsHaveChild
        /// </summary>
        public bool? IsHaveChild { get; set; }

        /// <summary>
        /// HouseProperty
        /// </summary>
        public int? HouseProperty { get; set; }

        /// <summary>
        /// LinealKinName
        /// </summary>
        public string LinealKinName { get; set; }

        /// <summary>
        /// LineaKinRelation
        /// </summary>
        public string LineaKinRelation { get; set; }

        /// <summary>
        /// LineaKinPhone
        /// </summary>
        public string LineaKinPhone { get; set; }

        /// <summary>
        /// LinealKinState
        /// </summary>
        public int? LinealKinState { get; set; }

        /// <summary>
        /// OtherLinkManName
        /// </summary>
        public string OtherLinkManName { get; set; }

        /// <summary>
        /// OtherLinkManRel
        /// </summary>
        public string OtherLinkManRel { get; set; }

        /// <summary>
        /// OtherLinkManPhone
        /// </summary>
        public string OtherLinkManPhone { get; set; }

        /// <summary>
        /// OtherLinkManState
        /// </summary>
        public int? OtherLinkManState { get; set; }

        /// <summary>
        /// EmergLinkManName1
        /// </summary>
        public string EmergLinkManName1 { get; set; }

        /// <summary>
        /// EmergLinkManRel1
        /// </summary>
        public string EmergLinkManRel1 { get; set; }

        /// <summary>
        /// EmergLinkManPhone1
        /// </summary>
        public string EmergLinkManPhone1 { get; set; }

        /// <summary>
        /// EmergLinkManName2
        /// </summary>
        public string EmergLinkManName2 { get; set; }

        /// <summary>
        /// EmergLinkManRel2
        /// </summary>
        public string EmergLinkManRel2 { get; set; }

        /// <summary>
        /// EmergLinkManPhone2
        /// </summary>
        public string EmergLinkManPhone2 { get; set; }

        /// <summary>
        /// IsDeleted
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        public int? IsEnable { get; set; }

        /// <summary>
        /// OperateId
        /// </summary>
        public int? OperateId { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// ChildCount
        /// </summary>
        public int? ChildCount { get; set; }

        /// <summary>
        /// ParentCount
        /// </summary>
        public int? ParentCount { get; set; }

        /// <summary>
        /// ParentComment
        /// </summary>
        public string ParentComment { get; set; }


    }
}
