using Dscf.CarLoan.Contract;
using Dscf.CarLoan.Domain;
using Dscf.CarLoan.Dto;
using Dscf.CarLoan.Manager;
using Dscf.PostLoanGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dscf.CarLoan.Dto.Extension;

namespace Dscf.CarLoan.Service
{
    public partial class CarLoanService : ICarLoanContract
    {
        public ILoanProductOrderManager LoanProductOrderManager { get; set; }

        /// <summary>
        /// 车贷借款信息分页
        /// </summary>
        /// <param name="loanSearchaRequest"></param>
        /// <returns></returns>
        public PagedList<LoanProductOrderDto> SelectLoanProductOrderList(LoanSearchaRequest loanSearchaRequest)
        {
            return LoanProductOrderManager.SelectLoanProductOrderList(loanSearchaRequest);
        }

        /// <summary>
        /// 根据订单编号查询订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public LoanProductOrderDto GetLoanProductOrderInfoByOrderId(int orderId)
        {
            return LoanProductOrderManager.GetLoanProductOrderInfoByOrderId(orderId);
        }
        /// <summary>
        /// 根据订单编号查询车贷借款详细信息附加展期
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public LoanProductExtensionOrderDto GetLoanProductExtensionOrderByOrderId(int orderId)
        {
            return LoanProductOrderManager.GetLoanProductExtensionOrderByOrderId(orderId);
        }

        public PagedList<CarRemindListDto> GetPageRepayRemindList(int pageNum, int pageSize, bool isLongLoan, int optId)
        {
            return LoanProductOrderManager.GetPageRepayRemindList(pageNum, pageSize, isLongLoan, optId);
        }

        /// <summary>
        /// 查询车贷还款提醒的详细信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="repayId"></param>
        /// <returns></returns>
        public CarRemidDetailDto GetCarRemindDetail(int orderId, int repayId)
        {
            return LoanProductOrderManager.GetCarRemindDetail(orderId, repayId);
        }
        /// <summary>
        /// 还款提醒Excle
        /// </summary>
        /// <param name="loanSearchaRequest"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<CarRemindListDto> GetRepayRemindList(string RepayIdArray)
        {
            return LoanProductOrderManager.GetRepayRemindList(RepayIdArray);

        }
        /// <summary>
        /// 获取车贷逾期客户信息分页数据
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isLongLoan"></param>
        /// <returns></returns>
        public PagedList<CarOverdueListDto> GetPageOverdueList(int pageNum, int pageSize, bool? isLongLoan, int optId)
        {
            return LoanProductOrderManager.GetPageOverdueList(pageNum, pageSize, isLongLoan, optId);
        }

        /// <summary>
        /// 查询借款产品订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public CarLoanOrderDetailDto GetLoanProductOrderDetail(int orderId)
        {
            return LoanProductOrderManager.GetLoanProductOrderDetail(orderId);
        }

        public LoanOrderDto GetLoanProductOrderSingleById(int orderId)
        {
            var order = this.LoanProductOrderManager.GetByKey(orderId);
            return AutoMapper.Mapper.Map<LoanProductOrder, LoanOrderDto>(order);
        }

        public bool UpdateLoanProductOrder(LoanOrderDto orderDto)
        {
            var order = AutoMapper.Mapper.Map<LoanOrderDto, LoanProductOrder>(orderDto);
            var rowCount = this.LoanProductOrderManager.Update(order);
            return rowCount > 0 ? true : false;
        }

        public bool EditLoanOrderReminderByOrderId(int orderId, int deptOptId)
        {
            return LoanProductOrderManager.EditLoanOrderReminderByOrderId(orderId, deptOptId);
        }

        public PagedList<CarOverdueListDto> GetPageDeductApprovalList(int pageNum, int pageSize, int[] keyList)
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
        public CarCountDto GetIsRemindCount(bool isLongLoan, int optId)
        {
            return LoanProductOrderManager.GetIsRemindCount(isLongLoan, optId);
        }
        /// <summary>
        /// 获取当月待划扣的月还信息
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedList<CarLoanBatchDeductDto> GetPageCarLoanBatchDeductList(int pageNum, int pageSize)
        {
            return LoanProductOrderManager.GetPageCarLoanBatchDeductList(pageNum, pageSize);
        }
        /// <summary>
        /// 车贷财务报表的Excle数据读取
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CarFinancialExportExcleDto[] GetCarFinancialExportExcleList(CarFinancialExportExcleRequest model)
        {
            return LoanProductOrderManager.GetCarFinancialExportExcleList(model);
        }
        /// <summary>
        /// 获取待划款订单
        /// </summary>
        /// <returns></returns>
        public List<CarLoanBatchDeductDto> GetCarLoanBatchDeductList()
        {
            return LoanProductOrderManager.GetCarLoanBatchDeductList();
        }
        /// <summary>
        /// 获取违约逾期报表
        /// </summary>
        /// <param name="overdueSearchRequest"></param>
        /// <returns></returns>
        public List<CarOverdueExcelDto> GetOverdueExcelList(OverdueSearchRequest overdueSearchRequest)
        {
            return LoanProductOrderManager.GetOverdueExcelList(overdueSearchRequest);
        }
    }
}
