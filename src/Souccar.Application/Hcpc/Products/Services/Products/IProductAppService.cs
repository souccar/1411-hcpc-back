using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Products.Dto.Products;
using System.Collections.Generic;

namespace Souccar.Hcpc.Products.Services.Products
{
    public interface IProductAppService : IAsyncSouccarAppService<ProductDto, int, PagedProductRequestDto, CreateProductDto, UpdateProductDto>
    {

        IList<ProductNameForDropdownDto> GetNameForDropdown();
    }
}
