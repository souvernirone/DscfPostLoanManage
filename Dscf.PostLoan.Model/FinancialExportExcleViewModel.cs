/*******************************************************
*类名称：财务报表导出ViewModel
*版本号：V1.0.0.0
*作者：成俊杰
*CLR版本：4.0.30319.36264
*创建时间：2017/5/12 11:24:17
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
    public class FinancialExportExcleViewModel
    {
        /// <summary>
        /// 借款类型
        /// </summary>
        public int? ProductType { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public int? CityName { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public int? ProductName { get; set; }

        /// <summary>
        /// 合同签署开始日期
        /// </summary>
        public DateTime? ContractDataBegin { get; set; }

        /// <summary>
        /// 合同签署结束日期
        /// </summary>
        public DateTime? ContractDataEnd { get; set; }

        /// <summary>
        /// 放款时间开始
        /// </summary>
        public DateTime? LoansDataBegin { get; set; }

        /// <summary>
        /// 放款时间结束
        /// </summary>
        public DateTime? LoansDataEnd { get; set; }

        /// <summary>
        /// 所属团队
        /// </summary>
        public int? TeamName { get; set; }
    }
}
