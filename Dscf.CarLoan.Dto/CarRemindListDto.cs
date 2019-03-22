using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dto
{
    /// <summary>
    /// 还款提醒
    /// </summary>
    [DataContract]
    public class CarRemindListDto
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int? OrderId { get; set; }

        [DataMember]
        /// <summary>
        /// 月还表主键
        /// </summary>
        public int? RepayId { get; set; }

        /// <summary>
        /// 是否已提醒
        /// </summary>
        [DataMember]
        public int? IsRemind { get; set; }

        /// <summary>
        /// 提醒文本
        /// </summary>
        [DataMember]
        public string RemindText { get; set; }

        /// <summary>
        /// 提醒时间
        /// </summary>
        [DataMember]
        public DateTime? RemindDate { get; set; }

        /// <summary>
        /// 车辆借款订单创建人Name
        /// </summary>
        [DataMember]
        public string OptName { get; set; }

        /// <summary>
        /// 车辆借款订单创建人ID
        /// </summary>
        [DataMember]
        public int? OperateId { get; set; }

        /// <summary>
        /// 催收操作员
        /// </summary>
        [DataMember]
        public string CollectorName { get; set; }

        /// <summary>
        /// 车辆借款订单创建人DeptID
        /// </summary>
        [DataMember]
        public int? OptDeptId { get; set; }

        /// <summary>
        /// 签约城市
        /// </summary>
        [DataMember]
        public string SignCity { get; set; }

        /// <summary>
        /// 客户姓名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [DataMember]
        public string UserPhone { get; set; }

        /// <summary>
        /// 产品类型
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// 合同金额
        /// </summary>
        [DataMember]
        public decimal? Amount { get; set; }

        /// <summary>
        /// 月还金额
        /// </summary>
        [DataMember]
        public decimal? MonthRepay { get; set; }

        /// <summary>
        /// 新增字段2017-3-27 是否可展期
        /// </summary>
        [DataMember]
        public bool? IsCanExtension { get; set; }

        /// <summary>
        /// 新增字段2017-4-5 是否允许展期
        /// </summary>
        [DataMember]
        public int? IsAllowExtension { get; set; }
        
        /// <summary>
        /// 新增字段2017-4-5 是否展期并有提醒是否状况
        /// </summary>
        [DataMember]
        public int? IsAllowRemain { get; set; }

    }
}
