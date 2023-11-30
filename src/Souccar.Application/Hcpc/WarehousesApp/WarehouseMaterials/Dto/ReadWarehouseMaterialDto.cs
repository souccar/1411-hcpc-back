using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Suppliers.Dto;
using Souccar.Hcpc.Units.Dto.Units;
using Souccar.Hcpc.WarehousesApp.InputRequests.Dto.InputRequestMaterialDtos;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto
{
    public class ReadWarehouseMaterialDto : IEntityDto<int>
    {
        public ReadWarehouseMaterialDto()
        {
            OutputRequestMaterilas = new List<ReadOutputRequestMaterialDto>();
        }
        public int Id { get; set; }
        public double Quantity { get; set; }
        public string ExpirationDate { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }


        public int? UnitId { get; set; }
        public int? UnitPriceId { get; set; }
        public int? MaterialId { get; set; }
        public int? SupplierId { get; set; }
        public int? WarehouseId { get; set; }
        public int? InputRequestMaterialId { get; set; }


        public ReadUnitDto Unit { get; set; }
        public ReadUnitDto UnitPrice { get; set; }
        public ReadMaterialDto Material { get; set; }
        public ReadSupplierDto Supplier { get; set; }
        public ReadWarehouseDto Warehouse { get; set; }
        public ReadInputRequestMaterialDto InputRequestMaterial { get; set; }

        public IList<ReadOutputRequestMaterialDto> OutputRequestMaterilas { get; set; }

    }
}
