using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Products.Dto.Products;

namespace Souccar.Hcpc.Products.Services.Products
{
    public interface IProductAppService : IAsyncSouccarAppService<ProductDto, int, PagedProductRequestDto, CreateProductDto, UpdateProductDto>
    {
    }
}
