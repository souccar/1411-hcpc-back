using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.Products.Services;
using Souccar.Hcpc.Warehouses.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Services
{
    public class PlanManager : SouccarDomainService<Plan, int>, IPlanManager
    {
        private readonly IRepository<Plan> _planRepository;
        private readonly IFormulaManager _formulaManager;
        private readonly IWarehouseMaterialManager _warehouseMaterialManager;

        public PlanManager(
            IRepository<Plan> planRepository, 
            IFormulaManager formulaManager,
            IWarehouseMaterialManager warehouseMaterialManager) : base(planRepository)
        {
            _planRepository = planRepository;
            _formulaManager = formulaManager;
            _warehouseMaterialManager = warehouseMaterialManager;
        }

        public override async Task<Plan> InsertAsync(Plan plan)
        {
            var formulas = _formulaManager.GetAllWithIncluding("Unit,Material");
            var warehouseMaterials = _warehouseMaterialManager.GetAll();
            foreach (var planProduct in plan.PlanProducts)
            {
                var productFormula = formulas.Where(x => x.ProductId == planProduct.ProductId);
                foreach (var formula in productFormula)
                {
                    var planProductMaterial = new PlanProductMaterial()
                    {
                        MaterialId = formula.MaterialId,
                        UnitId = formula.UnitId,
                        RequiredQuantity = planProduct.NumberOfItems * formula.Quantity
                    };
                    planProduct.PlanProductMaterials.Add(planProductMaterial);
                }
            }

            var planProductMaterials = plan.PlanProducts.SelectMany(x => x.PlanProductMaterials);
            var materialIds = planProductMaterials.Select(x=>x.MaterialId).Distinct();
            foreach (var materialId in materialIds)
            {
                var items = planProductMaterials.Where(x=>x.MaterialId == materialId);
                var warehouseMaterial = warehouseMaterials.FirstOrDefault(x => x.MaterialId == materialId);
                if (items.Any())
                {
                    var planMaterial = new PlanMaterial()
                    {
                        MaterialId = materialId,
                        UnitId = items.FirstOrDefault().UnitId,
                        TotalQuantity = items.Sum(x => x.RequiredQuantity),
                        InventoryQuantity = warehouseMaterial != null ? warehouseMaterial.Quantity : 0,
                    };

                    plan.PlanMaterials.Add(planMaterial);
                }
            }
            var planId = await _planRepository.InsertAndGetIdAsync(plan);
            return GetWithDetails(planId);

        }

        public Plan GetWithDetails(int id)
        {
            var plan = _planRepository.GetAllIncluding(pp => pp.PlanProducts, pm => pm.PlanMaterials)
                .Include(x => x.PlanProducts).ThenInclude(p => p.Product).ThenInclude(f => f.Formulas).ThenInclude(u => u.Unit)
                .Include(x => x.PlanProducts).ThenInclude(p => p.Product).ThenInclude(f => f.Formulas).ThenInclude(m => m.Material)
                .FirstOrDefault(x => x.Id == id);

            return plan;
        }
    }
}
