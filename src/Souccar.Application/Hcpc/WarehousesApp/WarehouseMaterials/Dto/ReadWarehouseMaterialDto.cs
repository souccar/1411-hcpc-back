using Abp.Application.Services.Dto;
using Souccar.Core.CustomAttributes;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Suppliers.Dto;
using Souccar.Hcpc.Units.Dto.Units;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;
using System;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto
{
    public class ReadWarehouseMaterialDto : EntityDto<int>
    {
        public ReadWarehouseMaterialDto()
        {
            OutputRequestMaterilas = new List<ReadOutputRequestMaterialDto>();
        }
        [ReadUserInterface(Searchable = true)]
        public DateTime EntryDate { get; set; }
        public double InitialQuantity { get; set; }
        public double CurrentQuantity { get; set; }

        [ReadUserInterface(Searchable = true)]
        public DateTime ExpirationDate { get; set; }
        public double PriceUSD { get; set; }
        public double PriceSYP { get; set; }

        /// <summary>
        /// 0 المادة غير منتهية الصلاحية
        /// 1 المادة على وشك الانتهاء
        /// 2 المادة منتهية
        /// </summary>
        /// 
        [ReadUserInterface(Searchable = true)]
        public int ExpiryStatus { get; set; }

        public int? UnitId { get; set; }
        //public int? UnitPriceId { get; set; }
        public int? MaterialId { get; set; }
        public int? SupplierId { get; set; }
        public int? WarehouseId { get; set; }


        public ReadUnitDto Unit { get; set; }
        public ReadUnitDto UnitPrice { get; set; }
        public ReadMaterialDto Material { get; set; }
        public ReadSupplierDto Supplier { get; set; }
        public ReadWarehouseDto Warehouse { get; set; }

        public IList<ReadOutputRequestMaterialDto> OutputRequestMaterilas { get; set; }

    }
}
