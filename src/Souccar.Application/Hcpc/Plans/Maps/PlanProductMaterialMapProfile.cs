using AutoMapper;
using Souccar.Hcpc.Plans.Dto.PlanProductMaterials;

namespace Souccar.Hcpc.Plans.Maps
{
    public class PlanProductMaterialMapProfile: Profile
    {
        public PlanProductMaterialMapProfile()
        {
            CreateMap<PlanProductMaterial, PlanProductMaterialDto>();
            CreateMap<CreatePlanProductMaterialDto, PlanProductMaterial>();
            CreateMap<UpdatePlanProductMaterialDto, PlanProduct>();
            CreateMap<PlanProductMaterial, UpdatePlanProductMaterialDto>();
        }
    }
}
