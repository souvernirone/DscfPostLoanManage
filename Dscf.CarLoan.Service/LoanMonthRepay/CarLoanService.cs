using Dscf.CarLoan.Contract;
using Dscf.CarLoan.Domain;
using Dscf.CarLoan.Dto;
using Dscf.CarLoan.Manager;
using Dscf.PostLoanGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Service
{
    public partial class CarLoanService : ICarLoanContract
    {
        public ILoanMonthRepayManager LoanMonthRepayManager { get; set; }

        /// <summary>
        /// 根据订单编号查询车贷订单的月还信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public LoanMonthRepayDto[] GetLoanMonthRepayInfoByOrderId(int orderId)
        {
            return LoanMonthRepayManager.GetLoanMonthRepayInfoByOrderId(orderId);
        }
        /// <summary>
        /// 修改车贷月还信息提醒状态
        /// </summary>
        /// <param name="repayId"></param>
        /// <param name="isRemind"></param>
        /// <returns></returns>
        public bool UpdateRepayRemindByRepayId(int repayId, int isRemind, int operatorId)
        {
            return LoanMonthRepayManager.UpdateRepayRemindByRepayId(repayId, isRemind, operatorId);
        }
        public bool UpdateMonthRepayInfo(CarDeductViewModelDto dto, int operatorId)
        {
            return LoanMonthRepayManager.UpdateMonthRepayInfo(dto, operatorId);
        }
    }
}
