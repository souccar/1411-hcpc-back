using System;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto
{
    public class CreateWarehouseMaterialDto
    {
        public string EntryDate { get; set; }
        public double InitialQuantity { get; set; }
        public string ExpirationDate { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }


        public int? UnitId { get; set; }
        public int? UnitPriceId { get; set; }
        public int? MaterialId { get; set; }
        public int? SupplierId { get; set; }
        public int? WarehouseId { get; set; }
    }
}
