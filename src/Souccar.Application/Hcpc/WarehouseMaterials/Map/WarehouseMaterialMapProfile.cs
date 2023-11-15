using AutoMapper;
using Souccar.Hcpc.WarehouseMaterials.Dto;
using Souccar.Hcpc.WarehouseMaterials;

namespace Souccar.Hcpc.WarehouseMaterials.Map
{
    public class WarehouseMaterialMapProfile: Profile
    {
        public WarehouseMaterialMapProfile()
        {
            CreateMap<WarehouseMaterial, WarehouseMaterialDto>();
            CreateMap<WarehouseMaterial, ReadWarehouseMaterialDto>();
            CreateMap<CreateWarehouseMaterialDto, WarehouseMaterial>();
            CreateMap<UpdateWarehouseMaterialDto, WarehouseMaterial>();
            CreateMap<WarehouseMaterial, UpdateWarehouseMaterialDto>();
        }
    }
}
