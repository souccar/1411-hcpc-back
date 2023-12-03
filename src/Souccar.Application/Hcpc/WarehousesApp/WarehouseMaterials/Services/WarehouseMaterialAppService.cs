using Abp.Application.Services.Dto;
using Souccar.Authorization.Users;
using Souccar.Core.Services;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
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

        public async Task SendMaterialExpiryNotifications()
        {
            var input = new GetUserNotificationsInput() { State = 0, MaxResultCount = 1000, SkipCount = 0 };

            var user = await UserManager.GetUserByIdAsync((long)AbpSession.UserId);



            var currentUserNotifications = await _notificationAppService.GetUserNotifications(input);
            var allThatWillExpire = await _warehouseMaterialDomainService.GetAllThatWillExpire();

            foreach (var warehouseMaterial in allThatWillExpire) 
            {
                string name = warehouseMaterial.Material.Name + " - " + warehouseMaterial.Code;
                string message = "The " + name + " material will expire on " + warehouseMaterial.ExpirationDate.ToString("dd/MM/yyyy");

                if (!currentUserNotifications.Items.Any(x => x.Notification.Data["Message"].ToString() == message))
                {
                    await _notifier.SendMaterialExpiryDate(user, name, warehouseMaterial.ExpirationDate);
                }
            }
        }
    }
}
