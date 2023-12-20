using Abp.Domain.Repositories;
using Abp.UI;
using Souccar.Core.Services.Implements;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Warehouses.Services.WarehouseServices
{
    public class WarehouseManager : SouccarDomainService<Warehouse, int>, IWarehouseManager
    {
        private readonly IRepository<Warehouse> _warehouseRepository;
        private readonly IWarehouseMaterialManager _warehouseMaterialManager;

        public WarehouseManager(IRepository<Warehouse> warehouseRepository, IWarehouseMaterialManager warehouseMaterialManager) : base(warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
            _warehouseMaterialManager = warehouseMaterialManager;
        }

        public override Task DeleteAsync(int id)
        {
            var relatedWarehouseMaterilas = _warehouseMaterialManager.GetAll()
                .Any(x => x.WarehouseId == id);
            if (relatedWarehouseMaterilas)
            {
                throw new UserFriendlyException("Cannot be deleted, This warehouse is associated with warehouse materials");
            }
            return base.DeleteAsync(id);
        }
    }
}
