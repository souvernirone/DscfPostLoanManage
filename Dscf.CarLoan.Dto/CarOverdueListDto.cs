using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    /// <summary>
    /// 车贷逾期列表Dto
    /// </summary>
    [DataContract]
    public class CarOverdueListDto
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        [DataMember]
        public int? OrderId { get; set; }


        /// <summary>
        /// 催收操作员
        /// </summary>
        [DataMember]
        public string CollectorName { get; set; }

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
        /// 合同金额
        /// </summary>
        [DataMember]
        public decimal? Amount { get; set; }
        /// <summary>
        /// 签约时间
        /// </summary>
        [DataMember]
        public DateTime? SignDate { get; set; }

        /// <summary>
        /// 累计逾期本金
        /// </summary>
        [DataMember]
        public decimal? OverduePrincipalSum { get; set; }

        /// <summary>
        /// 首逾日期
        /// </summary>
        [DataMember]
        public DateTime? FirstOverdueTime { get; set; }

        /// <summary>
        /// 逾期次数
        /// </summary>
        [DataMember]
        public int? OverdueCount { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// 债权状态
        /// </summary>
        [DataMember]
        public int? CarLoanStatus { get; set; }


        /// <summary>
        /// 债权状态名称
        /// </summary>
        [DataMember]
        public string CarLoanStatusName { get; set; }

        /// <summary>
        /// 车贷借款订单创建人
        /// </summary>
        [DataMember]
        public int? OperateId { get; set; }

        /// <summary>
        /// 是否能展期
        /// </summary>
        [DataMember]
        public bool? IsCanExtension { get; set; }

        /// <summary>
        /// 月还Id
        /// </summary>
        [DataMember]
        public int? RepayId { get; set; }

        [DataMember]
        public int? DeptOptId { get; set; }

        [DataMember]
        public int? CollectStatus { get; set; }

        [DataMember]
        public string CollectStatusName { get; set; }

        /// <summary>
        /// 申请展期次数
        /// </summary>
        [DataMember]
        public int? ExtensionApplyCount { get; set; }

        /// <summary>
        /// 展期复议审核状态
        /// </summary>
        [DataMember]
        public int? ReconsiderationStatusId { get; set; }

        [DataMember]
        public DateTime? LobbyTime { get; set; }

        [DataMember]
        string LicensePlate { get; set; }

        [DataMember]
        int? IsExtension { get; set; }
    }
}
