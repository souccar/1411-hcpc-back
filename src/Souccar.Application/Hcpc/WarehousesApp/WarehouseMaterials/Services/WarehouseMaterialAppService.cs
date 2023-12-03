using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using System.Threading.Tasks;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Services
{
    public class WarehouseMaterialAppService : AsyncSouccarAppService<WarehouseMaterial, WarehouseMaterialDto, int, PagedWarehouseMaterialRequestDto, CreateWarehouseMaterialDto, UpdateWarehouseMaterialDto>, IWarehouseMaterialAppService
    {
        private readonly IWarehouseMaterialManager _warehouseMaterialDomainService;
        public WarehouseMaterialAppService(IWarehouseMaterialManager warehouseMaterialDomainService) : base(warehouseMaterialDomainService)
        {
            _warehouseMaterialDomainService = warehouseMaterialDomainService;
        }

        public override async Task<WarehouseMaterialDto> GetAsync(EntityDto<int> input)
        {
            var warehouseMaterial = await _warehouseMaterialDomainService.GetWithDetailsAsync(input.Id);

            var warehouseMaterialDto = MapToEntityDto(warehouseMaterial);

            return warehouseMaterialDto;
        }

    }
}
