using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Dto
{
    [DataContract]
    public class ThroughListDto
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        [DataMember]
        public int? OrderId { get; set; }

        /// <summary>
        /// 签约城市
        /// </summary>
        [DataMember]
        public string SignCity { get; set; }

        /// <summary>
        /// 创建操作员部门
        /// </summary>
        [DataMember]
        public int? OptDeptId { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 签约时间
        /// </summary>
        [DataMember]
        public DateTime? SignDate { get; set; }

        /// <summary>
        /// 合同金额
        /// </summary>
        [DataMember]
        public decimal? Amount { get; set; }

        /// <summary>
        /// 划扣金额
        /// </summary>
        [DataMember]
        public decimal? RepayAmount { get; set; }

        /// <summary>
        /// 借款订单类型
        /// </summary>
        [DataMember]
        public int? OrderType { get; set; }


        /// <summary>
        /// 借款订单类型名称
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// 扣款方式名称
        /// </summary>
        [DataMember]
        public string PayWayName { get; set; }

        /// <summary>
        /// 扣款方式INT
        /// </summary>
        [DataMember]
        public int? PayWay { get; set; }

        /// <summary>
        /// 签约状态INT
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// 签约状态NAME
        /// </summary>
        [DataMember]
        public string ResultName { get; set; }

        /// <summary>
        ///扣款状态
        /// </summary>
        [DataMember]
        public int? ApprovalStatus { get; set; }

        /// <summary>
        /// 扣款状态Name
        /// </summary>
        [DataMember]
        public string ApprovalStatusName { get; set; }

        /// <summary>
        /// 划扣表id
        /// </summary>
        [DataMember]
        public int? ApplyId { get; set; }
    }
}
