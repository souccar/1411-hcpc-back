using Abp.Application.Services.Dto;
using Souccar.Authorization.Users;
using Souccar.Core.Services;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;
using Souccar.Notification;
using Souccar.Notification.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Services
{
    public class WarehouseMaterialAppService : AsyncSouccarAppService<WarehouseMaterial, WarehouseMaterialDto, int, PagedWarehouseMaterialRequestDto, CreateWarehouseMaterialDto, UpdateWarehouseMaterialDto>, IWarehouseMaterialAppService
    {
        private readonly IWarehouseMaterialManager _warehouseMaterialDomainService;
        private readonly IAppNotifier _notifier;
        private readonly INotificationAppService _notificationAppService;
        public UserManager UserManager { get; set; }

        public WarehouseMaterialAppService(IWarehouseMaterialManager warehouseMaterialDomainService, IAppNotifier notifier, INotificationAppService notificationAppService) : base(warehouseMaterialDomainService)
        {
            _warehouseMaterialDomainService = warehouseMaterialDomainService;
            _notifier = notifier;
            _notificationAppService = notificationAppService;
        }

        public override async Task<WarehouseMaterialDto> GetAsync(EntityDto<int> input)
        {
            var warehouseMaterial = await _warehouseMaterialDomainService.GetWithDetailsAsync(input.Id);

            var warehouseMaterialDto = MapToEntityDto(warehouseMaterial);

            return warehouseMaterialDto;
        }

        public async Task SendMaterialExpiryNotifications()
        {
            var input = new GetUserNotificationsInput() { State = 0, MaxResultCount = 1000, SkipCount = 0 };

            var user = await UserManager.GetUserByIdAsync(1);
            var allThatWillExpire = await _warehouseMaterialDomainService.GetAllThatWillExpire();

            foreach (var warehouseMaterial in allThatWillExpire) 
            {
                await _notifier.SendMaterialExpiryDate(user, warehouseMaterial.Material.Name +"/"+ warehouseMaterial.Code, warehouseMaterial.ExpirationDate);

                warehouseMaterial.AboutToFinish = true;
                await _warehouseMaterialDomainService.UpdateAsync(warehouseMaterial);
            }
        }

        public IList<WarehouseMaterialNameForDropdownDto> GetNameForDropdown()
        {
            return _warehouseMaterialDomainService.GetAll()
                .Select(x => new WarehouseMaterialNameForDropdownDto(x.Id, x.Code)).ToList();
        }
    }
}
