using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Dto
{
    [DataContract]
    public class RepayRemindDto
    {
        /// <summary>
        /// RemindId主键
        /// </summary>
        [DataMember]
        public int RemindId { get; set; }

        /// <summary>
        /// 操作员名字
        /// </summary>
        [DataMember]
        public string OptName { get; set; }

        /// <summary>
        /// 创建的操作员ID
        /// </summary>
        [DataMember]
        public int? CreateOptId { get; set; }

        /// <summary>
        /// 最后更新操作员
        /// </summary>
        [DataMember]
        public int? LastOperateId { get; set; }

        /// <summary>
        /// 月还表主键RepayId
        /// </summary>
        [DataMember]
        public int? RepayId { get; set; }

        /// <summary>
        /// 借款订单类型OrderType
        /// 1-信用借款
        /// 2-车辆借款
        /// </summary>
        [DataMember]
        public int? OrderType { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [DataMember]
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// 提醒类型
        /// </summary>

        [DataMember]
        public int? RemindType { get; set; }

        /// <summary>
        /// 提醒类型名称
        /// </summary>
        [DataMember]
        public string RemindTypeName { get; set; }

        /// <summary>
        /// 提醒日志
        /// </summary>
        [DataMember]
        public string RemindContent { get; set; }


    }
}
