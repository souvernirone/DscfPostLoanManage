using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoanGlobal
{
    /// <summary>
    /// 日期时间工具类
    /// </summary>
    public class DateUtil
    {
        /// <summary>
        /// 计算开始日期到结束日期之间的天数
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static  int GetDays(DateTime begin, DateTime end)
        {
            TimeSpan starTimeSpan = new TimeSpan(begin.Ticks);
            TimeSpan endTimeSpan = new TimeSpan(end.Ticks);
            int count = endTimeSpan.Days - starTimeSpan.Days;
            return count;
        }
    }
}
