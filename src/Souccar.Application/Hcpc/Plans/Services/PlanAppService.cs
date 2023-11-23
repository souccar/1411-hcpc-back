using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Plans.Dto.PlanMaterials;
using Souccar.Hcpc.Plans.Dto.PlanProductMaterials;
using Souccar.Hcpc.Plans.Dto.Plans;
using Souccar.Hcpc.Products.Services;
using Souccar.Hcpc.Warehouses.Services;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Services
{
    public class PlanAppService: AsyncSouccarAppService<Plan, PlanDto, int, PagedPlanRequestDto, CreatePlanDto, UpdatePlanDto>, IPlanAppService
    {
        private readonly IPlanManager _planManager;
        private readonly IProductManager _productManager;
        private readonly IFormulaManager _formulaManager;
        private readonly IWarehouseMaterialManager _warehouseMaterialManager;
        public PlanAppService(IFormulaManager formulaManager, IWarehouseMaterialManager warehouseMaterialManager, IProductManager productManager, IPlanManager planManager) : base(planManager)
        {
            _formulaManager = formulaManager;
            _warehouseMaterialManager = warehouseMaterialManager;
            _productManager = productManager;
            _planManager = planManager;
        }

        public override async Task<PlanDto> CreateAsync(CreatePlanDto input)
        {
            var insertedPlanDto = await base.CreateAsync(input);

             var planDtoWithDetails = InitPlanDetails(insertedPlanDto);

            return InitialDurationProduce(planDtoWithDetails);

        }

        public override async Task<PlanDto> UpdateAsync(UpdatePlanDto input)
        {
            var updatedPlan = await base.UpdateAsync(input);

            var UpdatedPlanDtoWithDetails = InitPlanDetails(updatedPlan);

            return InitialDurationProduce(UpdatedPlanDtoWithDetails);
        }

        public override async Task<PlanDto> GetAsync(EntityDto<int> input)
        {
            var plan = _planManager.GetWithDetails(input.Id);
            var planDto = MapToEntityDto(plan);

            var planDtoWithDetails = InitPlanDetails(planDto);
            return InitialDurationProduce(planDtoWithDetails);
        }



        #region Helper Methods
        private PlanDto InitPlanDetails(PlanDto planDto)
        {
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
                        RequiredQuantity = planProduct.NumberOfItems * formula.Quantity,
                        PlanProductId = planProduct.Id,
                    };
                    planProduct.PlanProductMaterials.Add(planProductMaterial);
                }
            }

            var planProductMaterials = planDto.PlanProducts.SelectMany(x => x.PlanProductMaterials);
            var materialIds = planProductMaterials.Select(x => x.MaterialId).Distinct();
            foreach (var materialId in materialIds)
            {
                double rate = 0;
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

                    rate = planMaterial.TotalQuantity != 0 ? (planMaterial.InventoryQuantity / planMaterial.TotalQuantity) : 0;

                    planDto.PlanMaterials.Add(planMaterial);
                }

               
                var plm = planProductMaterials.Where(x => x.MaterialId == materialId).ToList();


                foreach (var planProductMaterial in plm)
                {
                    var pl = planDto.PlanProducts
                        .FirstOrDefault(x => x.PlanProductMaterials.Any(f => f.MaterialId == materialId) && x.Id == planProductMaterial.PlanProductId);

                    if (rate < 1)
                    {
                            var tempCount = (int)(pl.NumberOfItems * rate);

                            if ((planProductMaterial.CanProduce != 0 && planProductMaterial.CanProduce > tempCount) || planProductMaterial.CanProduce == 0)
                            {
                                planProductMaterial.CanProduce = tempCount;
                            }
                    }
                    else
                    {
                            planProductMaterial.CanProduce = pl.NumberOfItems;
                    }
                }               
            }
            return planDto;
        }

        private PlanDto InitialDurationProduce(PlanDto planDto)
        {
            foreach (var planProduct in planDto.PlanProducts)
            {
                var product = _productManager.Get(planProduct.ProductId);

                planProduct.DurationProduce = product.ExpectedProduce != 0 ? planProduct.CanProduce / product.ExpectedProduce : 0;
            }

            return planDto;
        }
        #endregion
    }
}
