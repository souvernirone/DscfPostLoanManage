using Dscf.Common.Manager.Implement;
using Dscf.CreditLoan.Dao;
using Dscf.CreditLoan.Domain;
using Dscf.CreditLoan.Dto;
using Dscf.CreditLoan.Dto.Extension;
using Dscf.PostLoanGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.CreditLoan.Manager.Implement
{
    public class LoanProductOrderManager : GenericManagerBase<LoanProductOrder>, ILoanProductOrderManager
    {

        public ILoanProductOrderRepository LoanProductOrderRepository { get; set; }
        public ILoan_MonthRepayRepository LoanMonthRepayRepository { get; set; }
        public IUserInfoRepository UserInfoRepository { get; set; }
        public LoanProductOrderDto[] GetLoanProductOrderByUserId(int userId)
        {
            var orderList = this.CurrentRepository.Entities.Where(o => o.UserId == userId).ToList();

            return orderList.Select(opt => new LoanProductOrderDto { UserId = userId }).ToArray();
        }

        /// <summary>
        /// 获取信贷信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public PagedList<LoanInfoDto> GetPageLoanInfoList(LoanSearchViewModel LoanSearchViewModel)
        {
            using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
            {
                LoanSearchViewModel.DeptIds = client.GetDeptIdsById(LoanSearchViewModel.OptId);
            }
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                return repository.GetPageLoanInfoList(LoanSearchViewModel);
            }

            throw new Exception(string.Format("数据访问对象类型不正确,应为ILoanProductOrderRepository，实际为 {0}!", this.CurrentRepository.GetType().Name));
        }
        public CreditRemindListDto[] GetRepayRemindList(string RepayIdArray)
        {
            var repository = (ILoanProductOrderRepository)this.CurrentRepository;
            return repository.GetRepayRemindList(RepayIdArray);
        }
        public PagedList<CreditRemindListDto> GetPageRepayRemindList(int pageNum, int pageSize, int optId)
        {
            int[] deptIds;
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    deptIds = client.GetDeptIdsById(optId);
                }
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                PagedList<CreditRemindListDto> pagedList = repository.GetPageRepayRemindList(pageNum, pageSize, deptIds, optId);

                //来自UserCenter的信贷催收人员列表
                Dto.DscfACService.OperaterInfoDto[] collectorList;

                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    collectorList = client.GetCollectorListByRole(new int[] { RoleUtil.CreditLoanCollectorRole });
                }

                if (collectorList != null)
                {
                    foreach (CreditRemindListDto dto in pagedList.CurrentPageItems)
                    {
                        foreach (var collector in collectorList)
                        {
                            var dept = collector.SupportDeptList.Where(dp => dp.Id == dto.OptDeptId).FirstOrDefault();
                            if (dept != null)
                            {
                                dto.CollectorName += (" " + collector.Name);
                                continue;
                            }
                        }
                    }
                }
                return pagedList;
            }
            throw new Exception(string.Format("数据访问对象类型不正确,应为ILoanProductOrderRepository，实际为 {0}!", this.CurrentRepository.GetType().Name));
        }


        public CreditRemidDetailDto GetCreditRemindDetail(int orderId, int repayId)
        {
            LoanProductOrder loanOrder = this.CurrentRepository.Entities.Include("UserInfo.UserFamilyInfo")
                .Include("UserInfo.UserWorkInfo").Include("OperaterInfo.DepartmentInfo")
                .Where(order => order.OrderId == orderId).FirstOrDefault();
            Loan_MonthRepay monthRepay = this.LoanMonthRepayRepository.GetByKey(repayId);

            if (loanOrder == null)
            {
                throw new NullReferenceException(string.Format("没有找到编号为{0}的信用借款订单!", orderId));
            }

            UserFamilyInfo familyInfo = loanOrder.UserInfo.UserFamilyInfo;

            CreditRemidDetailDto dto = new CreditRemidDetailDto()
            {
                Name = loanOrder.UserInfo.Name,
                DeductBankAccount = loanOrder.DeductBankAccount,
                IDCard = loanOrder.UserInfo.IDCard,
                DeductBankName = loanOrder.DeductBankName,
                DeductBranchBank = loanOrder.DeductBranchBank,
                ContractNumber = ContractUtil.GenerateContractNumber(loanOrder),
                Amount = loanOrder.Amount,
                SignDate = loanOrder.SignDate,
                Term = loanOrder.Term,
                MonthRepay = monthRepay.MonthRepay,
                EmergLinkManName1 = familyInfo.EmergLinkManName1,
                EmergLinkManRel1 = familyInfo.EmergLinkManRel1,
                EmergLinkManPhone1 = familyInfo.EmergLinkManPhone1,
                EmergLinkManName2 = familyInfo.EmergLinkManName2,
                EmergLinkManRel2 = familyInfo.EmergLinkManRel2,
                EmergLinkManPhone2 = familyInfo.EmergLinkManPhone2
            };

            return dto;
        }

        /// <summary>
        ///获取信贷逾期客户信息分页数据
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public PagedList<CreditOverdueListDto> GetPageOverdueList(int pageNum, int pageSize, int optId)
        {
            int[] deptIds;
            int? collectTypeId;
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    deptIds = client.GetDeptIdsById(optId);
                    collectTypeId = client.GetOperaterInfoByID(optId).CollectionTypeId;
                }
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                PagedList<CreditOverdueListDto> pagedList = repository.GetPageOverdueList(pageNum, pageSize, deptIds, optId, collectTypeId);
                //来自UserCenter的信贷催收人员列表
                Dto.DscfACService.OperaterInfoDto[] collectorList;
                Dto.DscfACService.DictionaryDto[] collectionTypeList;
                Dto.DscfACService.DictionaryDto[] orderCollectStatusList;

                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    collectorList = client.GetCollectorListByRole(new int[] { RoleUtil.CreditLoanCollectorRole });
                    collectionTypeList = client.GetDictListByKey(DictUtil.CollectionTypeKey);
                    orderCollectStatusList = client.GetDictListByKey(DictUtil.OrderCollectStatusKey);
                }

                if (collectorList != null && collectionTypeList != null && orderCollectStatusList != null)
                {
                    foreach (CreditOverdueListDto dto in pagedList.CurrentPageItems)
                    {
                        if (dto.DeptOptId != null)
                        {
                            dto.CollectorName = (collectorList.Where(col => col.Id == dto.DeptOptId).FirstOrDefault() == null ? "" : collectorList.Where(col => col.Id == dto.DeptOptId).FirstOrDefault().Name);
                        }
                        else
                        {
                            foreach (var collector in collectorList)
                            {
                                if (dto.CreditStatus == collector.CollectionTypeId)
                                {
                                    var dept = collector.SupportDeptList.Where(dp => dp.Id == dto.OptDeptId).FirstOrDefault();

                                    if (dept != null)
                                    {
                                        dto.CollectorName = collector.Name;
                                        break;
                                    }
                                }
                                else
                                {
                                    continue;
                                }

                            }
                        }
                        var collectionType = collectionTypeList.Where(dict => dict.DictValue == dto.CreditStatus).FirstOrDefault();
                        if (collectionType != null)
                        {
                            dto.CreditStatusName = collectionType.DictMemo;
                        }
                        if (dto.CollectStatus != null)
                        {
                            var orderCollectStatus = orderCollectStatusList.Where(dict => dict.DictValue == dto.CollectStatus).FirstOrDefault();
                            if (orderCollectStatus != null)
                            {
                                dto.CollectStatusName = orderCollectStatus.DictMemo;
                            }
                        }
                        if (dto.CollectStatus == null)
                        {
                            dto.CollectStatusName = "等待催收";
                        }
                    }
                }
                return pagedList;
            }
            throw new Exception(string.Format("数据访问对象类型不正确,应为ILoanProductOrderRepository，实际为 {0}!", this.CurrentRepository.GetType().Name));
        }


        /// <summary>
        /// 查询借款产品订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public LoanOrderDetailDto GetLoanProductOrderDetail(int orderId)
        {
            LoanProductOrder loanOrder = this.CurrentRepository.Entities.Include("UserInfo.UserFamilyInfo")
              .Include("UserInfo.UserWorkInfo").Include("LoanMonthRepayList").Include("OperaterInfo.DepartmentInfo")
              .Where(order => order.OrderId == orderId).FirstOrDefault();

            var loanOrderDetailDto = loanOrder.ToModel();

            var optDept = loanOrder.OperaterInfo.DepartmentInfo;


            //来自UserCenter的信贷催收人员列表
            Dto.DscfACService.OperaterInfoDto[] collectorList;

            using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
            {
                collectorList = client.GetCollectorListByRole(new int[] { RoleUtil.CreditLoanCollectorRole });
            }

            if (collectorList != null)
            {
                foreach (var collector in collectorList)
                {
                    var dept = collector.SupportDeptList.Where(dp => dp.Id == optDept.DepId).FirstOrDefault();
                    if (dept != null)
                    {
                        loanOrderDetailDto.CollectorName = collector.Name;
                        break;
                    }
                }
            }
            loanOrderDetailDto.SignCity = optDept.SignCity;//签署城市
            return loanOrderDetailDto;
        }
        public bool EditLoanOrderReminderByOrderId(int orderId, int deptOptId)
        {
            LoanProductOrder loanProductOrder = this.CurrentRepository.Entities.Where(loOrder => loOrder.OrderId == orderId).FirstOrDefault();
            loanProductOrder.DeptOptId = deptOptId;
            return this.CurrentRepository.Update(loanProductOrder) > 0 ? true : false;
        }

        public PagedList<CreditOverdueListDto> GetPageDeductApprovalList(int pageNum, int pageSize, int[] keyList)
        {
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                PagedList<CreditOverdueListDto> pagedList = repository.GetDeductApprovalList(pageNum, pageSize, keyList);
                //来自UserCenter的信贷催收人员列表
                Dto.DscfACService.OperaterInfoDto[] collectorList;
                Dto.DscfACService.DictionaryDto[] collectionTypeList;

                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    collectorList = client.GetCollectorListByRole(new int[] { RoleUtil.CreditLoanCollectorRole });
                    collectionTypeList = client.GetDictListByKey(DictUtil.CollectionTypeKey);
                }

                if (collectorList != null && collectionTypeList != null)
                {
                    foreach (CreditOverdueListDto dto in pagedList.CurrentPageItems)
                    {
                        if (dto.DeptOptId != null)
                        {
                            dto.CollectorName = (collectorList.Where(col => col.Id == dto.DeptOptId).FirstOrDefault() == null ? "" : collectorList.Where(col => col.Id == dto.DeptOptId).FirstOrDefault().Name);
                        }
                        else
                        {
                            foreach (var collector in collectorList)
                            {
                                if (dto.CreditStatus == collector.CollectionTypeId)
                                {
                                    var dept = collector.SupportDeptList.Where(dp => dp.Id == dto.OptDeptId).FirstOrDefault();

                                    if (dept != null)
                                    {
                                        dto.CollectorName = collector.Name;
                                        break;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        var collectionType = collectionTypeList.Where(dict => dict.DictValue == dto.CreditStatus).FirstOrDefault();
                        if (collectionType != null)
                        {
                            dto.CreditStatusName = collectionType.DictMemo;
                        }
                    }
                }
                return pagedList;
            }
            throw new Exception(string.Format("数据访问对象类型不正确,应为ILoanProductOrderRepository，实际为 {0}!", this.CurrentRepository.GetType().Name));
        }
        public bool UpdateOrderCollectStatus(int orderId, int collectStatus, int optId)
        {
            var entity = this.CurrentRepository.Entities.Where(order => order.OrderId == orderId && order.IsDeleted != 1).FirstOrDefault();
            entity.LastOperateId = optId;
            entity.CollectStatus = collectStatus;
            entity.LastUpdateTime = DateTime.Now;
            return this.CurrentRepository.Update(entity) > 0 ? true : false;
        }
        public bool UpdateOrderCollectStatusBatch(int[] orderIds, int collectStatus, int optId)
        {
            foreach (var orderId in orderIds)
            {
                var entity = this.CurrentRepository.Entities.Where(order => order.OrderId == orderId && order.IsDeleted != 1).FirstOrDefault();
                entity.LastOperateId = optId;
                entity.CollectStatus = collectStatus;
                entity.LastUpdateTime = DateTime.Now;
                this.CurrentRepository.Update(entity, false);
            }
            this.CurrentRepository.UnitOfWork.Commit();
            return true;
        }
        public CreditCountDto GetIsRemindCount(int optId)
        {
            int[] deptIds;
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    deptIds = client.GetDeptIdsById(optId);
                }
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                return repository.GetIsRemindCount(deptIds, optId);
            }
            else return null;

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
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                var criticalAmountList = repository.GetCriticalAmountList(pageNum, pageSize, orderId);
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    var criticalStatusList = client.GetDictListByKey(DictUtil.CICCCodeKey);
                    if (criticalStatusList != null && criticalStatusList.Count() > 0)
                    {
                        foreach (var item in criticalAmountList.CurrentPageItems)
                        {
                            item.CodeName = criticalStatusList.Where(dedu => dedu.DictValue.Value.ToString() == item.Code).FirstOrDefault().DictMemo;
                        }
                    }
                }
                return criticalAmountList;
            }
            throw new Exception(string.Format("数据访问对象类型不正确,应为ILoanProductOrderRepository，实际为 {0}!", this.CurrentRepository.GetType().Name));
        }

        /// <summary>
        /// 获取信贷财务信息导出数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CreditFinancialExportExcleDto[] GetCreditFinancialExportExcleList(CreditFinancialExportExcleRequest model)
        {
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                var financialExportExcleList = repository.GetCreditFinancialExportExcleList(model);
                Loan_MonthRepayManager Loan_MonthRepayManager = new Implement.Loan_MonthRepayManager(LoanMonthRepayRepository);
                var loan_MonthRepayInfoArray = Loan_MonthRepayManager.GetLoan_MonthRepayInfoByorderID();
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    var operaterInfoList = client.GetOperaterInfoLists();
                    if (financialExportExcleList != null && financialExportExcleList.Count() > 0)
                    {

                        foreach (var item in financialExportExcleList)
                        {
                            var teamManagerOperaterInfo = operaterInfoList.Where(opt => opt.Id == item.TeamManager).FirstOrDefault();
                            var customerManagerOperaterInfo = operaterInfoList.Where(opt => opt.Id == item.CustomerManager).FirstOrDefault();
                            #region 数据处理
                            item.SignDateStr = item.SignDate.HasValue ? item.SignDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";//面签日期
                            item.ActualLenderDateStr = item.ActualLenderDate.HasValue ? item.ActualLenderDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";//实际放款日期
                            item.TeamManagerName = teamManagerOperaterInfo == null ? "" : teamManagerOperaterInfo.Name;//团队经理
                            item.CustomerManagerName = customerManagerOperaterInfo == null ? "" : customerManagerOperaterInfo.Name;//客户经理
                            item.PrepaymentDateStr = item.PrepaymentDate.HasValue ? item.PrepaymentDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";//面签日期
                            item.FirstRepaymentDate = AmountUtil.GetFirstRepaymentDate(item.Term, item.ActualLenderDate);//首次还款日期
                            item.FirstRepaymentDateStr = item.FirstRepaymentDate.HasValue ? item.FirstRepaymentDate.Value.ToString("yyyy-MM-dd") : "";//首次还款日期
                            #endregion
                        }
                    }
                }
                return financialExportExcleList.ToArray();
            }
            throw new Exception(string.Format("数据访问对象类型不正确,应为ILoanProductOrderRepository，实际为 {0}!", this.CurrentRepository.GetType().Name));
        }
        /// <summary>
        /// 根据订单编号查询订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public LoanOrderDetailDto GetOrderInfoByOrderId(int orderId)
        {
            LoanProductOrder order = this.CurrentRepository.GetByKey(orderId);
            order.UserInfo = UserInfoRepository.GetByKey(Convert.ToInt32(order.UserId));

            return order.ToModel();
        }
        /// <summary>
        ///获取违约逾期报表
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public List<CreditOverdueExcelDto> GetOverdueExcelList(CreditOverdueSearchRequest overdueSearchRequest)
        {
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                Dto.DscfACService.DictionaryDto[] collectionTypeList;
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                var list = repository.GetOverdueExcelList(overdueSearchRequest);
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    collectionTypeList = client.GetDictListByKey(DictUtil.CollectionTypeKey);
                }
                foreach (var item in list)
                {
                    item.MonthProfit = AmountUtil.GetMonthly(item.Amount, item.MonthRate);
                    item.DailyPenalties = item.OverDueDays * item.DailyPenalty;
                    item.TermTotal = item.DailyPenalties + item.OverduePenalty + item.MonthRepay;
                    var collectionType = collectionTypeList.Where(dict => dict.DictValue == item.CreditStatus).FirstOrDefault();
                    if (collectionType != null)
                    {
                        item.OverdueCondition = collectionType.DictMemo;
                    }
                }
                return list;
            }
            else return null;
        }
    }
}
