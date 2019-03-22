using Dscf.Common.Manager.Implement;
using Dscf.LoanAfter.Domain;
using Dscf.LoanAfter.Dto;
using Dscf.LoanAfter.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.LoanAfter.Dto.DscfCarLoanService;
using Dscf.LoanAfter.Dto.DscfCreditLoanService;
using Dscf.PostLoanGlobal;

namespace Dscf.LoanAfter.Manager.Implement
{
    //T_DeductPayApply
    public class DeductPayApplyManager : GenericManagerBase<DeductPayApply>, IDeductPayApplyManager
    {
        public IDeductPayApplyRepository DeductPayApplyRepository { get; set; }
        public DeductPayApplyDto GetDeductPayApplyAndFile(int orderId, int orderType)
        {

            var entity = this.DeductPayApplyRepository.Entities.Include("FileEntity")
                .Where(dePay => dePay.OrderId == orderId && dePay.OrderType == orderType && dePay.IsDeleted != true).OrderByDescending(dePay => dePay.Id).FirstOrDefault();
            var deductPayApplyDto = entity.ToModel();
            using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
            {
                var payWayNameList = client.GetDictListByKey(DictUtil.DeductTypeKey);
                if (payWayNameList != null && payWayNameList.Count() > 0 && deductPayApplyDto != null)
                {
                    deductPayApplyDto.PayWayName = payWayNameList.Where(pay => pay.DictValue == deductPayApplyDto.PayWay).FirstOrDefault().DictMemo;
                }
            }
            return deductPayApplyDto;

        }

        #region 分页查询划扣审核信息

        public PagedList<ApprovalListDto> GetDeductApprovalList(int pageNum, int pageSize)
        {
            IList<int> statusList = new List<int>() { -1 };//只查询-划扣审批状态-"未审批"的借款订单
            var deductPayList = DeductPayApplyRepository.GetPageDeductPayList(pageNum, pageSize, statusList);

            PagedList<ApprovalListDto> result = new PagedList<ApprovalListDto>()
            {
                TotalItemCount = deductPayList.TotalItemCount,
                TotalPageCount = deductPayList.TotalPageCount,
                CurrentPageIndex = deductPayList.CurrentPageIndex,

            };

            var pageItems = new List<ApprovalListDto>();

            #region 车贷

            int[] carKeyArray = deductPayList.CurrentPageItems.Where(pay => pay.OrderType == LoanOrderUtil.CarTypeKey).Select(pay => pay.OrderId.Value).ToArray();
            if (carKeyArray != null && carKeyArray.Length > 0)
            {
                using (var client = new Dto.DscfCarLoanService.CarLoanContractClient())
                {
                    PagedList<CarOverdueListDto> pageList = client.GetPageDeductApprovalList(1, carKeyArray.Length, carKeyArray);
                    var items = pageList.CurrentPageItems;
                    foreach (var item in items)
                    {
                        #region 类型转换
                        ApprovalListDto dto = new ApprovalListDto()
                        {
                            OrderId = item.OrderId,
                            CollectorName = item.CollectorName,
                            SignCity = item.SignCity,
                            OptDeptId = item.OptDeptId,
                            DeptOptId = item.DeptOptId,
                            UserName = item.UserName,
                            SignDate = item.SignDate,
                            OverduePrincipalSum = item.OverduePrincipalSum,
                            FirstOverdueTime = item.FirstOverdueTime,
                            OverdueCount = item.OverdueCount,
                            ProductName = item.ProductName,
                            CreditStatus = item.CarLoanStatus,
                            CreditStatusName = item.CarLoanStatusName,
                            OrderType = LoanOrderUtil.CarTypeKey

                        };
                        #endregion
                        pageItems.Add(dto);
                    }
                }
            }

            #endregion

            #region 信贷

            int[] creditKeyArray = deductPayList.CurrentPageItems.Where(pay => pay.OrderType == LoanOrderUtil.CreditTypeKey).Select(pay => pay.OrderId.Value).ToArray();

            if (creditKeyArray != null && creditKeyArray.Length > 0)
            {
                using (var client = new Dto.DscfCreditLoanService.CreditLoanContractClient())
                {
                    PagedList<CreditOverdueListDto> pageList = client.GetPageDeductApprovalList(1, creditKeyArray.Length, creditKeyArray);//根据划扣状态获取OrderId查询
                    var items = pageList.CurrentPageItems;
                    foreach (var item in items)
                    {
                        #region 类型转换
                        ApprovalListDto dto = new ApprovalListDto()
                        {
                            OrderId = item.OrderId,
                            CollectorName = item.CollectorName,
                            SignCity = item.SignCity,
                            OptDeptId = item.OptDeptId,
                            DeptOptId = item.DeptOptId,
                            UserName = item.UserName,
                            SignDate = item.SignDate,
                            OverduePrincipalSum = item.OverduePrincipalSum,
                            FirstOverdueTime = item.FirstOverdueTime,
                            OverdueCount = item.OverdueCount,
                            ProductName = item.ProductName,
                            CreditStatus = item.CreditStatus,
                            CreditStatusName = item.CreditStatusName,
                            OrderType = LoanOrderUtil.CreditTypeKey

                        };
                        #endregion
                        pageItems.Add(dto);
                    }
                }
            }

            #endregion

            result.CurrentPageItems = pageItems;

            return result;
        }

