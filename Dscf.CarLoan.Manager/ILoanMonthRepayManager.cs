using Dscf.CarLoan.Domain;
using Dscf.CarLoan.Dto;
using Dscf.Common.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Manager
{
    //借款月还款表
    public interface ILoanMonthRepayManager : IGenericManager<LoanMonthRepay>
    {
        /// <summary>
        /// 根据订单编号查询车贷订单的月还信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        LoanMonthRepayDto[] GetLoanMonthRepayInfoByOrderId(int orderId);

        /// <summary>
        /// 根据订单编号查询车贷订单的月还信息
        /// </summary>
        /// <returns></returns>
        LoanMonthRepayDto[] GetLoanMonthRepayInfoByOrderId();
        /// <summary>
        /// 修改车贷月还信息提醒状态
        /// </summary>
        /// <param name="repayId"></param>
        /// <param name="isRemind"></param>
        /// <returns></returns>
        bool UpdateRepayRemindByRepayId(int repayId, int isRemind, int operatorId);

        bool UpdateMonthRepayInfo(CarDeductViewModelDto dto, int operatorId);
    }
}
