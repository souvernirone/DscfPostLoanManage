using Dscf.PostLoanGlobal;
using Dscf.LoanAfter.Contract;
using Dscf.LoanAfter.Domain;
using Dscf.LoanAfter.Dto;
using Dscf.LoanAfter.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Service
{
    public partial class LoanAfterService : ILoanAfterContract
    {
        public IDeductPayApplyManager DeductPayApplyManager { get; set; }
        public bool AddDeductPayApply(DeductPayApplyDto deductPayApplyDto)
        {
            DeductPayApply entity = deductPayApplyDto.ToEntity();
            return this.DeductPayApplyManager.Insert(entity) > 0 ? true : false;
        }
        public DeductPayApplyDto GetDeductPayApplyAndFile(int orderId, int orderType)
        {
            return DeductPayApplyManager.GetDeductPayApplyAndFile(orderId, orderType);
        }
        /// <summary>
        /// 银行划扣返回结果
        /// </summary>
        /// <param name="ApplyId"></param>
        /// <param name="boolean"></param>
        /// <returns></returns>
        public bool UpdateStatusByApplyId(int applyId, bool boolean)
        {
            return DeductPayApplyManager.UpdateStatusByApplyId(applyId, boolean);
        }
        public PagedList<ApprovalListDto> GetDeductPayList(int pageNum, int pageSize)
        {
            return DeductPayApplyManager.GetDeductApprovalList(pageNum, pageSize);
        }

        public bool UpdateApplyStatusByKey(int orderId, int orderType, int status, int operatorId, string reason)
        {
            return DeductPayApplyManager.UpdateApplyStatusByKey(orderId, orderType, status, operatorId, reason);
        }
        public bool UpdateApplyStatusBatch(int[] creditOrderIds, int[] carOrderIds, int status, int operatorId, string reason)
        {
            return DeductPayApplyManager.UpdateApplyStatusBatch(creditOrderIds, carOrderIds, status, operatorId, reason);
        }
        /// <summary>
        /// 获取划扣申请信息
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="applyId">划扣ID</param>
        /// <returns></returns>
        public PagedList<DeductPayApplyDto> GetPageDeductPayList(int pageNum, int pageSize, int? applyId = null)
        {
            return DeductPayApplyManager.GetPageDeductPayList(pageNum, pageSize, applyId);
        }
        public PagedList<CarDeductPayInfoDto> SelectCarDeductOrderList(int pageNum, int pageSize, int orderType)
        {
            return DeductPayApplyManager.SelectCarDeductOrderList(pageNum, pageSize, orderType);
        }
        public PagedList<ThroughListDto> SelectCreditDeductOrderList(int pageNum, int pageSize, int? applyId = null)
        {
            return DeductPayApplyManager.SelectCreditDeductOrderList(pageNum, pageSize, applyId);
        }
    }
}
