using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService;
using Dscf.PostLoanGlobal;
using Dscf.Settlement.Model;
using Newtonsoft.Json;
using Dscf.Global.BaseBizModel;
using serverModel = Dscf.Global.Unionpay.Model;

namespace Dscf.PostLoan.CreditLoanBLL
{
    public class CreditLoanDeductProgressBLL
    {
        public DeductProgressInfo[] GetDeductList(int orderId)
        {
            using (CreditLoanContractClient client = new CreditLoanContractClient())
            {
                LoanDeductProgressDto[] deductProgresses = client.GetDeductList(orderId);
                if (deductProgresses != null)
                {
                    return deductProgresses.Select(deduct => deduct.ToModel()).ToArray();
                }
                else
                    return null;
            }
        }
        /// <summary>
        /// 增加划扣表数据，对接银行接口
        /// </summary>
        /// <param name="deductModel"></param>
        /// <param name="optId"></param>
        /// <returns></returns>
        public bool AddCreditDeductProgress(DeductViewModel deductModel, int optId)
        {
            bool isTrue = false;

            //支付类型,1为中金，0为银生宝
            if (deductModel.PayType == "1")
            {
                //调用中金支付接口，并添加划扣信息
                isTrue = CreateDeductMethod(deductModel, optId);
            }
            else if (deductModel.PayType == "0")
            {
                //调用银生宝支付接口，并添加划扣信息
                isTrue = YSHBPayMentSubMonthDeduct(deductModel, optId);
            }

            return isTrue;
        }
        /// <summary>
        /// 获取当前通过审核但是未成功划扣的信息
        /// </summary>
        /// <param name="statusList"></param>
        /// <returns></returns>
        public Loan_DeductProgressDto[] GetDeductionFailedList(IList<int> statusList = null)
        {
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                DscfCreditLoanService.Loan_DeductProgressDto[] progressList = client.GetDeductionFailedList(statusList.ToArray());
                return progressList;
            }
        }

