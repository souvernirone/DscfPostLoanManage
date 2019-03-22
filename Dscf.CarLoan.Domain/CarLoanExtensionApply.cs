using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain
{
    /// <summary>
    /// 车贷展期申请
    /// </summary>
    public class CarLoanExtensionApply
    {
        /// <summary>
        /// ExtensionId
        /// </summary>
        public int ExtensionId { get; set; }

        /// <summary>
        /// 车贷订单Id
        /// </summary>
        public int LoanProductOrerId { get; set; }

        /// <summary>
        /// 大堂数据记录Id
        /// </summary>
        public int? LobbyId { get; set; }

        /// <summary>
        /// 降额本金
        /// </summary>
        public decimal? DerationAmount { get; set; }

        /// <summary>
        /// 展期意见
        /// </summary>
        public string ExtensionMemo { get; set; }

        /// <summary>
        /// 验证状态Id
        /// </summary>
        public int VerfyStatusId { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int? IsDelete { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        public int? IsEnable { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

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
        /// 展期订单Id
        /// </summary>
        public int? ExtensionOrderId { get; set; }
    }
}
