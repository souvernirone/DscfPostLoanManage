using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    [DataContract]
    public class LoanInfoDto
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
        /// 手机号
        /// </summary>
        [DataMember]
        public string Phone { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        [DataMember]
        public string IDCard { get; set; }

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
        /// 订单类型【1信贷,2车贷】
        /// </summary>
        [DataMember]
        public int OrderType { get; set; }

        /// <summary>
        /// 订单所属部门Id
        /// </summary>
        [DataMember]
        public int? DeptId { get; set; }

    }
}
