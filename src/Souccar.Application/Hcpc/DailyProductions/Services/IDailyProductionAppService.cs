using Souccar.Core.Services;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionNoteDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.DailyProductions.Services
{
    public interface IDailyProductionAppService : IAsyncSouccarAppService<DailyProductionDto, int, PagedDailyProductionRequestDto, CreateDailyProductionDto, UpdateDailyProductionDto>
    {
        Dictionary<int, int> GetAllProductionsCountForPlan(int PlanId);
        Task<DailyProductionNoteDto> AddNote(string note,int dailyProductionId);
    }
}
