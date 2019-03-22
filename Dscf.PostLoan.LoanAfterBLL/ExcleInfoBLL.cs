using Dscf.PostLoanGlobal;
using Dscf.PostLoan.LoanAfterBLL.DscfLoanAfterService;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.PostLoan.CarLoanBLL.DscfCarLoanService;
using System.Data;
using Dscf.Settlement.Model;
using Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService;

namespace Dscf.PostLoan.LoanAfterBLL
{
    public class ExcleInfoBLL
    {
        /// <summary>
        /// 获取信贷产品信息
        /// </summary>
        /// <returns></returns>
        public ExcleInfoDto[] GetLoanAfterProduct(int type, int productTypeId)
        {
            using (LoanAfterContractClient client = new LoanAfterContractClient())
            {
                return client.GetLoanAfterProduct(type, productTypeId);
            }
        }

        public void OverdueExportExcle(OverdueExportExcleViewModel model)
        {
            System.Data.DataTable dt = new DataTable();
            Dictionary<string, string> header = new Dictionary<string, string>();

            switch (model.LoanOrderType)
            {
                case 1:
                    {
                        #region 逾期违约报表

                        header.Add("RepayIdentification", "还款标识");
                        header.Add("SignCity", "地区");
                        header.Add("RepayDate", "划扣日期");
                        header.Add("RepayDay", "账单日");
                        header.Add("ProductName", "产品类型");
                        header.Add("Contract", "合同编号");
                        header.Add("UserName", "姓名");
                        header.Add("IDCard", "身份证号");
                        header.Add("DeductBranchBank", "开户行");
                        header.Add("SubBranchCode", "开户行代码");
                        header.Add("DeductBankAccount", "划扣账号");
                        header.Add("ToalPeriod", "期数");
                        header.Add("IsDeductTerm", "已还期数");
                        header.Add("FirstRepaymentDate", "首还日期");
                        header.Add("SignDate", "借款日期");
                        header.Add("OverdueCondition", "逾期情况");
                        header.Add("CustomerName", "客户经理");
                        header.Add("ApplicationName", "信审");
                        header.Add("Amount", "合同额");
                        header.Add("MonthRepay", "月还款额");
                        header.Add("MonthRepayPrincipal", "月还本金");
                        header.Add("MonthProfit", "月还利息");

                        header.Add("OverDueDays", "逾期天数");
                        header.Add("OverduePenalty", "违约金");
                        header.Add("DailyPenalties", "罚息");

                        header.Add("TermTotal", "应还款总额");
                        header.Add("DeductMoney", "减免金额");
                        header.Add("ActualDeductDate", "实际还款日期");
                        header.Add("ActualDeductAmount", "实际还款金额");
                        header.Add("PayWayName", "还款方式");
                        header.Add("TotalShouldRepaid", "实时逾期金额");
                        header.Add("PeriodOrder", "公式上所在期数");
                        header.Add("UserPhone", "电话号码");
                        header.Add("Mark", "备注");
                        header.Add("FirstCustomer", "首还客户");
                        header.Add("ConfirmDate", "确认日期");
                        header.Add("DayRepay", "当天还款额");
                        #endregion

                        List<CreditOverdueExcelDto> list = new List<CreditOverdueExcelDto>();
                        CreditOverdueSearchRequest dto = AutoMapper.Mapper.Map<CreditOverdueSearchRequest>(model);
                        using (CreditLoanContractClient client = new CreditLoanContractClient())
                        {
                            list = client.GetOverdueExcelList(dto).ToList();
                        }
                        var creditOverdueExcel = list.Select(a => AutoMapper.Mapper.Map<CreditOverdueExcelDto, CreditOverdueExcelViewModel>(a)).ToList();
                        dt = Dscf.PostLoanGlobal.NpoiUtil.List2DataTable(creditOverdueExcel, header);
                        string fileName = "逾期违约报表(信贷)" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
                        Dscf.PostLoanGlobal.NpoiUtil.ExportExcel(dt, fileName, list.Count);
                        break;
                    };
                case 2:
                    {
                        #region 逾期违约报表

                        header.Add("RepayDate", "应划扣日期");
                        header.Add("Date", "核算月份");
                        header.Add("SignCity", "城市");
                        header.Add("CovenantNo", "合同号");
                        header.Add("SigningDate", "合同签署日期");
                        header.Add("UserName", "客户姓名");
                        header.Add("IDCard", "身份证号");
                        header.Add("BankCard", "银行账户");
                        header.Add("BankName", "所属银行");
                        header.Add("SubBranchName", "开户行");
                        header.Add("Amount", "合同金额");
                        header.Add("ContractType", "合同类型");
                        header.Add("CarLoanTypeName", "借款类型");
                        header.Add("MonthRate", "月利率");
                        header.Add("MonthProfit", "月利");
                        header.Add("MonthRateTotal", "服务费率");
                        header.Add("ComplexRateTotal", "总服务费率");
                        header.Add("ComplexTotal", "总服务费");
                        header.Add("Consultancy", "咨询费");
                        header.Add("ServicesFees", "服务费");
                        header.Add("AuditFees", "审核费");
                        header.Add("CollectionFeeLimit", "代收手续费上限");
                        header.Add("PaidFee", "实收手续费");
                        header.Add("IsLogical", "是否合理");
                        header.Add("InitialExpenses", "前期费用");
                        header.Add("GPSInstallationFee", "GPS安装费");
                        header.Add("ParkingFee", "停车费");
                        header.Add("TrafficCharges", "流量费");
                        header.Add("Margin", "保证金");
                        header.Add("ToalPeriod", "期数");
                        header.Add("MonthRepayPrincipal", "月还本金");
                        header.Add("EqualMonthlyReturn", "等额月还");
                        header.Add("TheSameMonth", "实际月还");
                        header.Add("TotalShouldRepaid", "累计应还款总额");
                        header.Add("DiscountPerformance", "体现业绩");
                        header.Add("RepayDay", "每月还款日");
                        header.Add("FirstRepaymentDate", "首次还款日期");
                        header.Add("LastRepaymentDate", "末次还款日期");
                        header.Add("ActualLoanDate", "实际放款日期");
                        header.Add("LastTermDueAmount", "末期欠款金额");
                        header.Add("MonthRepay", "本期月还");

                        header.Add("OverDueDays", "逾期天数");
                        header.Add("OverduePenalty", "违约金");
                        header.Add("DailyPenalties", "罚息");
                        header.Add("TermTotal", "本期应还款额");


                        header.Add("ActualDeductAmount", "实际还款金额");
                        header.Add("ActualDeductDate", "实际还款日期");
                        header.Add("PayWayName", "还款方式");
                        header.Add("TermAmountOwed", "本期欠款金额");
                        header.Add("IsDeductSucess", "本期是否还款成功");
                        header.Add("IsDeductAll", "是否提前一次性还款");
                        header.Add("IsDeductTerm", "累计已还期数");
                        header.Add("NotDeductTerm", "剩余还款期数");
                        header.Add("Mark", "备注");

                        #endregion

                        List<CarOverdueExcelDto> list = new List<CarOverdueExcelDto>();
                        OverdueSearchRequest dto = AutoMapper.Mapper.Map<OverdueSearchRequest>(model);
                        using (CarLoanContractClient client = new CarLoanContractClient())
                        {
                            list = client.GetOverdueExcelList(dto).ToList();
                        }
                        var carOverdueExcel = list.Select(a => AutoMapper.Mapper.Map<CarOverdueExcelDto, CarOverdueExcelViewModel>(a)).ToList();
                        dt = Dscf.PostLoanGlobal.NpoiUtil.List2DataTable(carOverdueExcel, header);
                        string fileName = "逾期违约报表(车贷)" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
                        Dscf.PostLoanGlobal.NpoiUtil.ExportExcel(dt, fileName, list.Count);
                        break;
                    };
                default: return;
            }







        }
    }
}
