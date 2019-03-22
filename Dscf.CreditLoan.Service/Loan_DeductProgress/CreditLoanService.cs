using Dscf.CreditLoan.Contract;
using Dscf.CreditLoan.Domain;
using Dscf.CreditLoan.Dto;
using Dscf.CreditLoan.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Service
{
    public partial class CreditLoanService : ICreditLoanContract
    {
        public ILoanDeductProgressManager ILoanDeductProgressManager { get; set; }

        public Loan_DeductProgressDto[] GetDeductionFailedList(IList<int> statusList = null)
        {
            return ILoanDeductProgressManager.GetDeductionFailedList(statusList);
        }
        /// <summary>
        /// 批量添加借款划扣情况表
        /// </summary>
        /// <param name="idAndPeriods"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public Boolean DeductinfoFailedAddAll(IList<string> idAndPeriods, int operatorId)
        {
            return ILoanDeductProgressManager.DeductinfoFailedAddAll(idAndPeriods, operatorId);
        }

        /// <summary>
        /// 批量添加借款划扣情况表
        /// </summary>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public Boolean DeductinfoFailedAddAlls(int operatorId)
        {
            return ILoanDeductProgressManager.DeductinfoFailedAddAll(operatorId);
        }
        /// <summary>
        /// 添加借款划扣情况表单个
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="operatorId"></param>
        /// <param name="PlanDeductAmount"></param>
        /// <returns></returns>
        public Boolean DeductinfoFailedAddOne(int orderId, int operatorId, LoanDeductProgressDto model)
        {
            return ILoanDeductProgressManager.DeductinfoFailedAddOne(orderId, operatorId, model);
        }

        public Boolean UpdateApplyIdByOrderId(int applyId, int orderId)
        {
            return ILoanDeductProgressManager.UpdateApplyIdByOrderId(applyId, orderId);
        }
    }
}
