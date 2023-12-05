using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Suppliers.Dto;
using Souccar.Hcpc.Units.Dto.Units;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto
{
    public class WarehouseMaterialDto : IEntityDto<int>
    {
        public WarehouseMaterialDto()
        {
            //OutputRequestMaterilas =new List<OutputRequestMaterialDto>();
        }
        public int Id { get; set; }
        public string EntryDate { get; set; }
        public double InitialQuantity { get; set; }
        public double CurrentQuantity { get; set; }
        public string ExpirationDate { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }


        public int? UnitId { get; set; }
        public int? UnitPriceId { get; set; }
        public int? MaterialId { get; set; }
        public int? SupplierId { get; set; }
        public int? WarehouseId { get; set; }


        public UnitDto Unit { get; set; }
        public UnitDto UnitPrice { get; set; }
        public MaterialDto Material { get; set; }
        public SupplierDto Supplier { get; set; }
        public WarehouseDto Warehouse { get; set; }

        //public IList<OutputRequestMaterialDto> OutputRequestMaterilas { get; set; }
    }
}
