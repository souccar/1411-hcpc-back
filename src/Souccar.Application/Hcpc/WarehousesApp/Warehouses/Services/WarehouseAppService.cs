using Souccar.Core.Services;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.Hcpc.WarehousesApp.Warehouses.Services
{
    public class WarehouseAppService : AsyncSouccarAppService<Warehouse, WarehouseDto, int, PagedWarehouseRequestDto, CreateWarehouseDto, UpdateWarehouseDto>, IWarehouseAppService
    {
        private readonly IWarehouseManager _warehouseManager;
        public WarehouseAppService(IWarehouseManager warehouseManager) : base(warehouseManager)
        {
            _warehouseManager = warehouseManager;
        }

        public IList<WarehouseNameForDropdownDto> GetNameForDropdown()
        {
            return _warehouseManager.GetAll()
                .Select(x => new WarehouseNameForDropdownDto(x.Id, x.Name)).ToList();
        }
    }
}
