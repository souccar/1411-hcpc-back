using Abp.Application.Services.Dto;
using Souccar.Hcpc.Products.Dto.Formulas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Categories.Dto
{
    public class ReadCategoryDto : CategoryDto, IEntityDto<int>
    {
        public int Id { get; set; }
        public CategoryDto ParentCategory { get; set; }
    }
}
