/*******************************************************
*类名称：展期复议请求ViewModel
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/7 13:44:17
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
    /// <summary>
    /// 
    /// </summary>
    public class ExhibitionViewModel
    {
        /// <summary>
        /// 借款订单KEY
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 借款客户KEY
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// T_Lobby.LoanExtensionId
        /// </summary>
        public int? LobbyLoanExtensionId  { get; set; }

        /// <summary>
        /// 大堂KEY
        /// </summary>
        public int LobbyId { get; set; }

        /// <summary>
        /// 展期复议意见
        /// </summary>
        public string StoreOption { get; set; }
    }
}
