using Dscf.CarLoan.Domain;
using Dscf.CarLoan.Dto;
using Dscf.PostLoanGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Contract
{
    [ServiceContract]
    public interface ICarLoanContract
    {
        #region UserInfo-用户信息

        [OperationContract]
        CarUserInfoDto[] QueryUserInfoList();
        #endregion



        #region LoanProductOrder-车辆借款订单
        /// <summary>
        /// 获取当月待划扣的月还信息
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [OperationContract]
        PagedList<CarLoanBatchDeductDto> GetPageCarLoanBatchDeductList(int pageNum, int pageSize);
        /// <summary>
        /// 修改催收状态
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="collectStatus"></param>
        /// <param name="optId"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateOrderCollectStatus(int orderId, int collectStatus, int optId);
        /// <summary>
        /// 批量修改催收状态
        /// </summary>
        /// <param name="orderIds"></param>
        /// <param name="collectStatus"></param>
        /// <param name="optId"></param>
        [OperationContract]
        bool UpdateOrderCollectStatusBatch(int[] orderIds, int collectStatus, int optId);
        /// <summary>
        /// 车贷借款信息分页
        /// </summary>
        /// <param name="loanSearchaRequest"></param>
        /// <returns></returns>
        [OperationContract]
        PagedList<LoanProductOrderDto> SelectLoanProductOrderList(LoanSearchaRequest loanSearchaRequest);

        /// <summary>
        /// 根据订单编号查询订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [OperationContract]
        LoanProductOrderDto GetLoanProductOrderInfoByOrderId(int orderId);

        /// <summary>
        /// 根据订单编号查询车贷借款详细信息附加展期
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [OperationContract]
        LoanProductExtensionOrderDto GetLoanProductExtensionOrderByOrderId(int orderId);
        /// <summary>
        /// 还款提醒Excle
        /// </summary>
        /// <param name="loanSearchaRequest"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [OperationContract]
        List<CarRemindListDto> GetRepayRemindList(string RepayIdArray);
        /// <summary>
        /// 获取车贷逾期客户信息分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [OperationContract]
        PagedList<CarOverdueListDto> GetPageOverdueList(int pageNum, int pageSize, bool? isLongLoan, int optId);

        /// <summary>
        /// 查询借款产品订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [OperationContract]
        CarLoanOrderDetailDto GetLoanProductOrderDetail(int orderId);

        [OperationContract]
        LoanOrderDto GetLoanProductOrderSingleById(int orderId);

        [OperationContract]
        bool UpdateLoanProductOrder(LoanOrderDto orderDto);

        [OperationContract]
        bool EditLoanOrderReminderByOrderId(int orderId, int deptOptId);

        /// <summary>
        /// 分页查询划扣审批列表
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="idList"></param>
        /// <returns></returns>
        [OperationContract]
        PagedList<CarOverdueListDto> GetPageDeductApprovalList(int pageNum, int pageSize, int[] keyList);
        /// <summary>
        /// 获取违约逾期报表
        /// </summary>
        /// <param name="overdueSearchRequest"></param>
        /// <returns></returns>
        [OperationContract]
        List<CarOverdueExcelDto> GetOverdueExcelList(OverdueSearchRequest overdueSearchRequest);
        #endregion

        #region LoanMonthRepay-借款月还信息

        [OperationContract]
        bool UpdateMonthRepayInfo(CarDeductViewModelDto dto, int operaterId);
        /// <summary>
        /// 根据订单编号查询车贷订单的月还信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [OperationContract]
        LoanMonthRepayDto[] GetLoanMonthRepayInfoByOrderId(int orderId);

        /// <summary>
        /// 获取车贷还款提醒信息分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isLongLoan"></param>
        /// <returns></returns>
        [OperationContract]
        PagedList<CarRemindListDto> GetPageRepayRemindList(int pageNum, int pageSize, bool isLongLoan, int optId);

        /// <summary>
        /// 修改车贷月还信息提醒状态
        /// </summary>
        /// <param name="repayId"></param>
        /// <param name="isRemind"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateRepayRemindByRepayId(int repayId, int isRemind, int operatorId);

        /// <summary>
        /// 查询车贷还款提醒的详细信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="repayId"></param>
        /// <returns></returns>
        [OperationContract]
        CarRemidDetailDto GetCarRemindDetail(int orderId, int repayId);
        /// <summary>
        /// 获取已经提醒数量
        /// </summary>
        /// <param name="isLongLoan"></param>
        /// <param name="signSities"></param>
        /// <param name="optId"></param>
        /// <returns></returns>
        [OperationContract]
        CarCountDto GetIsRemindCount(bool isLongLoan, int optId);



        #endregion

        #region CarLoanExtensionApply-展期申请

        [OperationContract]
        bool AddLoanExtensionApplyByDto(CarLoanExtensionApplyDto carLoanExtensionApplyDto);

        #endregion

        #region ExhibitionReview-展期复议

        [OperationContract]
        ExhibitionReviewDto[] GetExhibitionReviewlist(int? orderId);

        [OperationContract]
        bool InsertExhibitionReview(ExhibitionReviewDto reviewDto, out ExhibitionReviewDto dto);

        [OperationContract]
        bool UpdateExhibitionReview(ExhibitionReviewDto reviewDto, out ExhibitionReviewDto dto);

        #endregion

        #region Images-图片文件

        [OperationContract]
        bool InsertImages(ImagesDto dto);

        [OperationContract]
        bool DeleteImages(int key);

        [OperationContract]
        ImagesDto[] GetImages(int key);

        [OperationContract]
        bool DelImgFalse(int key);
        #endregion
        /// <summary>
        /// 获取划扣信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>  
        [OperationContract]
        DeductProgressDto[] GetDeductList(int orderId);
        /// <summary>
        /// 批量添加划款
        /// </summary>
        /// <param name="idAndPeriods"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        [OperationContract]
        Boolean AddCarDeductProgressByKey(IList<string> idAndPeriods, int operatorId);

        /// <summary>
        /// 车贷单笔划扣，添加划扣信息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        [OperationContract]
        Boolean AddCarDeductProgressOne(DeductProgressDto model, int operatorId);

        /// <summary>
        /// 修改applyid
        /// </summary>
        /// <param name="applyId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [OperationContract]
        Boolean UpdateApplyIdByOrderId(int applyId, int orderId);

        #region Excle
        /// <summary>
        /// 车贷财务报表的Excle数据读取
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        CarFinancialExportExcleDto[] GetCarFinancialExportExcleList(CarFinancialExportExcleRequest model);

        #endregion



        /// <summary>
        /// 获取待划款订单
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<CarLoanBatchDeductDto> GetCarLoanBatchDeductList();
    }
}
