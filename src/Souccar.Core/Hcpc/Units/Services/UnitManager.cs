using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.Hcpc.Units.Services
{
    public class UnitManager : SouccarDomainService<Unit, int>, IUnitManager
    {
        public UnitManager(IRepository<Unit> repository) : base(repository)
        {

        }
    }
}
