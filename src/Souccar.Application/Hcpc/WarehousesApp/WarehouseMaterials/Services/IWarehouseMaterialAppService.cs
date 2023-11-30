using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Services
{
    public interface IWarehouseMaterialAppService : IAsyncSouccarAppService<WarehouseMaterialDto, int, PagedWarehouseMaterialRequestDto, CreateWarehouseMaterialDto, UpdateWarehouseMaterialDto>
    {
    }
}
