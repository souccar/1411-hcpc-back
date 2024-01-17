using Abp.Events.Bus;

namespace Souccar.Hcpc.Warehouses.Events
{
    public class ModifyCurrentQuantityOfWarehouseMaterialData : EventData
    {
        public ModifyCurrentQuantityOfWarehouseMaterialData(int? warehouseMaterialId, double quantity, int? unitId)
        {
            WarehouseMaterialId = warehouseMaterialId;
            Quantity = quantity;
            UnitId = unitId;
        }

        public int? WarehouseMaterialId { get; set; }
        public double Quantity { get; set; }
        public int? UnitId { get; set; }
    }
}
