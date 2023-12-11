using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Products.Dto.Products.OutputRequestProductDtos
{
    public class UpdateOutputRequestProductDto : EntityDto<int>
    {
        public int ProductId { get; set; }
    }
}
