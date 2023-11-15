using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.Hcpc.Materials.Services
{
    public class MaterialManager: SouccarDomainService<Material, int>, IMaterialManager
    {
        public MaterialManager(IRepository<Material> repository): base(repository)
        {
            
        }
    }
}
