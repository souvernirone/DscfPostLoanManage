using Dscf.Common.Dao.Context;
using Dscf.Common.Dao.Implement;
using Dscf.CreditLoan.Domain;
using Dscf.CreditLoan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Dao.Implement
{
    public class Loan_MonthRepayRepository : RepositoryBase<Loan_MonthRepay>, ILoan_MonthRepayRepository
    {
        /// <summary>
        /// 获取信贷逾期月还信息（根据订单编号）
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Loan_MonthRepayInfoDto[] GetOverdueMonthListByOrderId(int orderId)
        {
            string SQL = @" SELECT ROW_NUMBER() OVER ( PARTITION BY 1 ORDER BY a.RepayId) AS row_n, a.RepayId,a.LoanOrderId,a.PeriodOrder,a.ContractAmount,a.TotalServiceFee,a.MonthRepay,
              a.MonthInterest,a.OverduePenalty,a.DailyPenalty,a.RepayDate,a.ActualDeductAmount,a.DebtOptId,
              DATEDIFF(day,a.repaydate,GETDATE())as MonthDay,u.Phone,u.Name,u.IDCard,a.IsDeductSucess,
              a.DeductMonthRepay,a.DeductOverduePenalty,a.DeductDailyPenalty 
              from T_Loan_MonthRepay as a 
              left join T_LoanProductOrder as o on a.LOANORDERID=o.ORDERID 
              inner join T_UserInfo as u on o.USERID=u.USERID 
              where (a.IsDeductSucess=0 or a.IsDeductSucess is null ) and DATEDIFF(day,a.repaydate,GETDATE()) >0 ";

            SQL += string.Format("and a.LoanOrderId ={0}", orderId);


            var unitOfWorkContex = this.EFContext as UnitOfWorkContextBase;
            var list = unitOfWorkContex.Context.Database.SqlQuery<Loan_MonthRepayInfoDto>(SQL).ToArray();
            return list;
        }
    }
}
