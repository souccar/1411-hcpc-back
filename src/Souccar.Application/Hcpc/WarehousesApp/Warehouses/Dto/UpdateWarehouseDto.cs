﻿using Abp.Application.Services.Dto;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.Warehouses.Dto
{
    public class UpdateWarehouseDto : IEntityDto
    {
        public UpdateWarehouseDto()
        {
            WarehouseMaterials = new List<UpdateWarehouseMaterialDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string WarehouseKeeper { get; set; }
        public IList<UpdateWarehouseMaterialDto> WarehouseMaterials { get; set; }
    }
}