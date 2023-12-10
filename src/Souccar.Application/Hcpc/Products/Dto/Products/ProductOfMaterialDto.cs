using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Products.Dto.Products
{
    public class ProductOfMaterialDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
