using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.Warehouses.Dto
{
    public class CreateWarehouseDto
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public string WarehouseKeeper { get; set; }
    }
}
