using Dscf.Common.Manager;
using Dscf.PostLoanGlobal;
using Dscf.LoanAfter.Domain;
using Dscf.LoanAfter.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Manager
{
    //T_DeductPayApply
    public interface IDeductPayApplyManager : IGenericManager<DeductPayApply>
    {
        DeductPayApplyDto GetDeductPayApplyAndFile(int orderId, int orderType);

        PagedList<ApprovalListDto> GetDeductApprovalList(int pageNum, int pageSize);
        PagedList<ThroughListDto> SelectCreditDeductOrderList(int pageNum, int pageSize, int? applyId = null);

        /// <summary>
        /// 银行划扣返回结果
        /// </summary>
        /// <param name="ApplyId"></param>
        /// <param name="boolean"></param>
        /// <returns></returns>
        bool UpdateStatusByApplyId(int applyId, bool boolean);
        bool UpdateApplyStatusByKey(int orderId, int orderType, int status, int operatorId, string reason);
        bool UpdateApplyStatusBatch(int[] creditOrderIds, int[] carOrderIds, int status, int operatorId, string reason);

        /// <summary>
        /// 获取划扣申请信息
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="applyId">划扣ID</param>
        /// <returns></returns>
        PagedList<DeductPayApplyDto> GetPageDeductPayList(int pageNum, int pageSize, int? applyId = null);

        PagedList<CarDeductPayInfoDto> SelectCarDeductOrderList(int pageNum, int pageSize, int orderType);
    }
}
