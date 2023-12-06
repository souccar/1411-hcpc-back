using Abp.Events.Bus;

namespace Souccar.Hcpc.Warehouses.Events
{
    public class ModifyCurrentQuantityOfWarehouseMaterialData : EventData
    {
        public ModifyCurrentQuantityOfWarehouseMaterialData(int? warehouseMaterialId, double quantity)
        {
            WarehouseMaterialId = warehouseMaterialId;
            Quantity = quantity;
        }

        public int? WarehouseMaterialId { get; set; }
        public double Quantity { get; set; }
    }
}
