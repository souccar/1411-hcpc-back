using Souccar.Core.Services;
using Souccar.Hcpc.GeneralSettings.Dto;

namespace Souccar.Hcpc.GeneralSettings.Services
{
    public interface IGeneralSettingAppService : IAsyncSouccarAppService<GeneralSettingDto, int, PagedGeneralSettingRequestDto, CreateGeneralSettingDto, UpdateGeneralSettingDto>
    {
    }
}
