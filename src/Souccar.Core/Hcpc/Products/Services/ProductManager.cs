using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.Hcpc.Products.Services
{
    public class ProductManager : SouccarDomainService<Product, int>, IProductManager
    {
        public ProductManager(IRepository<Product> repository) : base(repository)
        {

        }
    
    }
}
