using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain
{
    /// <summary>
    /// 车贷展期
    /// </summary>
    public class CarLoanExtension
    {
        /// <summary>
        /// ExtensionId
        /// </summary>
        public int ExtensionId { get; set; }

        /// <summary>
        /// 展期合同金额
        /// </summary>
        public decimal? ExtensionAmount { get; set; }

        /// <summary>
        /// 上期合同金额
        /// </summary>
        public decimal? PreAmount { get; set; }

        /// <summary>
        /// 降额本金
        /// </summary>
        public decimal? DeratingAmount { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal? Fee { get; set; }

        /// <summary>
        /// 本期综合费用
        /// </summary>
        public decimal? FeeAmount { get; set; }

        /// <summary>
        /// 本期扣款总额
        /// </summary>
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// 车贷订单编号
        /// </summary>
        public int? LoanProductOrderId { get; set; }

        /// <summary>
        /// 展期意见
        /// </summary>
        public string ExtensionMemo { get; set; }

        /// <summary>
        /// 展期状态
        /// </summary>
        public int? VerfyStatusId { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// 展期订单号
        /// </summary>
        public int? NewProductOrderId { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        public int? IsDelete { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

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
        /// LastUpdateTime
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// 违约金
        /// </summary>
        public decimal? BreachofcontractAmount { get; set; }

        /// <summary>
        /// 罚息
        /// </summary>
        public decimal? PenaltyInterest { get; set; }

        /// <summary>
        /// 利息
        /// </summary>
        public decimal? Interest { get; set; }

        /// <summary>
        /// 审核费
        /// </summary>
        public decimal? AuditFee { get; set; }

        /// <summary>
        /// 服务费
        /// </summary>
        public decimal? ServiceFee { get; set; }

        /// <summary>
        /// 咨询费
        /// </summary>
        public decimal? ConsultingFee { get; set; }

        /// <summary>
        /// IsOffLineDeduect
        /// </summary>
        public int? IsOffLineDeduect { get; set; }

        /// <summary>
        /// 应收违约金额
        /// </summary>
        public decimal? ReBreachofcontractAmount { get; set; }

        /// <summary>
        /// 应收罚息
        /// </summary>
        public decimal? RePenaltyInterest { get; set; }

        /// <summary>
        /// 应收其他费用
        /// </summary>
        public decimal? ReFee { get; set; }

        /// <summary>
        /// UpName
        /// </summary>
        public string UpName { get; set; }

        /// <summary>
        /// UpAmount
        /// </summary>
        public decimal? UpAmount { get; set; }

        /// <summary>
        /// UpType
        /// </summary>
        public string UpType { get; set; }

        /// <summary>
        /// UpBank
        /// </summary>
        public string UpBank { get; set; }
    }
}