        #endregion

        #region 获取划扣申请信息
        public PagedList<DeductPayApplyDto> GetPageDeductPayList(int pageNum, int pageSize, int? applyId = null)
        {
            IList<int> statusList = new List<int>() { DeductPayUtil.FailedDebit, DeductPayUtil.Approved, DeductPayUtil.DeductPending };//只查询-划扣审批状态-"未审批"的借款订单
            var deductPayList = DeductPayApplyRepository.GetPageDeductPayList(pageNum, pageSize, statusList, applyId);
            return deductPayList;
        }
        #endregion

        #region 分页查询信贷划扣操作信息

        public PagedList<ThroughListDto> SelectCreditDeductOrderList(int pageNum, int pageSize, int? applyId = null)
        {

            Dscf.LoanAfter.Dto.DscfCreditLoanService.Loan_DeductProgressDto[] progressList;//信贷

            IList<int> statusList = new List<int>() { DeductPayUtil.FailedDebit, DeductPayUtil.Approved, DeductPayUtil.DeductPending };//只查询-划扣审批状态-"未审批"的借款订单
            var deductPayList = DeductPayApplyRepository.GetPageDeductPayList(pageNum, pageSize, statusList, applyId, LoanOrderUtil.CreditTypeKey);
            using (Dscf.LoanAfter.Dto.DscfCreditLoanService.CreditLoanContractClient client = new Dscf.LoanAfter.Dto.DscfCreditLoanService.CreditLoanContractClient())
            {
                progressList = client.GetDeductionFailedList(deductPayList.CurrentPageItems.Where(p => p.OrderId.HasValue).Select(pro => pro.OrderId.Value).ToArray());
            }
            PagedList<ThroughListDto> result = new PagedList<ThroughListDto>()
            {
                TotalItemCount = deductPayList.TotalItemCount,
                TotalPageCount = deductPayList.TotalPageCount,
                CurrentPageIndex = deductPayList.CurrentPageIndex,
            };
            var pageItems = new List<ThroughListDto>();

            #region 信贷
            int[] creditKeyArray = deductPayList.CurrentPageItems.Where(pay => pay.OrderType == LoanOrderUtil.CreditTypeKey).Select(pay => pay.OrderId.Value).ToArray();
            if (creditKeyArray != null && creditKeyArray.Length > 0)
            {
                using (var client = new Dto.DscfCreditLoanService.CreditLoanContractClient())
                {
                    PagedList<CreditOverdueListDto> pageList = client.GetPageDeductApprovalList(1, creditKeyArray.Length, creditKeyArray);//根据划扣状态获取OrderId查询
                    var items = deductPayList.CurrentPageItems;
                    foreach (var item in items)
                    {
                        CreditOverdueListDto creditOverdueListDto = pageList.CurrentPageItems.Where(pay => pay.OrderId == item.OrderId).FirstOrDefault();
                        Loan_DeductProgressDto Loan_DeductProgressDto = new Loan_DeductProgressDto();
                        if (progressList != null)
                        {
                            Loan_DeductProgressDto = progressList.Where(pro => pro.LoanOrderId == item.OrderId).FirstOrDefault();
                        }
                        #region 类型转换

                        ThroughListDto dto = new ThroughListDto()
                        {
                            OrderId = creditOverdueListDto.OrderId,//订单编号
                            SignCity = creditOverdueListDto.SignCity,//签署地
                            OptDeptId = creditOverdueListDto.OptDeptId,
                            UserName = creditOverdueListDto.UserName,//姓名
                            SignDate = creditOverdueListDto.SignDate,//进入大堂时间
                            Amount = creditOverdueListDto.Amount,//合同金额
                            ProductName = creditOverdueListDto.ProductName,
                            PayWay = item.PayWay,//扣款方式
                            ApprovalStatus = item.ApprovalStatus,//银行返回结果码00 和 30 为成功
                            Code = Loan_DeductProgressDto == null ? "" : Loan_DeductProgressDto.Code,//银行返回结果码00 和 30 为成功
                            OrderType = LoanOrderUtil.CreditTypeKey,
                            ResultName = Loan_DeductProgressDto == null ? "等待划付" : Loan_DeductProgressDto.Result,
                            ApplyId = item.Id
                        };

                        #endregion
                        pageItems.Add(dto);
                    }
                }
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    var deductApprovalStatusList = client.GetDictListByKey(DictUtil.DeductApprovalStatusKey);
                    var payWayNameList = client.GetDictListByKey(DictUtil.DeductTypeKey);
                    if (deductApprovalStatusList != null && deductApprovalStatusList.Count() > 0)
                    {
                        foreach (var item in pageItems)
                        {
                            item.ApprovalStatusName = deductApprovalStatusList.Where(dedu => dedu.DictValue == item.ApprovalStatus).FirstOrDefault().DictMemo;
                            item.PayWayName = payWayNameList.Where(pay => pay.DictValue == item.PayWay).FirstOrDefault().DictMemo;
                        }
                    }
                }
            }
            #endregion
            result.CurrentPageItems = pageItems;
            return result;
        }

