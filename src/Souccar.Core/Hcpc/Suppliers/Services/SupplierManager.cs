using Souccar.Core.Services.Implements;
using Abp.Domain.Repositories;

namespace Souccar.Hcpc.Suppliers.Services
{
    public class SupplierManager : SouccarDomainService<Supplier, int>, ISupplierManager
    {
        public SupplierManager(IRepository<Supplier> repository) : base(repository)
        {

        }
    }
}
