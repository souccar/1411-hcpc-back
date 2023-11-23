using Souccar.Core.Services.Interfaces;

namespace Souccar.Hcpc.Plans.Services
{
    public interface IPlanManager: ISouccarDomainService<Plan,int>
    {
        Plan GetWithDetails(int id);
    }
}
