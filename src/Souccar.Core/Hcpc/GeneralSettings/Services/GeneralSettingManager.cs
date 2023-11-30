using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.Hcpc.GeneralSettings.Services
{
    public class GeneralSettingManager : SouccarDomainService<GeneralSetting, int>, IGeneralSettingManager
    {
        public GeneralSettingManager(IRepository<GeneralSetting, int> repository) : base(repository)
        {
        }
    }
}
