using AutoMapper;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Materials;
using Souccar.Hcpc.Materials.Dto.MaterialDetailsDtos;

namespace Souccar.Hcpc.Materials.Map
{
    public class MaterialMapProfile: Profile
    {
        public MaterialMapProfile()
        {
            CreateMap<Material, MaterialDto>();
            CreateMap<Material, MaterialDetailDto>()
                .ForMember(m => m.WarehouseMaterials, x => x.Ignore());
            CreateMap<Material, ReadMaterialDto>();
            CreateMap<CreateMaterialDto, Material>();
            CreateMap<UpdateMaterialDto, Material>();
            CreateMap<Material, UpdateMaterialDto>();
            CreateMap<Material, MaterialCodeForDropdownDto>();
        }
    }
}
