using Abp.Application.Services.Dto;
using Souccar.Core.CustomAttributes;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.Warehouses.Dto
{
    public class ReadWarehouseDto : EntityDto<int>
    {
        [ReadUserInterface(Searchable = true)]
        public string Name { get; set; }
        [ReadUserInterface(Searchable = true)]
        public string Place { get; set; }
        [ReadUserInterface(Searchable = true)]
        public string WarehouseKeeper { get; set; }
    }
}
