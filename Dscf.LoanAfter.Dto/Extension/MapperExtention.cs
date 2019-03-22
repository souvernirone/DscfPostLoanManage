using AutoMapper;
using Dscf.LoanAfter.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dscf.LoanAfter.Dto
{
    public static class MapperExtention
    {
        #region RepayRemind
        public static RepayRemindDto ToModel(this RepayRemind entity)
        {
            return Mapper.Map<RepayRemind, RepayRemindDto>(entity);
        }

        public static RepayRemind ToEntity(this RepayRemindDto model)
        {
            return Mapper.Map<RepayRemindDto, RepayRemind>(model);
        }
        #endregion

        #region DeductPayApply

        public static DeductPayApply ToEntity(this DeductPayApplyDto model)
        {
            return Mapper.Map<DeductPayApplyDto, DeductPayApply>(model);
        }
        public static DeductPayApplyDto ToModel(this DeductPayApply entity)
        {
            return Mapper.Map<DeductPayApply, DeductPayApplyDto>(entity);
        }
        #endregion

        #region DeductPayApply

        public static CollectionInfo ToEntity(this CollectionInfoDto model)
        {
            return Mapper.Map<CollectionInfoDto, CollectionInfo>(model);
        }
        public static CollectionInfoDto ToModel(this CollectionInfo model)
        {
            return Mapper.Map<CollectionInfo, CollectionInfoDto>(model);
        }
        #endregion

        #region ExtraInfo

        public static ExtraInfo ToEntity(this ExtraInfoDto model)
        {
            return Mapper.Map<ExtraInfoDto, ExtraInfo>(model);
        }

        public static ExtraInfoDto ToModel(this ExtraInfo model)
        {
            return Mapper.Map<ExtraInfo, ExtraInfoDto>(model);
        }

        public static Dscf.LoanAfter.Dto.DscfCarLoanService.CarFinancialExportExcleRequest ToCarModel(this FinancialExportExcleRequest model)
        {
            return Mapper.DynamicMap<FinancialExportExcleRequest, Dscf.LoanAfter.Dto.DscfCarLoanService.CarFinancialExportExcleRequest>(model);
        }

        public static FinancialExportExcleDto ToModel(this Dscf.LoanAfter.Dto.DscfCarLoanService.CarFinancialExportExcleDto model)
        {
            return Mapper.DynamicMap<Dscf.LoanAfter.Dto.DscfCarLoanService.CarFinancialExportExcleDto, FinancialExportExcleDto>(model);
        }

        public static Dscf.LoanAfter.Dto.DscfCreditLoanService.CreditFinancialExportExcleRequest ToCreditModel(this FinancialExportExcleRequest model)
        {
            return Mapper.DynamicMap<FinancialExportExcleRequest, Dscf.LoanAfter.Dto.DscfCreditLoanService.CreditFinancialExportExcleRequest>(model);
        }

        public static FinancialExportExcleDto ToModel(this Dscf.LoanAfter.Dto.DscfCreditLoanService.CreditFinancialExportExcleDto model)
        {
            return Mapper.DynamicMap<Dscf.LoanAfter.Dto.DscfCreditLoanService.CreditFinancialExportExcleDto, FinancialExportExcleDto>(model);
        }
        #endregion
    }
}
