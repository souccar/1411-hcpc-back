﻿using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Hcpc.Plans.Dto.Plans;
using Souccar.Hcpc.Products.Dto.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Plans.Services
{
    public interface IPlanAppService : IAsyncSouccarAppService<PlanDto, int, FullPagedRequestDto, CreatePlanDto, UpdatePlanDto>
    {
        Task<PlanDto> GetLastPlanAsync();
        Task<PlanDto> GetLastPlanActualAsync();
        Task<PlanDto> ChangeStatusToActual(int id);
        IList<PlanNameForDropdownDto> GetNameForDropdown();
        IList<PlanNameForDropdownDto> GetActualPlansNameForDropdown();
        IList<PlanDto> GetPendingPlans();
        IList<ProductInfoDropdownDto> GetProductsOfPlan(int planId);


    }
}
