using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    [DataContract]
    public class CarRemidDetailDto
    {
        /// <summary>
        /// 客户姓名
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        [DataMember]
        public string IDCard { get; set; }

        /// <summary>
        /// 划扣银行账号
        /// </summary>
        [DataMember]
        public string DeductBankAccount { get; set; }

        /// <summary>
        /// 划扣银行名称
        /// </summary>
        [DataMember]
        public string DeductBankName { get; set; }

        /// <summary>
        /// 划扣支行名称
        /// </summary>
        [DataMember]
        public string DeductBranchBank { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [DataMember]
        public string ContractNumber { get; set; }

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
        /// 借款期限(批款期限)
        /// </summary>
        [DataMember]
        public int? Term { get; set; }

        /// <summary>
        /// 月还金额
        /// </summary>
        [DataMember]
        public decimal? MonthRepay { get; set; }

        /// <summary>
        /// 划扣时间
        /// </summary>
        [DataMember]
        public DateTime? RepayDate { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [DataMember]
        public string CompanyName { get; set; }

        /// <summary>
        /// 公司联系电话
        /// </summary>
        [DataMember]
        public string CompanyTel { get; set; }

        #region 联系人信息
        /// <summary>
        /// EmergLinkManName1
        /// </summary>
        [DataMember]
        public string EmergLinkManName1 { get; set; }

        /// <summary>
        /// EmergLinkManRel1
        /// </summary>
        [DataMember]
        public string EmergLinkManRel1 { get; set; }

        /// <summary>
        /// EmergLinkManPhone1
        /// </summary>
        [DataMember]
        public string EmergLinkManPhone1 { get; set; }

        /// <summary>
        /// EmergLinkManName2
        /// </summary>
        [DataMember]
        public string EmergLinkManName2 { get; set; }

        /// <summary>
        /// EmergLinkManRel2
        /// </summary>
        [DataMember]
        public string EmergLinkManRel2 { get; set; }

        /// <summary>
        /// EmergLinkManPhone2
        /// </summary>
        [DataMember]
        public string EmergLinkManPhone2 { get; set; }

        #endregion

    }
}
