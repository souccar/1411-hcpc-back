using Souccar.Core.Services;
using Souccar.Hcpc.Plans.Dto.Plans;

namespace Souccar.Hcpc.Plans.Services
{
    public interface IPlanAppService : IAsyncSouccarAppService<PlanDto, int, PagedPlanRequestDto, CreatePlanDto, UpdatePlanDto>
    {
    }
}
