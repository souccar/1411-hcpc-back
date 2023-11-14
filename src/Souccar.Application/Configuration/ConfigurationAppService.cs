using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Souccar.Configuration.Dto;

namespace Souccar.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SouccarAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
