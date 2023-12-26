using Abp.Application.Services.Dto;
using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Plans.Dto.PlanProductMaterials
{
    public class UpdatePlanProductMaterialDto: EntityDto<int>
    {
        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public double Quantity { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? UnitId { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? MaterialId { get; set; }
    }
}
