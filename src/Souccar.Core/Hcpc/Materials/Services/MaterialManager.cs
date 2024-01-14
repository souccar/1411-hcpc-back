using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.Products.Services;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Materials.Services
{
    public class MaterialManager: SouccarDomainService<Material, int>, IMaterialManager
    {
        private readonly IRepository<Material> _materialRepository;
        private readonly IWarehouseMaterialManager _warehouseMaterialManager;
        private readonly IProductManager _productManager;
        private readonly IFormulaManager _formulaManager;
        private readonly IMaterialSupplierManager _materialSupplierManager;
        public MaterialManager(IRepository<Material> repository, IRepository<Material> materialRepository, IWarehouseMaterialManager warehouseMaterialManager, IProductManager productManager, IMaterialSupplierManager materialSupplierManager, IFormulaManager formulaManager) : base(repository)
        {
            _materialRepository = materialRepository;
            _warehouseMaterialManager = warehouseMaterialManager;
            _productManager = productManager;
            _materialSupplierManager = materialSupplierManager;
            _formulaManager = formulaManager;
        }

        public Material GetWithDetails(int id)
        {
            var material = _materialRepository.GetAllIncluding().Include(x=>x.Suppliers).ThenInclude(y=>y.Supplier).FirstOrDefault(x=>x.Id== id);

            return material;
        }

        public override Task DeleteAsync(int id)
        {
            var relatedProducts = _productManager.GetAll()
                .Any(x => x.Formulas.Any(y => y.ProductId == id));          
            if (relatedProducts)
            {
                throw new UserFriendlyException("Cannot be deleted, This material is associated with products");
            }

            var relatedWarehouseMaterials = _warehouseMaterialManager.GetAll()
                .Any(x => x.MaterialId == id);
            if (relatedWarehouseMaterials)
            {
                throw new UserFriendlyException("Cannot be deleted, This material is associated with warehouse materials");
            }
            return base.DeleteAsync(id);
        }

        public IList<MaterialSuppliers> GetMaterialsOfSupplier(int materialId)
        {
            var materialSuppliers = new List<MaterialSuppliers>();
            var material = _materialRepository.GetAllIncluding(x=>x.Suppliers).FirstOrDefault(x=>x.Id == materialId);
            if(material != null && material.Suppliers.Any())
            {
                var ids = material.Suppliers.Select(x => x.Id);
                materialSuppliers = _materialSupplierManager.GetAllWithIncluding("Supplier,Material").Where(x => ids.Contains(x.Id)).ToList();
            }
            
            return materialSuppliers;
        }

        public async Task<List<Material>> GetByProductsIds(int[] productsIds)
        {
            var materials = await Task.FromResult(_formulaManager
                .GetAllWithIncluding("Material")
                .Where(z=>productsIds.Contains((int)z.ProductId)).Select(x=>x.Material).Distinct()
                .ToList());
            return materials;
        }
    }
}
