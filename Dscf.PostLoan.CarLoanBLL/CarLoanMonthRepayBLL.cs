using Dscf.PostLoan.CarLoanBLL.DscfCarLoanService;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.PostLoan.CarLoanBLL.Extension;
using Dscf.Settlement.Model;

namespace Dscf.PostLoan.CarLoanBLL
{
    public class CarLoanMonthRepayBLL
    {
        /// <summary>
        /// 根据订单编号查询车贷订单的月还信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public CarLoanMonthRepayViewModel[] GetLoanMonthRepayInfoByOrderId(int orderId)
        {
            using (CarLoanContractClient client = new CarLoanContractClient())
            {
                LoanMonthRepayDto[] list = client.GetLoanMonthRepayInfoByOrderId(orderId);
                return list.Select(dto => dto.ToModel()).ToArray();
            }
        }
        public bool UpdateCarRemind(int repayId, int isRemind, int operatorId)
        {
            using (CarLoanContractClient client = new CarLoanContractClient())
            {
                return client.UpdateRepayRemindByRepayId(repayId, isRemind, operatorId);
            }
        }
        /// <summary>
        /// 修改月还
        /// </summary>
        /// <param name="deductModel"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public bool UpdateMonthRepay(DeductViewModel deductModel, int operatorId)
        {
            bool result = false;
            using (DscfCarLoanService.CarLoanContractClient client = new DscfCarLoanService.CarLoanContractClient())
            {
                CarDeductViewModelDto dto = AutoMapper.Mapper.Map<CarDeductViewModelDto>(deductModel);
                result = client.UpdateMonthRepayInfo(dto, operatorId);
            }
            return result;

        }
    }
}
