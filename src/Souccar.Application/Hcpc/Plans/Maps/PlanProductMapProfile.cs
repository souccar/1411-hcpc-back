using AutoMapper;
using Souccar.Hcpc.Plans.Dto.PlanProducts;

namespace Souccar.Hcpc.Plans.Maps
{
    public class PlanProductMapProfile: Profile
    {
        public PlanProductMapProfile()
        {
            CreateMap<PlanProduct, PlanProductDto>();
            CreateMap<CreatePlanProductDto, PlanProduct>();
            CreateMap<UpdatePlanProductDto, PlanProduct>();
            CreateMap<PlanProduct, UpdatePlanProductDto>();
        }
    }
}
