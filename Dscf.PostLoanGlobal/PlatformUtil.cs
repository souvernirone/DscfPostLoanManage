using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoanGlobal
{
    /// <summary>
    /// 平台工具类
    /// </summary>
    public static class PlatformUtil
    {
        /// <summary>
        /// 认证中心
        /// </summary>
        public static int AuthCenterPlat
        {
            get { return 15; }
        }


        /// <summary>
        /// 贷后系统
        /// </summary>
        public static int PostLoanPlat
        {
            get { return 26; }
        }

        /// <summary>
        /// 结算平台
        /// </summary>
        public static int SettleMentPlat
        {
            get { return 28; }
        }

    }
}
