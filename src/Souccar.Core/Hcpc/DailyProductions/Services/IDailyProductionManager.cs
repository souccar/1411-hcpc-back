using Souccar.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.DailyProductions.Services
{
    public interface IDailyProductionManager : ISouccarDomainService<DailyProduction, int>
    {
        DailyProduction GetWithDetails(int id);
        List<DailyProduction> GetAllIncluding();
        Dictionary<int, int> GetAllProductionsCountForPlan(int PlanId);
        Task<DailyProductionNote> AddNoteForDailyProductionAsync(string note,int dailyProductionId);
    }
}
