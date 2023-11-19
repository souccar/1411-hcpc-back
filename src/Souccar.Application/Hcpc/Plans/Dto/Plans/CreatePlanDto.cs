using Souccar.Hcpc.Plans.Dto.PlanMaterials;
using Souccar.Hcpc.Plans.Dto.PlanProducts;
using System;
using System.Collections.Generic;

namespace Souccar.Hcpc.Plans.Dto.Plans
{
    public class CreatePlanDto
    {
        public CreatePlanDto()
        {
            PlanProducts = new List<CreatePlanProductDto>();
        }
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime? StartDate { get; set; }
        public IList<CreatePlanProductDto> PlanProducts { get; set; }
    }
}
