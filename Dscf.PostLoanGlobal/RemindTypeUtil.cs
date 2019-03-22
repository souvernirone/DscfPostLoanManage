using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoanGlobal
{
    /// <summary>
    /// 提醒类型
    /// </summary>
    public static class RemindType
    {
        /// <summary>
        /// 发起展期
        /// </summary>
        public static int LaunchExtension
        {
            get { return 2; }
        }
        public static int AlreadyRemind
        {
            get { return 1; }
        }
        public static int GiveUpExtension
        {
            get { return 3; }
        }


    }
}
