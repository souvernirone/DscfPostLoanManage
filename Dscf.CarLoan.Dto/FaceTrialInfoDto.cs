using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    //面审记录
    [DataContract]
    public class FaceTrialInfoDto
    {
        /// <summary>
        /// FaceTrailId
        /// </summary>
        [DataMember]
        public int FaceTrailId { get; set; }

        /// <summary>
        /// 用户信息ID
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// 借款用途
        /// </summary>
        [DataMember]
        public string Purpose { get; set; }

        /// <summary>
        /// 申请贷款金额
        /// </summary>
        [DataMember]
        public decimal? ApplyAmount { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        [DataMember]
        public string LicensePlate { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        [DataMember]
        public int? ProductTypeId { get; set; }

        /// <summary>
        /// StatusId
        /// </summary>
        [DataMember]
        public int? StatusId { get; set; }

        /// <summary>
        /// 团队编号
        /// </summary>
        [DataMember]
        public string GroupNumber { get; set; }

        /// <summary>
        /// 团队经理
        /// </summary>
        [DataMember]
        public string GroupManager { get; set; }

        /// <summary>
        /// 团队经理电话
        /// </summary>
        [DataMember]
        public string GroupManagerPhone { get; set; }

        /// <summary>
        /// 客户经理
        /// </summary>
        [DataMember]
        public string CustomerManager { get; set; }

        /// <summary>
        /// 门店面审意见
        /// </summary>
        [DataMember]
        public string FaceTrialMemo { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        [DataMember]
        public DateTime? CreateTime { get; set; }

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

        /// <summary>
        /// LastUpdateTime
        /// </summary>
        [DataMember]
        public DateTime? LastUpdateTime { get; set; }

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
        /// 导航属性-车贷利息配置
        /// </summary>
        [DataMember]
        public virtual CarLoanConfigDto CarLoanConfig { get; set; }
    }
}
