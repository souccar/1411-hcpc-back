using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;

namespace Souccar.Hcpc.Materials.Services
{
    public class MaterialSupplierManager : SouccarDomainService<MaterialSuppliers, int>, IMaterialSupplierManager
    {
        public MaterialSupplierManager(IRepository<MaterialSuppliers> repository) : base(repository)
        {

        }
    }
}
