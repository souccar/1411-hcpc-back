using AutoMapper;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Materials;

namespace Souccar.Hcpc.Materials.Map
{
    public class MaterialMapProfile: Profile
    {
        public MaterialMapProfile()
        {
            CreateMap<Material, MaterialDto>();
            CreateMap<Material, ReadMaterialDto>();
            CreateMap<CreateMaterialDto, Material>();
            CreateMap<UpdateMaterialDto, Material>();
            CreateMap<Material, UpdateMaterialDto>();
        }
    }
}
