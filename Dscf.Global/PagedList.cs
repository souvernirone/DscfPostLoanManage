using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Global
{
    /// <summary>
    /// 分页数据结果
    /// </summary>
    [DataContract(Name = "Paged{0}List")]
    public class PagedList<T>
    {
        #region 构造函数

        public PagedList()
        {
            this.CurrentPageItems = new List<T>();
        }
        public PagedList(IEnumerable<T> currentPageItems, int pageIndex, int totalItemCount)
        {
            this.CurrentPageItems = currentPageItems;
            this.TotalItemCount = totalItemCount;
            this.CurrentPageIndex = pageIndex;

        }
        #endregion

        /// <summary>
        /// 当前页
        /// </summary>
        [DataMember]
        public int CurrentPageIndex { get; set; }

        /// <summary>
        /// 记录总条数
        /// </summary>
        [DataMember]
        public int TotalItemCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        [DataMember]
        public int TotalPageCount { get; set; }

        /// <summary>
        /// 结果集
        /// </summary>
        [DataMember]
        public IEnumerable<T> CurrentPageItems { get; set; }

    }
}
