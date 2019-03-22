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
    public interface ILoan_MonthRepayManager : IGenericManager<Loan_MonthRepay>
    {

        /// <summary>
        /// 根据订单ID获取月还信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Loan_MonthRepayInfoDto[] GetLoan_MonthRepayInfoByorderID(int orderId);
        bool UpdateCreditRemindByRepayId(int repayId, bool isRemind);
        Loan_MonthRepayInfoDto[] GetLoan_MonthRepayInfoByorderID();
        /// <summary>
        /// 获取月还信息详情
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="periodOrder">月还编号</param>
        /// <returns></returns>
        Loan_MonthRepayInfoDto GetLoan_MonthRepayInfoByorderIDPeriodOrder(int orderId, int periodOrder);

        /// <summary>
        /// 获取信贷逾期月还信息（根据订单编号）
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Loan_MonthRepayInfoDto[] GetOverdueMonthListByOrderId(int orderId);

        /// <summary>
        /// 更新月还信息（根据订单编号）
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        int UpdateMonthRepayInfo(CreditDeductViewDto model, int type, int isSuccess);


    }
}
