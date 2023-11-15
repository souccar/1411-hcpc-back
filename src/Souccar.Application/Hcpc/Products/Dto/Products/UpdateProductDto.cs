using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Products.Dto.Products
{
    public class UpdateProductDto : ProductBaseDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
