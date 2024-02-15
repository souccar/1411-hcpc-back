using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Categories.Dto
{
    public class CategoryDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryDto ParentCategory { get; set; }
    }
}
