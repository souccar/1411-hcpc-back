using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos;
using Souccar.Hcpc.DailyProductions;
using Souccar.Hcpc.Plans.Services;
using Souccar.Hcpc.Products.Dto.Products;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Products.Services.Products
{
    public class ProductAppService : AsyncSouccarAppService<Product, ProductDto, int, PagedProductRequestDto, CreateProductDto, UpdateProductDto>, IProductAppService
    {
        private readonly IProductManager _productDomainService;
        private readonly IPlanManager _planDomainService;
        private readonly IWarehouseMaterialManager _warehouseMaterialDomainService;
        public ProductAppService(IProductManager productDomainService, IPlanManager planDomainService, IWarehouseMaterialManager warehouseMaterialDomainService) : base(productDomainService)
        {
            _productDomainService = productDomainService;
            _planDomainService = planDomainService;
            _warehouseMaterialDomainService = warehouseMaterialDomainService;
        }

        public IList<ProductNameForDropdownDto> GetNameForDropdown()
        {
            return _productDomainService.GetAll()
                .Select(x => new ProductNameForDropdownDto(x.Id, x.Name)).ToList();
        }

        public override async Task<ProductDto> UpdateAsync(UpdateProductDto input)
        {
            var product = _productDomainService.GetWithDetails(input.Id);

            ObjectMapper.Map<UpdateProductDto, Product>(input, product);

            var updatedProduct = await _productDomainService.UpdateAsync(product);

            return ObjectMapper.Map<ProductDto>(updatedProduct);
        }
    }
}
