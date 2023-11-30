using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Suppliers.Dto;
using Souccar.Hcpc.Units.Dto.Units;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;

namespace Souccar.Hcpc.WarehousesApp.InputRequests.Dto.InputRequestMaterialDtos
{
    public class ReadInputRequestMaterialDto : IEntityDto<int>
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public string ExpirationDate { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }


        public int? UnitId { get; set; }
        public int? MaterialId { get; set; }
        public int? SupplierId { get; set; }
        public int? WarehouseId { get; set; }

        public ReadUnitDto Unit { get; set; }
        public ReadMaterialDto Material { get; set; }
        public ReadSupplierDto Supplier { get; set; }
        public ReadWarehouseDto Warehouse { get; set; }
    }
}
