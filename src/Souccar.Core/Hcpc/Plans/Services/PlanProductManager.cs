using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.Hcpc.Plans.Services
{
    public class PlanProductManager : SouccarDomainService<PlanProduct, int>, IPlanProductManager
    {
        public PlanProductManager(IRepository<PlanProduct, int> repository) : base(repository)
        {
        }
    }
}
