using Souccar.Core.Services.Interfaces;
using Souccar.Hcpc.Products;
using Souccar.Hcpc.Warehouses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Categories.Services
{
    public interface ICategoryManager : ISouccarDomainService<Category, int>
    {
        Category GetWithDetails(int id);
    }
}
