using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain
{
    public class BankInfo
    {
        /// <summary>
        /// BankInfoId
        /// </summary>
        public int BankInfoId { get; set; }

        /// <summary>
        /// BankName
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// BankCode
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// LimitAmount
        /// </summary>
        public decimal? LimitAmount { get; set; }

        /// <summary>
        /// LimitNumber
        /// </summary>
        public int? LimitNumber { get; set; }

        /// <summary>
        /// IntervalTime
        /// </summary>
        public string IntervalTime { get; set; }

        /// <summary>
        /// IsUploadCredentials
        /// </summary>
        public bool IsUploadCredentials { get; set; }

        /// <summary>
        /// CanGetOrder
        /// </summary>
        public bool CanGetOrder { get; set; }

        /// <summary>
        /// OperateId
        /// </summary>
        public int? OperateId { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

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
        /// IsDeleted
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// CurrentRate
        /// </summary>
        public decimal? CurrentRate { get; set; }

        /// <summary>
        /// EnName
        /// </summary>
        public string EnName { get; set; }

        /// <summary>
        /// BankImg
        /// </summary>
        public string BankImg { get; set; }

        /// <summary>
        /// 活期利率
        /// </summary>
        public decimal? LiveRate { get; set; }

        /// <summary>
        /// ChinaPayMentCode
        /// </summary>
        public string ChinaPayMentCode { get; set; }

        /// <summary>
        /// ChinaPayMentLimitAmount
        /// </summary>
        public decimal? ChinaPayMentLimitAmount { get; set; }

        /// <summary>
        /// SourceType
        /// </summary>
        public int? SourceType { get; set; }

    }
}
