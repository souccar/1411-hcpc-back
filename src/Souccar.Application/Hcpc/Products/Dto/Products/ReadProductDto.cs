using Abp.Application.Services.Dto;
using Souccar.Core.CustomAttributes;
using Souccar.Hcpc.Categories.Dto;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Products.Dto.Formulas;
using Souccar.Hcpc.Units.Dto.Units;
using System.Collections.Generic;

namespace Souccar.Hcpc.Products.Dto.Products
{
    public class ReadProductDto : EntityDto<int>
    {
    
        public ReadProductDto()
        {
            Formulas = new List<FormulaDto>();
        }
        [ReadUserInterface(Searchable = true)]
        public string Name { get; set; }
        public string Description { get; set; }

        [ReadUserInterface(Searchable = true)]
        public double Size { get; set; }
        [ReadUserInterface(Searchable = true)]
        public double Price { get; set; }

        #region Category
        public int? CategoryId { get; set; }
        public ReadCategoryDto Category { get; set; }
        #endregion

        public virtual IList<FormulaDto> Formulas { get; set; }
    }
}
