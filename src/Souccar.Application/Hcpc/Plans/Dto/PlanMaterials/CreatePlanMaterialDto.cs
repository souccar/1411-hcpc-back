using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Plans.Dto.PlanMaterials
{
    public class CreatePlanMaterialDto
    {

        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public double TotalQuantity { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public double InventoryQuantity { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? UnitId { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? MaterialId { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? PlanId { get; set; }
    }
}
