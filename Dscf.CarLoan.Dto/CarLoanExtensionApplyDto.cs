using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    //车贷展期申请
    [DataContract]
    public class CarLoanExtensionApplyDto
    {
        /// <summary>
        /// ExtensionId
        /// </summary>
        [DataMember]
        public int ExtensionId { get; set; }

        /// <summary>
        /// 车贷订单Id
        /// </summary>
        [DataMember]
        public int LoanProductOrerId { get; set; }

        /// <summary>
        /// 大堂数据记录Id
        /// </summary>
        [DataMember]
        public int? LobbyId { get; set; }

        /// <summary>
        /// 降额本金
        /// </summary>
        [DataMember]
        public decimal? DerationAmount { get; set; }

        /// <summary>
        /// 展期意见
        /// </summary>
        [DataMember]
        public string ExtensionMemo { get; set; }

        /// <summary>
        /// 验证状态Id
        /// </summary>
        public int VerfyStatusId { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [DataMember]
        public int? IsDelete { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        [DataMember]
        public int? IsEnable { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// OperateId
        /// </summary>
        [DataMember]
        public int? OperateId { get; set; }

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
        /// 展期订单Id
        /// </summary>
        [DataMember]
        public int? ExtensionOrderId { get; set; }
    }
}
