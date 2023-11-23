using Souccar.Core.Services.Interfaces;
using System.Collections.Generic;

namespace Souccar.Hcpc.DailyProductions.Services
{
    public interface IDailyProductionManager : ISouccarDomainService<DailyProduction, int>
    {
        DailyProduction GetWithDetails(int id);
        List<DailyProduction> GetAllIncluding();
    }
}