        #endregion

        public PagedList<CarDeductPayInfoDto> SelectCarDeductOrderList(int pageNum, int pageSize, int orderType)
        {
            IList<int> statusList = new List<int>() { DeductPayUtil.Approved, DeductPayUtil.DeductPending, DeductPayUtil.FailedDebit };
            var deductApplyList = DeductPayApplyRepository.GetPageCarDeductApplyListDistinctOrderId(pageNum, pageSize, statusList);

            PagedList<CarDeductPayInfoDto> result = new PagedList<CarDeductPayInfoDto>()
            {
                TotalItemCount = deductApplyList.TotalItemCount,
                TotalPageCount = deductApplyList.TotalPageCount,
                CurrentPageIndex = deductApplyList.CurrentPageIndex,
            };

            var pageItems = new List<CarDeductPayInfoDto>();
            int[] carIdArray = deductApplyList.CurrentPageItems.Select(pay => pay.OrderId.Value).ToArray();

            if (carIdArray != null && carIdArray.Length > 0)
            {
                using (var client = new Dto.DscfCarLoanService.CarLoanContractClient())
                {
                    PagedList<CarOverdueListDto> pageList = client.GetPageDeductApprovalList(1, carIdArray.Length, carIdArray);
                    var items = pageList.CurrentPageItems;
                    foreach (var item in items)
                    {
                        var deductApp = deductApplyList.CurrentPageItems.Where(i => item.OrderId == i.OrderId).FirstOrDefault();
                        #region 类型转换
                        CarDeductPayInfoDto dto = new CarDeductPayInfoDto()
                        {
                            Id = deductApp.Id,
                            OrderId = item.OrderId,
                            SignCity = item.SignCity,
                            UserName = item.UserName,
                            ProductName = item.ProductName,
                            OrderType = LoanOrderUtil.CarTypeKey,
                            LobbyTime = item.LobbyTime,
                            Amount = item.Amount,
                            LicensePlate = item.LicensePlate,
                            StatusId = deductApp.ApprovalStatus,
                            PayWay = deductApp.PayWay,
                            IsExtension = item.IsExtension
                        };
                        #endregion
                        pageItems.Add(dto);
                    }
                }
                using (Dto.DscfACService.AuthCenterContractClient client = new Dto.DscfACService.AuthCenterContractClient())
                {
                    var deductApprovalStatusList = client.GetDictListByKey(DictUtil.DeductApprovalStatusKey);
                    if (deductApprovalStatusList != null && deductApprovalStatusList.Count() > 0)
                    {
                        foreach (var item in pageItems)
                        {
                            item.StatusName = deductApprovalStatusList.Where(dedu => dedu.DictValue == item.StatusId)
                                .FirstOrDefault().DictMemo;
                        }
                    }
                    var deductPayWayList = client.GetDictListByKey(DictUtil.DeductTypeKey);
                    if (deductPayWayList != null && deductPayWayList.Count() > 0)
                    {
                        foreach (var item in pageItems)
                        {
                            item.PayWayName = deductPayWayList.Where(pay => pay.DictValue == item.PayWay).FirstOrDefault().DictMemo;
                        }
                    }
                }
            }
            result.CurrentPageItems = pageItems;
            return result;
        }
        /// <summary>
        /// 银行划扣返回结果
        /// </summary>
        /// <param name="ApplyId"></param>
        /// <param name="boolean"></param>
        /// <returns></returns>
        public bool UpdateStatusByApplyId(int applyId, bool boolean)
        {
            var entity = this.CurrentRepository.Entities.Where(dedu => dedu.Id == applyId).FirstOrDefault();
            if (boolean)
            {
                entity.ApprovalStatus = 3;
            }
            else
            {
                entity.ApprovalStatus = 4;
            }
            boolean = this.CurrentRepository.Update(entity) > 0 ? true : false;
            if (boolean)
            {
                if (entity.OrderType == LoanOrderUtil.CreditTypeKey)
                {
                    using (Dto.DscfCreditLoanService.CreditLoanContractClient client =
                        new Dto.DscfCreditLoanService.CreditLoanContractClient())
                    {
                        boolean = client.UpdateApplyIdByOrderId(applyId, entity.OrderId.Value);
                    }
                }
                if (entity.OrderType == LoanOrderUtil.CarTypeKey)
                {
                    using (Dto.DscfCarLoanService.CarLoanContractClient client =
                        new Dto.DscfCarLoanService.CarLoanContractClient())
                    {
                        boolean = client.UpdateApplyIdByOrderId(applyId, entity.OrderId.Value);
                    }
                }
            }
            return boolean;
        }
        public bool UpdateApplyStatusByKey(int orderId, int orderType, int status, int operatorId, string reason)
        {
            var deductPayApply = this.CurrentRepository.Entities
                .Where(dedu => dedu.OrderId == orderId && dedu.OrderType == orderType)
                .OrderByDescending(dedu => dedu.Id).FirstOrDefault();

            deductPayApply.Reason = reason;
            deductPayApply.ApprovalStatus = status;
            deductPayApply.LastOperateId = operatorId;
            deductPayApply.LastUpdateTime = DateTime.Now;
            return this.CurrentRepository.Update(deductPayApply) > 0 ? true : false;
        }
        public bool UpdateApplyStatusBatch(int[] creditOrderIds, int[] carOrderIds, int status, int operatorId, string reason)
        {
            foreach (var creditId in creditOrderIds)
            {
                var deductPayApply = this.CurrentRepository.Entities
                    .Where(dedu => dedu.OrderId == creditId && dedu.OrderType == LoanOrderUtil.CreditTypeKey)
                    .OrderByDescending(dedu => dedu.Id).FirstOrDefault();
                if (deductPayApply.Reason == null)
                {
                    deductPayApply.Reason = reason;
                }
                deductPayApply.ApprovalStatus = status;
                deductPayApply.LastOperateId = operatorId;
                deductPayApply.LastUpdateTime = DateTime.Now;
                this.CurrentRepository.Update(deductPayApply, false);
            }
            foreach (var carId in carOrderIds)
            {
                var deductPayApply = this.CurrentRepository.Entities
                    .Where(dedu => dedu.OrderId == carId && dedu.OrderType == LoanOrderUtil.CarTypeKey)
                    .OrderByDescending(dedu => dedu.Id).FirstOrDefault();
                if (deductPayApply.Reason == null)
                {
                    deductPayApply.Reason = reason;
                }
                deductPayApply.ApprovalStatus = status;
                deductPayApply.LastOperateId = operatorId;
                deductPayApply.LastUpdateTime = DateTime.Now;
                this.CurrentRepository.Update(deductPayApply, false);
            }
            this.CurrentRepository.UnitOfWork.Commit();

            return true;
        }


    }
}
