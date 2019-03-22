using Dscf.PostLoanGlobal;
using Dscf.LoanAfter.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Contract
{
    [ServiceContract]
    public interface ILoanAfterContract
    {
        #region RepayRemind-还款提醒

        [OperationContract]
        RepayRemindDto[] GetRepayRemindListByKey(int repayId, int orderType);

        [OperationContract]
        RemindExcleDto[] GetRepayRemindListByKeys(int productName, string timeBegin, string timeEnd);

        [OperationContract]
        bool AddRepayMindByDto(RepayRemindDto repayRemindDto, out RepayRemindDto dto);

        [OperationContract]
        bool EditRepayMindByDto(RepayRemindDto repayRemindDto, out RepayRemindDto dto);

        [OperationContract]
        bool DelRepayMindByDto(RepayRemindDto repayRemindDto);

        #endregion

        #region DeductPayApply-划扣申请

        [OperationContract]
        bool AddDeductPayApply(DeductPayApplyDto deductPayApplyDto);

        [OperationContract]
        UpFileResultMessage UpLoadFile(UpFileMessage fileMessage);

        [OperationContract]
        DeductPayApplyDto GetDeductPayApplyAndFile(int orderId, int orderType);

        /// <summary>
        /// 银行划扣返回结果
        /// </summary>
        /// <param name="ApplyId"></param>
        /// <param name="boolean"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateStatusByApplyId(int applyId, bool boolean);
        /// <summary>
        ///获取划扣审批信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        [OperationContract]
        PagedList<ApprovalListDto> GetDeductPayList(int pageNum, int pageSize);

        /// <summary>
        /// 获取划扣审批通过信息分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <summary>
        /// 批量修改划扣审批的状态
        /// </summary>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <param name="?"></param>
        [OperationContract]
        bool UpdateApplyStatusBatch(int[] creditOrderIds, int[] carOrderIds, int status, int operatorId, string reason);
        /// <summary>
        /// 修改划扣审批的状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="orderType"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateApplyStatusByKey(int orderId, int orderType, int status, int operatorId, string reason);

        /// <summary>
        /// 获取划扣申请信息
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="applyId">划扣ID</param>
        /// <returns></returns>
        [OperationContract]
        PagedList<DeductPayApplyDto> GetPageDeductPayList(int pageNum, int pageSize, int? applyId = null);

        /// <summary>
        /// 获取可以进行划扣行为的申请
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderType"></param>
        /// <returns></returns>
        [OperationContract]
        PagedList<CarDeductPayInfoDto> SelectCarDeductOrderList(int pageNum, int pageSize, int orderType);

        [OperationContract]
        PagedList<ThroughListDto> SelectCreditDeductOrderList(int pageNum, int pageSize, int? applyId = null);
        #endregion

        #region CollectionInfo-催收信息

        [OperationContract]
        bool InsertCollectionInfoAndUpFile(CollectionInfoDto dto);

        [OperationContract]
        CollectionInfoDto[] GetCollectionInfoByKey(int orderId, int orderType);

        [OperationContract]
        bool DelCollectionInfo(int id, int operaterId);

        [OperationContract]
        bool UpdateCollectionInfo(CollectionInfoDto dto, out CollectionInfoDto colletion);

        #endregion

        #region ExtraInfo-新增信息

        [OperationContract]
        ExtraInfoDto[] GetExtraInfoListByOrder(int orderId, int orderType);

        [OperationContract]
        bool InsertExtraInfo(ExtraInfoDto extradDto, out ExtraInfoDto dto);

        [OperationContract]
        bool UpdateExtraInfo(ExtraInfoDto extradDto, out ExtraInfoDto dto);

        [OperationContract]
        bool DelExtraInfo(int id);

        #endregion

        #region EexcleInfo导出信息
        /// <summary>
        /// 获取信贷产品信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ExcleInfoDto[] GetLoanAfterProduct(int type, int productTypeId);

        #endregion
    }
}
