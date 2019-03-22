using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain
{
    public class UserWorkInfo
    {

        /// <summary>
        /// UserId
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string Dept { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 工作邮箱
        /// </summary>
        public string WorkEmail { get; set; }

        /// <summary>
        /// 公司所在城市
        /// </summary>
        public int? WorkCity { get; set; }

        /// <summary>
        /// 公司地址
        /// </summary>
        public string CompanyAddress { get; set; }

        /// <summary>
        /// 公司类型
        /// </summary>
        public int? CompanyType { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime? EnterCompanyDate { get; set; }

        /// <summary>
        /// CompanyTel
        /// </summary>
        public string CompanyTel { get; set; }

        /// <summary>
        /// 证明人1
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
        /// MonthlySalary
        /// </summary>
        public decimal? MonthlySalary { get; set; }

        /// <summary>
        /// 其他收入
        /// </summary>
        public decimal? OtherSalary { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// OperateId
        /// </summary>
        public int? OperateId { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        public int? IsEnable { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        public int? IsDelete { get; set; }

        /// <summary>
        /// CompanyMemo
        /// </summary>
        public string CompanyMemo { get; set; }
    }
}
