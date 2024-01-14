using AutoMapper;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Map
{
    public class WarehouseMaterialMapProfile : Profile
    {
        public WarehouseMaterialMapProfile()
        {
            CreateMap<WarehouseMaterial, WarehouseMaterialDto>();
            CreateMap<WarehouseMaterial, ReadWarehouseMaterialDto>();
            CreateMap<CreateWarehouseMaterialDto, WarehouseMaterial>();
            CreateMap<UpdateWarehouseMaterialDto, WarehouseMaterial>();
            CreateMap<WarehouseMaterial, UpdateWarehouseMaterialDto>();
            CreateMap<WarehouseMaterial, WarehouseMaterialNameDto>();
            CreateMap<WarehouseMaterial, WarehouseMaterialIdDto>();
        }
    }
}
