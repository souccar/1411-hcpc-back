using Souccar.Hcpc.Products.Dto.Formulas;
using System.Collections.Generic;

namespace Souccar.Hcpc.Products.Dto.Products
{
    public class ProductBaseDto
    {

        public ProductBaseDto()
        {
            Formulas = new List<FormulaDto>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Size { get; set; }
        public double Price { get; set; }
        public virtual IList<FormulaDto> Formulas { get; set; }
    }
}
