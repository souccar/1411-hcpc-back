using Abp.Application.Services.Dto;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.Warehouses.Dto
{
    public class ReadWarehouseDto : IEntityDto
    {
        public ReadWarehouseDto()
        {
            WarehouseMaterials = new List<ReadWarehouseMaterialDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string WarehouseKeeper { get; set; }
        public IList<ReadWarehouseMaterialDto> WarehouseMaterials { get; set; }
    }
}
