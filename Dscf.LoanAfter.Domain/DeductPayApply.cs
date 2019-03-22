using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Domain
{
    /// <summary>
    /// 申请划扣-线下支付类
    /// </summary>
    public class DeductPayApply
    {

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// OrderId
        /// </summary>
        public int? OrderId { get; set; }

        /// <summary>
        /// OrderType
        /// </summary>
        public int? OrderType { get; set; }

        /// <summary>
        /// ReliefAmount
        /// </summary>
        public decimal? ReliefAmount { get; set; }

        /// <summary>
        /// RepayAmount
        /// </summary>
        public decimal? RepayAmount { get; set; }

        /// <summary>
        /// FileId
        /// </summary>
        public int? FileId { get; set; }

        /// <summary>
        /// CreateOptId
        /// </summary>
        public int? CreateOptId { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// IsDeleted
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// 还款支付方式 T_Dictionary_key_PayWay
        /// </summary>
        public int? PayWay { get; set; }

        /// <summary>
        /// 划扣审批状态
        /// </summary>
        public int? ApprovalStatus { get; set; }

        /// <summary>
        /// 拒绝原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 导航属性-上传文件
        /// </summary>
        public virtual FileEntity FileEntity { get; set; }


    }
}
