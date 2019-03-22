using Dscf.CarLoan.Domain;
using Dscf.CarLoan.Dto;
using Dscf.Common.Manager.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.CarLoan.Dto.Extension;
using System.Data;
using Dscf.CarLoan.Dao.Context;
using Dscf.CarLoan.Dao;
using Dscf.PostLoan.Model;
using Dscf.PostLoanGlobal;

namespace Dscf.CarLoan.Manager.Implement
{
    /// <summary>
    /// 车贷-订单信息
    /// </summary>
    public class LoanProductOrderManager : GenericManagerBase<LoanProductOrder>, ILoanProductOrderManager
    {
        public ILoanMonthRepayRepository LoanMonthRepayRepository { get; set; }
        public IUserWorkInfoRepository UserWorkInfoRepository { get; set; }
        public ILobbyInfoRepository LobbyInfoRepository { get; set; }
        public IDictionaryRepository DictionaryRepository { get; set; }
        public ICarLoanExtensionApplyRepository CarLoanExtensionApplyRepository { get; set; }
        public ICarLoanExtensionRepository CarLoanExtensionRepository { get; set; }
        public ICarLoanConfigRepository CarLoanConfigRepository { get; set; }

        public LoanProductOrderManager(ILoanProductOrderRepository repository, ILoanMonthRepayRepository loanMonthRepayRepository, IUserWorkInfoRepository userWorkInfoRepository)
        {
            this.CurrentRepository = repository;
            this.LoanMonthRepayRepository = loanMonthRepayRepository;
            this.UserWorkInfoRepository = userWorkInfoRepository;
        }


