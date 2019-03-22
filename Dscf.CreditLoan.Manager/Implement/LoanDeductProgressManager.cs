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
using Dscf.PostLoanGlobal;
using System.Transactions;
namespace Dscf.CreditLoan.Manager.Implement
{

    /// <summary>
    /// 信贷-订单信息
    /// </summary>
    public class LoanDeductProgressManager : GenericManagerBase<LoanDeductProgress>, ILoanDeductProgressManager
    {
        public ILoan_MonthRepayRepository Loan_MonthRepayRepository { get; set; }

        public ILoanProductOrderRepository LoanProductOrderRepository { get; set; }
        public LoanDeductProgressDto[] GetDeductList(int orderId)
        {
            Dto.DscfACService.OperaterInfoDto[] deductPersonList;
            Dto.DscfACService.DictionaryDto[] paymentTypeList;
            var list = this.CurrentRepository.Entities.Where(deduct => deduct.LoanOrderId == orderId).ToList();

            var deductList = list.OrderByDescending(deduct => deduct.DeductId).Select(deduct => deduct.ToModelGo()).ToArray();
            using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
            {
                deductPersonList = client.GetCollectorListByRole(new int[] { RoleUtil.SettlementPersonnel });
                paymentTypeList = client.GetDictListByKey(DictUtil.PaymentTypeKey);
            }
            if (deductList != null)
            {
                foreach (var deduct in deductList)
                {
                    var deductP = deductPersonList.Where(deductPerson => deductPerson.Id == deduct.DeductOptId).FirstOrDefault();
                    if (deductP != null)
                    {
                        deduct.DeductOptName = deductP.Name;
                    }
                    var paymentTypeName = paymentTypeList.Where(paymentType => paymentType.DictValue == deduct.IsPaymentType).FirstOrDefault();
                    if (paymentTypeName != null)
                    {
                        deduct.PaymentTypeName = paymentTypeName.DictMemo;
                    }
                }
            }
            return deductList;

        }

        public Loan_DeductProgressDto[] GetDeductionFailedList(IList<int> statusList = null)
        {
            Dto.DscfACService.OperaterInfoDto[] deductPersonList;

            IList<LoanDeductProgress> progressList = this.CurrentRepository.Entities.ToList();
            progressList = progressList.Where(p => statusList.Contains(int.Parse(p.LoanOrderId.HasValue ? p.LoanOrderId.ToString() : "0"))).ToList();
            if (progressList.Count() > 0)
            {
                var deductList = progressList.OrderByDescending(deduct => deduct.DeductId).Select(deduct => deduct.ToModel()).ToArray();
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    deductPersonList = client.GetCollectorListByRole(new int[] { RoleUtil.SettlementPersonnel });
                }
                if (deductList != null)
                {
                    foreach (var deduct in deductList)
                    {
                        var deductP = deductPersonList.Where(deductPerson => deductPerson.Id == deduct.DeductOptId).FirstOrDefault();
                        if (deductP != null)
                        {
                            deduct.BackFeedCode = deductP.Name;
                            continue;
                        }
                    }
                }
                return deductList;
            }
            return null;
        }

