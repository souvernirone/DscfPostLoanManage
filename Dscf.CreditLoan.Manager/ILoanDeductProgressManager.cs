using Dscf.Common.Manager;
using Dscf.CreditLoan.Domain;
using Dscf.CreditLoan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Manager
{
    public interface ILoanDeductProgressManager : IGenericManager<LoanDeductProgress>
    {
        LoanDeductProgressDto[] GetDeductList(int orderId);
        Loan_DeductProgressDto[] GetDeductionFailedList(IList<int> statusList = null);
        /// <summary>
        /// 批量添加借款划扣情况表
        /// </summary>
        /// <param name="idAndPeriods"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        Boolean DeductinfoFailedAddAll(IList<string> idAndPeriods, int operatorId);

        /// <summary>
        /// 批量添加借款划扣情况表
        /// </summary>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        Boolean DeductinfoFailedAddAll(int operatorId);

        /// <summary>
        /// 添加借款划扣情况表单个
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="operatorId"></param>
        /// <param name="PlanDeductAmount"></param>
        /// <returns></returns>
        Boolean DeductinfoFailedAddOne(int orderId, int operatorId, LoanDeductProgressDto model);

        Boolean UpdateApplyIdByOrderId(int applyId, int orderId);
    }
}
