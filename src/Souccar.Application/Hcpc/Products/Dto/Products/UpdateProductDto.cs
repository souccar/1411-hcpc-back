using Abp.Application.Services.Dto;
using Souccar.Hcpc.Products.Dto.Formulas;
using System.Collections.Generic;

namespace Souccar.Hcpc.Products.Dto.Products
{
    public class UpdateProductDto : EntityDto<int>
    {
        public UpdateProductDto()
        {
            Formulas = new List<UpdateFormulaDto>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public virtual IList<UpdateFormulaDto> Formulas { get; set; }
    }
}
