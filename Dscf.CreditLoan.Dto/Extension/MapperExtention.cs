using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dscf.CreditLoan.Domain;
namespace Dscf.CreditLoan.Dto.Extension
{

    /// <summary>
    /// AutoMapper映射扩展
    /// </summary>
    public static class MapperExtention
    {

        #region DepartmentInfo
        public static DepartmentInfoDto ToModel(this DepartmentInfo entity)
        {
            return Mapper.Map<DepartmentInfo, DepartmentInfoDto>(entity);
        }
        #endregion

        #region LoanDeductProgress
        public static LoanDeductProgressDto ToModelGo(this LoanDeductProgress entity)
        {
            return Mapper.Map<LoanDeductProgress, LoanDeductProgressDto>(entity);
        }
        #endregion

        #region LoanDeductProgress
        public static Loan_DeductProgressDto ToModel(this LoanDeductProgress entity)
        {
            try
            {
                return Mapper.DynamicMap<LoanDeductProgress, Loan_DeductProgressDto>(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Loan_MonthRepayInfo
        public static Loan_MonthRepayInfoDto ToModel(this Loan_MonthRepay entity)
        {
            return Mapper.Map<Loan_MonthRepay, Loan_MonthRepayInfoDto>(entity);
        }
        #endregion

        #region LoanProductOrder
        public static LoanOrderDetailDto ToModel(this LoanProductOrder entity)
        {
            return Mapper.Map<LoanProductOrder, LoanOrderDetailDto>(entity);
        }
        #endregion

        #region Product
        public static ProductDto ToModel(this Product entity)
        {
            return Mapper.DynamicMap<Product, ProductDto>(entity);
        }
        #endregion

        #region UserInfo
        public static UserInfoDto ToModel(this UserInfo entity)
        {
            return Mapper.Map<UserInfo, UserInfoDto>(entity);
        }
        #endregion

        #region UserFamilyInfo
        public static UserFamilyInfoDto ToModel(this UserFamilyInfo entity)
        {
            return Mapper.Map<UserFamilyInfo, UserFamilyInfoDto>(entity);
        }
        #endregion

        #region UserFamilyInfo
        public static UserWorkInfoDto ToModel(this UserWorkInfo entity)
        {
            return Mapper.Map<UserWorkInfo, UserWorkInfoDto>(entity);
        }
        #endregion

        #region BankInfo
        public static BankInfoDto ToModel(this BankInfo entity)
        {
            return Mapper.DynamicMap<BankInfo, BankInfoDto>(entity);
        }
        #endregion

     
    }
}
