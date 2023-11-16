using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Products.Dto.Products;

namespace Souccar.Hcpc.Products.Services.Products
{
    public class ProductAppService : AsyncSouccarAppService<Product, ProductDto, int, PagedProductRequestDto, CreateProductDto, UpdateProductDto>, IProductAppService
    {
        private readonly IProductManager _productDomainService;
        public ProductAppService(IProductManager productDomainService) : base(productDomainService)
        {
            _productDomainService = productDomainService;
        }
    }
}
