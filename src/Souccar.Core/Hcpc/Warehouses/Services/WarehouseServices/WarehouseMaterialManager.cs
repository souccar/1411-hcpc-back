using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Warehouses.Services.WarehouseServices
{
    public class WarehouseMaterialManager : SouccarDomainService<WarehouseMaterial, int>, IWarehouseMaterialManager
    {
        private readonly IRepository<WarehouseMaterial> _warehouseMaterialRepository;
        public WarehouseMaterialManager(IRepository<WarehouseMaterial> warehouseMaterialRepository) : base(warehouseMaterialRepository)
        {
            _warehouseMaterialRepository = warehouseMaterialRepository;
        }

        public async Task<WarehouseMaterial> GetWithDetailsAsync(int id)
        {
            var warehouseMaterial = await _warehouseMaterialRepository.GetAsync(id);

            if (warehouseMaterial != null)
            {
                await _warehouseMaterialRepository.EnsurePropertyLoadedAsync(warehouseMaterial, w => w.Warehouse);
                await _warehouseMaterialRepository.EnsurePropertyLoadedAsync(warehouseMaterial, s => s.Supplier);
                await _warehouseMaterialRepository.EnsurePropertyLoadedAsync(warehouseMaterial, m => m.Material);
                await _warehouseMaterialRepository.EnsurePropertyLoadedAsync(warehouseMaterial, up => up.UnitPrice);
                await _warehouseMaterialRepository.EnsurePropertyLoadedAsync(warehouseMaterial, u => u.Unit);
            }

            return warehouseMaterial;
        }
    }
}