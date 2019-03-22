using Dscf.CreditLoan.Contract;
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
        public ILoan_MonthRepayManager Loan_MonthRepayManager { get; set; }

        /// <summary>
        /// 根据订单ID获取月还信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Loan_MonthRepayInfoDto[] GetLoan_MonthRepayInfoByorderID(int orderId)
        {
            return Loan_MonthRepayManager.GetLoan_MonthRepayInfoByorderID(orderId);
        }
        public bool UpdateCreditRemind(int repayId, bool isRemind)
        {
            return Loan_MonthRepayManager.UpdateCreditRemindByRepayId(repayId, isRemind);
        }
        /// <summary>
        /// 获取月还信息详情
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="periodOrder">月还编号</param>
        /// <returns></returns>
        public Loan_MonthRepayInfoDto GetLoan_MonthRepayInfoByorderIDPeriodOrder(int orderId, int periodOrder)
        {
            return Loan_MonthRepayManager.GetLoan_MonthRepayInfoByorderIDPeriodOrder(orderId, periodOrder);
        }

        /// <summary>
        /// 获取信贷逾期月还信息（根据订单编号）
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Loan_MonthRepayInfoDto[] GetOverdueMonthListByOrderId(int orderId)
        {
            return Loan_MonthRepayManager.GetOverdueMonthListByOrderId(orderId);
        }

        /// <summary>
        /// 更新月还信息（根据订单编号）
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public int UpdateMonthRepayInfo(CreditDeductViewDto model, int type, int isSuccess)
        {
            return Loan_MonthRepayManager.UpdateMonthRepayInfo(model, type, isSuccess);
        }
    }
}
