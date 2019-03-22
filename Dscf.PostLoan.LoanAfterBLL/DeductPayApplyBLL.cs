using Dscf.PostLoanGlobal;
using Dscf.PostLoan.CarLoanBLL;
using Dscf.PostLoan.CreditLoanBLL;
using Dscf.PostLoan.LoanAfterBLL.DscfLoanAfterService;
using Dscf.Settlement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Dscf.PostLoan.LoanAfterBLL
{
    public class DeductPayApplyBLL
    {
        public CreditLoanProductOrderBLL CreditLoanProductOrderBLL { get; set; }
        public CreditLoanDeductProgressBLL CreditLoanDeductProgressBLL { get; set; }
        public CarLoanOrderProductBLL CarLoanOrderProductBLL { get; set; }
        public CarDeductProgressBLL CarDeductProgressBLL { get; set; }
        public CreditLoanInfoBLL CreditLoanInfoBLL { get; set; }
        public CreditLoanBackInfoBLL CreditLoanBackInfoBLL { get; set; }
        public CreditLoan_MonthRepayBLL CreditLoan_MonthRepayBLL { get; set; }

        public CarLoanMonthRepayBLL CarLoanMonthRepayBLL { get; set; }

        public bool AddDeductPayApply(LoanAfterBLL.DscfLoanAfterService.DeductPayApplyDto deductPayApplyDto)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.AddDeductPayApply(deductPayApplyDto);
            }
        }

        public DeductPayApplyDto GetDeductPayApplyAndFile(int orderId, int orderType)
        {

            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.GetDeductPayApplyAndFile(orderId, orderType);
            }
        }

        public PagedList<ApprovalListDto> GetDeductPayList(int pageNum, int pageSize)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.GetDeductPayList(pageNum, pageSize);
            }
        }

        public PagedList<ThroughListDto> SelectCreditDeductOrderList(int pageNum, int pageSize, int? applyId = null)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.SelectCreditDeductOrderList(pageNum, pageSize, applyId);
            }
        }

        public bool UpdateApplyStatusByKey(int orderId, int orderType, int status, int operatorId, string reason)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.UpdateApplyStatusByKey(orderId, orderType, status, operatorId, reason);
            }
        }

        public bool UpdateApplyStatusBatch(int[] creditOrderIds, int[] carOrderIds, int status, int operatorId, string reason)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.UpdateApplyStatusBatch(creditOrderIds, carOrderIds, status, operatorId, reason);
            }
        }

        public PagedList<CarDeductPayInfoDto> SelectCarDeductOrderList(int pageNum, int pageSize, int orderType)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.SelectCarDeductOrderList(pageNum, pageSize, orderType);
            }
        }

        public PagedList<DeductPayApplyDto> GetPageDeductPayList(int pageNum, int pageSize, int? applyId = null)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.GetPageDeductPayList(pageNum, pageSize, applyId);
            }
        }

        /// <summary>
        /// 划扣信息操作
        /// </summary>
        /// <param name="deductModel"></param>
        /// <param name="boolean">输入参数bool</param>
        /// <param name="operatorId">操作人ID</param>
        /// <returns></returns>
        public bool UpdateApplyStatusByKey(DeductViewModel deductModel, int operatorId)
        {
            #region 查看是否有正在处理中的划扣数据
            switch (deductModel.OrderType)
            {
                case 1: if (CreditLoanDeductProgressBLL.GetDeductList(deductModel.OrderId).Where(deduct => (deduct.Code == "10" && deduct.PaymentType == 0) || ((deduct.Code == "10" || deduct.Code == "20") && deduct.PaymentType == 1)).FirstOrDefault() != null)
                    {
                        return false;

                    }
                    break;
                default:
                    if (CarDeductProgressBLL.GetDeductList(deductModel.OrderId).Where(deduct => (deduct.Code == "10" && deduct.PaymentType == 0) || ((deduct.Code == "10" || deduct.Code == "20") && deduct.PaymentType == 1)).FirstOrDefault() != null)
                    {
                        return false;
                    }
                    break;
            }



            #endregion



            #region 划扣申请提交信息查询
            var creditOrCarDeductOrder = GetPageDeductPayList(1, 1, deductModel.ApplyId).CurrentPageItems.FirstOrDefault();

            deductModel.DeductMoney = creditOrCarDeductOrder.RepayAmount;//划扣金额
            switch (deductModel.OrderType)
            {
                case 1:
                    LoanSearchViewModels loanSearchViewModels = new LoanSearchViewModels() { OrderId = deductModel.OrderId.ToString(), OptId = operatorId, PageSize = 10, PageNum = 1 };
                    Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.LoanInfoDto loaninfo = CreditLoanInfoBLL.GetPageLoanInfoList(loanSearchViewModels).CurrentPageItems.ToList()[0];
                    deductModel.UserName = loaninfo.Name;//姓名
                    deductModel.IDCard = loaninfo.IDCard;//身份证号
                    deductModel.Phone = loaninfo.Phone;//手机号
                    deductModel.DeductBankAccount = loaninfo.DeductBankAccount;//银行卡号
                    deductModel.DeductBankName = loaninfo.DeductBankName;//银行名称
                    deductModel.SubBranchName = loaninfo.DeductBranchBank;//支行名称
                    break;
                default:
                    var carLoan = CarLoanOrderProductBLL.GetLoanProductOrderInfoByOrderId(deductModel.OrderId);
                    deductModel.UserName = carLoan.Name;//姓名
                    deductModel.IDCard = carLoan.IDCard;//身份证号
                    deductModel.Phone = carLoan.Phone;//手机号
                    deductModel.DeductBankAccount = carLoan.BankCard;//银行卡号
                    deductModel.DeductBankName = carLoan.BankName;//银行名称
                    deductModel.SubBranchName = carLoan.SubBranchName;//支行名称
                    break;
            }
            deductModel.BankCode = CreditLoanBackInfoBLL.GetBankInfoByName(deductModel.DeductBankName).BankCode;

            #endregion

            #region 划扣信息操作

            bool boolean = false;
            using (TransactionScope ts = new TransactionScope())
            {
                #region MyRegion

                if (deductModel.DeductKind == DeductPayUtil.HandDeduct)
                {
                    boolean = UpdateApplyStatusByKey(deductModel.OrderId, deductModel.OrderType, deductModel.Status, operatorId, deductModel.Reason);
                    if (boolean)
                    {
                        if (deductModel.DeductType == DeductPayUtil.DeductApply)
                        {
                            if (deductModel.Status == DeductPayUtil.DeductPending)
                            {
                                switch (deductModel.OrderType)
                                {

                                    case 1:
                                        {
                                            boolean = CreditLoanProductOrderBLL.UpdateCollectStatus(deductModel.OrderId, DeductPayUtil.OrderCollectDeductPending, operatorId);
                                            break;
                                        }
                                    default:
                                        {
                                            boolean = CarLoanOrderProductBLL.UpdateCollectStatus(deductModel.OrderId, DeductPayUtil.OrderCollectDeductPending, operatorId);
                                            break;
                                        }
                                }
                            }

                        }
                        else
                        {
                            if (deductModel.Status == DeductPayUtil.SuccessfulDebit)
                            {
                                switch (deductModel.OrderType)
                                {

                                    case 1:
                                        {
                                            boolean = CreditLoanProductOrderBLL.UpdateCollectStatus(deductModel.OrderId, DeductPayUtil.OrderCollectPendingApproved, operatorId);
                                            break;
                                        }
                                    default:
                                        {
                                            boolean = CarLoanOrderProductBLL.UpdateCollectStatus(deductModel.OrderId, DeductPayUtil.OrderCollectPendingApproved, operatorId);
                                            break;
                                        }
                                }
                                if (boolean)
                                {
                                    #region 修改月还
                                    switch (deductModel.OrderType)
                                    {

                                        case 1:
                                            {
                                                boolean = CreditLoan_MonthRepayBLL.UpdateMonthRepay(deductModel, operatorId);
                                                break;
                                            }
                                        default:
                                            {
                                                boolean = CarLoanMonthRepayBLL.UpdateMonthRepay(deductModel, operatorId);
                                                break;
                                            }
                                    }
                                    #endregion
                                }
                            }
                            else if (deductModel.Status == DeductPayUtil.RejectDebit)
                            {
                                switch (deductModel.OrderType)
                                {

                                    case 1:
                                        {
                                            boolean = CreditLoanProductOrderBLL.UpdateCollectStatus(deductModel.OrderId, deductModel.Status, operatorId);
                                            break;
                                        }
                                    default:
                                        {
                                            boolean = CarLoanOrderProductBLL.UpdateCollectStatus(deductModel.OrderId, deductModel.Status, operatorId);
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }

                #endregion

                if (boolean)
                {
                    if (deductModel.DeductKind == DeductPayUtil.HandDeduct)
                    {
                        if (deductModel.DeductType == DeductPayUtil.DeductApply)
                        {
                            if (deductModel.Status != DeductPayUtil.RejectDebit)
                            {
                                #region 增加划扣表数据、对接银行划扣接口
                                switch (deductModel.OrderType)
                                {
                                    case 1:
                                        {
                                            boolean = CreditLoanDeductProgressBLL.AddCreditDeductProgress(deductModel, operatorId);
                                            break;
                                        }
                                    default:
                                        {
                                            boolean = CarDeductProgressBLL.AddCarDeductProgress(deductModel, operatorId);
                                            break;
                                        }
                                }
                                #endregion
                            }
                        }
                        //else
                        //{
                        //    #region 增加划扣表数据、对接银行划扣接口
                        //    switch (deductModel.OrderType)
                        //    {

                        //        case 1:
                        //            {
                        //                boolean = CreditLoanDeductProgressBLL.AddCreditDeductProgress(deductModel, operatorId);
                        //                break;
                        //            }
                        //        default:
                        //            {
                        //                boolean = CarDeductProgressBLL.AddCarDeductProgress(deductModel, operatorId);
                        //                break;
                        //            }
                        //    }
                        //    #endregion
                        //}
                    }
                }

                if (boolean)
                {
                    ts.Complete();
                    return true;
                }
                else
                {
                    ts.Dispose();
                    return false;
                }
            }
            #endregion
        }
    }
}
