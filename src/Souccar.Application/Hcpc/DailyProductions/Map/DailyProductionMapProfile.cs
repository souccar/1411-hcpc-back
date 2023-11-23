using Abp.Application.Services.Dto;
using AutoMapper;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.DailyProductions.Map
{
    public class DailyProductionMapProfile : Profile
    {
        public DailyProductionMapProfile()
        {
            CreateMap<DailyProduction, DailyProductionDto>();
            CreateMap<CreateDailyProductionDto, DailyProduction>();
            CreateMap<UpdateDailyProductionDto, DailyProduction>();
            CreateMap<DailyProduction, UpdateDailyProductionDto>();
            CreateMap<List<DailyProduction>, PagedResultDto<DailyProductionDto>>();
        }
    }
}
