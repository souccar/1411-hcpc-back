using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto
{
    public class WarehouseMaterialNameDto : IEntityDto<int>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int? MaterialId { get; set; }
        public int? WarehouseId { get; set; }

        public MaterialDto Material { get; set; }
        public WarehouseDto Warehouse { get; set; }

    }
}
