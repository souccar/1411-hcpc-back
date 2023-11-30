using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Plans.Dto.PlanProducts
{
    public class UpdatePlanProductDto : EntityDto<int>
    {
        public int NumberOfItems { get; set; }
        public PriorityInPlan Priority { get; set; }
        public int? ProductId { get; set; }
        public int? PlanId { get; set; }
    }
}
