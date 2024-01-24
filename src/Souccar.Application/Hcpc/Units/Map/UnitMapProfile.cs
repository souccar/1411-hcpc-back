using AutoMapper;
using Souccar.Hcpc.Units.Dto.Units;

namespace Souccar.Hcpc.Units.Map
{
    public class UnitMapProfile : Profile
    {
        public UnitMapProfile()
        {
            CreateMap<Unit, UnitDto>();
            CreateMap<Unit, ReadUnitDto>();
            CreateMap<CreateUnitDto, Unit>();
            CreateMap<UpdateUnitDto, Unit>();
            CreateMap<Unit, UpdateUnitDto>();
            CreateMap<Unit, ParentUnitDto>();
            CreateMap<Unit, UnitNameForDropdownDto>();
        }
    }
}
