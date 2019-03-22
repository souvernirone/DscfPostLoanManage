using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class CreditDeductViewDto
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        [DataMember]
        public int OrderId { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        [DataMember]
        public int OrderType { get; set; }
        /// <summary>
        /// 所提交的划扣申请状态
        /// </summary>
        [DataMember]
        public int Status { get; set; }

        /// <summary>
        /// 如果划扣失败，其原因
        /// </summary>
        [DataMember]
        public string Reason { get; set; }
        /// <summary>
        /// 划扣类型（线上1，线下2）
        /// </summary>
        [DataMember]
        public int DeductType { get; set; }
        /// <summary>
        /// 划扣种类（手动1，批量2）
        /// </summary>
        [DataMember]
        public int DeductKind { get; set; }
        /// <summary>
        /// 划扣金额
        /// </summary>
        [DataMember]
        public decimal? DeductMoney { get; set; }
        /// <summary>
        /// 月还Id
        /// </summary>
        [DataMember]
        public int? RepayId { get; set; }
        /// <summary>
        /// 第几期
        /// </summary>
        [DataMember]
        public int? PeriodOrder { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 客户身份证号
        /// </summary>
        [DataMember]
        public string IDCard { get; set; }

        /// <summary>
        /// 客户手机号码
        /// </summary>
        [DataMember]
        public string Phone { get; set; }


        /// <summary>
        /// 客户银行卡号
        /// </summary>
        [DataMember]
        public string DeductBankAccount { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        [DataMember]
        public string DeductBankName { get; set; }

        /// <summary>
        /// 银行Code
        /// </summary>
        [DataMember]
        public string BankCode { get; set; }
        
        /// <summary>
        /// 银行支行
        /// </summary>
        [DataMember]
        public string SubBranchName { get; set; }

        /// <summary>
        /// 支付类型（1为中金，0为银生宝）
        /// </summary>
        [DataMember]
        public string PayType { get; set; }

        /// <summary>
        /// 划扣申请Id
        /// </summary>
        [DataMember]
        public int? ApplyId { get; set; }


    }
}
