using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    //车贷利息配置
    [DataContract]
    public class CarLoanConfigDto
    {
        /// <summary>
        /// ConfigId
        /// </summary>
        [DataMember]
        public int ConfigId { get; set; }

        /// <summary>
        /// LoanTypeId
        /// </summary>
        [DataMember]
        public int? LoanTypeId { get; set; }

        /// <summary>
        /// 车贷名称
        /// </summary>
        [DataMember]
        public string CarLoanTypeName { get; set; }

        /// <summary>
        /// 贷款天数
        /// </summary>
        [DataMember]
        public int? LoanDays { get; set; }

        /// <summary>
        /// 月利率
        /// </summary>
        [DataMember]
        public decimal? MonthRate { get; set; }

        /// <summary>
        /// 利率总计，综合服务费率
        /// </summary>
        [DataMember]
        public decimal? RateTotal { get; set; }

        /// <summary>
        /// 月综合费率
        /// </summary>
        [DataMember]
        public decimal? MonthRateTotal { get; set; }

        /// <summary>
        /// 综合费率总计
        /// </summary>
        [DataMember]
        public decimal? ComplexRateTotal { get; set; }

        /// <summary>
        /// 总利率
        /// </summary>
        [DataMember]
        public decimal? PenaltyRate { get; set; }

        /// <summary>
        /// 合同利率
        /// </summary>
        [DataMember]
        public decimal? BreachOfContractRate { get; set; }

        /// <summary>
        /// 合同连接符
        /// </summary>
        [DataMember]
        public string ContractChar { get; set; }

        /// <summary>
        /// 车贷类型，1短期，2长期
        /// </summary>
        [DataMember]
        public int? TypeId { get; set; }

        /// <summary>
        /// 中期利率,期中收费
        /// </summary>
        [DataMember]
        public decimal? MiddleRate { get; set; }

        /// <summary>
        /// 前期利率
        /// </summary>
        [DataMember]
        public decimal? BeforeRate { get; set; }

        /// <summary>
        /// IsShow
        /// </summary>
        [DataMember]
        public int? IsShow { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        [DataMember]
        public int? IsDelete { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        [DataMember]
        public int? IsEnable { get; set; }

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
        /// CreateTime
        /// </summary>
        [DataMember]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        [DataMember]
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// 咨询费比例，综合服务费的百分比
        /// </summary>
        [DataMember]
        public decimal? ConsultancyRate { get; set; }

        /// <summary>
        /// 服务费比例，综合服务费的百分比
        /// </summary>
        [DataMember]
        public decimal? ServicesFeesRate { get; set; }

        /// <summary>
        /// 审核费比例，综合服务费的百分比
        /// </summary>
        [DataMember]
        public decimal? AuditFeesRate { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        [DataMember]
        public decimal? OtherFees { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        [DataMember]
        public decimal? Margin { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        [DataMember]
        public decimal? Formality { get; set; }

        /// <summary>
        /// 违约金比例
        /// </summary>
        [DataMember]
        public decimal? BreakRate { get; set; }

        /// <summary>
        /// 逾期比例
        /// </summary>
        [DataMember]
        public decimal? OverdueRate { get; set; }

        /// <summary>
        /// GPS基础安装费
        /// </summary>
        [DataMember]
        public decimal? GPSInstallFees { get; set; }

        /// <summary>
        /// GPS安装费合同限额
        /// </summary>
        [DataMember]
        public decimal? GPSContractLimits { get; set; }

        /// <summary>
        /// GPS安装费的增幅
        /// </summary>
        [DataMember]
        public decimal? GPSIncrease { get; set; }    
    }
}