        /// <summary>
        /// 车贷借款信息分页
        /// </summary>
        /// <param name="loanSearchaRequest"></param>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedList<LoanProductOrderDto> SelectLoanProductOrderList(LoanSearchaRequest loanSearchaRequest)
        {
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    loanSearchaRequest.SignSities = client.GetDeptSignSitiesById(loanSearchaRequest.OptId);
                }
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                return repository.SelectLoanProductOrderList(loanSearchaRequest);
            }
            return null;

        }
        /// <summary>
        /// 根据订单编号查询车贷借款详细信息附加展期
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public LoanProductExtensionOrderDto GetLoanProductExtensionOrderByOrderId(int orderId)
        {
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                return repository.GetLoanProductExtensionOrderByOrderId(orderId);
            }
            return null;
        }
        /// <summary>
        /// 根据订单编号查询订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public LoanProductOrderDto GetLoanProductOrderInfoByOrderId(int orderId)
        {
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                return repository.GetLoanProductOrderByOrderId(orderId);
            }
            return null;
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
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                return repository.GetRepayRemindList(RepayIdArray);
            }
            return null;

        }

        /// <summary>
        /// 还款提醒分页
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <param name="isLongLoan"></param>
        /// <returns></returns>
        public PagedList<CarRemindListDto> GetPageRepayRemindList(int pageNum, int pageSize, bool isLongLoan, int optId)
        {
            string[] signSities;
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    signSities = client.GetDeptSignSitiesById(optId);
                }
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                PagedList<CarRemindListDto> pagedList = repository.GetPageRepayRemindList(pageNum, pageSize, isLongLoan, signSities, optId);

                //来自UserCenter的车贷催收人员列表
                Dto.DscfACService.OperaterInfoDto[] collectorList;

                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    collectorList = client.GetCollectorListByRole(new int[] { RoleUtil.CarLoanCollectorRole });
                }

                Dto.DscfACService.OperaterInfoDto[] optDtoArray;

                var optIdArray = pagedList.CurrentPageItems.Select(remind => remind.OperateId.HasValue ? remind.OperateId.Value : -1).Distinct().ToArray();

                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    optDtoArray = client.GetOperaterInfoList(optIdArray);
                }

                if (collectorList != null)
                {
                    foreach (CarRemindListDto dto in pagedList.CurrentPageItems)
                    {
                        if (dto.RemindText == null)
                        { dto.RemindText = "等待提醒"; }


                        ////判断 CarLoanConfig 表中 车贷类别是否是可展期的，如果是则查询订单的展期申请信息（押车30天和GPS30天是可展期的）
                        //if (dto.IsCanExtension == true)
                        //{
                        //    //查询展期申请信息
                        //    var extensionApply = this.CarLoanExtensionApplyRepository.Entities.Where(e => e.LoanProductOrerId == dto.OrderId).FirstOrDefault();
                        //    if (extensionApply != null)
                        //    {
                        //        dto.IsHasExtension = false;
                        //    }
                        //}

                        //查询展期信息
                        var extension = this.CarLoanExtensionRepository.Entities.Where(e => e.NewProductOrderId == dto.OrderId);

                        Dto.DscfACService.OperaterInfoDto createOptDto = optDtoArray.Where(opt => opt.Id == dto.OperateId).FirstOrDefault();
                        if (createOptDto != null)
                        {
                            dto.SignCity = createOptDto.Department.SignCity;
                            foreach (var collector in collectorList)
                            {
                                var dept = collector.SupportDeptList.Where(dp => dp.Id == createOptDto.Department.Id).FirstOrDefault();
                                if (dept != null)
                                {
                                    dto.CollectorName += (" " + collector.Name);
                                    continue;
                                }
                            }
                        }

                    }
                }
                return pagedList;
            }
            throw new Exception(string.Format("数据访问对象类型不正确,应为ILoanProductOrderRepository，实际为 {0}!", this.CurrentRepository.GetType().Name));
        }


        /// <summary>
        /// 查询车贷还款提醒的详细信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="repayId"></param>
        /// <returns></returns>
        public CarRemidDetailDto GetCarRemindDetail(int orderId, int repayId)
        {
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                LoanProductOrderDto loanOrder = repository.GetCarLoanRemindByOrderId(orderId);
                LoanMonthRepay monthRepay = this.LoanMonthRepayRepository.GetByKey(repayId);

                if (loanOrder == null)
                {
                    throw new NullReferenceException(string.Format("没有找到编号为{0}的车贷借款订单!", orderId));
                }

                CarRemidDetailDto dto = new CarRemidDetailDto()
                {
                    Name = loanOrder.Name,
                    DeductBankAccount = loanOrder.BankCard,
                    IDCard = loanOrder.IDCard,
                    DeductBankName = loanOrder.BankName,
                    DeductBranchBank = loanOrder.SubBranchName,
                    ContractNumber = loanOrder.Contract,
                    Amount = loanOrder.Amount,
                    SignDate = loanOrder.SignDate,
                    Term = loanOrder.Term,
                    MonthRepay = monthRepay.MonthRepay,
                    RepayDate = monthRepay.RepayDate,
                    EmergLinkManName1 = loanOrder.CertifyName,
                    EmergLinkManRel1 = loanOrder.CertifyTel,
                    EmergLinkManPhone1 = loanOrder.CertifyRelation,
                    EmergLinkManName2 = loanOrder.CertifyName2,
                    EmergLinkManRel2 = loanOrder.CertifyTel2,
                    EmergLinkManPhone2 = loanOrder.CertifyRelation2,
                    CompanyName = loanOrder.CompanyName,
                    CompanyTel = loanOrder.CompanyTel
                };
                return dto;
            }

            return null;
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
            string[] signSities;
            int? collectTypeId;
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    signSities = client.GetDeptSignSitiesById(optId);
                    collectTypeId = client.GetOperaterInfoByID(optId).CollectionTypeId;
                }
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                //获取车贷逾期数据
                PagedList<CarOverdueListDto> pagedList = repository.GetPageOverdueList(pageNum, pageSize, isLongLoan, signSities, optId, collectTypeId);

                //来自UserCenter的信贷催收人员列表
                Dto.DscfACService.OperaterInfoDto[] collectorList;

                //债权状态类型
                Dto.DscfACService.DictionaryDto[] collectionTypeList;
                Dto.DscfACService.DictionaryDto[] orderCollectStatusList;
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    collectorList = client.GetCollectorListByRole(new int[] { RoleUtil.CarLoanCollectorRole });
                    collectionTypeList = client.GetDictListByKey(DictUtil.CollectionTypeKey);
                    orderCollectStatusList = client.GetDictListByKey(DictUtil.OrderCollectStatusKey);

                }

                //获取车贷逾期里借款信息订单的创建操作员列表
                Dto.DscfACService.OperaterInfoDto[] optDtoArray;
                var optIdArray = pagedList.CurrentPageItems.Select(remind => remind.OperateId.HasValue ? remind.OperateId.Value : -1).Distinct().ToArray();
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    optDtoArray = client.GetOperaterInfoList(optIdArray);
                }

                if (collectorList != null && collectionTypeList != null && orderCollectStatusList != null)
                {
                    foreach (CarOverdueListDto dto in pagedList.CurrentPageItems)
                    {
                        //根据车贷的创建操作员信息 在 用户中心查询其操作员相关信息
                        Dto.DscfACService.OperaterInfoDto createOptDto = optDtoArray.Where(opt => opt.Id == dto.OperateId).FirstOrDefault();
                        if (createOptDto != null)
                        {
                            dto.SignCity = createOptDto.Department.SignCity;
                            foreach (var collector in collectorList)
                            {
                                if (dto.CarLoanStatus == collector.CollectionTypeId)
                                {
                                    var dept = collector.SupportDeptList.Where(dp => dp.Id == createOptDto.Department.Id).FirstOrDefault();

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
                        if (dto.DeptOptId != null)
                        {
                            dto.CollectorName = (collectorList.Where(col => col.Id == dto.DeptOptId).FirstOrDefault().Name);
                        }
                        var collectionType = collectionTypeList.Where(dict => dict.DictValue == dto.CarLoanStatus).FirstOrDefault();
                        if (collectionType != null)
                        {
                            dto.CarLoanStatusName = collectionType.DictMemo;
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
            return null;
        }


        /// <summary>
        /// 查询借款产品订单详情
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public CarLoanOrderDetailDto GetLoanProductOrderDetail(int orderId)
        {
            Dto.DscfACService.OperaterInfoDto opt;
            Dto.DscfACService.OperaterInfoDto[] collectorList;
            LoanProductOrder loanOrder = this.CurrentRepository.Entities.Include("LoanMonthRepayList").Include("ContractFormationList").Include("UserInfo").Include("UserInfo.UserWorkInfo")
              .Where(order => order.ProductOrderId == orderId && (order.IsEnable == 1 && order.IsDelete == 0)).FirstOrDefault();

            LobbyInfo lobbyInfo = this.LobbyInfoRepository.Entities.Include("SignedInfo").Include("CarInfo").Include("FaceTrialInfo").Where(lobby => lobby.NewOrderId == orderId && (lobby.IsEnable == 1 && lobby.IsDelete == 0)).FirstOrDefault();

            lobbyInfo.FaceTrialInfo.CarLoanConfig = this.CarLoanConfigRepository.Entities.Where(cc => cc.ConfigId == lobbyInfo.FaceTrialInfo.ProductTypeId).FirstOrDefault();

            loanOrder.LobbyInfo = lobbyInfo;

            //loanOrderDetailDto.SignCity = lobbyInfo.SignCity;

            var loanOrderDetailDto = loanOrder.ToModel();
            var userDto = loanOrderDetailDto.UserInfo;
            userDto.EducationText = this.DictionaryRepository.GetDictMemoByType(DictUtil.CarEducationKey, loanOrder.UserInfo.Education);
            userDto.MaritalTypeText = this.DictionaryRepository.GetDictMemoByType(DictUtil.CarMaritalStatusKey, loanOrder.UserInfo.Marital);
            userDto.ResideTypeText = this.DictionaryRepository.GetDictMemoByType(DictUtil.CarResideTypeKey, loanOrder.UserInfo.ResideType);

            using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
            {
                collectorList = client.GetCollectorListByRole(new int[] { RoleUtil.CarLoanCollectorRole });
            }
            if (loanOrder.OperateId != null)
            {
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    opt = client.GetOperaterInfoByID(Convert.ToInt32(loanOrder.OperateId));
                    if (opt != null)
                    {
                        loanOrderDetailDto.SignCity = opt.Department.SignCity;
                    }
                }
                foreach (var collector in collectorList)
                {
                    var dept = collector.SupportDeptList.Where(dp => dp.Id == opt.Department.Id).FirstOrDefault();

                    if (dept != null)
                    {
                        loanOrderDetailDto.CollectorName = collector.Name;
                        break;
                    }
                }
            }
            if (loanOrder.DeptOptId != null)
            {
                loanOrderDetailDto.CollectorName = collectorList.Where(col => col.Id == loanOrder.DeptOptId).FirstOrDefault().Name;
            }
            return loanOrderDetailDto;
        }
        public bool EditLoanOrderReminderByOrderId(int orderId, int deptOptId)
        {
            LoanProductOrder loanProductOrder = this.CurrentRepository.Entities.Where(loOrder => loOrder.ProductOrderId == orderId).FirstOrDefault();
            loanProductOrder.DeptOptId = deptOptId;
            return this.CurrentRepository.Update(loanProductOrder) > 0 ? true : false;
        }

        public PagedList<CarOverdueListDto> GetPageDeductApprovalList(int pageNum, int pageSize, int[] keyList)
        {
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                //获取车贷逾期数据
                PagedList<CarOverdueListDto> pagedList = repository.GetPageDeductApprovalList(pageNum, pageSize, keyList);

                //来自UserCenter的信贷催收人员列表
                Dto.DscfACService.OperaterInfoDto[] collectorList;
                //债券状态类型
                Dto.DscfACService.DictionaryDto[] collectionTypeList;
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    collectorList = client.GetCollectorListByRole(new int[] { RoleUtil.CarLoanCollectorRole });
                    collectionTypeList = client.GetDictListByKey(DictUtil.CollectionTypeKey);
                }

                //获取车贷逾期里借款信息订单的创建操作员列表
                Dto.DscfACService.OperaterInfoDto[] optDtoArray;
                var optIdArray = pagedList.CurrentPageItems.Select(remind => remind.OperateId.HasValue ? remind.OperateId.Value : -1).Distinct().ToArray();
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    optDtoArray = client.GetOperaterInfoList(optIdArray);
                }

                if (collectorList != null && collectionTypeList != null)
                {
                    foreach (CarOverdueListDto dto in pagedList.CurrentPageItems)
                    {
                        //根据车贷的创建操作员信息 在 用户中心查询其操作员相关信息
                        Dto.DscfACService.OperaterInfoDto createOptDto = optDtoArray.Where(opt => opt.Id == dto.OperateId).FirstOrDefault();
                        if (createOptDto != null)
                        {
                            dto.SignCity = createOptDto.Department.SignCity;
                            foreach (var collector in collectorList)
                            {
                                if (dto.CarLoanStatus == collector.CollectionTypeId)
                                {
                                    var dept = collector.SupportDeptList.Where(dp => dp.Id == createOptDto.Department.Id).FirstOrDefault();

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
                        if (dto.DeptOptId != null)
                        {
                            dto.CollectorName = (collectorList.Where(col => col.Id == dto.DeptOptId).FirstOrDefault().Name);
                        }
                        var collectionType = collectionTypeList.Where(dict => dict.DictValue == dto.CarLoanStatus).FirstOrDefault();
                        if (collectionType != null)
                        {
                            dto.CarLoanStatusName = collectionType.DictMemo;
                        }
                    }
                }

                return pagedList;
            }
            return null;
        }
        public bool UpdateOrderCollectStatus(int orderId, int collectStatus, int optId)
        {
            var entity = this.CurrentRepository.Entities.Where(order => order.ProductOrderId == orderId && order.IsDelete != 1).FirstOrDefault();
            entity.LastOperateId = optId;
            entity.CollectStatus = collectStatus;
            entity.LastUpdateTime = DateTime.Now;
            return this.CurrentRepository.Update(entity) > 0 ? true : false;
        }
        public bool UpdateOrderCollectStatusBatch(int[] orderIds, int collectStatus, int optId)
        {
            foreach (var orderId in orderIds)
            {
                var entity = this.CurrentRepository.Entities.Where(order => order.ProductOrderId == orderId && order.IsDelete != 1).FirstOrDefault();
                entity.LastOperateId = optId;
                entity.CollectStatus = collectStatus;
                entity.LastUpdateTime = DateTime.Now;
                this.CurrentRepository.Update(entity, false);
            }
            this.CurrentRepository.UnitOfWork.Commit();
            return true;
        }
        public CarCountDto GetIsRemindCount(bool isLongLoan, int optId)
        {
            string[] signSities;
            var repository = (ILoanProductOrderRepository)this.CurrentRepository;
            using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
            {
                signSities = client.GetDeptSignSitiesById(optId);
            }

            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                repository = (ILoanProductOrderRepository)this.CurrentRepository;
                return repository.GetIsRemindCount(isLongLoan, signSities, optId);
            }
            return null;
        }
        /// <summary>
        /// 获取当月待划扣的月还信息
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PagedList<CarLoanBatchDeductDto> GetPageCarLoanBatchDeductList(int pageNum, int pageSize)
        {
            var repository = (ILoanProductOrderRepository)this.CurrentRepository;
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                Dto.DscfACService.DictionaryDto[] codeList;
                repository = (ILoanProductOrderRepository)this.CurrentRepository;
                var datas = repository.GetPageCarLoanBatchDeductList(pageNum, pageSize);
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    codeList = client.GetDictListByKey(DictUtil.CICCCodeKey);
                }
                foreach (var data in datas.CurrentPageItems)
                {
                    if (data.PaymentType == PaymentUtil.CICC)
                    {
                        data.CodeName = codeList.Where(code => (code.DictValue.ToString() == data.Code)).FirstOrDefault() == null ? "等待划扣" : codeList.Where(code => (code.DictValue.ToString() == data.Code)).FirstOrDefault().DictMemo;
                    }
                    else
                    {
                        data.CodeName = data.Code == "0000" ? "提交成功" : (data.Code == "00" ? "回款成功" : (data.Code == "10" ? "处理中" : (data.Code == "20" ? "划扣失败" : "等待划扣")));
                    }
                }
                return datas;
            }
            return null;
        }
        /// <summary>
        /// 获取违约逾期报表
        /// </summary>
        /// <param name="overdueSearchRequest"></param>
        /// <returns></returns>
        public List<CarOverdueExcelDto> GetOverdueExcelList(OverdueSearchRequest overdueSearchRequest)
        {
            var repository = (ILoanProductOrderRepository)this.CurrentRepository;


            if (overdueSearchRequest.DeptId != null)
            {
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    overdueSearchRequest.City = client.GetDeptByDeptID(Convert.ToInt32(overdueSearchRequest.DeptId)).SignCity;
                }
            }
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                var list = repository.GetOverdueExcelList(overdueSearchRequest);
                foreach (var item in list)
                {
                    item.MonthProfit = AmountUtil.GetMonthly(item.Amount, item.MonthRate);
                    item.ComplexTotal = AmountUtil.GetTotalServiceCharge(item.CarLoanTypeName, item.Amount, item.MonthRateTotal, item.ToalPeriod);
                    item.Consultancy = AmountUtil.GetConsultationFee(item.ComplexTotal);
                    item.AuditFees = AmountUtil.GetAuditFee(item.ComplexTotal);
                    item.ServicesFees = AmountUtil.GetServiceCharge(item.ComplexTotal, item.Consultancy, item.AuditFees);
                    item.CollectionFeeLimit = AmountUtil.GetCollectionFeeLimit();
                    item.PaidFee = AmountUtil.GetCollectionFeeLimit();


                    item.ParkingFee = AmountUtil.GetParkingFee(item.CarLoanTypeName);//获取停车费
                    item.GPSInstallationFee = AmountUtil.GetGPSInstallationFee(item.CarLoanTypeName, item.Amount);//获取GPS安装费
                    item.InitialExpenses = AmountUtil.GetInitialExpenses(item.ComplexTotal, item.PaidFee, item.GPSInstallationFee, item.ParkingFee, item.Margin);//获取前期费用
                    item.TrafficCharges = AmountUtil.GetTrafficCharges(item.CarLoanTypeName);//获取流量费
                    item.MonthRepayPrincipal = AmountUtil.GetMonthAlsoPrincipal(item.Amount, item.CarLoanTypeName, item.ToalPeriod);//获取月还本金
                    item.EqualMonthlyReturn = AmountUtil.GetEqualMonthlyReturn(item.Amount, item.CarLoanTypeName, item.ToalPeriod, item.MonthProfit);//获取等额月还
                    item.TheSameMonth = AmountUtil.GetTheSameMonth(item.MonthRepayPrincipal, item.MonthProfit, item.TrafficCharges, item.ParkingFee, item.CarLoanTypeName);//获取实际月还
                    item.TotalShouldRepaid = AmountUtil.GetTotalShouldRepaid(item.CarLoanTypeName, item.TheSameMonth, item.ToalPeriod);//累计应还款总额
                    item.DiscountPerformance = AmountUtil.GetDiscountPerformance(item.CarLoanTypeName, item.Amount);//获取折标业绩
                    item.Margin = AmountUtil.GetMargin(item.CarLoanTypeName, item.Amount);///获取保证金

                    item.DailyPenalties = item.OverDueDays * item.DailyPenalty;
                    item.TermTotal = item.DailyPenalties + item.OverduePenalty + item.MonthRepay;
                    item.TermAmountOwed = item.ActualDeductAmount - item.TermTotal;
                }
                return list;
            }

            else
            { return null; }
        }
        /// <summary>
        /// 车贷财务报表的Excle数据读取
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CarFinancialExportExcleDto[] GetCarFinancialExportExcleList(CarFinancialExportExcleRequest model)
        {
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                var repository = (ILoanProductOrderRepository)this.CurrentRepository;
                var financialExportExcleList = repository.GetCarFinancialExportExcleList(model);
                LoanMonthRepayManager LoanMonthRepayManager = new LoanMonthRepayManager(LoanMonthRepayRepository);
                var loan_MonthRepayInfoArray = LoanMonthRepayManager.GetLoanMonthRepayInfoByOrderId();
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    var operaterInfoList = client.GetOperaterInfoLists();
                    if (financialExportExcleList != null && financialExportExcleList.Count() > 0)
                    {
                        foreach (var item in financialExportExcleList)
                        {
                            var loan_MonthRepayInfoList = loan_MonthRepayInfoArray.Where(loa => loa.LoanOrderId == item.OrderId);
                            #region 数据处理
                            item.FirstRepaymentDate = AmountUtil.GetFirstRepaymentDate(item.Term, item.ActualLenderDate);//首次还款日期
                            item.LastRepaymentDate = AmountUtil.GetLastRepaymentDate(item.Term, item.FirstRepaymentDate);//末次还款日期
                            item.CalculateMonthStr = DateTime.Now.ToShortDateString();//核算月份
                            item.SignDateStr = item.SignDate.HasValue ? item.SignDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";//面签时间
                            item.FirstRepaymentDateStr = item.FirstRepaymentDate.HasValue ? item.FirstRepaymentDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";//首次还款日期
                            item.LastRepaymentDateStr = item.LastRepaymentDate.HasValue ? item.LastRepaymentDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";//末次还款日期
                            item.ActualLenderDateStr = item.ActualLenderDate.HasValue ? item.ActualLenderDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";//实际放款日期
                            item.DateOfLastJournalStr = item.DateOfLastJournal.HasValue ? item.DateOfLastJournal.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";//上日报日期
                            item.ServiceRate = AmountUtil.GetServiceRate(item.ProductName);
                            item.MonthlyRate = AmountUtil.MonthlyRate;//月利率
                            item.TotalServiceCharge = AmountUtil.GetTotalServiceCharge(item.ProductName, item.Amount, item.ServiceRate, item.Term);//获取总服务费
                            item.Monthly = AmountUtil.GetMonthly(item.Amount, item.MonthlyRate);//月利
                            item.AuditFee = AmountUtil.GetAuditFee(item.TotalServiceCharge);//获取审核费
                            item.ConsultationFee = AmountUtil.GetConsultationFee(item.TotalServiceCharge);//获取咨询费
                            item.ServiceCharge = AmountUtil.GetServiceCharge(item.TotalServiceCharge, item.ConsultationFee, item.AuditFee);//获取服务费
                            item.Margin = AmountUtil.GetMargin(item.ProductName, item.Amount);//获取保证金
                            item.CollectionFeeLimit = AmountUtil.GetCollectionFeeLimit();//获取代收手续费上限
                            item.ParkingFee = AmountUtil.GetParkingFee(item.ProductName);//获取停车费
                            item.GPSInstallationFee = AmountUtil.GetGPSInstallationFee(item.ProductName, item.Amount);//获取GPS安装费
                            item.InitialExpenses = AmountUtil.GetInitialExpenses(item.TotalServiceCharge, item.PaidFee, item.GPSInstallationFee, item.ParkingFee, item.Margin);//获取前期费用
                            item.TrafficCharges = AmountUtil.GetTrafficCharges(item.ProductName);//获取流量费
                            item.MonthAlsoPrincipal = AmountUtil.GetMonthAlsoPrincipal(item.Amount, item.ProductName, item.Term);//获取月还本金
                            item.EqualMonthlyReturn = AmountUtil.GetEqualMonthlyReturn(item.Amount, item.ProductName, item.Term, item.Monthly);//获取等额月还
                            item.TheSameMonth = AmountUtil.GetTheSameMonth(item.MonthAlsoPrincipal, item.Monthly, item.TrafficCharges, item.ParkingFee, item.ProductName);//获取实际月还
                            item.TotalShouldRepaid = AmountUtil.GetTotalShouldRepaid(item.ProductName, item.TheSameMonth, item.Term);//累计应还款总额
                            item.DiscountPerformance = AmountUtil.GetDiscountPerformance(item.ProductName, item.Amount);//获取折标业绩
                            item.IsExpire = AmountUtil.GetIsExpire(item.LastRepaymentDate);//是否已到期
                            item.RepaymentPeriod = AmountUtil.GetRepaymentPeriod(item.FirstRepaymentDate);//获取应还款期数
                            item.AccumulatedAmount = loan_MonthRepayInfoList.Where(loa => loa.IsDeductSucess == true).Sum(loa => loa.TotalPricipalInterest) + loan_MonthRepayInfoList.Where(loa => loa.IsDeductSucess == false).Sum(loa => loa.ActualDeductAmount);//已还款总额
                            item.CumulativeReturnPeriod = loan_MonthRepayInfoList.Where(loa => loa.IsDeductSucess == true).Count();//已还款期数
                            item.RemainingPeriod = AmountUtil.GetRemainingPeriod(item.Term, item.CumulativeReturnPeriod);//剩余期数
                            item.SurplusPrincipal = AmountUtil.GetSurplusPrincipal(item.Amount, item.Term, item.RemainingPeriod);//月利
                            item.PrepaymentPenalty = AmountUtil.GetPrepaymentPenalty(item.RepaymentPeriod, item.Term, item.ProductName, item.Amount);//获取提前还款违约金
                            item.PrepaymentAmount = AmountUtil.GetPrepaymentAmount(item.RemainingPeriod, item.ProductName, item.Monthly, item.SurplusPrincipal, item.Margin, item.TrafficCharges, item.Amount, item.PrepaymentPenalty);//月利
                            #endregion
                        }
                    }
                }
                return financialExportExcleList.ToArray();
            }
            throw new Exception(string.Format("数据访问对象类型不正确,应为ILoanProductOrderRepository，实际为 {0}!", this.CurrentRepository.GetType().Name));
        }
        /// <summary>
        /// 获取待划款订单
        /// </summary>
        /// <returns></returns>
        public List<CarLoanBatchDeductDto> GetCarLoanBatchDeductList()
        {
            var repository = (ILoanProductOrderRepository)this.CurrentRepository;
            if (this.CurrentRepository is ILoanProductOrderRepository)
            {
                repository = (ILoanProductOrderRepository)this.CurrentRepository;
                var datas = repository.GetCarLoanBatchDeductList();
                return datas;
            }
            return null;
        }


        /// <summary>
        /// 查询月单条利率
        /// </summary>
        /// <param name="list"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        private CarLoanConfig MonthR(List<CarLoanConfig> list, int? ProductTypeId)
        {
            CarLoanConfig model = new CarLoanConfig();
            if (ProductTypeId == null)
            {
                return model;
            }
            model = (from p in list where p.LoanTypeId == ProductTypeId select p).FirstOrDefault();
            if (model == null)
            {
                model = new CarLoanConfig();
            }
            return model;
        }

        /// <summary>
        /// 产品名称
        /// </summary>
        /// <param name="list"></param>
        /// <param name="FacModel"></param>
        /// <returns></returns>
        private string ProductName(List<CarLoanConfig> list, int? ProductTypeId)
        {
            string str = "";

            if (ProductTypeId == null)
            {
                return str;
            }

            CarLoanConfig model = (from p in list where p.LoanTypeId == ProductTypeId select p).FirstOrDefault();
            if (model != null)
            {
                str = model.CarLoanTypeName;
            }
            return str;
        }
    }
}
