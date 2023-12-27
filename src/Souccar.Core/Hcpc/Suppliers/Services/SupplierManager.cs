using Souccar.Core.Services.Implements;
using Abp.Domain.Repositories;
using System.Collections.Generic;
using Souccar.Hcpc.Materials.Services;
using System.Linq;

namespace Souccar.Hcpc.Suppliers.Services
{
    public class SupplierManager : SouccarDomainService<Supplier, int>, ISupplierManager
    {
        private readonly IMaterialSupplierManager _materialSupplierManager;

        public SupplierManager(IRepository<Supplier> repository, IMaterialSupplierManager materialSupplierManager) : base(repository)
        {
            _materialSupplierManager = materialSupplierManager;
        }
        public List<Supplier> GetSuppliersByMaterialId(int materialId)
        {
            var supliers = _materialSupplierManager.GetAllWithIncluding("Suplier")
                .Where(x => x.MaterialId == materialId)
                .Select(s => s.Supplier).ToList();
            return supliers;
        }
    }
}
