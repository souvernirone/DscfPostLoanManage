using AutoMapper;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.Settlement.Model;
using Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService;

namespace Dscf.PostLoan.CreditLoanBLL
{
    public static class MapperExtension
    {
        #region ACDepartmentDto
        public static DeptViewModel ToModel(this DscfCreditLoanService.DepartmentInfoDto entity)
        {
            return Mapper.DynamicMap<DscfCreditLoanService.DepartmentInfoDto, DeptViewModel>(entity);
        }
        #endregion


        public static Loan_MonthRepayViewModel ToModel(this DscfCreditLoanService.Loan_MonthRepayInfoDto entity)
        {
            return Mapper.DynamicMap<DscfCreditLoanService.Loan_MonthRepayInfoDto, Loan_MonthRepayViewModel>(entity);
        }

        public static DeductProgressInfo ToModel(this DscfCreditLoanService.LoanDeductProgressDto entity)
        {
            return Mapper.Map<DscfCreditLoanService.LoanDeductProgressDto, DeductProgressInfo>(entity);
        }

        public static Settlement.Model.CreditFinancialExportExcleViewModel ToModel(this CreditFinancialExportExcleDto model)
        {
            return Mapper.Map<CreditFinancialExportExcleDto, Settlement.Model.CreditFinancialExportExcleViewModel>(model);
        }
    }
}
