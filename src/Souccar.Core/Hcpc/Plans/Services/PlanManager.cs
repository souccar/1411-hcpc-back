using Abp.Domain.Repositories;
using Souccar.Core.Services.Implements;
using Souccar.Hcpc.Materials.Services;
using Souccar.Hcpc.Products;
using Souccar.Hcpc.Products.Services;
using Souccar.Hcpc.Warehouses.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Services
{
    public class PlanManager : SouccarDomainService<Plan, int>, IPlanManager
    {
        private readonly IRepository<Plan> _planRepository;
        private readonly IProductManager _productManager;
        private readonly IMaterialManager _materialManager;
        private readonly IWarehouseMaterialManager _warehouseMaterialManager;


        public PlanManager(IRepository<Plan> planRepository, IProductManager productManager, IMaterialManager materialManager, IWarehouseMaterialManager warehouseMaterialManager) : base(planRepository)
        {
            _planRepository = planRepository;
            _productManager = productManager;
            _materialManager = materialManager;
            _warehouseMaterialManager = warehouseMaterialManager;
        }

        public override async Task<Plan> InsertAsync(Plan plan)
        {
            //var product = await _productManager.GetAgreggateAsync(plan.ProductId);
            //var warehouseMaterials = _warehouseMaterialManager.GetAll();

            //foreach (var formula in product.Formulas)
            //{
            //    var materialInWarehouse = warehouseMaterials.FirstOrDefault(x => x.MaterialId == formula.MaterialId);
            //    var material = await _materialManager.GetAsync(formula.MaterialId.Value);
            //    var planItem = new PlanItem()
            //    {
            //        FormulaId = formula.Id,
            //        QuantityInFormula = formula.Quantity,
            //        QuantityInPlan = plan.Count * formula.Quantity,
            //        QuantityInWarehoure = materialInWarehouse.Quantity,
            //        MaterialLeadTime = material.LeadTime,
            //        MaterialPrice = material.Price
            //    };

            //    plan.PlanItems.Add(planItem);
            //}

            //var planId = await _planRepository.InsertAndGetIdAsync(plan);

            //var createdPlan = await _planRepository.GetAsync(planId);
            //await _planRepository.EnsureCollectionLoadedAsync(createdPlan, x => x.PlanItems);
            //return createdPlan;
            throw new System.Exception();
        }
    }
}
