using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.Warehouses.Dto
{
    public class CreateWarehouseDto
    {
        public CreateWarehouseDto()
        {
            WarehouseMaterials = new List<CreateWarehouseMaterialDto>();
        }

        public string Name { get; set; }
        public string Place { get; set; }
        public string WarehouseKeeper { get; set; }
        public IList<CreateWarehouseMaterialDto> WarehouseMaterials { get; set; }
    }
}
