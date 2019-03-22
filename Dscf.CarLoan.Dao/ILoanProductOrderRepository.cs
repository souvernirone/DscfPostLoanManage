using Dscf.CarLoan.Domain;
using Dscf.CarLoan.Dto;
using Dscf.Common.Dao;
using Dscf.PostLoanGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CarLoan.Dao
{
    //贷款订单表
    public interface ILoanProductOrderRepository : IRepository<LoanProductOrder>
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
        LoanProductOrderDto GetLoanProductOrderByOrderId(int orderId);

        /// <summary>
        /// 根据订单编号查询车贷借款详细信息附加展期
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        LoanProductExtensionOrderDto GetLoanProductExtensionOrderByOrderId(int orderId);
        /// <summary>
        ///获取车贷还款提醒Excle数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        List<CarRemindListDto> GetRepayRemindList(string RepayIdArray);
        /// <summary>
        ///获取车贷还款提醒信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        PagedList<CarRemindListDto> GetPageRepayRemindList(int pageNum, int pageSize, bool isLongLoan, string[] signSities, int optId);

        /// <summary>
        /// 根据订单编号查询车贷借款详细信息及展期（车贷月还提醒）
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        LoanProductOrderDto GetCarLoanRemindByOrderId(int orderId);

        /// <summary>
        /// 获取车贷逾期客户信息分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isLongLoan"></param>
        /// <returns></returns>
        PagedList<CarOverdueListDto> GetPageOverdueList(int pageNum, int pageSize, bool? isLongLoan, string[] signSities, int optId, int? collectTypeId);

        /// /// <summary>
        /// 获取车贷划扣审批信息分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isLongLoan"></param>
        /// <returns></returns>
        PagedList<CarOverdueListDto> GetPageDeductApprovalList(int pageNum, int pageSize, int[] keyList);

        /// <summary>
        /// 获取已经提醒的数量和总数量
        /// </summary>
        /// <param name="isLongLoan"></param>
        /// <param name="signSities"></param>
        /// <param name="optId"></param>
        /// <returns></returns>
        CarCountDto GetIsRemindCount(bool isLongLoan, string[] signSities, int optId);

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
        List<CarFinancialExportExcleDto> GetCarFinancialExportExcleList(CarFinancialExportExcleRequest model);

        /// <summary>
        /// 获取待划款的订单
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
