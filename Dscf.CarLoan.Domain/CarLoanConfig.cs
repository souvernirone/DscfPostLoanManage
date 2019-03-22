using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain
{
    //车贷利息配置    
    public class CarLoanConfig
    {
        /// <summary>
        /// ConfigId
        /// </summary>
        public int ConfigId { get; set; }

        /// <summary>
        /// LoanTypeId
        /// </summary>
        public int? LoanTypeId { get; set; }

        /// <summary>
        /// 车贷名称
        /// </summary>
        public string CarLoanTypeName { get; set; }

        /// <summary>
        /// 贷款天数
        /// </summary>
        public int? LoanDays { get; set; }

        /// <summary>
        /// 月利率
        /// </summary>
        public decimal? MonthRate { get; set; }

        /// <summary>
        /// 利率总计，综合服务费率
        /// </summary>
        public decimal? RateTotal { get; set; }

        /// <summary>
        /// 月综合费率
        /// </summary>
        public decimal? MonthRateTotal { get; set; }

        /// <summary>
        /// 综合费率总计
        /// </summary>
        public decimal? ComplexRateTotal { get; set; }

        /// <summary>
        /// 总利率
        /// </summary>
        public decimal? PenaltyRate { get; set; }

        /// <summary>
        /// 合同利率
        /// </summary>
        public decimal? BreachOfContractRate { get; set; }

        /// <summary>
        /// 合同连接符
        /// </summary>
        public string ContractChar { get; set; }

        /// <summary>
        /// 车贷类型，1短期，2长期
        /// </summary>
        public int? TypeId { get; set; }

        /// <summary>
        /// 中期利率,期中收费
        /// </summary>
        public decimal? MiddleRate { get; set; }

        /// <summary>
        /// 前期利率
        /// </summary>
        public decimal? BeforeRate { get; set; }

        /// <summary>
        /// IsShow
        /// </summary>
        public int? IsShow { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        public int? IsDelete { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        public int? IsEnable { get; set; }

        /// <summary>
        /// OperateId
        /// </summary>
        public int? OperateId { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// 咨询费比例，综合服务费的百分比
        /// </summary>
        public decimal? ConsultancyRate { get; set; }

        /// <summary>
        /// 服务费比例，综合服务费的百分比
        /// </summary>
        public decimal? ServicesFeesRate { get; set; }

        /// <summary>
        /// 审核费比例，综合服务费的百分比
        /// </summary>
        public decimal? AuditFeesRate { get; set; }

        /// <summary>
        /// 其他费用
        /// </summary>
        public decimal? OtherFees { get; set; }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal? Margin { get; set; }

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal? Formality { get; set; }

        /// <summary>
        /// 违约金比例
        /// </summary>
        public decimal? BreakRate { get; set; }

        /// <summary>
        /// 逾期比例
        /// </summary>
        public decimal? OverdueRate { get; set; }

        /// <summary>
        /// GPS基础安装费
        /// </summary>
        public decimal? GPSInstallFees { get; set; }

        /// <summary>
        /// GPS安装费合同限额
        /// </summary>
        public decimal? GPSContractLimits { get; set; }

        /// <summary>
        /// GPS安装费的增幅
        /// </summary>
        public decimal? GPSIncrease { get; set; }

        /// <summary>
        /// 新增字段2017-3-27 是否可展期
        /// </summary>
        public bool? IsCanExtension { get; set; }    
    }
}
