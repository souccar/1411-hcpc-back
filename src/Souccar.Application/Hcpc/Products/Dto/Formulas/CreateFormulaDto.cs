using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Products.Dto.Formulas
{
    public class CreateFormulaDto
    {
        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public double Percentage { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public double? Quantity { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? MaterialId { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? UnitId { get; set; }

        //public int? ProductId { get; set; }
    }
}
