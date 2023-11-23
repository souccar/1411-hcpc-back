using Souccar.Core.Services;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos;
using Souccar.Hcpc.Plans.Dto.Plans;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Services
{
    public interface IPlanAppService : IAsyncSouccarAppService<PlanDto, int, PagedPlanRequestDto, CreatePlanDto, UpdatePlanDto>
    {
        Task<PlanDto> GetLastPlanAsync();
    }
}
