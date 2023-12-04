using Souccar.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Warehouses.Services.WarehouseServices
{
    public interface IWarehouseMaterialManager : ISouccarDomainService<WarehouseMaterial, int>
    {
        Task<List<WarehouseMaterial>> GetAllThatWillExpire();
        Task<WarehouseMaterial> GetWithDetailsAsync(int id);
    }
}
