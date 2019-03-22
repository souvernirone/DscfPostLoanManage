using AutoMapper;
using Dscf.PostLoan.CarLoanBLL.DscfCarLoanService;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.Settlement.Model;

namespace Dscf.PostLoan.CarLoanBLL.Extension
{
    /// <summary>
    /// AutoMapper映射扩展
    /// </summary>
    public static class MapperExtention
    {
        #region CLLoanProductOrder
        public static LoanInfoViewModel ToModel(this LoanProductOrderDto entity)
        {
            return Mapper.Map<LoanProductOrderDto, LoanInfoViewModel>(entity);
        }
        #endregion

        #region CLLoanMonthRepayDto
        public static CarLoanMonthRepayViewModel ToModel(this LoanMonthRepayDto entity)
        {
            return Mapper.Map<LoanMonthRepayDto, CarLoanMonthRepayViewModel>(entity);
        }
        #endregion

        #region DeductProgressDto
        public static DeductProgressInfo ToModel(this DeductProgressDto entity)
        {
            return Mapper.Map<DeductProgressDto, DeductProgressInfo>(entity);
        }
        #endregion

        public static CarFinancialExportExcleViewModel ToModel(this CarFinancialExportExcleDto model)
        {
            return Mapper.Map<CarFinancialExportExcleDto, CarFinancialExportExcleViewModel>(model);
        }
    }
}
