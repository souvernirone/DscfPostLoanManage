/*******************************************************
*类名称：CarClaimsInfoTotal
*版本号：V1.0.0.0
*作者：左涛瑞
*CLR版本：4.0.30319.36264
*创建时间：2017/4/12 15:34:07
*说明：
*更新备注：
**********************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.Model
{
    public class CarClaimsInfoTotal
    {
        /// <summary>
        /// 借款订单ID
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 借款客户姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 催收操作员
        /// </summary>
        public string CollectorName { get; set; }

        /// <summary>
        /// 签约城市
        /// </summary>
        public string SignCity { get; set; }

        /// <summary>
        /// 首逾日期
        /// </summary>
        public DateTime? FirstOverdueTime { get; set; }

        /// <summary>
        /// 累计逾期天数
        /// </summary>
        public int? OverdueTimeCount { get; set; }

        /// <summary>
        /// 逾期次数
        /// </summary>
        public int? OverdueCount { get; set; }

        /// <summary>
        /// 累计逾期本金
        /// </summary>
        public decimal? OverduePrincipalSum { get; set; }

        /// <summary>
        /// 累计违约金
        /// </summary>
        public decimal? OverduePenaltySum { get; set; }

        /// <summary>
        /// 累计每天罚息
        /// </summary>
        public decimal? DailyPenaltySum { get; set; }

        /// <summary>
        /// 每期债权列表
        /// </summary>
        public IList<CarClaimsInfo> ClaimsInfoList { get; set; }
    }
}
