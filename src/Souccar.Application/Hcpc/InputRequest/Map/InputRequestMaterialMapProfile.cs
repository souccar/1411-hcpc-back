using AutoMapper;
using Souccar.Hcpc.InputRequest.Dto.InputRequestMaterialDto;

namespace Souccar.Hcpc.InputRequest.Map
{
    public class InputRequestMaterialMapProfile : Profile
    {
        public InputRequestMaterialMapProfile()
        {
            CreateMap<Souccar.Hcpc.Warehouses.InputRequestMaterial, InputRequestMaterialDto>();
            CreateMap<Souccar.Hcpc.Warehouses.InputRequestMaterial, ReadInputRequestMaterialDto>();
            CreateMap<CreateInputRequestMaterialDto, Souccar.Hcpc.Warehouses.InputRequestMaterial>();
            CreateMap<UpdateInputRequestMaterialDto, Souccar.Hcpc.Warehouses.InputRequestMaterial>();
            CreateMap<Souccar.Hcpc.Warehouses.InputRequestMaterial, UpdateInputRequestMaterialDto>();
        }
    }
}
