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
using System.Data;
using Dscf.CarLoan.Dao.Context;
using Dscf.CarLoan.Dao;
using Dscf.PostLoan.Model;
using Dscf.CarLoan.Dao.Implement;
using System.Transactions;

namespace Dscf.CarLoan.Manager.Implement
{
    /// <summary>
    /// 车贷-订单信息
    /// </summary>
    public class DeductProgressManager : GenericManagerBase<DeductProgress>, IDeductProgressManager
    {
        public ILoanMonthRepayRepository LoanMonthRepayRepository { get; set; }
        public DeductProgressDto[] GetDeductList(int orderId)
        {
            Dto.DscfACService.OperaterInfoDto[] deductPersonList;
            Dto.DscfACService.DictionaryDto[] paymentTypeList;
            var list = this.CurrentRepository.Entities.Where(deduct => deduct.OrderId == orderId && deduct.IsDelete != 1).ToList();

            var deductList = list.OrderByDescending(deduct => deduct.DeductId).Select(deduct => deduct.ToModel()).ToArray();
            using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
            {
                deductPersonList = client.GetCollectorListByRole(new int[] { RoleUtil.SettlementPersonnel });
                paymentTypeList = client.GetDictListByKey(DictUtil.PaymentTypeKey);
            }

            foreach (var deduct in deductList)
            {
                var deductP = deductPersonList.Where(deductPerson => deductPerson.Id == deduct.DeductOptId).FirstOrDefault();
                if (deductP != null)
                {
                    deduct.DeductOptName = deductP.Name;
                }
                var paymentTypeName = paymentTypeList.Where(paymentType => paymentType.DictValue == deduct.PaymentType).FirstOrDefault();
                if (paymentTypeName != null)
                {
                    deduct.PaymentTypeName = paymentTypeName.DictMemo;
                }
            }

            return deductList;


        }
        public Boolean AddCarDeductProgressByKey(IList<string> idAndPeriods, int operatorId)
        {
            List<DeductProgress> LoanDeductProgressList =
                 new List<DeductProgress>();
            DeductProgress deductProgress = null;
            LoanMonthRepayDto[] loanMonthRepayDtoList = LoanMonthRepayRepository.Entities.ToList().Select(Loan => Loan.ToModel()).ToArray();
            foreach (var idAndPeriod in idAndPeriods)
            {
                string[] idAndPeriodArray = idAndPeriod.Split(',');

                deductProgress = new DeductProgress();
                deductProgress.OrderId = int.Parse(idAndPeriodArray[0]);
                deductProgress.RepayId = int.Parse(idAndPeriodArray[1]);

                LoanMonthRepayDto loanMonthRepayDto = loanMonthRepayDtoList.Where(Loan => Loan.RepayId == deductProgress.RepayId).FirstOrDefault();
                DateTime planDeductDate = DateTime.Now;
                string ReqSn = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                if (loanMonthRepayDto != null)
                {
                    deductProgress.PlanDeductAmount = loanMonthRepayDto.MonthRepay;
                    deductProgress.DeductOptId = operatorId;
                    deductProgress.PlanDeductDate = planDeductDate;
                    deductProgress.Code = "10";
                    deductProgress.Result = "请求正在处理";
                    deductProgress.RepayId = loanMonthRepayDto.RepayId;
                    deductProgress.RepayPeriod = loanMonthRepayDto.PeriodOrder;
                    deductProgress.DeductGuid = Guid.NewGuid();
                    deductProgress.ReqSn = ReqSn;
                    deductProgress.PaymentType = 0;
                }
                LoanDeductProgressList.Add(deductProgress);
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
        /// 车贷单笔划扣，添加划扣信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public Boolean AddCarDeductProgressOne(DeductProgressDto model, int operatorId)
        {
            DeductProgress deductProgress = new DeductProgress();
            DateTime planDeductDate = DateTime.Now;

            deductProgress.PlanDeductAmount = model.PlanDeductAmount;
            deductProgress.DeductOptId = operatorId;
            deductProgress.PlanDeductDate = planDeductDate;
            deductProgress.Code = "10";
            deductProgress.Result = "请求正在处理";
            deductProgress.RepayId = model.RepayId;
            deductProgress.RepayPeriod = model.RepayPeriod;
            deductProgress.DeductGuid = Guid.NewGuid();
            deductProgress.ReqSn = model.ReqSn;
            deductProgress.PaymentType = model.PaymentType;
            deductProgress.OperateId = operatorId;
            deductProgress.ApplyId = model.ApplyId;
            deductProgress.OrderId = model.OrderId;

            //事务处理
            using (TransactionScope ts = new TransactionScope())
            {
                int count = this.CurrentRepository.Insert(deductProgress);
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
            DeductProgress DeductProgress = this.CurrentRepository.Entities.ToList()
                .Where(loan => loan.OrderId.HasValue ? (loan.OrderId.Value == orderId) : true)
                .OrderByDescending(loan => loan.DeductId).FirstOrDefault();
            DeductProgress.ApplyId = applyId;
            return this.CurrentRepository.Update(DeductProgress) > 0 ? true : false;
        }
    }


}
