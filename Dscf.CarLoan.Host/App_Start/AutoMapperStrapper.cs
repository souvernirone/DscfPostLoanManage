using AutoMapper;
using Dscf.CarLoan.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dscf.CarLoan.Domain;

namespace Dscf.CarLoan.Host
{
    public class AutoMapperStrapper
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
           {

               config.CreateMap<LoanMonthRepay, LoanMonthRepayDto>();
               config.CreateMap<CarLoanExtensionApply, CarLoanExtensionApplyDto>();
               config.CreateMap<CarLoanExtensionApplyDto, CarLoanExtensionApply>().ForMember(dto => dto.CreateTime, opt => opt.Ignore());

               config.CreateMap<LoanProductOrder, CarLoanOrderDetailDto>().ForMember(dto => dto.OrderId, order => { order.MapFrom(o => o.ProductOrderId); });

               config.CreateMap<LobbyInfo, LobbyInfoDto>();

               config.CreateMap<SignedInfo, SignedInfoDto>();

               config.CreateMap<CarInfo, CarInfoDto>();

               config.CreateMap<FaceTrialInfo, FaceTrialInfoDto>();

               config.CreateMap<CarLoanConfig, CarLoanConfigDto>();

               config.CreateMap<UserInfo, UserInfoDto>();

               config.CreateMap<UserWorkInfo, UserWorkInfoDto>();

               config.CreateMap<LoanMonthRepay, LoanMonthRepayDto>();

               config.CreateMap<ContractFormation, ContractFormationDto>();


               config.CreateMap<ExhibitionReview, ExhibitionReviewDto>();
               config.CreateMap<ExhibitionReviewDto, ExhibitionReview>();

               config.CreateMap<LoanProductOrder, LoanOrderDto>();
               config.CreateMap<LoanOrderDto, LoanProductOrder>();

               config.CreateMap<Images, ImagesDto>();
               config.CreateMap<ImagesDto, Images>();

               config.CreateMap<DeductProgress, DeductProgressDto>();

           });
        }
    }
}