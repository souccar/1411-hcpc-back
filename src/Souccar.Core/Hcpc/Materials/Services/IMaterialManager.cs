using Souccar.Core.Services.Interfaces;

namespace Souccar.Hcpc.Materials.Services
{
    public interface IMaterialManager: ISouccarDomainService<Material,int>
    {
       Material GetWithDetails(int id);
    }
}
