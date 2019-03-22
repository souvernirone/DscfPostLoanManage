using Dscf.PostLoanGlobal;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dscf.PostLoan.CarLoanBLL.DscfCarLoanService;
using Dscf.Settlement.Model;
using Dscf.PostLoan.CarLoanBLL.Extension;

namespace Dscf.PostLoan.CarLoanBLL
{
    public class CarLoanExcleInfoBLL
    {
        /// <summary>
        ///  财务报表的Excle导出
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void GetFinancialExportExcle(FinancialExportExcleViewModel FinancialExportExcleViewModel)
        {
            List<CarFinancialExportExcleViewModel> carFinancialExportExcleList = new List<CarFinancialExportExcleViewModel>();
            CarFinancialExportExcleRequest carModel = AutoMapper.Mapper.Map<CarFinancialExportExcleRequest>(FinancialExportExcleViewModel);
            using (var client = new DscfCarLoanService.CarLoanContractClient())
            {
                var CarFinancialExportExcleList = client.GetCarFinancialExportExcleList(carModel);
                carFinancialExportExcleList = CarFinancialExportExcleList.Select(car => car.ToModel()).ToList();
            }
            Dictionary<string, string> header = new Dictionary<string, string>();
            #region 财务报表
            header.Add("OrderId", "借款订单编号");
            header.Add("CalculateMonthStr", "核算月份");
            header.Add("SignCity", "签约城市");
            header.Add("Contract", "合同编号");
            header.Add("SignDateStr", "面签时间");
            header.Add("Name", "姓名");
            header.Add("IDCard", "证件号码");
            header.Add("DeductBankAccount", "划扣银行账户");
            header.Add("DeductBankName", "划扣银行");
            header.Add("DeductBranchBank", "划扣银行支行");
            header.Add("Amount", "合同额");
            header.Add("UserId", "客户信息");
            header.Add("ProductName", "借款类型");
            header.Add("MonthlyRate", "月利率");
            header.Add("Monthly", "月利");
            header.Add("ServiceRate", "服务费率");
            header.Add("TotalServiceCharge", "总服务费");
            header.Add("ConsultationFee", "咨询费");
            header.Add("AuditFee", "审核费");
            header.Add("ServiceCharge", "服务费");
            header.Add("CollectionFeeLimit", "代收手续费上限");
            header.Add("PaidFee", "实收手续费");
            header.Add("IsReasonable", "是否合理");
            header.Add("InitialExpenses", "前期费用");
            header.Add("GPSInstallationFee", "GPS安装费");
            header.Add("ParkingFee", "停车费");
            header.Add("TrafficCharges", "流量费");
            header.Add("Margin", "保证金");
            header.Add("Term", "借款期限批款期");
            header.Add("MonthAlsoPrincipal", "月还本金");
            header.Add("EqualMonthlyReturn", "等额月还");
            header.Add("TheSameMonth", "实际月还");
            header.Add("TotalShouldRepaid", "累计应还款总额");
            header.Add("DiscountPerformance", "折标业绩");
            header.Add("DeductDate", "每月还款日");
            header.Add("FirstRepaymentDateStr", "首次还款日期");
            header.Add("LastRepaymentDateStr", "末次还款日期");
            header.Add("ActualLenderDateStr", "实际放款日期");
            header.Add("CarModels", "车型");
            header.Add("CarNumberPlate", "车牌号");
            header.Add("CustomerManager", "客户经理员工编号");
            header.Add("CustomerManagerName", "客户经理姓名");
            header.Add("CustomerManagerPhone", "客户经理联系电话");
            header.Add("TeamManager", "团队经理员工编号");
            header.Add("TeamManagerGroup", "团队名称");
            header.Add("TeamManagerName", "团队经理项目");
            header.Add("SalesManagerName", "营业部经理姓名");
            header.Add("SalesManagerNo", "营业部经理员工编号");
            header.Add("CityManagerName", "城市经理姓名");
            header.Add("CityManagerNo", "城市经理员工编号");
            header.Add("RegionalManagerName", "大区经理姓名");
            header.Add("RegionalManagerNo", "大区经理员工编号");
            header.Add("IsExpire", "是否已到期");
            header.Add("RepaymentPeriod", "应还款期数");
            header.Add("CumulativeReturnPeriod", "累计已还期数");
            header.Add("AccumulatedAmount", "累计已还金额");
            header.Add("RemainingPeriod", "剩余期数");
            header.Add("SurplusPrincipal", "剩余应还本金");
            header.Add("PrepaymentPenalty", "提前还款违约金");
            header.Add("PrepaymentAmount", "提前还款金额");
            header.Add("IsPrepayment", "是否已提前一次性还款");
            header.Add("BusinessStatus", "业务状态");
            header.Add("IsChargesApproved", "是否确认收费");
            header.Add("Remarks", "备注");
            header.Add("DateOfLastJournalStr", "上日报日期");
            #endregion
            System.Data.DataTable dt = new DataTable();
            string fileName = "借款端放款明细报表(车贷)" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
            dt = Dscf.PostLoanGlobal.NpoiUtil.List2DataTable(carFinancialExportExcleList, header);
            Dscf.PostLoanGlobal.NpoiUtil.ExportExcel(dt, fileName, dt.Rows.Count);
        }
    }
}
