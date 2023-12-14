using Souccar.Core.Services;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos;
using Souccar.Hcpc.Plans.Dto.Plans;
using Souccar.Hcpc.Products.Dto.Products;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Services
{
    public interface IPlanAppService : IAsyncSouccarAppService<PlanDto, int, PagedPlanRequestDto, CreatePlanDto, UpdatePlanDto>
    {
        Task<PlanDto> GetLastPlanAsync();
        Task<PlanDto> GetLastPlanActualAsync();
        Task<PlanDto> ChangeStatusToActual(int id);
        IList<PlanNameForDropdownDto> GetNameForDropdown();
        IList<PlanNameForDropdownDto> GetActualPlansNameForDropdown();

        IList<ProductNameForDropdownDto> GetProductsOfPlan(int planId);


    }
}
