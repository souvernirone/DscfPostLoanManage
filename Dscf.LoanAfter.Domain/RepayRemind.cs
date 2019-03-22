using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Domain
{
    public class RepayRemind
    {

        /// <summary>
        /// RemindId主键
        /// </summary>
        public int RemindId { get; set; }

        /// <summary>
        /// 月还表主键RepayId
        /// </summary>
        public int? RepayId { get; set; }

        /// <summary>
        /// 借款订单类型OrderType
        /// 1-信用借款
        /// 2-车辆借款
        /// </summary>
        public int? OrderType { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreateOptId { get; set; }

        /// <summary>
        /// 是否被删除
        /// </summary>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// 最后更新操作员
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// 提醒类型
        /// </summary>
        public int? RemindType { get; set; }

        /// <summary>
        /// 提醒日志
        /// </summary>
        public string RemindContent { get; set; }


    }
}
