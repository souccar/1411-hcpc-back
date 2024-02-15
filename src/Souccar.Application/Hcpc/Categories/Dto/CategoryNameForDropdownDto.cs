using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Categories.Dto
{
    public class CategoryNameForDropdownDto : EntityDto<int>
    {
        public CategoryNameForDropdownDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Name { get; set; }
    }
}
