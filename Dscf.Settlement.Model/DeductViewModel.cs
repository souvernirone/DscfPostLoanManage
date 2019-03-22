using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Settlement.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class DeductViewModel
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public int OrderType { get; set; }
        /// <summary>
        /// 所提交的划扣申请状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 如果划扣失败，其原因
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 划扣类型（线上1，线下2）
        /// </summary>
        public int DeductType { get; set; }
        /// <summary>
        /// 划扣种类（手动1，批量2）
        /// </summary>
        public int DeductKind { get; set; }
        /// <summary>
        /// 划扣金额
        /// </summary>
        public decimal? DeductMoney { get; set; }
        /// <summary>
        /// 月还Id
        /// </summary>
        public int? RepayId { get; set; }
        /// <summary>
        /// 第几期
        /// </summary>
        public int? PeriodOrder { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 客户身份证号
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// 客户手机号码
        /// </summary>
        public string Phone { get; set; }


        /// <summary>
        /// 客户银行卡号
        /// </summary>
        public string DeductBankAccount { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string DeductBankName { get; set; }

        /// <summary>
        /// 银行Code
        /// </summary>
        public string BankCode { get; set; }
        
        /// <summary>
        /// 银行支行
        /// </summary>
        public string SubBranchName { get; set; }

        /// <summary>
        /// 支付类型（1为中金，0为银生宝）
        /// </summary>
        public string PayType { get; set; }

        /// <summary>
        /// 划扣申请Id
        /// </summary>
        public int? ApplyId { get; set; }


    }
}
