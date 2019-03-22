using AutoMapper;
using Dscf.PostLoan.AuthCenterBLL.DscfACService;
using Dscf.PostLoan.CarLoanBLL.DscfCarLoanService;
using Dscf.PostLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dscf.Settlement.Model;


namespace Dscf.PostLoan.Web
{
    public static class AutoMapperStrapper
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
           {

               config.CreateMap<DepartmentInfoDto, DeptViewModel>();

               config.CreateMap<Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.DepartmentInfoDto, DeptViewModel>().ForMember(dto => dto.Id, opt => { opt.MapFrom(src => src.DepId); });

               config.CreateMap<LoanProductOrderDto, LoanInfoViewModel>();
               config.CreateMap<LoanSearchaRequest, LoanSearchViewModel>();

               config.CreateMap<LoanInfoViewModel, LoanProductOrderDto>();
               config.CreateMap<LoanSearchViewModel, LoanSearchaRequest>();

               config.CreateMap<LoanProductOrderDto, CarLoanInfoDetailViewModel>();

               config.CreateMap<LoanMonthRepayDto, CarLoanMonthRepayViewModel>()//如果（当前时间早于月还计划时间并且划扣状态为0）账单状态为未划扣，如果（当前时间晚于月还计划时间并且划扣状态为1）账单状态为已划扣，其他情况为取消（异常）
                    .ForMember(d => d.IsDeductSucess, opt => opt.MapFrom(
                        s => ((DateTime.Compare(DateTime.Now, s.RepayDate.Value) <= 0 && s.IsDeductSucess == false) ? 0 : ((DateTime.Compare(DateTime.Now, s.RepayDate.Value) >= 0 && s.IsDeductSucess == true) ? 1 : -1))));

               config.CreateMap<LoanInfoViewModel, Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.LoanInfoDto>();

               config.CreateMap<LoanSearchViewModel, Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.LoanSearchViewModel>();

               config.CreateMap<Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.Loan_MonthRepayInfoDto, Loan_MonthRepayViewModel>();

               config.CreateMap<DeductPayApplyViewModel, LoanAfterBLL.DscfLoanAfterService.DeductPayApplyDto>();
               config.CreateMap<LoanAfterBLL.DscfLoanAfterService.UpFileResultMessage, LoanAfterBLL.DscfLoanAfterService.FileEntityDto>();

               config.CreateMap<CollectionInfoViewModel, LoanAfterBLL.DscfLoanAfterService.CollectionInfoDto>();
               config.CreateMap<DeductProgressDto, DeductProgressInfo>().ForMember(dest => dest.OperateDate, dto => dto.MapFrom(src => src.CreateTime));
               config.CreateMap<Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.LoanDeductProgressDto, DeductProgressInfo>().ForMember(dest => dest.PaymentType, dto => dto.MapFrom(src => src.IsPaymentType));


           });
        }
    }
}