using Souccar.Core.Services;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.DailyProductions.Services
{
    public interface IDailyProductionAppService : IAsyncSouccarAppService<DailyProductionDto, int, PagedDailyProductionRequestDto, CreateDailyProductionDto, UpdateDailyProductionDto>
    {
        Dictionary<int, int> GetAllProductionsCountForPlan(int PlanId);
    }
}
