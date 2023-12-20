using Abp.Domain.Repositories;
using Abp.UI;
using Souccar.Core.Services.Implements;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Souccar.Hcpc.GeneralSettings.Services
{
    public class GeneralSettingManager : SouccarDomainService<GeneralSetting, int>, IGeneralSettingManager
    {
        public GeneralSettingManager(IRepository<GeneralSetting, int> repository) : base(repository)
        {
        }

        public override Task<GeneralSetting> InsertAsync(GeneralSetting input)
        {
            var generalSettings = GetAll();
            if (generalSettings.Any())
            {
                throw new UserFriendlyException("Only one setting can be added");
            }
            else
            {
                return base.InsertAsync(input);
            }
            
        }

        public override Task DeleteAsync(int id)
        {
            throw new UserFriendlyException("These settings cannot be deleted, please modify");
        }
    }
}
