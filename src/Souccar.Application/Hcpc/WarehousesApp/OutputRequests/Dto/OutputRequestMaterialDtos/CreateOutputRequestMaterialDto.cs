using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto.OutputRequestMaterialDtos
{
    public class CreateOutputRequestMaterialDto
    {
        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public double Quantity { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? UnitId { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? WarehouseMaterialId { get; set; }
    }
}
