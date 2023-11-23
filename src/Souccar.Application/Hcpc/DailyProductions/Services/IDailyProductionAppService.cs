using Souccar.Core.Services;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos;

namespace Souccar.Hcpc.DailyProductions.Services
{
    public interface IDailyProductionAppService : IAsyncSouccarAppService<DailyProductionDto, int, PagedDailyProductionRequestDto, CreateDailyProductionDto, UpdateDailyProductionDto>
    {
    }
}
