using Souccar.Core.Services;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Services
{
    public interface IWarehouseMaterialAppService : IAsyncSouccarAppService<WarehouseMaterialDto, int, PagedWarehouseMaterialRequestDto, CreateWarehouseMaterialDto, UpdateWarehouseMaterialDto>
    {
        Task SendMaterialExpiryNotifications();
        IList<WarehouseMaterialNameForDropdownDto> GetNameForDropdown();
        Task<IList<WarehouseMaterialWithWarehouseNameAndExpiryDateDto>> GetByMaterialId(int materialId);
        Task<IList<WarehouseMaterialWithWarehouseNameAndExpiryDateDto>> GetWithWarehouseNameAndExpiryDate();
    }
}
