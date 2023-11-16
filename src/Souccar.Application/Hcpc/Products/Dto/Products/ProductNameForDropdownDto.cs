using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Products.Dto.Products
{
    public class ProductNameForDropdownDto : EntityDto<int>
    {
        public ProductNameForDropdownDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public string Name { get; set; }
    }
}
