using AutoMapper;
using Dscf.AuthCenter.Domain;
using Dscf.AuthCenter.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dscf.AuthCenter.Dto.Extension;

namespace Dscf.AuthCenter.Host
{
    public static class AutoMapperStrapper
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
          {
              config.CreateMap<OperaterInfo, OperaterInfoDto>().ForMember(dto => dto.RoleIdList, opt => { opt.MapFrom(src => src.RoleList.Select(r => r.Id)); });

              config.CreateMap<DepartmentInfo, DepartmentInfoDto>();

              config.CreateMap<Dscf.AuthCenter.Dto.DscfCreditLoanService.DepartmentInfoDto, DepartmentInfoDto>()
                  .ForMember(dto => dto.Id, opt => { opt.MapFrom(src => src.DepId); });

              config.CreateMap<Dictionary, DictionaryDto>();
          });
        }
    }
}