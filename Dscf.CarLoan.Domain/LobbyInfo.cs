using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain
{
    //大堂数据记录
    public class LobbyInfo
    {
        /// <summary>
        /// LobbyId
        /// </summary>
        public int LobbyId { get; set; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCard { get; set; }

        /// <summary>
        /// 车牌
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 大堂数据状态
        /// </summary>
        public int? StatusId { get; set; }

        /// <summary>
        /// 面审表外键
        /// </summary>
        public int? FaceTrialId { get; set; }

        /// <summary>
        /// 评估表外键
        /// </summary>
        public int? AssessId { get; set; }

        /// <summary>
        /// 面签表外键
        /// </summary>
        public int? SignedId { get; set; }

        /// <summary>
        /// 订单表外键
        /// </summary>
        public int? OrderId { get; set; }

        /// <summary>
        /// 新增/展期
        /// </summary>
        public int? LobbyTypeId { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 车辆信息ID
        /// </summary>
        public int? CarInfoId { get; set; }

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
        /// 签署地
        /// </summary>
        public string SignCity { get; set; }

        /// <summary>
        /// LoanExtensionId
        /// </summary>
        public int? LoanExtensionId { get; set; }

        /// <summary>
        /// DeptId
        /// </summary>
        public int? DeptId { get; set; }

        /// <summary>
        /// NewOrderId
        /// </summary>
        public int? NewOrderId { get; set; }

        /// <summary>
        /// 导航属性-面签信息
        /// </summary>
        public virtual SignedInfo SignedInfo { get; set; }

        /// <summary>
        /// 导航属性-面审记录
        /// </summary>
        public virtual FaceTrialInfo FaceTrialInfo { get; set; }

        /// <summary>
        /// 导航树型-车辆信息
        /// </summary>
        public virtual CarInfo CarInfo { get; set; }

    }
}
