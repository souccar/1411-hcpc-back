using Souccar.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Categories.Services
{
    public interface ICategoryManager : ISouccarDomainService<Category, int>
    {
        Task<Category> GetWithDetailsAsync(int id);
    }
}
