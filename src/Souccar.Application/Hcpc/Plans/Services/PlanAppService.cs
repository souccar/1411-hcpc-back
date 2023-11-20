using Souccar.Core.Services;
using Souccar.Hcpc.Plans.Dto.Plans;

namespace Souccar.Hcpc.Plans.Services
{
    public class PlanAppService: AsyncSouccarAppService<Plan, PlanDto, int, PagedPlanRequestDto, CreatePlanDto, UpdatePlanDto>, IPlanAppService
    {
        private readonly IPlanManager _planManager;
        public PlanAppService(IPlanManager planManager) : base(planManager)
        {
            _planManager = planManager;
        }
    }
}
