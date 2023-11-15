using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.Hcpc.Warehouses.Services
{
    public class WarehouseMaterialManager : SouccarDomainService<WarehouseMaterial, int>, IWarehouseMaterialManager
    {
        public WarehouseMaterialManager(IRepository<WarehouseMaterial> repository) : base(repository)
        {

        }
    }
}