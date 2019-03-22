using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Domain
{
    public class Product
    {
        /// <summary>
        /// 产品ID
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 产品类型【1为理财，2为贷款】
        /// </summary>
        public int? Type { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? OrderNo { get; set; }

        /// <summary>
        /// 预计年华收益
        /// </summary>
        public decimal? YearRebate { get; set; }

        /// <summary>
        /// 封闭期
        /// </summary>
        public int? ClosePeriod { get; set; }

        /// <summary>
        /// 理财模式
        /// </summary>
        public int? FinancialMode { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int? IsDeleted { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public int? IsEnable { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public int? OperateId { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public int? LastOperateId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// 折后率
        /// </summary>
        public string AfterPercent { get; set; }

        /// <summary>
        /// 产品简介
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 产品图标
        /// </summary>
        public string ProductIcon { get; set; }

        /// <summary>
        /// 产品详情页
        /// </summary>
        public string DetialContent { get; set; } 

        /// <summary>
        /// 导航属性-认证文件列表
        /// </summary>
        //public virtual IList<Authention> AuthentionList { get; set; }
    }
}
