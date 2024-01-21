using Souccar.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Units.Services
{
    public interface IUnitManager : ISouccarDomainService<Unit, int>
    {
        Task<Unit> GetIncludeParentAsync(int id);
        Task<IList<Unit>> GetAllParentUnitsAsync();
        Task<IList<Unit>> GetAllRelatedUnitsAsync(int id);
    }
}
