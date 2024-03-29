﻿using Souccar.Core.Dto.PagedRequests;
using Abp.Authorization;
using Souccar.Authorization;
using Souccar.Core.Services;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;
using Souccar.hr.Personnel.Employees.Dto;
using Souccar.hr.Personnel.Employees.Services;
using Souccar.hr.Personnel.Employees;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.WarehousesApp.Warehouses.Services
{
    [AbpAuthorize(PermissionNames.Warehouses_Warehouses)]
    public class WarehouseAppService : AsyncSouccarAppService<Warehouse, WarehouseDto, int, FullPagedRequestDto, CreateWarehouseDto, UpdateWarehouseDto>, IWarehouseAppService
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

        public override async Task<WarehouseDto> GetAsync(EntityDto<int> input)
        {
            var warehouse = await _warehouseManager.GetWarehouseByIdWithDetails(input.Id);
            return ObjectMapper.Map<WarehouseDto>(warehouse);
        }
    }
}
