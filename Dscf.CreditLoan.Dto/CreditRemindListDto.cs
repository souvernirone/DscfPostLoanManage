using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    /// <summary>
    /// 还款提醒列表数据模型
    /// </summary>
    [DataContract]
    public class CreditRemindListDto
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
         public bool? IsRemind { get; set; }

        /// <summary>
        /// 创建操作员名字
        /// </summary>
        [DataMember]
        public string OptName { get; set; }

        /// <summary>
        /// 催收操作员
        /// </summary>
        [DataMember]
        public string CollectorName { get; set; }

        /// <summary>
        /// 创建操作员部门
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


    }
}
