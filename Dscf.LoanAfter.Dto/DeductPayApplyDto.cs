using System;
using System.Runtime.Serialization;

namespace Dscf.LoanAfter.Dto
{
    [DataContract]
    public class DeductPayApplyDto
    {
        /// <summary>
        /// 划扣申请Id
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// OrderId
        /// </summary>
        [DataMember]
        public int? OrderId { get; set; }

        /// <summary>
        /// 订单类型-1:信用借款 2:车辆借款
        /// </summary>
        [DataMember]
        public int? OrderType { get; set; }

        /// <summary>
        /// 支付方式 1:申请划扣 2:线下支付
        /// </summary>
        [DataMember]
        public int? PayWay { get; set; }

        /// <summary>
        /// 划扣方式
        /// </summary>
        [DataMember]
        public string PayWayName { get; set; }

        /// <summary>
        /// ReliefAmount
        /// </summary>
        [DataMember]
        public decimal? ReliefAmount { get; set; }

        /// <summary>
        /// RepayAmount
        /// </summary>
        [DataMember]
        public decimal? RepayAmount { get; set; }

        /// <summary>
        /// FileId
        /// </summary>
        [DataMember]
        public int? FileId { get; set; }

        /// <summary>
        /// CreateOptId
        /// </summary>
        [DataMember]
        public int? CreateOptId { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        [DataMember]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        [DataMember]
        public int? LastOperateId { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        [DataMember]
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// 划扣审批状态
        /// </summary>
        [DataMember]
        public int? ApprovalStatus { get; set; }

        /// <summary>
        /// 拒绝原因
        /// </summary>
        [DataMember]
        public string Reason { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        [DataMember]
        public FileEntityDto FileEntity { get; set; }

        /// <summary>
        /// 划扣申请表ID
        /// </summary>
         [DataMember]
        public int? ApplyId { get; set; }

    }
}
