using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain
{
    /// <summary>
    /// 工作信息
    /// </summary>
    public class UserWorkInfo
    {

        /// <summary>
        /// UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// CompanyName
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Dept
        /// </summary>
        public string Dept { get; set; }

        /// <summary>
        /// Position
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// WorkEmail
        /// </summary>
        public string WorkEmail { get; set; }

        /// <summary>
        /// WorkCity
        /// </summary>
        public int? WorkCity { get; set; }

        /// <summary>
        /// CompanyAddress
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// CompanyType
        /// </summary>
        public int? CompanyType { get; set; }

        /// <summary>
        /// 4 三年以上
        /// </summary>
        public int? WorkYears { get; set; }

        /// <summary>
        /// EnterCompanyDate
        /// </summary>
        public DateTime? EnterCompanyDate { get; set; }

        /// <summary>
        /// CompanyTel
        /// </summary>
        public string CompanyTel { get; set; }

        /// <summary>
        /// CertifyName
        /// </summary>
        public string CertifyName { get; set; }

        /// <summary>
        /// CertifyRelation
        /// </summary>
        public string CertifyRelation { get; set; }

        /// <summary>
        /// CertifyTel
        /// </summary>
        public string CertifyTel { get; set; }

        /// <summary>
        /// CertifyName2
        /// </summary>
        public string CertifyName2 { get; set; }

        /// <summary>
        /// CertifyRelation2
        /// </summary>
        public string CertifyRelation2 { get; set; }

        /// <summary>
        /// CertifyTel2
        /// </summary>
        public string CertifyTel2 { get; set; }

        /// <summary>
        /// IsDeleted
        /// </summary>
        public int? IsDeleted { get; set; }

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
        /// MonthlySalary
        /// </summary>
        public decimal? MonthlySalary { get; set; }

        /// <summary>
        /// OtherSalary
        /// </summary>
        public decimal? OtherSalary { get; set; }

        /// <summary>
        /// CreateCompanyDate
        /// </summary>
        public DateTime? CreateCompanyDate { get; set; }


    }
}
