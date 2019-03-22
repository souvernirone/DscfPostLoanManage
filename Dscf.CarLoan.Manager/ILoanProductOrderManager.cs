using Dscf.CarLoan.Domain;
using Dscf.CarLoan.Dto;
using Dscf.Common.Manager;
using Dscf.PostLoanGlobal;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Manager
{
    public interface ILoanProductOrderManager : IGenericManager<LoanProductOrder>
    {
        /// <summary>
        /// 车贷借款信息分页
        /// </summary>
        /// <param name="loanSearchaRequest"></param>
        /// <returns></returns>
        PagedList<LoanProductOrderDto> SelectLoanProductOrderList(LoanSearchaRequest loanSearchaRequest);

        /// <summary>
        /// 根据订单编号查询车贷借款详细信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        /// <summary>
        LoanProductOrderDto GetLoanProductOrderInfoByOrderId(int orderId);
        /// <summary>
        /// 根据订单编号查询车贷借款详细信息附加展期
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        LoanProductExtensionOrderDto GetLoanProductExtensionOrderByOrderId(int orderId);

        /// <summary>
        /// 还款提醒Excle
        /// </summary>
        /// <param name="loanSearchaRequest"></param>
        /// <returns></returns>
        List<CarRemindListDto> GetRepayRemindList(string RepayIdArray);
        /// <summary>
        ///获取车贷还款提醒信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        PagedList<CarRemindListDto> GetPageRepayRemindList(int pageNum, int pageSize, bool isLongLoan, int optId);

        /// <summary>
        /// 查询车贷还款提醒的详细信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="repayId"></param>
        /// <returns></returns>
        CarRemidDetailDto GetCarRemindDetail(int orderId, int repayId);

        /// <summary>
        /// 获取车贷逾期客户信息分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isLongLoan"></param>
        /// <returns></returns>
        PagedList<CarOverdueListDto> GetPageOverdueList(int pageNum, int pageSize, bool? isLongLoan, int optId);

        /// <summary>
        /// 查询借款产品订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        CarLoanOrderDetailDto GetLoanProductOrderDetail(int orderId);

        /// <summary>
        /// 修改借款产品订单的催收人
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="deptOptId"></param>
        /// <returns></returns>
        bool EditLoanOrderReminderByOrderId(int orderId, int deptOptId);


        PagedList<CarOverdueListDto> GetPageDeductApprovalList(int pageNum, int pageSize, int[] keyList);

        bool UpdateOrderCollectStatus(int orderId, int collectStatus, int optId);

        bool UpdateOrderCollectStatusBatch(int[] orderIds, int collectStatus, int optId);

        CarCountDto GetIsRemindCount(bool isLongLoan, int optId);
        /// <summary>
        /// 获取当月待划扣的月还信息
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        PagedList<CarLoanBatchDeductDto> GetPageCarLoanBatchDeductList(int pageNum, int pageSize);
        /// <summary>
        /// 车贷财务报表的Excle数据读取
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        CarFinancialExportExcleDto[] GetCarFinancialExportExcleList(CarFinancialExportExcleRequest model);
        /// <summary>
        /// 获取待划款订单
        /// </summary>
        /// <returns></returns>
        List<CarLoanBatchDeductDto> GetCarLoanBatchDeductList();
        /// <summary>
        /// 获取违约逾期报表
        /// </summary>
        /// <param name="overdueSearchRequest"></param>
        /// <returns></returns>
        List<CarOverdueExcelDto> GetOverdueExcelList(OverdueSearchRequest overdueSearchRequest);
    }
}
