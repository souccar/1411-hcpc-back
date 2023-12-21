using Abp.Application.Services.Dto;
using Abp.Threading;
using Microsoft.AspNetCore.Connections.Features;
using Souccar.Core.Services;
using Souccar.Hcpc.DailyProductions.Services;
using Souccar.Hcpc.Plans.Dto.PlanMaterials;
using Souccar.Hcpc.Plans.Dto.PlanProductMaterials;
using Souccar.Hcpc.Plans.Dto.Plans;
using Souccar.Hcpc.Products.Dto.Products;
using Souccar.Hcpc.Products.Services;
using Souccar.Hcpc.Units.Dto.Units;
using Souccar.Hcpc.Units.Services;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Services
{
    public class PlanAppService : AsyncSouccarAppService<Plan, PlanDto, int, PagedPlanRequestDto, CreatePlanDto, UpdatePlanDto>, IPlanAppService
    {
        private readonly IPlanManager _planManager;
        private readonly IPlanProductManager _planProductManager;
        private readonly IFormulaManager _formulaManager;
        private readonly IWarehouseMaterialManager _warehouseMaterialManager;
        private readonly IDailyProductionManager _dailyProductionManager;
        private readonly ITransferManager _transferManager;
        public PlanAppService(IFormulaManager formulaManager,
            IWarehouseMaterialManager warehouseMaterialManager,
            IPlanManager planManager,
            IDailyProductionManager dailyProductionManager,
            IPlanProductManager planProductManager,
            ITransferManager transferManager) : base(planManager)
        {
            _formulaManager = formulaManager;
            _warehouseMaterialManager = warehouseMaterialManager;
            _planManager = planManager;
            _dailyProductionManager = dailyProductionManager;
            _planProductManager = planProductManager;
            _transferManager = transferManager;
        }

        public IList<PlanNameForDropdownDto> GetNameForDropdown()
        {
            var plans = _planManager.GetAllWithIncluding("OutputRequests");
            return ObjectMapper.Map<List<PlanNameForDropdownDto>>(plans);
        }

        public IList<PlanNameForDropdownDto> GetActualPlansNameForDropdown()
        {
            var plans = _planManager.GetAllWithIncluding("OutputRequests")
                .Where(x => x.Status == PlanStatus.Actual).ToList();
            return ObjectMapper.Map<List<PlanNameForDropdownDto>>(plans);
        }

        public override async Task<PlanDto> CreateAsync(CreatePlanDto input)
        {
            var insertedPlanDto = await base.CreateAsync(input);

            return InitCreatePlanDetails(insertedPlanDto);

        }

        public override async Task<PlanDto> UpdateAsync(UpdatePlanDto input)
        {
            var updatedPlan = UpdatePlan(input);
            return updatedPlan;
        }

        public override async Task<PlanDto> GetAsync(EntityDto<int> input)
        {
            var plan = _planManager.GetWithDetails(input.Id);
            var planDto = MapToEntityDto(plan);

            return InitPlanDetails(planDto);
        }

        public async Task<PlanDto> GetLastPlanAsync()
        {
            var LastPlan = await _planManager.GetLastPlanAsync();
            var LastPlanDto = MapToEntityDto(LastPlan);

            return InitPlanDetails(LastPlanDto);
        }

        public async Task<PlanDto> GetLastPlanActualAsync()
        {
            var LastPlan = await _planManager.GetLastPlanActualAsync();
            var LastPlanDto = MapToEntityDto(LastPlan);

            return InitPlanDetails(LastPlanDto);
        }

        public async Task<PlanDto> ChangeStatusToActual(int id)
        {
            var UpdatedPlan = await _planManager.ChangeStausToActual(id);
            return MapToEntityDto(UpdatedPlan);
        }

        public async Task<PlanDto> ChangeStatusToArchive(int id)
        {
            var UpdatedPlan = await _planManager.ChangeStausToArchive(id);
            return MapToEntityDto(UpdatedPlan);
        }

        public IList<PlanDto> GetPendingPlans()
        {
            var pendingPlans = _planManager.GetPendingPlans();
            return ObjectMapper.Map<IList<PlanDto>>(pendingPlans);
        }

        public IList<ProductNameForDropdownDto> GetProductsOfPlan(int planId)
        {
            IList<ProductNameForDropdownDto> productNameForDropdownDtos = new List<ProductNameForDropdownDto>();

            var products = _planManager.GetProductsOfPlan(planId);

            foreach (var product in products)
            {
                var productNameForDropdownDto = new ProductNameForDropdownDto(product.Id, product.Name);
                productNameForDropdownDtos.Add(productNameForDropdownDto);
            }

            return productNameForDropdownDtos;
        }



        #region Helper Methods
        private PlanDto InitPlanDetails(PlanDto planDto)
        {
            //If there is no plan
            if (planDto.Id == 0)
                return new PlanDto();

            var formulas = _formulaManager.GetAllWithIncluding("Unit,Material");
            var warehouseMaterials = _warehouseMaterialManager.GetAllWithIncluding("Unit,Material");
            var TotalProduction = _dailyProductionManager.GetAllProductionsCountForPlan(planDto.Id);
            var costs = GetProductsCostForPlan(planDto.Id);

            foreach (var planProduct in planDto.PlanProducts)
            {
                var productCost = costs.Where(x=>x.ProductId == planProduct.ProductId).FirstOrDefault();
                var productFormula = formulas.Where(x => x.ProductId == planProduct.ProductId);
                foreach (var formula in productFormula)
                {
                    var planProductMaterial = new PlanProductMaterialDto()
                    {
                        MaterialId = formula.MaterialId,
                        UnitId = formula.UnitId,
                        RequiredQuantity = planProduct.NumberOfItems * formula.Quantity,
                        PlanProductId = planProduct.Id
                    };
                    planProduct.PlanProductMaterials.Add(planProductMaterial);
                }

                planProduct.TotalProduction = TotalProduction[(int)planProduct.ProductId];

                planProduct.ItemCost = productCost.CostOfProduction;

            }

            var planProductMaterials = planDto.PlanProducts.SelectMany(x => x.PlanProductMaterials);
            var materialIds = planProductMaterials.Select(x => x.MaterialId).Distinct();
            var materials = planDto.PlanProducts.Select(x => x.Product).SelectMany(x => x.Formulas).Select(x => x.Material);
            var previousActualPlans = GetActualPlans().Where(x=>x.Id < planDto.Id); /////

            foreach (var materialId in materialIds)
            {
                double rate = 0;
                var items = planProductMaterials.Where(x => x.MaterialId == materialId).ToList();
                var material = materials.FirstOrDefault(x => x.Id == materialId);
                var stock = warehouseMaterials.Where(x => x.MaterialId == materialId && x.CurrentQuantity != 0).ToList();
                var totalQuantity = items.Sum(x => x.RequiredQuantity);
                var totalQuantityAfterTranfer = AsyncHelper.RunSync(()=> _transferManager.ConvertTo(items.FirstOrDefault().UnitId, stock.FirstOrDefault().UnitId, totalQuantity));

                //////////

                double allReservedQuantities = 0;

                foreach (var previousActualPlan in previousActualPlans)
                {
                    if (previousActualPlan.PlanMaterials.Any())
                    {
                        allReservedQuantities += previousActualPlan.PlanMaterials.Where(x => x.MaterialId == materialId).FirstOrDefault().TotalQuantity;
                    }
                }

                var stockWithoutReserved = stock != null ? stock.Sum(x => x.CurrentQuantity) - allReservedQuantities : 0;

                //////////

                if (items.Any())
                {
                    var planMaterial = new PlanMaterialDto()
                    {
                        MaterialId = materialId,
                        UnitId = stock.FirstOrDefault().UnitId,
                        Unit = ObjectMapper.Map<UnitDto>(stock.FirstOrDefault().Unit),
                        TotalQuantity = totalQuantityAfterTranfer,
                        InventoryQuantity = stockWithoutReserved < 0 ? 0 : stockWithoutReserved, ///////
                        Material = material,
                        ReservedQuantities = allReservedQuantities
                    };

                    rate = planMaterial.TotalQuantity != 0 ? (planMaterial.InventoryQuantity / planMaterial.TotalQuantity) : 0;                    
                    
                    planDto.PlanMaterials.Add(planMaterial);
                }


                foreach (var planProductMaterial in items)
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
        private IList<ProductCostDto> GetProductsCostForPlan(int planId)
        {
            IList<ProductCostDto> productsCost = new List<ProductCostDto>();

            var plan = _planManager.GetWithDetails(planId);

            foreach (var planProduct in plan.PlanProducts)
            {
                double productCost = 0;

                foreach (var formula in planProduct.Product.Formulas)
                {
                    var warehouseMaterials = _warehouseMaterialManager.GetAll()
                        .Where(x => x.MaterialId == formula.MaterialId && x.CurrentQuantity != 0);

                    var materialPrice = ((warehouseMaterials.Sum(x => x.Price)) / (warehouseMaterials.Sum(x => x.InitialQuantity)));

                    productCost = productCost + materialPrice;
                }

                productsCost.Add(new ProductCostDto()
                { ProductId = (int)planProduct.ProductId, CostOfProduction = productCost });
            }

            return productsCost;
        }
        private PlanDto UpdatePlan(UpdatePlanDto data)
        {
            var plan = _planManager.GetWithDetails(data.Id);
            var planProducts = _planProductManager.GetAll();

            ObjectMapper.Map<UpdatePlanDto, Plan>(data, plan);


            foreach (var planProduct in plan.PlanProducts)
            {
                if (!planProducts.Any(x=>x.ProductId == planProduct.ProductId && x.PlanId == planProduct.PlanId))
                {
                    var createdPlanProduct = AsyncHelper.RunSync(() => _planProductManager.InsertAsync(planProduct));
                }
                
            }            

            var update = _planManager.UpdatePlan(plan);

            var dto = ObjectMapper.Map<PlanDto>(update);

            return InitUpdatePlanDetails(dto);
        }

        /////
        private PlanDto InitCreatePlanDetails(PlanDto planDto)
        {
            //If there is no plan
            if (planDto.Id == 0)
                return new PlanDto();

            var formulas = _formulaManager.GetAllWithIncluding("Unit,Material");
            var warehouseMaterials = _warehouseMaterialManager.GetAllWithIncluding("Unit,Material");
            var TotalProduction = _dailyProductionManager.GetAllProductionsCountForPlan(planDto.Id);
            var costs = GetProductsCostForPlan(planDto.Id);

            foreach (var planProduct in planDto.PlanProducts)
            {
                var productCost = costs.Where(x => x.ProductId == planProduct.ProductId).FirstOrDefault();
                var productFormula = formulas.Where(x => x.ProductId == planProduct.ProductId);
                foreach (var formula in productFormula)
                {
                    var planProductMaterial = new PlanProductMaterialDto()
                    {
                        MaterialId = formula.MaterialId,
                        UnitId = formula.UnitId,
                        RequiredQuantity = planProduct.NumberOfItems * formula.Quantity,
                        PlanProductId = planProduct.Id
                    };
                    planProduct.PlanProductMaterials.Add(planProductMaterial);
                }

                planProduct.TotalProduction = TotalProduction[(int)planProduct.ProductId];

                planProduct.ItemCost = productCost.CostOfProduction;

            }

            var planProductMaterials = planDto.PlanProducts.SelectMany(x => x.PlanProductMaterials);
            var materialIds = planProductMaterials.Select(x => x.MaterialId).Distinct();
            var materials = planDto.PlanProducts.Select(x => x.Product).SelectMany(x => x.Formulas).Select(x => x.Material);
            var previousActualPlans = GetActualPlans(); /////

            foreach (var materialId in materialIds)
            {
                double rate = 0;
                var items = planProductMaterials.Where(x => x.MaterialId == materialId).ToList();
                var material = materials.FirstOrDefault(x => x.Id == materialId);
                var stock = warehouseMaterials.Where(x => x.MaterialId == materialId && x.CurrentQuantity != 0).ToList();
                var totalQuantity = items.Sum(x => x.RequiredQuantity);
                var totalQuantityAfterTranfer = AsyncHelper.RunSync(() => _transferManager.ConvertTo(items.FirstOrDefault().UnitId, stock.FirstOrDefault().UnitId, totalQuantity));

                //////////

                double allBookingQuantities = 0;

                foreach (var previousActualPlan in previousActualPlans)
                {
                    if (previousActualPlan.PlanMaterials.Any())
                    {
                        allBookingQuantities += previousActualPlan.PlanMaterials.Where(x => x.MaterialId == materialId).FirstOrDefault().TotalQuantity;
                    }
                }

                var stockWithoutBooking = stock != null ? stock.Sum(x => x.CurrentQuantity) - allBookingQuantities : 0;

                //////////

                if (items.Any())
                {
                    var planMaterial = new PlanMaterialDto()
                    {
                        MaterialId = materialId,
                        UnitId = stock.FirstOrDefault().UnitId,
                        Unit = ObjectMapper.Map<UnitDto>(stock.FirstOrDefault().Unit),
                        TotalQuantity = totalQuantityAfterTranfer,
                        InventoryQuantity = stockWithoutBooking < 0 ? 0 : stockWithoutBooking, ///////
                        Material = material,
                        //InventoryUnitId = stock.FirstOrDefault().UnitId,
                        //InventoryUnit = ObjectMapper.Map<UnitDto>(stock.FirstOrDefault().Unit),
                    };

                    rate = planMaterial.TotalQuantity != 0 ? (planMaterial.InventoryQuantity / planMaterial.TotalQuantity) : 0;

                    planDto.PlanMaterials.Add(planMaterial);
                }
                //var plm = planProductMaterials.Where(x => x.MaterialId == materialId).ToList();


                foreach (var planProductMaterial in items)
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

        private PlanDto InitUpdatePlanDetails(PlanDto planDto)
        {
            //If there is no plan
            if (planDto.Id == 0)
                return new PlanDto();

            var formulas = _formulaManager.GetAllWithIncluding("Unit,Material");
            var warehouseMaterials = _warehouseMaterialManager.GetAllWithIncluding("Unit,Material");
            var TotalProduction = _dailyProductionManager.GetAllProductionsCountForPlan(planDto.Id);
            var costs = GetProductsCostForPlan(planDto.Id);

            foreach (var planProduct in planDto.PlanProducts)
            {
                var productCost = costs.Where(x => x.ProductId == planProduct.ProductId).FirstOrDefault();
                var productFormula = formulas.Where(x => x.ProductId == planProduct.ProductId);
                foreach (var formula in productFormula)
                {
                    var planProductMaterial = new PlanProductMaterialDto()
                    {
                        MaterialId = formula.MaterialId,
                        UnitId = formula.UnitId,
                        RequiredQuantity = planProduct.NumberOfItems * formula.Quantity,
                        PlanProductId = planProduct.Id
                    };
                    planProduct.PlanProductMaterials.Add(planProductMaterial);
                }

                planProduct.TotalProduction = TotalProduction[(int)planProduct.ProductId];

                planProduct.ItemCost = productCost.CostOfProduction;

            }

            var planProductMaterials = planDto.PlanProducts.SelectMany(x => x.PlanProductMaterials);
            var materialIds = planProductMaterials.Select(x => x.MaterialId).Distinct();
            var materials = planDto.PlanProducts.Select(x => x.Product).SelectMany(x => x.Formulas).Select(x => x.Material);
            var previousActualPlans = GetActualPlans().Where(x => x.Id != planDto.Id); /////

            foreach (var materialId in materialIds)
            {
                double rate = 0;
                var items = planProductMaterials.Where(x => x.MaterialId == materialId).ToList();
                var material = materials.FirstOrDefault(x => x.Id == materialId);
                var stock = warehouseMaterials.Where(x => x.MaterialId == materialId && x.CurrentQuantity != 0).ToList();
                var totalQuantity = items.Sum(x => x.RequiredQuantity);
                var totalQuantityAfterTranfer = AsyncHelper.RunSync(() => _transferManager.ConvertTo(items.FirstOrDefault().UnitId, stock.FirstOrDefault().UnitId, totalQuantity));

                //////////

                double allBookingQuantities = 0;

                foreach (var previousActualPlan in previousActualPlans)
                {
                    if (previousActualPlan.PlanMaterials.Any() && previousActualPlan.PlanMaterials.Where(x => x.MaterialId == materialId).Any())
                    {
                        allBookingQuantities += previousActualPlan.PlanMaterials.Where(x => x.MaterialId == materialId).FirstOrDefault().TotalQuantity;
                    }
                }

                var stockWithoutBooking = stock != null ? stock.Sum(x => x.CurrentQuantity) - allBookingQuantities : 0;

                //////////

                if (items.Any())
                {
                    var planMaterial = new PlanMaterialDto()
                    {
                        MaterialId = materialId,
                        UnitId = stock.FirstOrDefault().UnitId,
                        Unit = ObjectMapper.Map<UnitDto>(stock.FirstOrDefault().Unit),
                        TotalQuantity = totalQuantityAfterTranfer,
                        InventoryQuantity = stockWithoutBooking < 0 ? 0 : stockWithoutBooking, ///////
                        Material = material,
                        //InventoryUnitId = stock.FirstOrDefault().UnitId,
                        //InventoryUnit = ObjectMapper.Map<UnitDto>(stock.FirstOrDefault().Unit),
                    };

                    rate = planMaterial.TotalQuantity != 0 ? (planMaterial.InventoryQuantity / planMaterial.TotalQuantity) : 0;

                    planDto.PlanMaterials.Add(planMaterial);
                }
                //var plm = planProductMaterials.Where(x => x.MaterialId == materialId).ToList();


                foreach (var planProductMaterial in items)
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

        private IList<PlanDto> GetActualPlans()
        {
            IList<PlanDto> planDtos = new List<PlanDto>();
            var actualPlans = _planManager.GetActualPlans();
            var actualPlansDtos = ObjectMapper.Map<IList<PlanDto>>(actualPlans);
            foreach (var actualPlansDto in actualPlansDtos)
            {
                var formulas = _formulaManager.GetAllWithIncluding("Unit,Material");
                var warehouseMaterials = _warehouseMaterialManager.GetAllWithIncluding("Unit,Material");
                var TotalProduction = _dailyProductionManager.GetAllProductionsCountForPlan(actualPlansDto.Id);
                var costs = GetProductsCostForPlan(actualPlansDto.Id);

                foreach (var planProduct in actualPlansDto.PlanProducts)
                {
                    var productCost = costs.Where(x => x.ProductId == planProduct.ProductId).FirstOrDefault();
                    var productFormula = formulas.Where(x => x.ProductId == planProduct.ProductId);
                    foreach (var formula in productFormula)
                    {
                        var planProductMaterial = new PlanProductMaterialDto()
                        {
                            MaterialId = formula.MaterialId,
                            UnitId = formula.UnitId,
                            RequiredQuantity = planProduct.NumberOfItems * formula.Quantity,
                            PlanProductId = planProduct.Id
                        };
                        planProduct.PlanProductMaterials.Add(planProductMaterial);
                    }

                    planProduct.TotalProduction = TotalProduction[(int)planProduct.ProductId];

                    planProduct.ItemCost = productCost.CostOfProduction;

                }

                var planProductMaterials = actualPlansDto.PlanProducts.SelectMany(x => x.PlanProductMaterials);
                var materialIds = planProductMaterials.Select(x => x.MaterialId).Distinct();
                var materials = actualPlansDto.PlanProducts.Select(x => x.Product).SelectMany(x => x.Formulas).Select(x => x.Material);

                foreach (var materialId in materialIds)
                {
                    double rate = 0;
                    var items = planProductMaterials.Where(x => x.MaterialId == materialId).ToList();
                    var material = materials.FirstOrDefault(x => x.Id == materialId);
                    var stock = warehouseMaterials.Where(x => x.MaterialId == materialId && x.CurrentQuantity != 0).ToList();
                    var totalQuantity = items.Sum(x => x.RequiredQuantity);
                    var totalQuantityAfterTranfer = AsyncHelper.RunSync(() => _transferManager.ConvertTo(items.FirstOrDefault().UnitId, stock.FirstOrDefault().UnitId, totalQuantity));

                    if (items.Any())
                    {
                        var planMaterial = new PlanMaterialDto()
                        {
                            MaterialId = materialId,
                            UnitId = stock.FirstOrDefault().UnitId,
                            Unit = ObjectMapper.Map<UnitDto>(stock.FirstOrDefault().Unit),
                            TotalQuantity = totalQuantityAfterTranfer,
                            InventoryQuantity = stock != null ? stock.Sum(x => x.CurrentQuantity) : 0,
                            Material = material,
                            //InventoryUnitId = stock.FirstOrDefault().UnitId,
                            //InventoryUnit = ObjectMapper.Map<UnitDto>(stock.FirstOrDefault().Unit),
                        };

                        rate = planMaterial.TotalQuantity != 0 ? (planMaterial.InventoryQuantity / planMaterial.TotalQuantity) : 0;

                        actualPlansDto.PlanMaterials.Add(planMaterial);
                    }
                    //var plm = planProductMaterials.Where(x => x.MaterialId == materialId).ToList();


                    foreach (var planProductMaterial in items)
                    {
                        var pl = actualPlansDto.PlanProducts
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
            }
            return actualPlansDtos;
        }        

        /////

        #endregion
    }
}
