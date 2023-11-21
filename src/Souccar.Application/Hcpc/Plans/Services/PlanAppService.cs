using Souccar.Core.Services;
using Souccar.Hcpc.Plans.Dto.PlanMaterials;
using Souccar.Hcpc.Plans.Dto.PlanProductMaterials;
using Souccar.Hcpc.Plans.Dto.Plans;
using Souccar.Hcpc.Products.Services;
using Souccar.Hcpc.Warehouses.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Services
{
    public class PlanAppService: AsyncSouccarAppService<Plan, PlanDto, int, PagedPlanRequestDto, CreatePlanDto, UpdatePlanDto>, IPlanAppService
    {
        private readonly IPlanManager _planManager;
        private readonly IFormulaManager _formulaManager;
        private readonly IWarehouseMaterialManager _warehouseMaterialManager;
        public PlanAppService(IPlanManager planManager, IFormulaManager formulaManager, IWarehouseMaterialManager warehouseMaterialManager) : base(planManager)
        {
            _planManager = planManager;
            _formulaManager = formulaManager;
            _warehouseMaterialManager = warehouseMaterialManager;
        }

        public override async Task<PlanDto> CreateAsync(CreatePlanDto input)
        {
            var inputPlan = ObjectMapper.Map<Plan>(input);

            var plan = await _planManager.InsertAsync(inputPlan);

            var planDto = ObjectMapper.Map<PlanDto>(plan);

            var formulas = _formulaManager.GetAllWithIncluding("Unit,Material");
            var warehouseMaterials = _warehouseMaterialManager.GetAll();
            foreach (var planProduct in planDto.PlanProducts)
            {
                var productFormula = formulas.Where(x => x.ProductId == planProduct.ProductId);
                foreach (var formula in productFormula)
                {
                    var planProductMaterial = new PlanProductMaterialDto()
                    {
                        MaterialId = formula.MaterialId,
                        UnitId = formula.UnitId,
                        RequiredQuantity = planProduct.NumberOfItems * formula.Quantity
                    };
                    planProduct.PlanProductMaterials.Add(planProductMaterial);
                }
            }

            var planProductMaterials = planDto.PlanProducts.SelectMany(x => x.PlanProductMaterials);
            var materialIds = planProductMaterials.Select(x => x.MaterialId).Distinct();
            foreach (var materialId in materialIds)
            {
                var items = planProductMaterials.Where(x => x.MaterialId == materialId);
                var warehouseMaterial = warehouseMaterials.FirstOrDefault(x => x.MaterialId == materialId);
                if (items.Any())
                {
                    var planMaterial = new PlanMaterialDto()
                    {
                        MaterialId = materialId,
                        UnitId = items.FirstOrDefault().UnitId,
                        TotalQuantity = items.Sum(x => x.RequiredQuantity),
                        InventoryQuantity = warehouseMaterial != null ? warehouseMaterial.Quantity : 0,
                    };

                    planDto.PlanMaterials.Add(planMaterial);
                }
            }           
            return planDto;

        }
    }
}
