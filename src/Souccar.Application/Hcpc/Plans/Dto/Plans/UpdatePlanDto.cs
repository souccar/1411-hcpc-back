using Abp.Application.Services.Dto;
using Souccar.Hcpc.Plans.Dto.PlanProducts;
using System;
using System.Collections.Generic;

namespace Souccar.Hcpc.Plans.Dto.Plans
{
    public class UpdatePlanDto: EntityDto<int>
    {
        public UpdatePlanDto()
        {
            PlanProducts = new List<UpdatePlanProductDto>();
        }
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime? StartDate { get; set; }
        public IList<UpdatePlanProductDto> PlanProducts { get; set; }
    }
}
