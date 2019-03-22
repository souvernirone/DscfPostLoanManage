using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Dscf.CreditLoan.Domain;
using Dscf.CreditLoan.Dto;
namespace Dscf.CreditLoan.Host
{
    public static class AutoMapperStrapper
    {
        public static void RegisterMaps()
        {

            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<DepartmentInfo, DepartmentInfoDto>();

                config.CreateMap<Loan_MonthRepay, Loan_MonthRepayInfoDto>();

                config.CreateMap<LoanProductOrder, LoanOrderDetailDto>();

                config.CreateMap<UserInfo, UserInfoDto>();

                config.CreateMap<UserFamilyInfo, UserFamilyInfoDto>();

                config.CreateMap<UserWorkInfo, UserWorkInfoDto>();

                config.CreateMap<LoanDeductProgress, LoanDeductProgressDto>();
            });

        }
    }
}