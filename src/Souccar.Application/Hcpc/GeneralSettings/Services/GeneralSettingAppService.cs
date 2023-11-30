using Souccar.Core.Services;
using Souccar.Hcpc.GeneralSettings.Dto;

namespace Souccar.Hcpc.GeneralSettings.Services
{
    public class GeneralSettingAppService : AsyncSouccarAppService<GeneralSetting, GeneralSettingDto, int, PagedGeneralSettingRequestDto, CreateGeneralSettingDto, UpdateGeneralSettingDto>, IGeneralSettingAppService
    {
        private readonly IGeneralSettingManager _generalSettingAppService;
        public GeneralSettingAppService(IGeneralSettingManager generalSettingAppService) : base(generalSettingAppService)
        {
            _generalSettingAppService = generalSettingAppService;
        }
    }
}
