using Dscf.Common.Manager.Implement;
using Dscf.CreditLoan.Dao;
using Dscf.CreditLoan.Domain;
using Dscf.CreditLoan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.CreditLoan.Dto.Extension;
namespace Dscf.CreditLoan.Manager.Implement
{
    public class Loan_MonthRepayManager : GenericManagerBase<Loan_MonthRepay>, ILoan_MonthRepayManager
    {

        public ILoan_MonthRepayRepository Loan_MonthRepayRepository { get; set; }
        public Loan_MonthRepayManager(ILoan_MonthRepayRepository repository)
        {
            this.CurrentRepository = repository;
        }

        public Loan_MonthRepayInfoDto[] GetLoan_MonthRepayInfoByorderID(int orderId)
        {
            IList<Loan_MonthRepay> deptList = this.CurrentRepository.Entities.Where(Loan_Month => Loan_Month.LoanOrderId == orderId).ToList();
            return deptList.Select(Loan_Month => Loan_Month.ToModel()).ToArray();
        }
        public Loan_MonthRepayInfoDto[] GetLoan_MonthRepayInfoByorderID()
        {
            IList<Loan_MonthRepay> deptList = this.CurrentRepository.Entities.ToList();
            return deptList.Select(Loan_Month => Loan_Month.ToModel()).ToArray();
        }
        public bool UpdateCreditRemindByRepayId(int repayId, bool isRemind)
        {
            var loan_MonthRepay = this.CurrentRepository.Entities.Where(Loan_Month => Loan_Month.RepayId == repayId).FirstOrDefault();
            loan_MonthRepay.IsRemind = isRemind;
            return this.CurrentRepository.Update(loan_MonthRepay, true) > 0 ? true : false;
        }

        /// <summary>
        /// 获取月还信息详情
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="periodOrder">月还编号</param>
        /// <returns></returns>
        public Loan_MonthRepayInfoDto GetLoan_MonthRepayInfoByorderIDPeriodOrder(int orderId, int periodOrder)
        {
            Loan_MonthRepay deptModel = this.CurrentRepository.Entities.Where(Loan_Month => Loan_Month.LoanOrderId == orderId && Loan_Month.PeriodOrder == periodOrder).ToList().FirstOrDefault();
            return deptModel.ToModel();
        }

        /// <summary>
        /// 获取信贷逾期月还信息（根据订单编号）
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Loan_MonthRepayInfoDto[] GetOverdueMonthListByOrderId(int orderId)
        {
            var repository = (ILoan_MonthRepayRepository)this.CurrentRepository;
            return repository.GetOverdueMonthListByOrderId(orderId);
        }


