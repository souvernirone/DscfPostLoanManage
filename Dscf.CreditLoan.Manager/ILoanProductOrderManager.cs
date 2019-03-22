using Dscf.Common.Manager;
using Dscf.CreditLoan.Domain;
using Dscf.CreditLoan.Dto;
using Dscf.PostLoanGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dscf.CreditLoan.Manager
{
    public interface ILoanProductOrderManager : IGenericManager<LoanProductOrder>
    {
        /// <summary>
        /// 根据用户编号查询订单相关信息
        /// </summary>
        /// <returns></returns>
        LoanProductOrderDto[] GetLoanProductOrderByUserId(int userId);


        /// <summary>
        /// 分页查询信贷信息
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        PagedList<LoanInfoDto> GetPageLoanInfoList(LoanSearchViewModel LoanSearchViewModel);
        /// <summary>
        /// 还款提醒Excle
        /// </summary>
        /// <param name="loanSearchaRequest"></param>
        /// <returns></returns>
        CreditRemindListDto[] GetRepayRemindList(string RepayIdArray);
        /// <summary>
        ///获取信贷还款提醒信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        PagedList<CreditRemindListDto> GetPageRepayRemindList(int pageNum, int pageSize, int optId);

        /// <summary>
        /// 查询借款订单还款提醒详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        CreditRemidDetailDto GetCreditRemindDetail(int orderId, int repayId);

        /// <summary>
        ///获取信贷逾期客户信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        PagedList<CreditOverdueListDto> GetPageOverdueList(int pageNum, int pageSize, int optId);

        /// <summary>
        /// 查询借款产品订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        LoanOrderDetailDto GetLoanProductOrderDetail(int orderId);

        /// <summary>
        /// 修改订单的催收人
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="debtOptId"></param>
        /// <returns></returns>
        bool EditLoanOrderReminderByOrderId(int orderId, int deptOptId);

        PagedList<CreditOverdueListDto> GetPageDeductApprovalList(int pageNum, int pageSize, int[] keyList);

        bool UpdateOrderCollectStatus(int orderId, int collectStatus, int optId);

        bool UpdateOrderCollectStatusBatch(int[] orderIds, int collectStatus, int optId);

        CreditCountDto GetIsRemindCount(int optId);

        PagedList<CreditCriticalAmountListDto> GetCriticalAmountList(int pageNum, int pageSize, int orderId = 0);

        /// <summary>
        /// 根据订单编号查询订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        LoanOrderDetailDto GetOrderInfoByOrderId(int orderId);

        /// <summary>
        /// 获取信贷财务信息导出数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        CreditFinancialExportExcleDto[] GetCreditFinancialExportExcleList(CreditFinancialExportExcleRequest model);
        /// <summary>
        ///获取违约逾期报表
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        List<CreditOverdueExcelDto> GetOverdueExcelList(CreditOverdueSearchRequest overdueSearchRequest);
    }
}
