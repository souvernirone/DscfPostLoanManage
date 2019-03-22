using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    [DataContract]
    public class CarLoanOrderDetailDto
    {
        /// <summary>
        /// 借款订单编号
        /// </summary>
        [DataMember]
        public int OrderId { get; set; }

        /// <summary>
        /// 合同额
        /// </summary>
        [DataMember]
        public decimal? Amount { get; set; }

        /// <summary>
        /// 到手额
        /// </summary>
        [DataMember]
        public decimal? NetAmount { get; set; }

        /// <summary>
        /// 合同开始时间
        /// </summary>
        [DataMember]
        public DateTime? ContractStartDate { get; set; }

        /// <summary>
        /// 合同结束时间
        /// </summary>
        [DataMember]
        public DateTime? ContractEndDate { get; set; }

        /// <summary>
        /// 面签时间
        /// </summary>
        [DataMember]
        public DateTime? SignDate { get; set; }


        /// <summary>
        /// 划扣银行
        /// </summary>
        [DataMember]
        public string DeductBankName { get; set; }

        /// <summary>
        /// 划扣银行支行
        /// </summary>
        [DataMember]
        public string DeductBranchBank { get; set; }

        /// <summary>
        /// 划扣银行账户
        /// </summary>
        [DataMember]
        public string DeductBankAccount { get; set; }


        /// <summary>
        /// 用户信息
        /// </summary>
        [DataMember]
        public UserInfoDto UserInfo { get; set; }

        /// <summary>
        /// 借款订单月还列表
        /// </summary>
        [DataMember]
        public IList<LoanMonthRepayDto> LoanMonthRepayList { get; set; }

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
        /// 车辆信息
        /// </summary>
        [DataMember]
        public CarInfoDto CarInfo { get; set; }

        /// <summary>
        /// 大堂信息
        /// </summary>
        [DataMember]
        public LobbyInfoDto LobbyInfo { get; set; }

        /// <summary>
        /// 导航属性-借款订单合同列表
        /// </summary>
        [DataMember]
        public IList<ContractFormationDto> ContractFormationList { get; set; }
    }
}
