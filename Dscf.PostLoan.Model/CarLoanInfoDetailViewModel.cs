using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.Model
{
    public class CarLoanInfoDetailViewModel
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 签署地
        /// </summary>
        public string SignCity { get; set; }


        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IDCard { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        public string Contract { get; set; }

        /// <summary>
        /// 合同金额
        /// </summary>
        public decimal? Amount { get; set; }

        /// <summary>
        /// 签约日期
        /// </summary>
        public DateTime? SignDate { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 银行卡信息
        /// </summary>
        public string BankCard { get; set; }

        /// <summary>
        /// 银行支行名称
        /// </summary>
        public string SubBranchName { get; set; }


        public int? LobbyLoanExtensionId { get; set; }

        /// <summary>
        /// 大堂KEY
        /// </summary>
        public int? LobbyId { get; set; }

        /// <summary>
        /// 借款客户KEY
        /// </summary>
        public int? UserId { get; set; }
    }
}
