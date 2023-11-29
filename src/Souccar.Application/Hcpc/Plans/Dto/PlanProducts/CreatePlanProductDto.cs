namespace Souccar.Hcpc.Plans.Dto.PlanProducts
{
    public class CreatePlanProductDto
    {
        public int NumberOfItems { get; set; }
        public PriorityInPlan Priority { get; set; }
        public int? ProductId { get; set; }
        public int? PlanId { get; set; }
    }
}
