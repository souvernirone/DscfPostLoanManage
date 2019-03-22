using Dscf.Common.Dao;
using Dscf.CreditLoan.Domain;
using Dscf.CreditLoan.Dto;
using Dscf.PostLoanGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dscf.CreditLoan.Dao
{
    public interface ILoanProductOrderRepository : IRepository<LoanProductOrder>
    {

        /// <summary>
        ///获取信贷信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        PagedList<LoanInfoDto> GetPageLoanInfoList(LoanSearchViewModel LoanSearchViewModel);
        /// <summary>
        ///获取信贷还款提醒信息Excle数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        CreditRemindListDto[] GetRepayRemindList(string RepayIdArray);
        /// <summary>
        ///获取信贷还款提醒信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        PagedList<CreditRemindListDto> GetPageRepayRemindList(int pageNum, int pageSize, int[] deptIds, int optId);

        /// <summary>
        ///获取信贷逾期客户信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        PagedList<CreditOverdueListDto> GetPageOverdueList(int pageNum, int pageSize, int[] deptIds, int optId, int? collectTypeId);

        /// <summary>
        ///获取信贷划扣审批信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        PagedList<CreditOverdueListDto> GetDeductApprovalList(int pageNum, int pageSize, int[] keyList);
        /// <summary>
        /// 获取已经提醒数量和总数量
        /// </summary>
        /// <param name="deptIds"></param>
        /// <param name="optId"></param>
        /// <returns></returns>
        CreditCountDto GetIsRemindCount(int[] deptIds, int optId);

        /// <summary>
        /// 获取批量划扣的当月信息
        /// </summary>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        PagedList<CreditCriticalAmountListDto> GetCriticalAmountList(int pageNum, int pageSize, int orderId = 0);

        /// <summary>
        /// 获取批量划扣的当月信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        List<CreditCriticalAmountListDto> GetCriticalAmountList(int orderId = 0);
        /// <summary>
        /// 获取信贷财务信息导出数据
        /// </summary>
        /// <param name="model">条件搜索</param>
        /// <returns></returns>
        List<CreditFinancialExportExcleDto> GetCreditFinancialExportExcleList(CreditFinancialExportExcleRequest model);
        /// <summary>
        ///获取违约逾期报表
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        List<CreditOverdueExcelDto> GetOverdueExcelList(CreditOverdueSearchRequest overdueSearchRequest);
    }
}
