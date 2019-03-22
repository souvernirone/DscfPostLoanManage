using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    //大堂数据记录
    [DataContract]
    public class LobbyInfoDto
    {
        /// <summary>
        /// LobbyId
        /// </summary>
        [DataMember]
        public int LobbyId { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        [DataMember]
        public string IdCard { get; set; }

        /// <summary>
        /// 车牌
        /// </summary>
        [DataMember]
        public string LicensePlate { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 大堂数据状态
        /// </summary>
        [DataMember]
        public int? StatusId { get; set; }

        /// <summary>
        /// 面审表外键
        /// </summary>
        [DataMember]
        public int? FaceTrialId { get; set; }

        /// <summary>
        /// 评估表外键
        /// </summary>
        [DataMember]
        public int? AssessId { get; set; }

        /// <summary>
        /// 面签表外键
        /// </summary>
        [DataMember]
        public int? SignedId { get; set; }

        /// <summary>
        /// 订单表外键
        /// </summary>
        [DataMember]
        public int? OrderId { get; set; }

        /// <summary>
        /// 新增/展期
        /// </summary>
        [DataMember]
        public int? LobbyTypeId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        [DataMember]
        public int? UserId { get; set; }

        /// <summary>
        /// 车辆信息ID
        /// </summary>
        [DataMember]
        public int? CarInfoId { get; set; }

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
        /// 签署地
        /// </summary>
        [DataMember]
        public string SignCity { get; set; }

        /// <summary>
        /// LoanExtensionId
        /// </summary>
        [DataMember]
        public int? LoanExtensionId { get; set; }

        /// <summary>
        /// DeptId
        /// </summary>
        [DataMember]
        public int? DeptId { get; set; }

        /// <summary>
        /// NewOrderId
        /// </summary>
        [DataMember]
        public int? NewOrderId { get; set; }

        /// <summary>
        /// 导航属性-面签信息
        /// </summary>
        [DataMember]
        public virtual SignedInfoDto SignedInfo { get; set; }

        /// <summary>
        /// 导航属性-面审记录
        /// </summary>
        [DataMember]
        public virtual FaceTrialInfoDto FaceTrialInfo { get; set; }

        /// <summary>
        /// 导航树型-车辆信息
        /// </summary>
        [DataMember]
        public virtual CarInfoDto CarInfo { get; set; }

    }
}