        /// <summary>
        /// 批量添加借款划扣情况表
        /// </summary>
        /// <param name="statusList"></param>
        /// <returns></returns>
        public Boolean DeductinfoFailedAddAll(IList<string> idAndPeriods, int operatorId)
        {
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                Boolean boolean = client.DeductinfoFailedAddAll(idAndPeriods.ToArray(), operatorId);
                return boolean;
            }
        }

        /// <summary>
        /// 批量添加借款划扣情况表
        /// </summary>
        /// <param name="statusList"></param>
        /// <returns></returns>
        public Boolean DeductinfoFailedAddAll(int operatorId)
        {
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                Boolean boolean = client.DeductinfoFailedAddAlls(operatorId);
                return boolean;
            }
        }

        /// <summary>
        /// 添加借款划扣情况表单个
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="operatorId"></param>
        /// <param name="PlanDeductAmount"></param>
        /// <returns></returns>
        public Boolean DeductinfoFailedAddOne(int orderId, int operatorId, LoanDeductProgressDto model)
        {
            using (DscfCreditLoanService.CreditLoanContractClient client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                Boolean boolean = client.DeductinfoFailedAddOne(orderId, operatorId, model);
                return boolean;
            }
        }

        #region 中金划扣接口调用部分
        /// <summary>
        /// 中金划扣调用接口
        /// </summary>
        /// <param name="deductModel"></param>
        /// <param name="optId"></param>
        /// <returns></returns>
        private bool CreateDeductMethod(DeductViewModel deductModel, int optId)
        {
            try
            {
                DateTime submit = DateTime.Now;
                serverModel.UnionpaySubmitModel paySubmitModel = new serverModel.UnionpaySubmitModel();
                //划扣详细信息
                List<serverModel.UnionpayOperateModel> deductList = new List<serverModel.UnionpayOperateModel>();
                serverModel.UnionpayOperateModel deductOperateModel = new serverModel.UnionpayOperateModel();

                deductOperateModel.ZItemNo = Guid.NewGuid().ToString().Replace("-", "");
                deductOperateModel.AMOUNT = deductModel.DeductMoney.ToString();
                deductOperateModel.BANK_CODE = deductModel.BankCode;
                deductOperateModel.ZAccountType = "11";
                deductOperateModel.ACCOUNT_NAME = deductModel.UserName;
                deductOperateModel.ACCOUNT_NO = deductModel.DeductBankAccount;
                deductOperateModel.ID_TYPE = "0";
                deductOperateModel.IDCard = deductModel.IDCard;
                deductOperateModel.ZNote = "L-" + deductModel.OrderId;
                deductOperateModel.LoanOrderId = deductModel.OrderId;
                deductOperateModel.RepayId = deductModel.RepayId;
                deductOperateModel.RepayPeriod = deductModel.PeriodOrder;
                deductList.Add(deductOperateModel);

                //deductOperateModel.ZItemNo = Guid.NewGuid().ToString().Replace("-", "");
                //deductOperateModel.AMOUNT = "0.01";
                //deductOperateModel.BANK_CODE = "105";
                //deductOperateModel.ZAccountType = "11";
                //deductOperateModel.ACCOUNT_NAME = "李永林";
                //deductOperateModel.ACCOUNT_NO = "6217004120004620460";
                //deductOperateModel.ID_TYPE = "0";
                //deductOperateModel.IDCard = "612701196809053818";
                //deductOperateModel.ZNote = "C-" + deductModel.OrderId;
                //deductOperateModel.LoanOrderId = deductModel.OrderId;
                //deductOperateModel.RepayId = deductModel.RepayId;
                //deductOperateModel.RepayPeriod = deductModel.PeriodOrder;
                //deductList.Add(deductOperateModel);

                paySubmitModel.PaymentType = PaymentType.ChinaPay; //支付类型
                paySubmitModel.ChinaPayMentType = ChinaPayMentType.DeductType;//操作类型

                paySubmitModel.TOTAL_ITEM = deductList.Count.ToString(); //总数
                paySubmitModel.TOTAL_SUM = deductModel.DeductMoney.ToString(); //总金额
                paySubmitModel.PayList = deductList;
                paySubmitModel.ZBatchNo = DateTime.Now.ToString("yyyyMMddHHmmssffff");

                //调用中金划扣接口
                string rest = LogicProxy.DscfFinancingGlobal.WebDscfFinancingProxy.PaySubmissionCall(paySubmitModel);
                dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(rest);
                string resultCode = obj.RequestCode;
                string resultMsg = "[" + obj.RequestCode + "] : " + obj.RequestMessage;
                //中金划扣成功为2000，成功返回true，不成功则返回false
                if (obj.RequestCode == "2000")
                {
                    //中金提交成功后——添加划扣数据信息
                    LoanDeductProgressDto deductDto = new LoanDeductProgressDto();
                    deductDto.ReqSn = paySubmitModel.ZBatchNo;
                    deductDto.PlanDeductAmount = Convert.ToDecimal(deductOperateModel.AMOUNT);
                    deductDto.RepayPeriod = deductOperateModel.RepayPeriod;
                    deductDto.RepayId = deductOperateModel.RepayId;
                    deductDto.IsPaymentType = Convert.ToInt32(deductModel.PayType);
                    deductDto.ApplyId = deductModel.ApplyId;
                    return DeductinfoFailedAddOne(deductModel.OrderId, optId, deductDto);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        #endregion

        #region 银生宝接口调用部分

        /// <summary>
        /// 银生宝提交
        /// </summary>
        /// <param name="deductModel"></param>
        /// <param name="optId"></param>
        /// <returns></returns>
        public bool YSHBPayMentSubMonthDeduct(DeductViewModel deductModel, int optId)
        {
            serverModel.UnionpaySubmitModel unionpaySubmitModel = new serverModel.UnionpaySubmitModel();
            serverModel.UnionpayOperateModel unionpayOperateModel = new serverModel.UnionpayOperateModel();
            //返回消息接收实体对象
            Dscf.Global.Unionpay.Model.UnionpayResultModel resultModel = new Dscf.Global.Unionpay.Model.UnionpayResultModel();

            try
            {
                //扣款目的
                unionpayOperateModel.Purpose = "扣款";
                //金额
                unionpayOperateModel.Amount = deductModel.DeductMoney.ToString();

                //商户生成的订单编号
                string sn = Guid.NewGuid().ToString().Replace("-", "");
                unionpayOperateModel.OrderId = sn;

                unionpayOperateModel.Name = deductModel.UserName;
                unionpayOperateModel.CardNo = deductModel.DeductBankAccount;
                unionpayOperateModel.IdCardNo = deductModel.IDCard;
                unionpayOperateModel.Cycle = "2";//1每年，2每月，3每日
                unionpayOperateModel.TriesLimit = "3";
                unionpayOperateModel.PhoneNo = deductModel.Phone;
                unionpayOperateModel.RepayId = deductModel.RepayId;
                unionpayOperateModel.RepayPeriod = deductModel.PeriodOrder;
                unionpayOperateModel.LoanOrderId = deductModel.OrderId;
                unionpayOperateModel.DscfOrderId = deductModel.OrderId;
                unionpayOperateModel.ZItemNo = sn;

                unionpaySubmitModel = new serverModel.UnionpaySubmitModel();
                unionpaySubmitModel.ZBatchNo = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                unionpaySubmitModel.PaymentType = PaymentType.UnspayYSBPay; //支付类型

                unionpayOperateModel.SubContractId = CheckUserToken(unionpayOperateModel, unionpaySubmitModel);

                //子协议查询，如果没有查到则进行子协议录入
                if (string.IsNullOrEmpty(unionpayOperateModel.SubContractId))
                {
                    //进行子协议录入，得到子协议码
                    unionpayOperateModel.SubContractId = SubContractSignSimple(unionpayOperateModel, unionpaySubmitModel);
                }
                else
                {
                    //银生宝划扣
                    resultModel = Deduct(unionpayOperateModel, unionpaySubmitModel);
                    //子协议过期处理
                    if (resultModel.Result_code == "2029")
                    {
                        if (SubConstractExtension(unionpayOperateModel, unionpaySubmitModel) == true)
                        {
                            //银生宝划扣
                            resultModel = Deduct(unionpayOperateModel, unionpaySubmitModel);
                        }
                    }
                }

                if (resultModel.Result_code == "0000")
                {
                    //银生宝提交成功后——添加划扣数据信息
                    LoanDeductProgressDto deductDto = new LoanDeductProgressDto();
                    deductDto.ReqSn = unionpaySubmitModel.ZBatchNo;
                    deductDto.PlanDeductAmount = Convert.ToDecimal(unionpayOperateModel.AMOUNT);
                    deductDto.RepayPeriod = unionpayOperateModel.RepayPeriod;
                    deductDto.RepayId = unionpayOperateModel.RepayId;
                    deductDto.IsPaymentType = Convert.ToInt32(deductModel.PayType);
                    deductDto.ApplyId = deductModel.ApplyId;

                    if (DeductinfoFailedAddOne(deductModel.OrderId, optId, deductDto) == true)
                    {
                        //银生宝订单查询
                        resultModel = QueryDeductResult(unionpayOperateModel, unionpaySubmitModel);
                        if (resultModel.Result_code == "0000")
                        {
                            //银生宝划扣查询，此次交易成功
                            if (resultModel.Status == "00")
                            {
                                return true;
                            }
                            //银生宝划扣查询，此次交易失败
                            else if (resultModel.Status == "20")
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }


        /// <summary>
        /// 查询用户子协议
        /// </summary>
        /// <param name="lobModel"></param>
        /// <returns></returns>
        private string CheckUserToken(serverModel.UnionpayOperateModel model, serverModel.UnionpaySubmitModel unionpaySubmitModel)
        {
            try
            {
                Dscf.Global.Unionpay.Model.UnionpayResultModel resultModel = new Dscf.Global.Unionpay.Model.UnionpayResultModel();

                //子协议查询
                unionpaySubmitModel.UnspayYinShengBaoPayType = UnspayYinShengBaoPayType.SubContractIdQuery;//操作类型
                unionpaySubmitModel.Name = model.Name;
                unionpaySubmitModel.CardNo = model.CardNo;
                unionpaySubmitModel.IdCardNo = model.IDCard;
                unionpaySubmitModel.PhoneNo = model.PhoneNo;
                unionpaySubmitModel.Cycle = "2";//1每年，2每月，3每日
                unionpaySubmitModel.TriesLimit = "3";

                string result = LogicProxy.DscfFinancingGlobal.WebDscfFinancingProxy.PaySubmissionCall(unionpaySubmitModel);
                resultModel = (Dscf.Global.Unionpay.Model.UnionpayResultModel)JsonConvert.DeserializeObject(result, typeof(Dscf.Global.Unionpay.Model.UnionpayResultModel));
                if (!result.Contains("0000"))
                {
                    return resultModel.Result_code;
                }

            }
            catch (Exception ex)
            {

                return "";
            }
            return "";
        }


        /// <summary>
        /// 子协议号录入
        /// </summary>
        /// <param name="lobModel"></param>
        /// <returns></returns>
        private string SubContractSignSimple(serverModel.UnionpayOperateModel model, serverModel.UnionpaySubmitModel unionpaySubmitModel)
        {
            try
            {
                Dscf.Global.Unionpay.Model.UnionpayResultModel resultModel = new Dscf.Global.Unionpay.Model.UnionpayResultModel();

                //子协议号录入
                unionpaySubmitModel.UnspayYinShengBaoPayType = UnspayYinShengBaoPayType.SubContractSignSimple;//操作类型

                unionpaySubmitModel.Name = model.Name;
                unionpaySubmitModel.CardNo = model.CardNo;
                unionpaySubmitModel.IdCardNo = model.IDCard;
                unionpaySubmitModel.PhoneNo = model.PhoneNo;
                unionpaySubmitModel.Cycle = "2";//1每年，2每月，3每日
                unionpaySubmitModel.TriesLimit = "3";

                string result = LogicProxy.DscfFinancingGlobal.WebDscfFinancingProxy.PaySubmissionCall(unionpaySubmitModel);
                resultModel = (Dscf.Global.Unionpay.Model.UnionpayResultModel)JsonConvert.DeserializeObject(result, typeof(Dscf.Global.Unionpay.Model.UnionpayResultModel));
                if (resultModel.Result_code == "0000")
                {
                    return resultModel.SubContractId;
                }

            }
            catch (Exception ex)
            {

                return "";
            }
            return "";
        }

        /// <summary>
        /// 银生宝划扣（如果结果为2029则要进行子协议延期）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private Dscf.Global.Unionpay.Model.UnionpayResultModel Deduct(serverModel.UnionpayOperateModel model, serverModel.UnionpaySubmitModel unionpaySubmitModel)
        {
            Dscf.Global.Unionpay.Model.UnionpayResultModel resultModel = new Dscf.Global.Unionpay.Model.UnionpayResultModel();
            //委托划扣
            unionpaySubmitModel.UnspayYinShengBaoPayType = UnspayYinShengBaoPayType.DeductType;//操作类型
            //子协议编号
            unionpaySubmitModel.SubContractId = model.SubContractId;
            unionpaySubmitModel.Purpose = "还款划扣";
            unionpaySubmitModel.OrderId = model.OrderId;
            //unionpaySubmitModel.Amount = model.Amount;
            unionpaySubmitModel.Amount = "0.01";

            string result = LogicProxy.DscfFinancingGlobal.WebDscfFinancingProxy.PaySubmissionCall(unionpaySubmitModel);
            resultModel = (Dscf.Global.Unionpay.Model.UnionpayResultModel)JsonConvert.DeserializeObject(result, typeof(Dscf.Global.Unionpay.Model.UnionpayResultModel));

            return resultModel;
        }

        /// <summary>
        /// 银生宝子协议延期
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool SubConstractExtension(serverModel.UnionpayOperateModel model, serverModel.UnionpaySubmitModel unionpaySubmitModel)
        {
            //子协议延期
            unionpaySubmitModel.UnspayYinShengBaoPayType = UnspayYinShengBaoPayType.SubConstractExtension;//操作类型            

            string result = LogicProxy.DscfFinancingGlobal.WebDscfFinancingProxy.PaySubmissionCall(unionpaySubmitModel);
            if (result.IndexOf("0000") != -1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 银生宝划扣结果查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private Dscf.Global.Unionpay.Model.UnionpayResultModel QueryDeductResult(serverModel.UnionpayOperateModel model, serverModel.UnionpaySubmitModel unionpaySubmitModel)
        {
            Dscf.Global.Unionpay.Model.UnionpayResultModel resultModel = new Dscf.Global.Unionpay.Model.UnionpayResultModel();
            unionpaySubmitModel.UnspayYinShengBaoPayType = UnspayYinShengBaoPayType.DeductQueryType;//操作类型
            unionpaySubmitModel.OrderId = model.SN;

            string result = LogicProxy.DscfFinancingGlobal.WebDscfFinancingProxy.PaySubmissionCall(unionpaySubmitModel);
            resultModel = (Dscf.Global.Unionpay.Model.UnionpayResultModel)JsonConvert.DeserializeObject(result, typeof(Dscf.Global.Unionpay.Model.UnionpayResultModel));
            return resultModel;
        }

        #endregion

    }
}
