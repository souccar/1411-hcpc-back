using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Services
{
    public interface IWarehouseMaterialAppService : IAsyncSouccarAppService<WarehouseMaterialDto, int, PagedWarehouseMaterialRequestDto, CreateWarehouseMaterialDto, UpdateWarehouseMaterialDto>
    {
        Task SendMaterialExpiryNotifications();
        IList<WarehouseMaterialNameForDropdownDto> GetNameForDropdown();
    }
}
