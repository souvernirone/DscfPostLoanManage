using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    /// <summary>
    /// 批量划扣DTO
    /// </summary>
    [DataContract]
    public class CreditCriticalAmountListDto
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        [DataMember]
        public int OrderId { get; set; }

        /// <summary>
        /// 签署地
        /// </summary>
        [DataMember]
        public string SignCity { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [DataMember]
        public string Contract { get; set; }

        /// <summary>
        /// 合同金额
        /// </summary>
        [DataMember]
        public decimal? Amount { get; set; }

        /// <summary>
        /// 月还金额
        /// </summary>
        [DataMember]
        public decimal? MonthRepay { get; set; }

        /// <summary>
        /// 订单月还期次
        /// </summary>
        [DataMember]
        public int PeriodOrder { get; set; }

        /// <summary>
        /// 划扣日期
        /// </summary>
        [DataMember]
        public DateTime? RepayDate { get; set; }

        /// <summary>
        /// 签约日期
        /// </summary>
        [DataMember]
        public DateTime? SignDate { get; set; }

        /// <summary>
        ///划扣银行名称
        /// </summary>
        [DataMember]
        public string DeductBankName { get; set; }

        /// <summary>
        ///划扣支行名称
        /// </summary>
        [DataMember]
        public string DeductBranchBank { get; set; }

        /// <summary>
        ///划扣银行账号
        /// </summary>
        [DataMember]
        public string DeductBankAccount { get; set; }

        /// <summary>
        /// 银行划扣后返回的Code
        /// 中金
        ///    2000是提交成功，30是回款成功，40是失败，10或20是处理中
        ///银生宝
        ///    0000是提交成功，00是回款成功，10 是处理中，20是失败
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// 根据结果取名称
        /// </summary>
        [DataMember]
        public string CodeName { get; set; }

        /// <summary>
        /// 划扣日期
        /// </summary>
        [DataMember]
        public DateTime? OperateDate { get; set; }

        /// <summary>
        /// 银行返回的处理结果
        /// </summary>
        [DataMember]
        public string Result { get; set; }

        /// <summary>
        /// 月还ID
        /// </summary>
        [DataMember]
        public int RepayId { get; set; }

    }
}
