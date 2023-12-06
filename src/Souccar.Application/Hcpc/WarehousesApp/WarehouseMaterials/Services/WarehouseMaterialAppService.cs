using Abp.Application.Services.Dto;
using Souccar.Authorization.Users;
using Souccar.Core.Services;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Services.OutputRequestServices;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
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
        private readonly IOutputRequestManager _outputRequestManager;
        public UserManager UserManager { get; set; }

        public WarehouseMaterialAppService(IWarehouseMaterialManager warehouseMaterialDomainService, IAppNotifier notifier, INotificationAppService notificationAppService, IOutputRequestManager outputRequestManager) : base(warehouseMaterialDomainService)
        {
            _warehouseMaterialDomainService = warehouseMaterialDomainService;
            _notifier = notifier;
            _notificationAppService = notificationAppService;
            _outputRequestManager = outputRequestManager;
        }

        public override async Task<WarehouseMaterialDto> GetAsync(EntityDto<int> input)
        {
            var warehouseMaterial = await _warehouseMaterialDomainService.GetWithDetailsAsync(input.Id);
            var outputRequests = _outputRequestManager.GetAllWithIncluding("OutputRequestMaterials").Where(x => x.OutputRequestMaterials.Any(y => y.WarehouseMaterialId == input.Id)).ToList();            

            var warehouseMaterialDto = MapToEntityDto(warehouseMaterial);

            foreach (var outputRequest in outputRequests)
            {
                foreach (var OutputRequestMaterial in outputRequest.OutputRequestMaterials)
                {
                    if (OutputRequestMaterial.WarehouseMaterialId == input.Id)
                    {
                        warehouseMaterialDto.outputRequests
                            .Add(new OutputRequestForWarehouseMaterialDto() { Id = outputRequest.Id, Title = outputRequest.Title, OutputDate = outputRequest.OutputDate.ToString(), Quantity = OutputRequestMaterial.Quantity });
                    }
                }
                
            }

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
