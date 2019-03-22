/*******************************************************
*类名称：ExhibitionReview
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/7 10:44:41
*说明：
*更新备注：
**********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain
{
    public class ExhibitionReview
    {

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int? StatusId { get; set; }

        /// <summary>
        /// 展期复议意见
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public int? LoanOrderId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 车贷展期id
        /// </summary>
        public int? CarExtensionId { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        public int? IsEnable { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        public int? IsDelete { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// OperateId
        /// </summary>
        public int? OperateId { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        public int? LastOperateId { get; set; }


    }
}
