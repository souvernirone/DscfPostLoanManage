using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Dscf.LoanAfter.Domain;
using Dscf.LoanAfter.Dto;

namespace Dscf.LoanAfter.Host
{
    public static class AutoMapperStrapper
    {
        public static void RegisterMaps()
        {

            AutoMapper.Mapper.Initialize(config =>
            {

                config.CreateMap<RepayRemind, RepayRemindDto>();
                config.CreateMap<RepayRemindDto, RepayRemind>().ForMember(entity => entity.CreateTime, opt => opt.Ignore());

                config.CreateMap<DeductPayApplyDto, DeductPayApply>();
                config.CreateMap<DeductPayApply, DeductPayApplyDto>();

                config.CreateMap<FileEntity, FileEntityDto>();
                config.CreateMap<FileEntityDto, FileEntity>();

                //催收信息记录
                config.CreateMap<CollectionInfo, CollectionInfoDto>();
                config.CreateMap<CollectionInfoDto, CollectionInfo>();

                //新增信息
                config.CreateMap<ExtraInfo, ExtraInfoDto>();
                config.CreateMap<ExtraInfoDto, ExtraInfo>();
            });

        }
    }
}