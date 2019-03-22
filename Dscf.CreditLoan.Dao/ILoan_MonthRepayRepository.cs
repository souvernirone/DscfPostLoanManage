using Dscf.Common.Dao;
using Dscf.CreditLoan.Domain;
using Dscf.CreditLoan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dao
{
    //T_Loan_MonthRepay
    public interface ILoan_MonthRepayRepository : IRepository<Loan_MonthRepay>
    {
        /// <summary>
        /// 获取信贷逾期月还信息（根据订单编号）
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Loan_MonthRepayInfoDto[] GetOverdueMonthListByOrderId(int orderId);
    }
}
