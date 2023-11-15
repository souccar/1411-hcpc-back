using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.WarehouseMaterials.Dto;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Services;

namespace Souccar.Hcpc.WarehouseMaterials.Services
{
    public class WarehouseMaterialAppService: AsyncSouccarAppService<WarehouseMaterial, WarehouseMaterialDto, int, PagedWarehouseMaterialRequestDto, CreateWarehouseMaterialDto, UpdateWarehouseMaterialDto, WarehouseMaterialDto, EntityDto<int>>, IWarehouseMaterialAppService
    {
        private readonly IWarehouseMaterialManager _warehouseMaterialDomainService;
    public WarehouseMaterialAppService(IWarehouseMaterialManager warehouseMaterialDomainService) : base(warehouseMaterialDomainService)
    {
        _warehouseMaterialDomainService = warehouseMaterialDomainService;
    }

}
}
