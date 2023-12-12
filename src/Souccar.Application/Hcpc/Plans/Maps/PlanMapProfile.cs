using AutoMapper;
using Souccar.Hcpc.Plans.Dto.Plans;

namespace Souccar.Hcpc.Plans.Maps
{
    public class PlanMapProfile: Profile
    {
        public PlanMapProfile()
        {
            CreateMap<Plan, PlanDto>();
            CreateMap<CreatePlanDto, Plan>();
            CreateMap<UpdatePlanDto, Plan>();
            CreateMap<Plan, UpdatePlanDto>();
            CreateMap<Plan, PlanNameDto>();
            CreateMap<Plan, PlanNameForDropdownDto>();
        }
    }
}
