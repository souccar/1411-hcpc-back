using Abp.Application.Services.Dto;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.Warehouses.Dto
{
    public class WarehouseDto : IEntityDto
    {
        public WarehouseDto()
        {
            WarehouseMaterials = new List<WarehouseMaterialDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string WarehouseKeeper { get; set; }
        public IList<WarehouseMaterialDto> WarehouseMaterials { get; set; }
    }
}
