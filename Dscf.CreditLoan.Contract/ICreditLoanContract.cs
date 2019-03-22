using Dscf.CreditLoan.Dto;
using Dscf.PostLoanGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Contract
{
    [ServiceContract]
    public interface ICreditLoanContract
    {
        #region 信贷订单
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
        /// 批量修改订单催收状态
        /// </summary>
        /// <param name="orderIds"></param>
        /// <param name="collectStatus"></param>
        /// <param name="optId"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateOrderCollectStatusBatch(int[] orderIds, int collectStatus, int optId);
        /// <summary>
        /// 根据用户编号查询订单的相关信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        LoanProductOrderDto[] GetLoanProductOrderByUserId(int userId);

        /// <summary>
        ///  获取信贷逾期客户信息分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [OperationContract]
        PagedList<CreditOverdueListDto> GetPageOverdueList(int pageNum, int pageSize, int OptId);

        /// <summary>
        /// 查询借款产品订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [OperationContract]
        LoanOrderDetailDto GetLoanProductOrderDetail(int orderId);

        /// <summary>
        /// 获取信贷信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        [OperationContract]
        PagedList<LoanInfoDto> GetPageLoanInfoList(LoanSearchViewModel LoanSearchViewModel);
        /// <summary>
        ///获取违约逾期报表
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        [OperationContract]
        List<CreditOverdueExcelDto> GetOverdueExcelList(CreditOverdueSearchRequest overdueSearchRequest);
        #endregion

        #region 信贷月还信息
        /// <summary>
        /// 获取已经提醒数量和总数量
        /// </summary>
        /// <param name="deptIds"></param>
        /// <param name="optId"></param>
        /// <returns></returns>
        [OperationContract]
        CreditCountDto GetIsRemindCount(int optId);
        /// <summary>
        /// 根据订单ID获取月还信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [OperationContract]
        Loan_MonthRepayInfoDto[] GetLoan_MonthRepayInfoByorderID(int orderId);
        /// <summary>
        /// 获取所有信贷信息Excle
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        CreditRemindListDto[] GetRepayRemindList(string RepayIdArray);
        /// <summary>
        ///获取信贷还款提醒信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        [OperationContract]
        PagedList<CreditRemindListDto> GetPageRepayRemindList(int pageNum, int pageSize, int optId);

        /// <summary>
        /// 修改信贷提醒状态
        /// </summary>
        /// <param name="repayId"></param>
        /// <param name="isRemind"></param>
        /// <returns></returns>
        [OperationContract]
        bool UpdateCreditRemind(int repayId, bool isRemind);

        /// <summary>
        /// 获取月还信息详情
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <param name="periodOrder">月还编号</param>
        /// <returns></returns>
        [OperationContract]
        Loan_MonthRepayInfoDto GetLoan_MonthRepayInfoByorderIDPeriodOrder(int orderId, int periodOrder);

        /// <summary>
        /// 查询借款订单还款提醒详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="repayId"></param>
        /// <returns></returns>
        [OperationContract]
        CreditRemidDetailDto GetCreditRemindDetail(int orderId, int repayId);

        /// <summary>
        /// 修改订单的催收人
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="debtOptId"></param>
        /// <returns></returns>

        /// <summary>
        /// 获取批量划扣的当月信息
        /// </summary>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        [OperationContract]
        PagedList<CreditCriticalAmountListDto> GetCriticalAmountList(int pageNum, int pageSize, int orderId = 0);

        /// <summary>
        /// 获取信贷逾期月还信息（根据订单编号）
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [OperationContract]
        Loan_MonthRepayInfoDto[] GetOverdueMonthListByOrderId(int orderId);


        /// <summary>
        /// 更新月还信息（根据订单编号）
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [OperationContract]
        int UpdateMonthRepayInfo(CreditDeductViewDto model, int type, int isSuccess);

        #endregion

        #region 信贷划扣信息

        /// <summary>
        /// 获取当前通过审核但是未成功划扣的信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Loan_DeductProgressDto[] GetDeductionFailedList(IList<int> statusList = null);

        /// <summary>
        /// 批量添加借款划扣情况表
        /// </summary>
        /// <param name="idAndPeriods"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        [OperationContract]
        Boolean DeductinfoFailedAddAll(IList<string> idAndPeriods, int operatorId);

        /// <summary>
        /// 批量添加借款划扣情况表
        /// </summary>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        [OperationContract]
        Boolean DeductinfoFailedAddAlls(int operatorId);
        /// <summary>
        /// 添加借款划扣情况表单个
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="operatorId"></param>
        /// <param name="PlanDeductAmount"></param>
        /// <returns></returns>
        [OperationContract]
        Boolean DeductinfoFailedAddOne(int orderId, int operatorId, LoanDeductProgressDto model);

        /// <summary>
        /// 修改applyid
        /// </summary>
        /// <param name="applyId"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [OperationContract]
        Boolean UpdateApplyIdByOrderId(int applyId, int orderId);
        #endregion

        #region 信贷部门

        /// <summary>
        /// 查询指定部门的子部门列表
        /// </summary>
        /// <param name="parentDeptID">上级部门ID</param>
        /// <returns></returns>
        [OperationContract]
        DepartmentInfoDto[] GetChildDeptListByDeptID(int parentDeptID);

        /// <summary>
        /// 查询贷后支持城市列表
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        DepartmentInfoDto[] GetSupportCityList();
        [OperationContract]
        bool EditLoanOrderReminderByOrderId(int orderId, int deptOptId);

        /// <summary>
        /// /获取信贷划扣审批信息分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyList"></param>
        /// <returns></returns>
        [OperationContract]
        PagedList<CreditOverdueListDto> GetPageDeductApprovalList(int pageNum, int pageSize, int[] keyList);
        /// <summary>
        /// 获取划扣信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>  
        [OperationContract]
        LoanDeductProgressDto[] GetDeductList(int orderId);

        #endregion

        #region 信贷类型
        /// <summary>
        /// 获取信贷产品信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        ProductDto[] GetLoanProductList(int type);

        /// <summary>
        /// 获取信贷财务信息导出数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [OperationContract]
        CreditFinancialExportExcleDto[] GetCreditFinancialExportExcleList(CreditFinancialExportExcleRequest model);
        #endregion

        #region 用户信息

        /// <summary>
        /// 根据用户id查询用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [OperationContract]
        UserInfoDto GetUserInfoByUserId(int userId);

        #endregion

        #region 根据订单id查询订单信息

        /// <summary>
        /// 根据订单编号查询订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [OperationContract]
        LoanOrderDetailDto GetOrderInfoByOrderId(int orderId);

        #endregion

        #region 根据银行名称查询银行信息
        /// <summary>
        /// 根据银行名称查询银行信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [OperationContract]
        BankInfoDto GetBankInfoByName(string name);
        #endregion
    }
}
