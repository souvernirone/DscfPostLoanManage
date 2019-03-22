using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Domain
{
    //面审记录
    public class FaceTrialInfo
    {
        /// <summary>
        /// FaceTrailId
        /// </summary>
        public int FaceTrailId { get; set; }

        /// <summary>
        /// 用户信息ID
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// 借款用途
        /// </summary>
        public string Purpose { get; set; }

        /// <summary>
        /// 申请贷款金额
        /// </summary>
        public decimal? ApplyAmount { get; set; }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        public int? ProductTypeId { get; set; }

        /// <summary>
        /// StatusId
        /// </summary>
        public int? StatusId { get; set; }

        /// <summary>
        /// 团队编号
        /// </summary>
        public string GroupNumber { get; set; }

        /// <summary>
        /// 团队经理
        /// </summary>
        public string GroupManager { get; set; }

        /// <summary>
        /// 团队经理电话
        /// </summary>
        public string GroupManagerPhone { get; set; }

        /// <summary>
        /// 客户经理
        /// </summary>
        public string CustomerManager { get; set; }

        /// <summary>
        /// 门店面审意见
        /// </summary>
        public string FaceTrialMemo { get; set; }

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
        /// 导航属性-车贷利息配置
        /// </summary>
        public virtual CarLoanConfig CarLoanConfig { get; set; }
    }
}
