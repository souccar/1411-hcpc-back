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
        public int ExpectedProduce { get; set; }
        public virtual IList<FormulaDto> Formulas { get; set; }
    }
}
