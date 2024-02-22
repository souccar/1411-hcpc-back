using Souccar.Core.Services.Interfaces;

namespace Souccar.Hcpc.Categories.Services
{
    public interface ICategoryManager : ISouccarDomainService<Category, int>
    {
        Category GetWithDetails(int id);
    }
}
