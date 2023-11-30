using AutoMapper;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Map
{
    public class OutputRequestMaterialMapProfile : Profile
    {
        public OutputRequestMaterialMapProfile()
        {
            CreateMap<OutputRequestMaterial, OutputRequestMaterialDto>();
            CreateMap<OutputRequestMaterial, ReadOutputRequestMaterialDto>();
            CreateMap<CreateOutputRequestMaterialDto, OutputRequestMaterial>();
            CreateMap<UpdateOutputRequestMaterialDto, OutputRequestMaterial>();
            CreateMap<OutputRequestMaterial, UpdateOutputRequestMaterialDto>();
        }
    }
}
