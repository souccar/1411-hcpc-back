using Souccar.Core.Services.Interfaces;
using Souccar.Hcpc.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Services
{
    public interface IPlanManager: ISouccarDomainService<Plan,int>
    {
        Plan GetWithDetails(int id);
        Task<Plan> GetLastPlanAsync();
        Task<Plan> GetLastPlanActualAsync();
        Plan UpdatePlan(Plan plan);
        Task<Plan> ChangeStausToActual(int id);
        Task<Plan> ChangeStausToArchive(int id);
        IList<Plan> GetActualPlans();
        IList<Plan> GetPendingPlans();
        IQueryable<Product> GetProductsOfPlan(int planId);

    }
}
