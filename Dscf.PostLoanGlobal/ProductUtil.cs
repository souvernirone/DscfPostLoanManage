using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoanGlobal
{
    public static class ProductUtil
    {
        /// <summary>
        /// 理财
        /// </summary>
        public static int CreditType
        {
            get
            {
                return 1;
            }
        }
        /// <summary>
        /// 借贷
        /// </summary>
        public static int FinancialType
        {
            get
            {
                return 2;
            }
        }
    }
}
