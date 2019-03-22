using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoanGlobal
{
    public static class DeductPayUtil
    {
        /// <summary>
        /// 划扣申请状态
        /// </summary>
        public static int ApprovalPending
        {
            get { return -1; }
        }
        public static int NotApproved
        {
            get { return 0; }
        }
        public static int Approved
        {
            get { return 1; }
        }
        public static int DeductPending
        {
            get { return 2; }
        }
        public static int SuccessfulDebit
        {
            get { return 3; }
        }
        public static int FailedDebit
        {
            get { return 4; }
        }

        public static int RejectDebit
        {
            get { return 5; }
        }

        /// <summary>
        /// 划扣方式
        /// </summary>
        public static int DeductApply
        {
            get { return 1; }
        }
        public static int PayOffline
        {
            get { return 2; }
        }
        public static int CarDisposal
        {
            get { return 3; }
        }
        /// <summary>
        /// 订单催收状态
        /// </summary>
        public static int OrderCollectPendingApproved
        {
            get { return -1; }
        }
        public static int OrderCollectNotApproved
        {
            get { return 0; }
        }
        public static int OrderCollectApproved
        {
            get { return 1; }
        }
        public static int OrderCollectSubmitApproved
        {
            get { return 2; }
        }
        public static int OrderCollectDeductPending
        {
            get { return 3; }
        }
        public static int OrderCollectFailedDebit
        {
            get { return 4; }
        }
        public static int OrderCollectRejectDebit
        {
            get { return 5; }
        }

        /// <summary>
        /// 划款方式
        /// </summary>
        public static int HandDeduct
        {
            get { return 1; }
        }
        public static int BatchDeduct
        {
            get { return 2; }
        }

    }
}
