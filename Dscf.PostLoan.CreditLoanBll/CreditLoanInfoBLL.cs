using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService;
using Dscf.PostLoanGlobal;

namespace Dscf.PostLoan.CreditLoanBLL
{
    public class CreditLoanInfoBLL
    {
        /// <summary>
        /// 获取信贷信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public PagedList<DscfCreditLoanService.LoanInfoDto> GetPageLoanInfoList(Dscf.PostLoan.Model.LoanSearchViewModel LoanSearchViewModel)
        {
            DscfCreditLoanService.LoanSearchViewModel model = AutoMapper.Mapper.Map<DscfCreditLoanService.LoanSearchViewModel>(LoanSearchViewModel);
            using (CreditLoanContractClient client = new CreditLoanContractClient())
            {
                PagedList<DscfCreditLoanService.LoanInfoDto> dtoList = client.GetPageLoanInfoList(model);
                return dtoList;
            }
        }

        public PagedList<DscfCreditLoanService.LoanInfoDto> GetPageLoanInfoList(Dscf.Settlement.Model.LoanSearchViewModels LoanSearchViewModel)
        {
            DscfCreditLoanService.LoanSearchViewModel model = AutoMapper.Mapper.Map<DscfCreditLoanService.LoanSearchViewModel>(LoanSearchViewModel);
            using (CreditLoanContractClient client = new CreditLoanContractClient())
            {
                PagedList<DscfCreditLoanService.LoanInfoDto> dtoList = client.GetPageLoanInfoList(model);
                return dtoList;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedList<CreditRemindListDto> GetPageRepayRemindList(int pageNum, int pageSize, int optId)
        {
            using (CreditLoanContractClient client = new CreditLoanContractClient())
            {
                PagedList<DscfCreditLoanService.CreditRemindListDto> dtoList = client.GetPageRepayRemindList(pageNum, pageSize, optId);
                return dtoList;
            }
        }

        public bool UpdateCreditRemind(int repayId, bool isRemind)
        {

            using (CreditLoanContractClient client = new CreditLoanContractClient())
            {
                return client.UpdateCreditRemind(repayId, isRemind);
            }


        }

        public CreditRemidDetailDto GetCreditRemindDetail(int orderId, int repayId)
        {
            using (CreditLoanContractClient client = new CreditLoanContractClient())
            {
                return client.GetCreditRemindDetail(orderId, repayId);
            }
        }

        public PagedList<CreditOverdueListDto> GetPageOverdueList(int pageNum, int pageSize, int optId)
        {
            using (CreditLoanContractClient client = new CreditLoanContractClient())
            {
                return client.GetPageOverdueList(pageNum, pageSize, optId);
            }
        }

        public LoanOrderDetailDto GetLoanProductOrderDetail(int orderId)
        {
            using (CreditLoanContractClient client = new CreditLoanContractClient())
            {
                return client.GetLoanProductOrderDetail(orderId);
            }
        }

        /// <summary>
        /// 生成信用借款订单的债权信息
        /// </summary>
        /// <param name="orderDetail"></param>
        /// <returns></returns>
        public CreditClaimsInfoTotal GenerateCreditClaimsInfo(DscfCreditLoanService.LoanOrderDetailDto orderDetail)
        {
            IList<CreditClaimsInfo> claimsInfoList = new List<CreditClaimsInfo>();

            //逾期月还信息列表
            var overdueMonthRepayList = orderDetail.LoanMonthRepayList
                .Where(repay => DateTime.Compare(repay.RepayDate.Value, DateTime.Now.Date) < 0 && repay.IsDeductSucess != true).ToList();
            if (overdueMonthRepayList.Count <= 0)
            {
                return null;
            }
            foreach (var monthRepay in overdueMonthRepayList)
            {
                //每日罚息总额
                var dailyPenaltySumPerPeriod = monthRepay.DailyPenalty * DateUtil.GetDays(monthRepay.RepayDate.Value, DateTime.Now.Date);

                CreditClaimsInfo claims = new CreditClaimsInfo()
                {
                    RepayDate = monthRepay.RepayDate,
                    OverdueDayCount = DateUtil.GetDays(monthRepay.RepayDate.Value, DateTime.Now.Date),
                    MonthRepay = monthRepay.MonthRepay,
                    OverduePenalty = monthRepay.OverduePenalty,
                    DailyPenaltySumPerPeriod = dailyPenaltySumPerPeriod,
                    RemianOverduePenalty = monthRepay.OverduePenalty - (monthRepay.DeductOverduePenalty ?? 0),
                    RemianDailyPenalty = dailyPenaltySumPerPeriod - (monthRepay.DeductDailyPenalty ?? 0),
                    RemianMonthRepay = monthRepay.MonthRepay - (monthRepay.DeductMonthRepay ?? 0),
                    //OverduePrincipalPerPeriod = GetOverduePrincipalPerPeriod(monthRepay),
                    DeductAmountSumPerPeriod = (monthRepay.DeductOverduePenalty ?? 0) + (monthRepay.DeductDailyPenalty ?? 0) + (monthRepay.DeductMonthRepay ?? 0),


                };
                claimsInfoList.Add(claims);
            }

            var earlyClaims = claimsInfoList.OrderBy(claims => claims.RepayDate).FirstOrDefault();

            CreditClaimsInfoTotal totalClaims = new CreditClaimsInfoTotal()
            {
                FirstOverdueTime = earlyClaims.RepayDate,
                OverdueTimeCount = DateUtil.GetDays(earlyClaims.RepayDate.Value, DateTime.Now.Date),
                OverdueCount = claimsInfoList.Count(),
                OverduePrincipalSum = claimsInfoList.Sum(claims => claims.RemianMonthRepay),
                OverduePenaltySum = claimsInfoList.Sum(claims => claims.RemianOverduePenalty),
                DailyPenaltySum = claimsInfoList.Sum(claims => claims.RemianDailyPenalty),
                UserName = orderDetail.UserInfo.Name,
                SignCity = orderDetail.SignCity,
                CollectorName = orderDetail.CollectorName,
                OrderId = orderDetail.OrderId,
                ClaimsInfoList = claimsInfoList
            };
            return totalClaims;
        }
        /// <summary>
        /// 获取批量划扣的当月信息
        /// </summary>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        public PagedList<CreditCriticalAmountListDto> GetCriticalAmountList(int pageNum, int pageSize, int orderId = 0)
        {
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                return client.GetCriticalAmountList(pageNum, pageSize, orderId);
            }

        }

    }
}
