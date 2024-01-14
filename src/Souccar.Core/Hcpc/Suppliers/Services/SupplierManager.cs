using Souccar.Core.Services.Implements;
using Abp.Domain.Repositories;
using System.Collections.Generic;
using Souccar.Hcpc.Materials.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Souccar.Hcpc.Suppliers.Services
{
    public class SupplierManager : SouccarDomainService<Supplier, int>, ISupplierManager
    {
        private readonly IMaterialSupplierManager _materialSupplierManager;
        private readonly IRepository<Supplier> _supplierRepository;

        public SupplierManager(IRepository<Supplier> repository, IMaterialSupplierManager materialSupplierManager) : base(repository)
        {
            _materialSupplierManager = materialSupplierManager;
            _supplierRepository = repository;
        }
        public List<Supplier> GetSuppliersByMaterialId(int materialId)
        {
            var supliers = _materialSupplierManager.GetAllWithIncluding("Suplier")
                .Where(x => x.MaterialId == materialId)
                .Select(s => s.Supplier).ToList();
            return supliers;
        }

        public List<Supplier> GetSuppliersWithDetails(int materialId)
        {
            var supliers = _supplierRepository.GetAll()
                .Include(x => x.MaterialSuppliers).ThenInclude(x => x.Material)
                .Where(x => x.MaterialSuppliers.Any() && x.MaterialSuppliers.Any(y => y.MaterialId == materialId));

            return supliers.ToList();
        }
    }
}
