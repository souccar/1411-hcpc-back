using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Abp.UI;
using Souccar.Hcpc.Units.Services;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Warehouses.Events
{
    public class ModifyCurrentQuantityOfWarehouseMaterialHandler : IAsyncEventHandler<ModifyCurrentQuantityOfWarehouseMaterialData>, ITransientDependency
    {
        private readonly IWarehouseMaterialManager _warehouseMaterialManager;
        private readonly ITransferManager _transferManager;

        public ModifyCurrentQuantityOfWarehouseMaterialHandler(IWarehouseMaterialManager warehouseMaterialManager, ITransferManager transferManager)
        {
            _warehouseMaterialManager = warehouseMaterialManager;
            _transferManager = transferManager;
        }

        public async Task HandleEventAsync(ModifyCurrentQuantityOfWarehouseMaterialData eventData)
        {
            var warehouseMaterial = await _warehouseMaterialManager.GetWithDetailsAsync((int)eventData.WarehouseMaterialId);
            var quantity = await _transferManager.ConvertTo(eventData.UnitId, warehouseMaterial.UnitId, eventData.Quantity);
            if (warehouseMaterial != null) {

                if (warehouseMaterial.CurrentQuantity < quantity)
                {
                    throw new UserFriendlyException("Current Quantity Of Material " + warehouseMaterial.Material.Code  + " / " + warehouseMaterial.ExpirationDate + " is not Enough");
                }

                warehouseMaterial.CurrentQuantity = warehouseMaterial.CurrentQuantity - quantity;

                await _warehouseMaterialManager.UpdateAsync(warehouseMaterial);
            }
            
        }
    }
}
