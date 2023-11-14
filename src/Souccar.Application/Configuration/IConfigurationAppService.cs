using System.Threading.Tasks;
using Souccar.Configuration.Dto;

namespace Souccar.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
