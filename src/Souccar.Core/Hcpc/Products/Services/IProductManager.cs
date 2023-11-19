using Souccar.Core.Services.Interfaces;
using System.Linq;

namespace Souccar.Hcpc.Products.Services
{
    public interface IProductManager : ISouccarDomainService<Product, int>
    {
        IQueryable<Product> GetWithFormula(int[] ids);
    }
}
