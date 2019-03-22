using Dscf.CarLoan.Dao;
using Dscf.CarLoan.Domain;
using Dscf.CarLoan.Dto;
using Dscf.Common.Manager.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.CarLoan.Dto.Extension;
using Dscf.PostLoanGlobal;

namespace Dscf.CarLoan.Manager.Implement
{
    //借款月还款表
    public class LoanMonthRepayManager : GenericManagerBase<LoanMonthRepay>, ILoanMonthRepayManager
    {
        public ILoanMonthRepayRepository LoanMonthRepayRepository { get; set; }

        public LoanMonthRepayManager(ILoanMonthRepayRepository repository)
        {
            this.CurrentRepository = repository;
        }
        /// <summary>
        /// 根据订单编号查询车贷订单的月还信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public LoanMonthRepayDto[] GetLoanMonthRepayInfoByOrderId(int orderId)
        {
            if (this.CurrentRepository is ILoanMonthRepayRepository)
            {
                IList<LoanMonthRepay> repayList = this.CurrentRepository.Entities.Where(repay => repay.LoanOrderId == orderId).ToList();
                return repayList.Select(repay => repay.ToModel()).ToArray();
            }
            return null;
        }

        /// <summary>
        /// 根据订单编号查询车贷订单的月还信息
        /// </summary>
        /// <returns></returns>
        public LoanMonthRepayDto[] GetLoanMonthRepayInfoByOrderId()
        {
            if (this.CurrentRepository is ILoanMonthRepayRepository)
            {
                IList<LoanMonthRepay> repayList = this.CurrentRepository.Entities.ToList();
                return repayList.Select(repay => repay.ToModel()).ToArray();
            }
            return null;
        }

