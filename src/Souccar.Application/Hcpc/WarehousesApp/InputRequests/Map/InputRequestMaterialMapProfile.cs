using AutoMapper;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.InputRequests.Dto.InputRequestMaterialDtos;

namespace Souccar.Hcpc.WarehousesApp.InputRequests.Map
{
    public class InputRequestMaterialMapProfile : Profile
    {
        public InputRequestMaterialMapProfile()
        {
            CreateMap<InputRequestMaterial, InputRequestMaterialDto>();
            CreateMap<InputRequestMaterial, ReadInputRequestMaterialDto>();
            CreateMap<CreateInputRequestMaterialDto, InputRequestMaterial>();
            CreateMap<UpdateInputRequestMaterialDto, InputRequestMaterial>();
            CreateMap<InputRequestMaterial, UpdateInputRequestMaterialDto>();
        }
    }
}
