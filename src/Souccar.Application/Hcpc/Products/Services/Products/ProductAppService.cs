using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Products.Dto.Products;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.Hcpc.Products.Services.Products
{
    public class ProductAppService : AsyncSouccarAppService<Product, ProductDto, int, PagedProductRequestDto, CreateProductDto, UpdateProductDto, ProductDto, EntityDto<int>>, IProductAppService
    {
        private readonly IProductManager _productDomainService;
        public ProductAppService(IProductManager productDomainService) : base(productDomainService)
        {
            _productDomainService = productDomainService;
        }

        public IList<ProductNameForDropdownDto> GetNameForDropdown()
        {
            return _productDomainService.GetAll()
                .Select(x => new ProductNameForDropdownDto(x.Id, x.Name)).ToList();
        }
    }
}
