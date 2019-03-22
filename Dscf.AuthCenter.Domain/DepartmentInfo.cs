using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.AuthCenter.Domain
{
    public class DepartmentInfo
    {
        /// <summary>
        /// DepartmentId
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 签约地址
        /// </summary>
        public string SignAddress { get; set; }

        /// <summary>
        /// 签约城市
        /// </summary>
        public string SignCity { get; set; }

        /// <summary>
        /// 客户服务电话
        /// </summary>
        public string CustomerServicePhone { get; set; }

        /// <summary>
        /// 循环借款咨询电话
        /// </summary>
        public string RevolvingLoanPhone { get; set; }

        /// <summary>
        /// 提前还款咨询电话
        /// </summary>
        public string EarlyRepayPhone { get; set; }

        /// <summary>
        /// 部门描述
        /// </summary>
        public string DeptDesc { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 上级部门id
        /// </summary>
        public int? ParentDeptId { get; set; }

        /// <summary>
        /// 签署地邮编
        /// </summary>
        public string SignZipCode { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreateOptId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

    }
}