        /// <summary>
        /// 修改车贷月还信息提醒状态
        /// </summary>
        /// <param name="repayId"></param>
        /// <param name="isRemind"></param>
        /// <returns></returns>
        public bool UpdateRepayRemindByRepayId(int repayId, int isRemind, int operatorId)
        {
            var loan_MonthRepay = this.LoanMonthRepayRepository.Entities.Where(Loan_Month => Loan_Month.RepayId == repayId).FirstOrDefault();
            loan_MonthRepay.IsRemind = isRemind;
            if (isRemind == 3)
            {
                loan_MonthRepay.GiveUpExtension += 1;
            }
            loan_MonthRepay.LastOperateId = operatorId;
            loan_MonthRepay.LastUpdateTime = DateTime.Now;
            return this.LoanMonthRepayRepository.Update(loan_MonthRepay, true) > 0 ? true : false;
        }
        public bool UpdateMonthRepayInfo(CarDeductViewModelDto dto, int operatorId)
        {
            var monthRepays = GetLoanMonthRepayInfoByOrderId(dto.OrderId).Where(repay => (repay.IsDeductSucess != true && repay.RepayDate < DateTime.Now)).OrderBy(repay => repay.RepayId).ToArray();
            if (monthRepays.Count() > 0)
            {
                decimal? dailyPenaltySumPerPeriod;
                decimal? RemianOverduePenalty;
                decimal? RemianDailyPenalty;
                decimal? RemianMonthRepay;
                decimal? RemainTotal;
                for (int i = 0; i < monthRepays.Count(); i++)
                {
                    int repayId = monthRepays[i].RepayId;
                    LoanMonthRepay loanMonthRepay = this.LoanMonthRepayRepository.Entities.Where(Loan_Month => Loan_Month.RepayId == repayId).FirstOrDefault();
                    dailyPenaltySumPerPeriod = DateUtil.GetDays(monthRepays[i].RepayDate.Value, DateTime.Now.Date) * monthRepays[i].DailyPenalty;
                    RemianOverduePenalty = monthRepays[i].OverduePenalty - (monthRepays[i].DeductOverduePenalty ?? 0);
                    RemianDailyPenalty = dailyPenaltySumPerPeriod - (monthRepays[i].DeductDailyPenalty ?? 0);
                    RemianMonthRepay = monthRepays[i].MonthRepay - (monthRepays[i].DeductMonthRepay ?? 0);
                    RemainTotal = RemianOverduePenalty + RemianDailyPenalty + RemianMonthRepay;

                    if (dto.DeductMoney >= RemainTotal)
                    {
                        loanMonthRepay.IsDeductSucess = true;
                        loanMonthRepay.DeductDailyPenalty = dailyPenaltySumPerPeriod;
                        loanMonthRepay.DeductOverduePenalty = loanMonthRepay.OverduePenalty;
                        loanMonthRepay.DeductMonthRepay = loanMonthRepay.MonthRepay;
                        loanMonthRepay.ActualDeductAmount = loanMonthRepay.DeductDailyPenalty + loanMonthRepay.DeductOverduePenalty + loanMonthRepay.DeductMonthRepay;
                        loanMonthRepay.ActualDeductDate = DateTime.Now;
                        loanMonthRepay.RepayId = monthRepays[i].RepayId;
                        loanMonthRepay.LastUpdateTime = DateTime.Now;
                        loanMonthRepay.OperateId = operatorId;
                        dto.DeductMoney = dto.DeductMoney - RemainTotal;
                        this.LoanMonthRepayRepository.Update(loanMonthRepay, false);
                        if (dto.DeductMoney == 0)
                        {
                            this.CurrentRepository.UnitOfWork.Commit();
                            return true;
                        }
                        else if (dto.DeductMoney < 0)
                        {
                            return false;
                        }
                        else continue;
                    }
                    else
                    {
                        if (dto.DeductMoney < RemianOverduePenalty)
                        {
                            loanMonthRepay.RepayId = monthRepays[i].RepayId;
                            loanMonthRepay.IsDeductSucess = false;
                            loanMonthRepay.DeductOverduePenalty = monthRepays[i].DeductOverduePenalty + dto.DeductMoney;
                            loanMonthRepay.ActualDeductAmount = loanMonthRepay.DeductOverduePenalty;
                            loanMonthRepay.ActualDeductDate = DateTime.Now;
                            loanMonthRepay.LastUpdateTime = DateTime.Now;
                            loanMonthRepay.OperateId = operatorId;
                            return this.LoanMonthRepayRepository.Update(loanMonthRepay, true) > 0 ? true : false;
                        }
                        else if (dto.DeductMoney < (RemianDailyPenalty + RemianOverduePenalty))
                        {
                            loanMonthRepay.RepayId = monthRepays[i].RepayId;
                            loanMonthRepay.IsDeductSucess = false;
                            loanMonthRepay.DeductOverduePenalty = monthRepays[i].OverduePenalty;
                            loanMonthRepay.DeductDailyPenalty = monthRepays[i].DeductDailyPenalty + (dto.DeductMoney - RemianOverduePenalty);
                            loanMonthRepay.ActualDeductAmount = monthRepays[i].ActualDeductAmount ?? 0 + dto.DeductMoney;
                            loanMonthRepay.ActualDeductDate = DateTime.Now;
                            loanMonthRepay.LastUpdateTime = DateTime.Now;
                            loanMonthRepay.OperateId = operatorId;
                            return this.LoanMonthRepayRepository.Update(loanMonthRepay, true) > 0 ? true : false;
                        }
                        else if (dto.DeductMoney < RemainTotal)
                        {
                            loanMonthRepay.RepayId = monthRepays[i].RepayId;
                            loanMonthRepay.IsDeductSucess = false;
                            loanMonthRepay.DeductOverduePenalty = monthRepays[i].OverduePenalty;
                            loanMonthRepay.DeductDailyPenalty = dailyPenaltySumPerPeriod;
                            loanMonthRepay.DeductMonthRepay = dto.DeductMoney - RemianOverduePenalty - RemianDailyPenalty + monthRepays[i].DeductMonthRepay;
                            loanMonthRepay.ActualDeductAmount = monthRepays[i].ActualDeductAmount ?? 0 + dto.DeductMoney;
                            loanMonthRepay.ActualDeductDate = DateTime.Now;
                            loanMonthRepay.LastUpdateTime = DateTime.Now;
                            loanMonthRepay.OperateId = operatorId;
                            return this.LoanMonthRepayRepository.Update(loanMonthRepay, true) > 0 ? true : false;
                        }
                    }
                }
            }

            return false;

        }
    }
}
