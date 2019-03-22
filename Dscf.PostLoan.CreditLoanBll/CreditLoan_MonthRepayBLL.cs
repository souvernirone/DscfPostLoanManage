using Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.Settlement.Model;

namespace Dscf.PostLoan.CreditLoanBLL
{
    public class CreditLoan_MonthRepayBLL
    {
        /// <summary>
        /// 根据订单Id获取月还信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Loan_MonthRepayViewModel[] GetLoan_MonthRepayInfoByorderID(int orderId)
        {
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                DscfCreditLoanService.Loan_MonthRepayInfoDto[] loanmonthList = client.GetLoan_MonthRepayInfoByorderID(orderId);
                return loanmonthList.Select(dto => dto.ToModel()).ToArray();
            }
        }
        public bool UpdateCreditRemind(int repayId, bool isRemind)
        {
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                return client.UpdateCreditRemind(repayId, isRemind);
            }
        }
        /// <summary>
        /// 获取月还信息详情
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="periodOrder">月还编号</param>
        /// <returns></returns>
        public Loan_MonthRepayViewModel GetLoan_MonthRepayInfoByorderIDPeriodOrder(int orderId, int periodOrder)
        {
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                DscfCreditLoanService.Loan_MonthRepayInfoDto loanmonthModel = client.GetLoan_MonthRepayInfoByorderIDPeriodOrder(orderId, periodOrder);
                return loanmonthModel.ToModel();
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
            int result = 0;
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                //如果失败原因为空，则为划扣成功
                if (string.IsNullOrEmpty(deductModel.Reason))
                {
                    //如果不是逾期客户月还
                    if (!string.IsNullOrEmpty(deductModel.RepayId.ToString()) && !string.IsNullOrEmpty(deductModel.PeriodOrder.ToString()))
                    {
                        //更新月还表信息（//type等于0 不为逾期月还处理）
                        result = UpdateMonthRepayModel(deductModel, 0, 1);
                    }
                    else
                    {
                        //更新月还表信息（//type等于1 为逾期月还处理）
                        result = UpdateMonthRepayModel(deductModel, 1, 1);
                        //更新订单表催收状态信息，等待催收
                        result = client.UpdateOrderCollectStatus(deductModel.OrderId, -1, operatorId) == true ? 1 : 0;
                    }
                }
                else
                {
                    //更新月还表信息
                    result = UpdateMonthRepayModel(deductModel, 1, 0);

                    //如果是逾期客户月还
                    if (string.IsNullOrEmpty(deductModel.RepayId.ToString()) && string.IsNullOrEmpty(deductModel.PeriodOrder.ToString()))
                    {
                        //更新订单表催收状态信息，划扣失败
                        result = client.UpdateOrderCollectStatus(deductModel.OrderId, 4, operatorId) == true ? 1 : 0;
                    }
                }
            }

            return result > 0 ? true : false;
        }


        /// <summary>
        /// 修改月还
        /// </summary>
        /// <param name="deductModel"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public int UpdateMonthRepayModel(DeductViewModel deductModel, int type, int isSuccess)
        {
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                CreditDeductViewDto dto = AutoMapper.Mapper.Map<CreditDeductViewDto>(deductModel);

                //更新月还表信息
                return client.UpdateMonthRepayInfo(dto, type, isSuccess);
            }
        }
    }
}
