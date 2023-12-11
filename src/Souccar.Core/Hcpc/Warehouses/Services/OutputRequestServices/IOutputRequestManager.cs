using Souccar.Core.Services.Interfaces;
using Souccar.Hcpc.DailyProductions;
using Souccar.Hcpc.Products;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Warehouses.Services.OutputRequestServices
{
    public interface IOutputRequestManager : ISouccarDomainService<OutputRequest, int>
    {
        OutputRequest GetOutputRequestWithDetails(int id);
        IQueryable<OutputRequest> GetPlanOutputRequests(int planId);

        public List<OutputRequest> GetAllIncluding();
    }
}
