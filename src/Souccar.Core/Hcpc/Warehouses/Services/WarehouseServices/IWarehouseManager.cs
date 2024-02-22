using Souccar.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Warehouses.Services.WarehouseServices
{
    public interface IWarehouseManager : ISouccarDomainService<Warehouse, int>
    {
        Task<Warehouse> GetWarehouseByIdWithDetails(int id);
    }
}
