
using Souccar.Consts;
using Souccar.Hcpc.Products.Dto.Formulas;
using Souccar.Validation.List;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Products.Dto.Products
{
    public class CreateProductDto
    {
        public CreateProductDto()
        {
            Formulas = new List<CreateFormulaDto>();
        }

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Name { get; set; }

        [MaxLength(SouccarAppConstant.MultiLinesStringMaxLength)]
        public string Description { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public double Size { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required), Range(0, double.PositiveInfinity, ErrorMessage = SouccarAppConstant.LessThanZero)]
        public double Price { get; set; }

        [NotEmptyList(ErrorMessage = SouccarAppConstant.EmptyList)]
        public virtual IList<CreateFormulaDto> Formulas { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? CategoryId { get; set; }
    }
}
