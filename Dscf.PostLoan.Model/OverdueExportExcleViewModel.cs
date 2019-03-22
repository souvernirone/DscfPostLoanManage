/*******************************************************
*类名称：逾期违约报表导出ViewModel
*版本号：V1.0.0.0
*作者：成俊杰
*CLR版本：4.0.30319.36264
*创建时间：2017/5/12 14:12:17
*说明：
*更新备注：
**********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.Model
{
    public class OverdueExportExcleViewModel
    {

        /// <summary>
        /// 操作员Id
        /// </summary>
        public int? OptId { get; set; }
        /// <summary>
        /// 1信 2车
        /// </summary>
        public int LoanOrderType { get; set; }

        public int? DeptId { get; set; }
        /// <summary>
        /// 新客户1 老客户 0 展期客户2
        /// </summary>
        public int? CustomerType { get; set; }
        /// <summary>
        /// 借款类型
        /// </summary>
        public int? LoanTypeId { get; set; }

        public DateTime? RepayDate { get; set; }

        /// <summary>
        /// 状态 已还款 1  还一部分2  逾期0
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 催收成功1  催收失败 0
        /// </summary>
        public int? CollectStatus { get; set; }

    }
}
