using AutoMapper;
using Dscf.PostLoan.AuthCenterBLL.DscfACService;
using Dscf.PostLoan.CarLoanBLL.DscfCarLoanService;
using Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService;
using Dscf.PostLoan.LoanAfterBLL.DscfLoanAfterService;
using Dscf.PostLoan.Model;
using Dscf.Settlement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dscf.SettleMents.Web.App_Start
{
    public static class AutoMapperStrapper
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
           {

               config.CreateMap<LoanSearchaRequest, LoanSearchViewModels>();
               config.CreateMap<LoanSearchViewModels, LoanSearchaRequest>();
               config.CreateMap<LoanSearchViewModels, Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.LoanSearchViewModel>();

               config.CreateMap<Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.DepartmentInfoDto, DeptViewModel>().ForMember(dto => dto.Id, opt => { opt.MapFrom(src => src.DepId); });

               config.CreateMap<Dscf.Settlement.Model.PartialLoanInfoViewModel, CarLoanInfoDetailViewModel>();
               config.CreateMap<CarLoanInfoDetailViewModel, Dscf.Settlement.Model.PartialLoanInfoViewModel>();

               config.CreateMap<Dscf.Settlement.Model.PartialLoanInfoViewModel, Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.LoanInfoDto>();
               config.CreateMap<Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.LoanInfoDto, Dscf.Settlement.Model.PartialLoanInfoViewModel>()
                   .ForMember(dto => dto.BankName, opt => opt.MapFrom(src => src.DeductBankName))
                   .ForMember(dto => dto.SubBranchName, opt => opt.MapFrom(src => src.DeductBranchBank))
                   .ForMember(dto => dto.BankCard, opt => opt.MapFrom(src => src.DeductBankAccount));
               config.CreateMap<Dscf.PostLoan.CarLoanBLL.DscfCarLoanService.LoanProductOrderDto, CarLoanInfoDetailViewModel>();

               //config.CreateMap<LoanMonthRepayDto, CarLoanMonthRepayViewModel>()//如果（当前时间早于月还计划时间并且划扣状态为0）账单状态为未划扣，如果（当前时间晚于月还计划时间并且划扣状态为1）账单状态为已划扣，其他情况为取消（异常）
               //     .ForMember(d => d.IsDeductSucess, opt => opt.MapFrom(
               //         s => ((DateTime.Compare(DateTime.Now, s.RepayDate.Value) <= 0 && s.IsDeductSucess == false) ? 0 : ((DateTime.Compare(DateTime.Now, s.RepayDate.Value) >= 0 && s.IsDeductSucess == true) ? 1 : -1))));

               //config.CreateMap<LoanInfoViewModel, Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.LoanInfoDto>();

               //config.CreateMap<LoanSearchViewModel, Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.LoanSearchViewModel>();

               //config.CreateMap<Dscf.PostLoan.CreditLoanBLL.DscfCreditLoanService.Loan_MonthRepayInfoDto, Loan_MonthRepayViewModel>();

               //config.CreateMap<DeductPayApplyViewModel, LoanAfterBLL.DscfLoanAfterService.DeductPayApplyDto>();
               //config.CreateMap<LoanAfterBLL.DscfLoanAfterService.UpFileResultMessage, LoanAfterBLL.DscfLoanAfterService.FileEntityDto>();

               //config.CreateMap<CollectionInfoViewModel, LoanAfterBLL.DscfLoanAfterService.CollectionInfoDto>();
               config.CreateMap<DeductProgressDto, DeductProgressInfo>().ForMember(dest => dest.OperateDate, dto => dto.MapFrom(src => src.CreateTime));
               config.CreateMap<LoanDeductProgressDto, DeductProgressInfo>().ForMember(dest => dest.PaymentType, dto => dto.MapFrom(src => src.IsPaymentType));

               config.CreateMap<Loan_DeductProgressDto, DeductProgressInfo>();
               config.CreateMap<DeductProgressInfo, Loan_DeductProgressDto>().ForMember(dest => dest.LoanOrderId, dto => dto.MapFrom(src => src.OrderId));
               config.CreateMap<LoanMonthRepayDto, CarLoanMonthRepayViewModel>()//如果（当前时间早于月还计划时间并且划扣状态为0）账单状态为未划扣，如果（当前时间晚于月还计划时间并且划扣状态为1）账单状态为已划扣，其他情况为取消（异常）
                 .ForMember(d => d.IsDeductSucess, opt => opt.MapFrom(
                     s => ((DateTime.Compare(DateTime.Now, s.RepayDate.Value) <= 0 && s.IsDeductSucess == false) ? 0 : ((DateTime.Compare(DateTime.Now, s.RepayDate.Value) >= 0 && s.IsDeductSucess == true) ? 1 : -1))));
               config.CreateMap<OverdueExportExcleViewModel, CreditOverdueSearchRequest>();
               config.CreateMap<OverdueExportExcleViewModel, OverdueSearchRequest>();
               config.CreateMap<OverdueSearchRequest, OverdueExportExcleViewModel>();
               config.CreateMap<CarOverdueExcelDto, CarOverdueExcelViewModel>();
               config.CreateMap<CreditOverdueExcelDto, CreditOverdueExcelViewModel>();
               config.CreateMap<CreditOverdueExcelDto, CreditOverdueExcelViewModel>();

               config.CreateMap<DeductViewModel, CarDeductViewModelDto>();

               config.CreateMap<DeductViewModel, CreditDeductViewDto>();

           });
        }
    }
}