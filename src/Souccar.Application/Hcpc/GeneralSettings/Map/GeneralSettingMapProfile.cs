using AutoMapper;
using Souccar.Hcpc.GeneralSettings.Dto;

namespace Souccar.Hcpc.GeneralSettings.Map
{
    public class GeneralSettingMapProfile : Profile
    {
        public GeneralSettingMapProfile()
        {
            CreateMap<GeneralSetting, GeneralSettingDto>();
            CreateMap<GeneralSetting, ReadGeneralSettingDto>();
            CreateMap<CreateGeneralSettingDto, GeneralSetting>();
            CreateMap<UpdateGeneralSettingDto, GeneralSetting>();
            CreateMap<GeneralSetting, UpdateGeneralSettingDto>();
        }
    }
}
