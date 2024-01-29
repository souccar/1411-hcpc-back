using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;
using Souccar.Authorization.Users;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Hcpc.GeneralSettings.Services;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Services.OutputRequestServices;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;
using Souccar.Notification;
using Souccar.Notification.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Services
{
    public class WarehouseMaterialAppService :
        AsyncSouccarAppService<WarehouseMaterial, WarehouseMaterialDto, int, FullPagedRequestDto, CreateWarehouseMaterialDto, UpdateWarehouseMaterialDto>, IWarehouseMaterialAppService
    {
        private readonly IWarehouseMaterialManager _warehouseMaterialDomainService;
        private readonly IAppNotifier _notifier;
        private readonly INotificationAppService _notificationAppService;
        private readonly IOutputRequestManager _outputRequestManager;
        private readonly IGeneralSettingManager _generalSettingManager;
        public UserManager UserManager { get; set; }

        public WarehouseMaterialAppService(IWarehouseMaterialManager warehouseMaterialDomainService,
            IAppNotifier notifier, INotificationAppService notificationAppService,
            IOutputRequestManager outputRequestManager, IGeneralSettingManager generalSettingManager) : base(warehouseMaterialDomainService)
        {
            _warehouseMaterialDomainService = warehouseMaterialDomainService;
            _notifier = notifier;
            _notificationAppService = notificationAppService;
            _outputRequestManager = outputRequestManager;
            _generalSettingManager = generalSettingManager;
        }

        public override async Task<PagedResultDto<WarehouseMaterialDto>> GetAllAsync(FullPagedRequestDto input)
        {
            var generalSetting = await _generalSettingManager.GetAll().FirstOrDefaultAsync();
            var warehouseMaterials = await base.GetAllAsync(input);
            foreach (var warehouseMaterial in warehouseMaterials.Items)
            {
                if (generalSetting != null)
                {
                    if (warehouseMaterial.ExpirationDate.Date <= DateTime.Now.AddDays(generalSetting.ExpiryDurationNotify).Date)
                    {
                        if (warehouseMaterial.ExpirationDate.Date < DateTime.Now.Date)
                        {
                            // 2 المادة منتهية
                            warehouseMaterial.ExpiryStatus = 2;
                        }
                        else
                        {
                            // 1 المادة على وشك الانتهاء
                            warehouseMaterial.ExpiryStatus = 1;
                        }
                    }
                    else
                    {
                        // 0 المادة غير منتهية الصلاحية
                        warehouseMaterial.ExpiryStatus = 0;
                    }
                }
            }
            return warehouseMaterials;
        }

        public override async Task<WarehouseMaterialDto> GetAsync(EntityDto<int> input)
        {
            var warehouseMaterial = await _warehouseMaterialDomainService.GetWithDetailsAsync(input.Id);
            var outputRequests = _outputRequestManager.GetAllWithIncluding("OutputRequestMaterials").Where(x =>x.Status != OutputRequestStatus.Pending && x.OutputRequestMaterials.Any(y => y.WarehouseMaterialId == input.Id)).ToList();            

            var warehouseMaterialDto = MapToEntityDto(warehouseMaterial);

            foreach (var outputRequest in outputRequests)
            {
                foreach (var OutputRequestMaterial in outputRequest.OutputRequestMaterials)
                {
                    if (OutputRequestMaterial.WarehouseMaterialId == input.Id)
                    {
                        warehouseMaterialDto.outputRequests
                            .Add(new OutputRequestForWarehouseMaterialDto() { Id = outputRequest.Id, Title = outputRequest.Title, OutputDate = (DateTime)outputRequest.OutputDate, Quantity = OutputRequestMaterial.Quantity });
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
                await _notifier.SendMaterialExpiryDate(user, warehouseMaterial.Material.Code, warehouseMaterial.ExpirationDate);

                warehouseMaterial.AboutToFinish = true;
                await _warehouseMaterialDomainService.UpdateAsync(warehouseMaterial);
            }
        }

        public IList<WarehouseMaterialNameForDropdownDto> GetNameForDropdown()
        {
            return _warehouseMaterialDomainService.GetAllWithIncluding("material")
                .Select(x => new WarehouseMaterialNameForDropdownDto(x.Id, x.Material.Code + " / " + x.ExpirationDate.ToString("dd-MM-yyyy"))).ToList();
        }

        public async Task<IList<WarehouseMaterialWithWarehouseNameAndExpiryDateDto>> GetByMaterialId(int materialId)
        {
            IList<WarehouseMaterialWithWarehouseNameAndExpiryDateDto> dtos = new List<WarehouseMaterialWithWarehouseNameAndExpiryDateDto>();
            var warehouseMaterials = await _warehouseMaterialDomainService.GetByMaterialIdAsync(materialId);
            foreach (var warehouseMaterial in warehouseMaterials)
            {
                dtos.Add(
                    new WarehouseMaterialWithWarehouseNameAndExpiryDateDto(warehouseMaterial.Id,
                    warehouseMaterial.Warehouse.Name + " / " + warehouseMaterial.ExpirationDate.ToString("dd-MM-yyyy")));
            }
            return dtos;
        }

        public async Task<IList<WarehouseMaterialWithWarehouseNameAndExpiryDateDto>> GetWithWarehouseNameAndExpiryDate()
        {
            IList<WarehouseMaterialWithWarehouseNameAndExpiryDateDto> dtos = new List<WarehouseMaterialWithWarehouseNameAndExpiryDateDto>();
            var warehouseMaterials = await _warehouseMaterialDomainService.GetWithWarehouseNameAndExpiryDate();
            foreach (var warehouseMaterial in warehouseMaterials)
            {
                dtos.Add(
                    new WarehouseMaterialWithWarehouseNameAndExpiryDateDto(warehouseMaterial.Id,
                    warehouseMaterial.Warehouse.Name + " / " + warehouseMaterial.ExpirationDate.ToString("dd-MM-yyyy")));
            }
            return dtos;
        }
    }
}
