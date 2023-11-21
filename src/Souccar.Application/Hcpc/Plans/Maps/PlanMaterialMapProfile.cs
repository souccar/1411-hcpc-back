using AutoMapper;
using Souccar.Hcpc.Plans.Dto.PlanMaterials;
using Souccar.Hcpc.Plans.Dto.Plans;

namespace Souccar.Hcpc.Plans.Maps
{
    public class PlanMaterialMapProfile : Profile
    {
        public PlanMaterialMapProfile()
        {
            CreateMap<PlanMaterial, PlanMaterialDto>();
            CreateMap<CreatePlanMaterialDto, PlanMaterial>();
            //CreateMap<UpdatePlanMaterialDto, PlanMaterial>();
            //CreateMap<PlanMaterial, UpdatePlanDto>();
        }
    }
}
