using Abp.Application.Services.Dto;
using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Hcpc.Categories.Dto
{
    public class UpdateCategoryDto : EntityDto<int>
    {
      
        public int? ParentCategoryId { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public string Name { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public string Description { get; set; }
    }
}
