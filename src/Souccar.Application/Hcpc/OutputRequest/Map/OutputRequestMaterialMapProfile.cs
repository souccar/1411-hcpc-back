using AutoMapper;
using Souccar.Hcpc.OutputRequest.Dto.OutputRequestMaterialDtos;

namespace Souccar.Hcpc.OutputRequest.Map
{
    public class OutputRequestMaterialMapProfile : Profile
    {
        public OutputRequestMaterialMapProfile()
        {
            CreateMap<Souccar.Hcpc.Warehouses.OutputRequestMaterial, OutputRequestMaterialDto>();
            CreateMap<Souccar.Hcpc.Warehouses.OutputRequestMaterial, ReadOutputRequestMaterialDto>();
            CreateMap<CreateOutputRequestMaterialDto, Souccar.Hcpc.Warehouses.OutputRequestMaterial>();
            CreateMap<UpdateOutputRequestMaterialDto, Souccar.Hcpc.Warehouses.OutputRequestMaterial>();
            CreateMap<Souccar.Hcpc.Warehouses.OutputRequestMaterial, UpdateOutputRequestMaterialDto>();
        }
    }
}
