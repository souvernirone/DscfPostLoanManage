using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dto
{
    [DataContract]
    public class ProductDto
    {

        /// <summary>
        /// 产品ID
        /// </summary>
        [DataMember]
        public int ProductId { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [DataMember]
        public string ProductName { get; set; }

        /// <summary>
        /// 产品类型【1为理财，2为贷款】
        /// </summary>
        [DataMember]
        public int? Type { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        public int? OrderNo { get; set; }

        /// <summary>
        /// 预计年华收益
        /// </summary>
        [DataMember]
        public decimal? YearRebate { get; set; }

        /// <summary>
        /// 封闭期
        /// </summary>
        [DataMember]
        public int? ClosePeriod { get; set; }

        /// <summary>
        /// 理财模式
        /// </summary>
        [DataMember]
        public int? FinancialMode { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        [DataMember]
        public string ProductCode { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [DataMember]
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        [DataMember]
        public int? IsEnable { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [DataMember]
        public int? OperateId { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        [DataMember]
        public int? LastOperateId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DataMember]
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// 折后率
        /// </summary>
        [DataMember]
        public string AfterPercent { get; set; }

        /// <summary>
        /// 产品简介
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 产品图标
        /// </summary>
        [DataMember]
        public string ProductIcon { get; set; }

        /// <summary>
        /// 产品详情页
        /// </summary>
        [DataMember]
        public string DetialContent { get; set; }

        /// <summary>
        /// 导航属性-认证文件列表
        /// </summary>
        //public virtual IList<Authention> AuthentionList { get; set; }

    }

}
