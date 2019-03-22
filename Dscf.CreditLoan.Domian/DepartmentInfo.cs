using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain
{
    public class DepartmentInfo
    {
        /// <summary>
        /// DepId
        /// </summary>
        public int DepId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepName { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        public string DepCode { get; set; }

        /// <summary>
        /// 上级部门id
        /// </summary>
        public int ParentDepId { get; set; }

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
        /// 是否删除
        /// </summary>
        public int? IsDeleted { get; set; }


        /// <summary>
        /// 是否显示
        /// </summary>
        public int? IsEnable { get; set; }

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
        public int? OperateId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

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
