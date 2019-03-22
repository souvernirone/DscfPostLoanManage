using Dscf.CreditLoan.Contract;
using Dscf.CreditLoan.Dto;
using Dscf.CreditLoan.Manager;
using Dscf.PostLoanGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Service
{
    public partial class CreditLoanService : ICreditLoanContract
    {
        public ILoanProductOrderManager LoanProductOrderManager { get; set; }

        /// <summary>
        /// 根据用户编号查询订单相关信息
        /// </summary>
        /// <returns></returns>
        public LoanProductOrderDto[] GetLoanProductOrderByUserId(int userId)
        {
            return LoanProductOrderManager.GetLoanProductOrderByUserId(userId);
        }

        /// <summary>
        /// 获取信贷分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public PagedList<LoanInfoDto> GetPageLoanInfoList(LoanSearchViewModel LoanSearchViewModel)
        {
            return LoanProductOrderManager.GetPageLoanInfoList(LoanSearchViewModel);
        }
        public CreditRemindListDto[] GetRepayRemindList(string RepayIdArray)
        {
            return LoanProductOrderManager.GetRepayRemindList(RepayIdArray);
        }
        public PagedList<CreditRemindListDto> GetPageRepayRemindList(int pageNum, int pageSize, int optId)
        {
            return LoanProductOrderManager.GetPageRepayRemindList(pageNum, pageSize, optId);
        }

        public CreditRemidDetailDto GetCreditRemindDetail(int orderId, int repayId)
        {
            return LoanProductOrderManager.GetCreditRemindDetail(orderId, repayId);
        }


        public PagedList<CreditOverdueListDto> GetPageOverdueList(int pageNum, int pageSize, int optId)
        {
            return LoanProductOrderManager.GetPageOverdueList(pageNum, pageSize, optId);
        }

        public LoanOrderDetailDto GetLoanProductOrderDetail(int orderId)
        {
            return LoanProductOrderManager.GetLoanProductOrderDetail(orderId);
        }

        public bool EditLoanOrderReminderByOrderId(int orderId, int deptOptId)
        {
            return LoanProductOrderManager.EditLoanOrderReminderByOrderId(orderId, deptOptId);
        }

        public PagedList<CreditOverdueListDto> GetPageDeductApprovalList(int pageNum, int pageSize, int[] keyList)
        {
            return LoanProductOrderManager.GetPageDeductApprovalList(pageNum, pageSize, keyList);
        }
        public bool UpdateOrderCollectStatus(int orderId, int collectStatus, int optId)
        {
            return LoanProductOrderManager.UpdateOrderCollectStatus(orderId, collectStatus, optId);
        }
        public bool UpdateOrderCollectStatusBatch(int[] orderIds, int collectStatus, int optId)
        {
            return LoanProductOrderManager.UpdateOrderCollectStatusBatch(orderIds, collectStatus, optId);
        }
        public CreditCountDto GetIsRemindCount(int optId)
        {
            return LoanProductOrderManager.GetIsRemindCount(optId);
        }
        /// <summary>
        /// 获取批量划扣的当月信息
        /// </summary>
        /// <param name="pageNum">页码</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="orderId">订单编号</param>
        /// <returns></returns>
        public PagedList<CreditCriticalAmountListDto> GetCriticalAmountList(int pageNum, int pageSize, int orderId = 0)
        {
            return LoanProductOrderManager.GetCriticalAmountList(pageNum, pageSize, orderId);
        }

        /// <summary>
        /// 获取信贷财务信息导出数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CreditFinancialExportExcleDto[] GetCreditFinancialExportExcleList(CreditFinancialExportExcleRequest model)
        {
            return LoanProductOrderManager.GetCreditFinancialExportExcleList(model);
        }


        /// <summary>
        /// 根据订单编号查询订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public LoanOrderDetailDto GetOrderInfoByOrderId(int orderId)
        {
            return LoanProductOrderManager.GetOrderInfoByOrderId(orderId);
        }
        /// <summary>
        ///获取违约逾期报表
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public List<CreditOverdueExcelDto> GetOverdueExcelList(CreditOverdueSearchRequest overdueSearchRequest)
        {
            return LoanProductOrderManager.GetOverdueExcelList(overdueSearchRequest);
        }
    }
}
