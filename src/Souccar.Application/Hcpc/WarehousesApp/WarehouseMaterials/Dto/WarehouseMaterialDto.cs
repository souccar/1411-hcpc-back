using Abp.Application.Services.Dto;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Suppliers.Dto;
using Souccar.Hcpc.Units.Dto.Units;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;
using System;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto
{
    public class WarehouseMaterialDto : IEntityDto<int>
    {
        public WarehouseMaterialDto()
        {
            outputRequests = new List<OutputRequestForWarehouseMaterialDto>();
        }
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public double InitialQuantity { get; set; }
        public double CurrentQuantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double PriceUSD { get; set; }
        public double PriceSYP { get; set; }

        /// <summary>
        /// 0 المادة غير منتهية الصلاحية
        /// 1 المادة على وشك الانتهاء
        /// 2 المادة منتهية
        /// </summary>
        public int? ExpiryStatus { get; set; }

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

        public IList<OutputRequestForWarehouseMaterialDto> outputRequests { get; set; }
    }
}
