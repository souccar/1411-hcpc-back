﻿using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Hcpc.Suppliers.Dto;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.Warehouses.Services
{
    public interface IWarehouseAppService : IAsyncSouccarAppService<WarehouseDto, int, FullPagedRequestDto, CreateWarehouseDto, UpdateWarehouseDto>
    {
        IList<WarehouseNameForDropdownDto> GetNameForDropdown();
    }
}
