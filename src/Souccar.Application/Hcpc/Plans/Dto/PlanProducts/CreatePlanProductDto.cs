using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Plans.Dto.PlanProducts
{
    public class CreatePlanProductDto
    {

        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public int NumberOfItems { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, 1)]
        public PriorityInPlan Priority { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? ProductId { get; set; }

        public int? PlanId { get; set; }
    }
}
