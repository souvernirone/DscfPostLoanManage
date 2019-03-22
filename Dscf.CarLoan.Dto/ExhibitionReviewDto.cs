/*******************************************************
*类名称：LoanReviewDto
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/7 14:10:26
*说明：
*更新备注：
**********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    [DataContract]
    public class ExhibitionReviewDto
    {
        /// <summary>
        /// Id
        /// </summary>
        [DataMember]
        public int Id { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public int? StatusId { get; set; }

        /// <summary>
        /// 展期复议意见
        /// </summary>
        [DataMember]
        public string Memo { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [DataMember]
        public int? LoanOrderId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// 车贷展期id
        /// </summary>
        [DataMember]
        public int? CarExtensionId { get; set; }

        /// <summary>
        /// IsEnable
        /// </summary>
        [DataMember]
        public int? IsEnable { get; set; }

        /// <summary>
        /// IsDelete
        /// </summary>
        [DataMember]
        public int? IsDelete { get; set; }

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
        /// OperateId
        /// </summary>
        [DataMember]
        public int? OperateId { get; set; }

        /// <summary>
        /// LastOperateId
        /// </summary>
        [DataMember]
        public int? LastOperateId { get; set; }
    }
}
