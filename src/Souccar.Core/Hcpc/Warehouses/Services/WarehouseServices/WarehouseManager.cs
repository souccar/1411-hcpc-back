using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.Hcpc.Warehouses.Services.WarehouseServices
{
    public class WarehouseManager : SouccarDomainService<Warehouse, int>, IWarehouseManager
    {
        public WarehouseManager(IRepository<Warehouse, int> repository) : base(repository)
        {
        }
    }
}
