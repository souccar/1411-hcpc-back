using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.WarehouseMaterials.Dto;

namespace Souccar.Hcpc.WarehouseMaterials.Services
{
    public interface IWarehouseMaterialAppService : IAsyncSouccarAppService<WarehouseMaterialDto, int, PagedWarehouseMaterialRequestDto, CreateWarehouseMaterialDto, UpdateWarehouseMaterialDto>
    {
    }
}
