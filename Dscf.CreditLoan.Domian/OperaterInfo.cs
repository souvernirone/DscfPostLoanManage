using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain
{
    public class OperaterInfo
    {

        /// <summary>
        /// OptId
        /// </summary>
        public int OptId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// DepId
        /// </summary>
        public int? DepId { get; set; }

        /// <summary>
        /// IsDeleted
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// CertificateType
        /// </summary>
        public int? CertificateType { get; set; }

        /// <summary>
        /// IDCard
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// ParentOptId
        /// </summary>
        public int? ParentOptId { get; set; }

        /// <summary>
        /// WorkEmail
        /// </summary>
        public string WorkEmail { get; set; }

        /// <summary>
        /// Weixin
        /// </summary>
        public string Weixin { get; set; }

        /// <summary>
        /// EntryDate
        /// </summary>
        public DateTime? EntryDate { get; set; }

        /// <summary>
        /// QuitDate
        /// </summary>
        public DateTime? QuitDate { get; set; }

        /// <summary>
        /// PositionId
        /// </summary>
        public int? PositionId { get; set; }

        /// <summary>
        /// OperateId
        /// </summary>
        public int? OperateId { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        public int? IsEnable { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// HeadPhoto
        /// </summary>
        public string HeadPhoto { get; set; }

        /// <summary>
        /// Sex
        /// </summary>
        public int? Sex { get; set; }

        /// <summary>
        /// RoleId
        /// </summary>
        public int? RoleId { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// 邮寄地址
        /// </summary>
        public string PostAddress { get; set; }

        ///// <summary>
        ///// 积分
        ///// </summary>
        //public int? Integral { get; set; }

        ///// <summary>
        ///// 冻结积分
        ///// </summary>
        //public int? FreezeIntegral { get; set; }

        /// <summary>
        /// PostName
        /// </summary>
        public string PostName { get; set; }

        /// <summary>
        /// PostPhone
        /// </summary>
        public string PostPhone { get; set; }

        /// <summary>
        /// 导航属性-操作员角色列表
        /// </summary>
        public virtual IList<OperatorRole> OperatorRoleList { get; set; }

        /// <summary>
        /// 导航属性-部门信息
        /// </summary>
        public virtual DepartmentInfo DepartmentInfo { get; set; }


    }
}
