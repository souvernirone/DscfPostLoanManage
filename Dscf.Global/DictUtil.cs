using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.Global
{
    public static class DictUtil
    {
        /// <summary>
        /// 催收类型
        /// </summary>
        public static string CollectionTypeKey
        {
            get { return "CollectionType"; }
        }

        /// <summary>
        /// 催收状态
        /// </summary>
        public static string CollectionStatusKey
        {
            get { return "CollectionStatus"; }
        }

        /// <summary>
        /// 信用借款联系人类型
        /// </summary>
        public static string CreditLinkPersonTypeKey
        {
            get { return "CreditLinkType"; }
        }

        /// <summary>
        /// 信用借款联系人类型
        /// </summary>
        public static string CarLinkPersonTypeKey
        {
            get { return "CarLinkType"; }
        }

        /// <summary>
        /// 学历
        /// </summary>
        public static string CarEducationKey
        {
            get { return "Education"; }
        }

        /// <summary>
        /// 婚姻状况
        /// </summary>
        public static string CarMaritalStatusKey
        {
            get { return "MaritalStatus"; }
        }

        /// <summary>
        /// 本市居住情况
        /// </summary>
        public static string CarResideTypeKey
        {
            get { return "ResideType"; }
        }


        public static string RemindTypeKey
        {
            get { return "RepayRemindType"; }
        }
        public static string CarLoanTypeKey
        {
            get { return "LoanType"; }
        }
        public static string DeductApprovalStatusKey
        {
            get { return "DeductApprovalStatus"; }
        }
        public static string OrderCollectStatusKey
        {
            get { return "OrderCollectStatus"; }
        }
        public static string DeductTypeKey
        {
            get { return "DeductWayType"; }
        }
        public static string CICCCodeKey
        {
            get { return "CICCCode"; }
        }
        public static string PaymentTypeKey
        {
            get { return "PaymentType"; }
        }
    }
}
