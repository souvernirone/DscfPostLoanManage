using Dscf.PostLoanGlobal;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService;
using Dscf.Settlement.Model;

namespace Dscf.PostLoan.CreditLoanBLL
{
    public class CreditLoanExcleInfoBLL
    {
        /// <summary>
        ///  财务报表的Excle导出
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public void GetFinancialExportExcle(FinancialExportExcleViewModel FinancialExportExcleViewModel)
        {
            List<CreditFinancialExportExcleViewModel> creditFinancialExportExcleList = new List<CreditFinancialExportExcleViewModel>();
            CreditFinancialExportExcleRequest carModel = AutoMapper.Mapper.DynamicMap<CreditFinancialExportExcleRequest>(FinancialExportExcleViewModel);
            using (var client = new DscfCreditLoanService.CreditLoanContractClient())
            {
                var CreditFinancialExportExcleList = client.GetCreditFinancialExportExcleList(carModel);
                creditFinancialExportExcleList = CreditFinancialExportExcleList.Select(car => car.ToModel()).ToList();
            }
            Dictionary<string, string> header = new Dictionary<string, string>();
            #region 财务报表

            header.Add("SignCity", "签约城市");
            header.Add("Contract", "合同编号");
            header.Add("OrderId", "项目编号");
            header.Add("Name", "姓名");
            header.Add("IDCard", "证件号码");
            header.Add("ProductName", "借款类型");
            header.Add("Purpose", "借款人借款用途");
            header.Add("IsRecyclingLoans", "是否循环贷");
            header.Add("DeductBankAccount", "账户");
            header.Add("DeductBankName", "划扣银行");
            header.Add("DeductBranchBank", "开户行");
            header.Add("SignDateStr", "签约日期");
            header.Add("ApplyAmount", "初始借款金额(合同金额）");
            header.Add("Amount", "实际放款额");
            header.Add("Term", "借款期数");
            header.Add("RepayPerMonth", "月还金额");
            header.Add("FirstRepaymentDateStr", "首次还款日期");
            header.Add("DeductDate", "划款日期");
            header.Add("Phone", "客户联系电话");
            header.Add("IsCoborrowLoan", "是否联名贷");
            header.Add("CoborrowName", "共同借款人姓名");
            header.Add("CoborrowIDCard", "共同借款人身份证号");
            header.Add("IsExtension", "是否加急");
            header.Add("IsPrepayment", "是否已提前还款");
            header.Add("PrepaymentDateStr", "提前还款日期");
            header.Add("OnetimeRepaymentAmount", "一次性还款金额");
            header.Add("Remarks", "备注");
            header.Add("ActualLenderDateStr", "实际放款日期");
            header.Add("CustomerManagerName", "客户经理");
            header.Add("CustomerManager", "客户经理员工编号");
            header.Add("TeamManagerGroup", "团队名称");
            header.Add("TeamManagerName", "团队经理");
            header.Add("TeamManager", "团队经理员工编号");
            header.Add("SalesManagerName", "营业部经理");
            header.Add("SalesManagerNo", "营业部经理员工编号");
            header.Add("CityManagerName", "城市经理");
            header.Add("CityManagerNo", "城市经理员工编号");
            header.Add("RegionalManagerName", "大区经理姓名");
            header.Add("RegionalManagerNo", "大区经理");
            #endregion
            System.Data.DataTable dt = new DataTable();
            string fileName = "借款端放款明细报表(信贷)" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
            dt = Dscf.PostLoanGlobal.NpoiUtil.List2DataTable(creditFinancialExportExcleList, header);
            Dscf.PostLoanGlobal.NpoiUtil.ExportExcel(dt, fileName, dt.Rows.Count);
        }
    }
}