        /// <summary>
        /// 更新月还信息（根据订单编号）
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public int UpdateMonthRepayInfo(CreditDeductViewDto model, int type, int isSuccess)
        {
            int result = 0;
            var repository = (ILoan_MonthRepayRepository)this.CurrentRepository;

            //划扣结果为成功
            if (isSuccess == 1)
            {
                //type等于1 为逾期月还处理
                if (type == 1)
                {
                    #region 逾期客户月还处理

                    //根据订单编号查询月还逾期信息
                    Loan_MonthRepayInfoDto[] list = GetOverdueMonthListByOrderId(Convert.ToInt32(model.OrderId));

                    //划扣违约金、罚息、逾期月还本金的差额变量，用于判断金额不够还时（是否没还或没还完）
                    decimal? deductOverduePenalty, deductDailyPenalty, deductMonthRepay;

                    //差额初始值为实际还款金额
                    var diff = model.DeductMoney;
                    for (int i = 0; i < list.Count(); i++)
                    {
                        //如果差额小于或等于0 则直接跳出循环不继续执行
                        if (diff <= 0)
                        {
                            break;
                        }
                        // 根据月还id查询月还信息
                        Loan_MonthRepay updateModel = repository.GetByKey(list[i].RepayId);
                        //计算出划扣违约金、罚息、逾期月还本金的差额，有多少金额要还
                        deductOverduePenalty = list[i].OverduePenalty - (list[i].DeductOverduePenalty ?? 0);
                        deductDailyPenalty = (list[i].DailyPenalty * list[i].MonthDay) - (list[i].DeductDailyPenalty ?? 0);
                        deductMonthRepay = list[i].MonthRepay - (list[i].DeductMonthRepay ?? 0);

                        //计算出每期月还逾期金额
                        var repaySum = deductOverduePenalty + deductDailyPenalty + deductMonthRepay;

                        // 实际划扣金额足以支付本期的逾期金额
                        if (diff >= repaySum)
                        {
                            updateModel.ActualDeductAmount = list[i].ActualDeductAmount + repaySum; //总计金额
                            updateModel.DeductOverduePenalty = list[i].OverduePenalty; //划扣违约金
                            updateModel.DeductDailyPenalty = (list[i].DailyPenalty * list[i].MonthDay);  //划扣罚息（日罚息 * 欠款天数）
                            updateModel.DeductMonthRepay = list[i].MonthRepay;  //划扣逾期月还已还本金
                            updateModel.IsDeductSucess = true;
                            //每次差额减去总计金额
                            diff = diff - repaySum;
                        }
                        else
                        {
                            //如果差额不足以支付本期逾期金额，则按照 逾期违约金、罚息、月还本金 的顺序扣款
                            //因为考虑到会有部分还款情况，所以划扣金额为 本次实际划扣金额 + 上一次的实际划扣金额,金额默认为0

                            //不足支付的 实际划扣金额为 上一次实际划扣金额 + 本次实际划扣金额
                            updateModel.ActualDeductAmount = list[i].ActualDeductAmount + diff;

                            //如果违约金没还或没还完
                            if (deductOverduePenalty > 0 && diff > 0)
                            {
                                //如果不足以支付违约金，划扣违约金为 本次划扣金额 + 上一次的划扣违约金
                                updateModel.DeductOverduePenalty = (diff - deductOverduePenalty) >= 0 ? list[i].OverduePenalty : diff + (list[i].DeductOverduePenalty ?? 0); //划扣违约金
                                diff = diff - list[i].OverduePenalty;
                            }

                            //如果罚息没还或没还完
                            if (deductDailyPenalty > 0 && diff > 0)
                            {
                                updateModel.DeductOverduePenalty = list[i].OverduePenalty; //划扣违约金
                                //如果不足以支付罚息，划扣罚息为 本次划扣金额 + 上一次的划扣罚息
                                updateModel.DeductDailyPenalty = (diff - deductDailyPenalty) >= 0 ? (list[i].DailyPenalty * list[i].MonthDay) : diff + (list[i].DeductDailyPenalty ?? 0); //划扣违约金
                                diff = diff - (list[i].DailyPenalty * list[i].MonthDay);
                            }

                            //如果逾期月还本金没还或没还完
                            if (deductMonthRepay > 0 && diff > 0)
                            {
                                updateModel.DeductOverduePenalty = list[i].OverduePenalty; //划扣违约金
                                updateModel.DeductDailyPenalty = (list[i].DailyPenalty * list[i].MonthDay);  //划扣罚息（日罚息 * 欠款天数）
                                updateModel.DeductMonthRepay = (diff - deductMonthRepay) >= 0 ? list[i].MonthRepay : diff + (list[i].DeductMonthRepay ?? 0);  //划扣逾期月还已还本金
                                diff = diff - list[i].MonthRepay;
                            }
                            updateModel.IsDeductSucess = false;
                        }

                        updateModel.RepayId = list[i].RepayId;
                        updateModel.ActualDeductDate = DateTime.Now;
                        result = repository.Update(updateModel);
                    }

                    #endregion 逾期客户月还处理
                }
                else
                {
                    Loan_MonthRepay updateModel = repository.GetByKey(model.RepayId);
                    updateModel.IsDeductSucess = true;
                    updateModel.ActualDeductAmount = model.DeductMoney;
                    updateModel.RepayId = Convert.ToInt32(model.RepayId);
                    updateModel.ActualDeductDate = DateTime.Now;
                    result = repository.Update(updateModel);
                }

            }
            else //划扣结果为失败
            {
                Loan_MonthRepay updateModel = repository.GetByKey(model.RepayId);
                updateModel.IsDeductSucess = false;
                updateModel.ActualDeductAmount = 0;
                updateModel.RepayId = Convert.ToInt32(model.RepayId);
                result = repository.Update(updateModel);
            }
            return result;
        }

    }
}
