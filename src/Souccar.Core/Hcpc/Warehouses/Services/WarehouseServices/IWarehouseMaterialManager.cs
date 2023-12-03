using Souccar.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Warehouses.Services.WarehouseServices
{
    public interface IWarehouseMaterialManager : ISouccarDomainService<WarehouseMaterial, int>
    {
        Task<WarehouseMaterial> GetWithDetailsAsync(int id);
    }
}
