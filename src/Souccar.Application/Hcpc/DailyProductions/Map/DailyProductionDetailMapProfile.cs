using AutoMapper;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDetailsDtos;

namespace Souccar.Hcpc.DailyProductions.Map
{
    public class DailyProductionDetailMapProfile : Profile
    {
        public DailyProductionDetailMapProfile()
        {
            CreateMap<DailyProductionDetail, DailyProductionDetailsDto>();
            CreateMap<CreateDailyProductionDetailsDto, DailyProductionDetail>();
            CreateMap<UpdateDailyProductionDetailsDto, DailyProductionDetail>();
            CreateMap<DailyProductionDetail, UpdateDailyProductionDetailsDto>();
        }
    }
}
