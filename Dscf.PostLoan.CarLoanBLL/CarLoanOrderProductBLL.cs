using Dscf.PostLoan.CarLoanBLL.DscfCarLoanService;
using Dscf.PostLoan.Model;
using Dscf.PostLoanGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.PostLoan.CarLoanBLL
{
    public class CarLoanOrderProductBLL
    {
        public List<CarLoanBatchDeductDto> GetCarLoanBatchDeductList()
        {
            using (CarLoanContractClient client = new CarLoanContractClient())
            {
                var pageData = client.GetCarLoanBatchDeductList();
                return pageData.ToList();
            }
        }
        /// <summary>
        /// 获取当月待划扣的月还信息
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedList<CarLoanBatchDeductDto> GetPageCarLoanBatchDeductList(int pageNum, int pageSize)
        {
            using (CarLoanContractClient client = new CarLoanContractClient())
            {
                var pageData = client.GetPageCarLoanBatchDeductList(pageNum, pageSize);
                return pageData;
            }
        }
        /// <summary>
        /// 借款订单列表分页
        /// </summary>
        /// <param name="loanViewModel"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedList<LoanProductOrderDto> SelectLoanProductOrderList(Dscf.PostLoan.Model.LoanSearchViewModel loanSViewModel)
        {
            using (CarLoanContractClient client = new CarLoanContractClient())
            {
                LoanSearchaRequest model = AutoMapper.Mapper.Map<LoanSearchaRequest>(loanSViewModel);
                var pageData = client.SelectLoanProductOrderList(model);
                return pageData;
            }
        }
        /// <summary>
        /// 借款订单列表分页
        /// </summary>
        /// <param name="loanViewModel"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedList<LoanProductOrderDto> SelectLoanProductOrderList(Dscf.Settlement.Model.LoanSearchViewModels loanSViewModel)
        {
            using (CarLoanContractClient client = new CarLoanContractClient())
            {
                LoanSearchaRequest model = AutoMapper.Mapper.Map<LoanSearchaRequest>(loanSViewModel);
                var pageData = client.SelectLoanProductOrderList(model);
                return pageData;
            }
        }

        /// <summary>
        /// 根据订单编号查询订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public CarLoanInfoDetailViewModel GetLoanProductOrderInfoByOrderId(int orderId)
        {
            using (CarLoanContractClient client = new CarLoanContractClient())
            {
                var model = client.GetLoanProductOrderInfoByOrderId(orderId);
                CarLoanInfoDetailViewModel lvModel = AutoMapper.Mapper.Map<LoanProductOrderDto, CarLoanInfoDetailViewModel>(model);
                return lvModel;
            }
        }
        public LoanProductExtensionOrderDto GetLoanProductExtensionOrderByOrderId(int orderId)
        {
            using (CarLoanContractClient client = new CarLoanContractClient())
            {
                var model = client.GetLoanProductExtensionOrderByOrderId(orderId);
                return model;
            }
        }

        /// <summary>
        /// 车贷还款提醒分页
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedList<CarRemindListDto> GetPageRepayRemindList(int pageNum, int pageSize, bool isLongLoan, int optId)
        {
            using (CarLoanContractClient client = new CarLoanContractClient())
            {
                PagedList<CarRemindListDto> dtoList = client.GetPageRepayRemindList(pageNum, pageSize, isLongLoan, optId);
                return dtoList;
            }
        }

        /// <summary>
        /// 修改车贷月还信息提醒状态
        /// </summary>
        /// <param name="repayId"></param>
        /// <param name="isRemind"></param>
        /// <returns></returns>
        public bool UpdateCarRemind(int repayId, int isRemind, int operatorId)
        {
            using (CarLoanContractClient client = new CarLoanContractClient())
            {
                return client.UpdateRepayRemindByRepayId(repayId, isRemind, operatorId);
            }
        }

        /// <summary>
        /// 查询车贷还款提醒的详细信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="repayId"></param>
        /// <returns></returns>
        public CarRemidDetailDto GetCarRemindDetail(int orderId, int repayId)
        {
            using (CarLoanContractClient client = new CarLoanContractClient())
            {
                return client.GetCarRemindDetail(orderId, repayId);
            }
        }

        /// <summary>
        /// 获取车贷逾期客户信息分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isLongLoan"></param>
        /// <returns></returns>
        public PagedList<CarOverdueListDto> GetPageCarOverdueList(int pageNum, int pageSize, bool isLongLoan, int optId)
        {
            using (CarLoanContractClient client = new CarLoanContractClient())
            {
                var list = client.GetPageOverdueList(pageNum, pageSize, isLongLoan, optId);
                foreach (var dto in list.CurrentPageItems)
                {
                    LoanMonthRepayDto loanM = client.GetLoanMonthRepayInfoByOrderId(Convert.ToInt32(dto.OrderId)).FirstOrDefault();
                    if (loanM != null) dto.RepayId = loanM.RepayId;
                    if (dto.IsCanExtension == true && (loanM.IsRemind == RemindType.LaunchExtension))
                    {
                        dto.IsCanExtension = false;
                    }
                }
                return list;
            }
        }

        /// <summary>
        /// 查询借款产品订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public CarLoanOrderDetailDto GetLoanProductOrderDetail(int orderId)
        {
            using (CarLoanContractClient client = new CarLoanContractClient())
            {
                return client.GetLoanProductOrderDetail(orderId);
            }
        }
        /// <summary>
        /// 修改订单催收人
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="deptOptId"></param>
        /// <returns></returns>
        public bool UpdateReminder(int orderId, int deptOptId)
        {
            using (CarLoanContractClient client = new CarLoanContractClient())
            {
                return client.EditLoanOrderReminderByOrderId(orderId, deptOptId);
            }
        }

        public CarClaimsInfoTotal GenerateCarClaimsInfo(Dscf.PostLoan.CarLoanBLL.DscfCarLoanService.CarLoanOrderDetailDto orderDetail)
        {
            IList<CarClaimsInfo> claimsInfoList = new List<CarClaimsInfo>();
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

                CarClaimsInfo claims = new CarClaimsInfo()
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

            CarClaimsInfoTotal totalClaims = new CarClaimsInfoTotal()
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
        public bool UpdateCollectStatus(int orderId, int collectStatus, int optId)
        {
            using (DscfCarLoanService.CarLoanContractClient client = new DscfCarLoanService.CarLoanContractClient())
            {
                return client.UpdateOrderCollectStatus(orderId, collectStatus, optId);
            }
        }
        public bool UpdateCollectStatusBatch(int[] orderIds, int collectStatus, int optId)
        {
            using (DscfCarLoanService.CarLoanContractClient client = new DscfCarLoanService.CarLoanContractClient())
            {
                return client.UpdateOrderCollectStatusBatch(orderIds, collectStatus, optId);
            }
        }
        public DscfCarLoanService.CarCountDto GetIsRemindCount(bool isLongLoan, int optId)
        {
            using (DscfCarLoanService.CarLoanContractClient client = new DscfCarLoanService.CarLoanContractClient())
            {
                return client.GetIsRemindCount(isLongLoan, optId);
            }
        }

    }
}
