
using Souccar.Hcpc.Products.Dto.Formulas;
using System.Collections.Generic;

namespace Souccar.Hcpc.Products.Dto.Products
{
    public class CreateProductDto
    {
        public CreateProductDto()
        {
            Formulas = new List<CreateFormulaDto>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ExpectedProduce { get; set; }
        public double Price { get; set; }
        public virtual IList<CreateFormulaDto> Formulas { get; set; }
    }
}
