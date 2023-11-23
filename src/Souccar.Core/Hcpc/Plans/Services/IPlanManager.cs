using Souccar.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Services
{
    public interface IPlanManager: ISouccarDomainService<Plan,int>
    {
        Plan GetWithDetails(int id);
        Task<Plan> GetLastPlanAsync();

    }
}
