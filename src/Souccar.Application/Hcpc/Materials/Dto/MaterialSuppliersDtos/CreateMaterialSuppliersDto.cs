using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos
{
    public class CreateMaterialSuppliersDto
    {
        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public int LeadTime { get; set; }
    }
}