        /// <summary>
        /// 批量添加借款划扣情况表
        /// </summary>
        /// <param name="idAndPeriods"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public Boolean DeductinfoFailedAddAll(IList<string> idAndPeriods, int operatorId)
        {
            List<LoanDeductProgress> LoanDeductProgressList = new List<LoanDeductProgress>();
            LoanDeductProgress LoanDeductProgress = null;
            Loan_MonthRepayInfoDto[] Loan_MonthRepayInfoList = Loan_MonthRepayRepository.Entities.ToList().Select(Loan => Loan.ToModel()).ToArray();
            foreach (var idAndPeriod in idAndPeriods)
            {
                string[] idAndPeriodArray = idAndPeriod.Split(',');
                if (int.Parse(idAndPeriodArray[2]) == 10 || int.Parse(idAndPeriodArray[2]) == 20)
                {
                    continue;
                }
                LoanDeductProgress = new LoanDeductProgress();
                LoanDeductProgress.LoanOrderId = int.Parse(idAndPeriodArray[0]);
                LoanDeductProgress.RepayPeriod = int.Parse(idAndPeriodArray[1]);

                Loan_MonthRepayInfoDto Loan_MonthRepayInfoDto = Loan_MonthRepayInfoList.Where(Loan => Loan.LoanOrderId == LoanDeductProgress.LoanOrderId && Loan.PeriodOrder == LoanDeductProgress.RepayPeriod).FirstOrDefault();
                DateTime PlanDeductDate = DateTime.Now;
                string ReqSn = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                if (Loan_MonthRepayInfoDto != null)
                {
                    LoanDeductProgress.PlanDeductAmount = Loan_MonthRepayInfoDto.MonthRepay;
                    LoanDeductProgress.DeductOptId = operatorId;
                    LoanDeductProgress.PlanDeductDate = PlanDeductDate;
                    LoanDeductProgress.OperateDate = PlanDeductDate;
                    LoanDeductProgress.Code = "2000";
                    LoanDeductProgress.Result = "请求正在处理";
                    LoanDeductProgress.IsResult = 2;
                    LoanDeductProgress.RepayId = Loan_MonthRepayInfoDto.RepayId;
                    LoanDeductProgress.DeductGuid = Guid.NewGuid();
                    LoanDeductProgress.ReqSn = ReqSn;
                }
                LoanDeductProgressList.Add(LoanDeductProgress);
            }
            //事务处理
            using (TransactionScope ts = new TransactionScope())
            {
                int count = this.CurrentRepository.Insert(LoanDeductProgressList);
                if (count != LoanDeductProgressList.Count())
                {
                    ts.Dispose();
                    return false;
                }
                ts.Complete();
                return true;
            }
        }
        /// <summary>
        /// 全部执行方法
        /// </summary>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public Boolean DeductinfoFailedAddAll(int operatorId)
        {
            var CriticalAmountList = this.GetCriticalAmountList();
            List<LoanDeductProgress> LoanDeductProgressList =
                 new List<LoanDeductProgress>();
            LoanDeductProgress LoanDeductProgress = null;
            foreach (var CriticalAmount in CriticalAmountList)
            {
                if (CriticalAmount.Code == "10" || CriticalAmount.Code == "20")
                {
                    continue;
                }
                LoanDeductProgress = new LoanDeductProgress();
                LoanDeductProgress.LoanOrderId = CriticalAmount.OrderId;
                LoanDeductProgress.RepayPeriod = CriticalAmount.PeriodOrder;

                DateTime PlanDeductDate = DateTime.Now;
                string ReqSn = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                LoanDeductProgress.PlanDeductAmount = CriticalAmount.MonthRepay;
                LoanDeductProgress.DeductOptId = operatorId;
                LoanDeductProgress.PlanDeductDate = PlanDeductDate;
                LoanDeductProgress.OperateDate = PlanDeductDate;
                LoanDeductProgress.Code = "2000";
                LoanDeductProgress.Result = "请求正在处理";
                LoanDeductProgress.IsResult = 2;
                LoanDeductProgress.RepayId = CriticalAmount.RepayId;
                LoanDeductProgress.DeductGuid = Guid.NewGuid();
                LoanDeductProgress.ReqSn = ReqSn;
                LoanDeductProgressList.Add(LoanDeductProgress);
            }
            //事务处理
            using (TransactionScope ts = new TransactionScope())
            {
                int count = this.CurrentRepository.Insert(LoanDeductProgressList);
                if (count != LoanDeductProgressList.Count())
                {
                    ts.Dispose();
                    return false;
                }
                ts.Complete();
                return true;
            }
        }
        /// <summary>
        /// 获取批量划扣的当月信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<CreditCriticalAmountListDto> GetCriticalAmountList(int orderId = 0)
        {
            if (LoanProductOrderRepository is ILoanProductOrderRepository)
            {
                var repository = (ILoanProductOrderRepository)LoanProductOrderRepository;
                var criticalAmountList = repository.GetCriticalAmountList(orderId);

                return criticalAmountList;
            }
            throw new Exception(string.Format("数据访问对象类型不正确,应为ILoanProductOrderRepository，实际为 {0}!", this.CurrentRepository.GetType().Name));
        }

        /// <summary>
        /// 添加借款划扣情况表单个
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="operatorId"></param>
        /// <param name="PlanDeductAmount"></param>
        /// <returns></returns>
        public Boolean DeductinfoFailedAddOne(int orderId, int operatorId, LoanDeductProgressDto model)
        {
            LoanDeductProgress LoanDeductProgress = new Domain.LoanDeductProgress();
            LoanDeductProgress.LoanOrderId = orderId;
            DateTime planDeductDate = DateTime.Now;
            string ReqSn = model.ReqSn;
            LoanDeductProgress.PlanDeductAmount = model.PlanDeductAmount;
            LoanDeductProgress.DeductOptId = operatorId;
            LoanDeductProgress.PlanDeductDate = planDeductDate;
            LoanDeductProgress.OperateDate = planDeductDate;
            LoanDeductProgress.Code = "10";
            LoanDeductProgress.Result = "请求正在处理";
            LoanDeductProgress.IsResult = 1;
            LoanDeductProgress.DeductGuid = Guid.NewGuid();
            LoanDeductProgress.ReqSn = ReqSn;
            LoanDeductProgress.RepayPeriod = model.RepayPeriod;
            LoanDeductProgress.RepayId = model.RepayId;
            LoanDeductProgress.IsPaymentType = model.IsPaymentType;
            LoanDeductProgress.ApplyId = model.ApplyId;

            //事务处理
            using (TransactionScope ts = new TransactionScope())
            {
                int count = this.CurrentRepository.Insert(LoanDeductProgress);
                if (count == 0)
                {
                    ts.Dispose();
                    return false;
                }
                ts.Complete();
                return true;
            }
        }

        public Boolean UpdateApplyIdByOrderId(int applyId, int orderId)
        {
            LoanDeductProgress LoanDeductProgress = this.CurrentRepository.Entities.ToList().Where(loan => loan.LoanOrderId.HasValue ? (loan.LoanOrderId.Value == orderId) : true).OrderByDescending(loan => loan.DeductId).FirstOrDefault();
            LoanDeductProgress.ApplyId = applyId;
            return this.CurrentRepository.Update(LoanDeductProgress) > 0 ? true : false;
        }

    }


}
