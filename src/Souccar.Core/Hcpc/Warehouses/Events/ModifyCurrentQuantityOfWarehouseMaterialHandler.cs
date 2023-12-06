using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Abp.UI;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Warehouses.Events
{
    public class ModifyCurrentQuantityOfWarehouseMaterialHandler : IAsyncEventHandler<ModifyCurrentQuantityOfWarehouseMaterialData>, ITransientDependency
    {
        private readonly IWarehouseMaterialManager _warehouseMaterialManager;

        public ModifyCurrentQuantityOfWarehouseMaterialHandler(IWarehouseMaterialManager warehouseMaterialManager)
        {
            _warehouseMaterialManager = warehouseMaterialManager;
        }

        public async Task HandleEventAsync(ModifyCurrentQuantityOfWarehouseMaterialData eventData)
        {
            var warehouseMaterial = await _warehouseMaterialManager.GetWithDetailsAsync((int)eventData.WarehouseMaterialId);

            if (warehouseMaterial != null) {

                if (warehouseMaterial.CurrentQuantity < eventData.Quantity)
                {
                    throw new UserFriendlyException("Current Quantity Of Material " + warehouseMaterial.Material.Name + "/" + warehouseMaterial.Code + " is not Enough");
                }

                warehouseMaterial.CurrentQuantity = warehouseMaterial.CurrentQuantity - eventData.Quantity;

                await _warehouseMaterialManager.UpdateAsync(warehouseMaterial);
            }
            
        }
    }
}
