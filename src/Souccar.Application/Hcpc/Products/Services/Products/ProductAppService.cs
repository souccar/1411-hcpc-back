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
using Souccar.Core.Dto.PagedRequests;

namespace Souccar.Hcpc.Products.Services.Products
{
    public class ProductAppService : AsyncSouccarAppService<Product, ProductDto, int, FullPagedRequestDto, CreateProductDto, UpdateProductDto>, IProductAppService
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

        public IList<ProductInfoDropdownDto> GetNameForDropdown()
        {
            //return _productDomainService.GetAll()
            //    .Select(x => new ProductNameForDropdownDto(x.Id, x.Name)).ToList();
            var products = _productDomainService.GetAll().ToList();
            var productsDto = new List<ProductInfoDropdownDto>();
            for (int i = 0; i < products.Count(); i++)
            {
                var product = new ProductInfoDropdownDto() { Id = products[i].Id, Information = products[i].Name + " | " + products[i].Size };
                productsDto.Add(product);
            }

            return productsDto;
        }

        public override async Task<ProductDto> UpdateAsync(UpdateProductDto input)
        {
            var product = _productDomainService.GetWithDetails(input.Id);

            ObjectMapper.Map<UpdateProductDto, Product>(input, product);

            var updatedProduct = await _productDomainService.UpdateAsync(product);

            return ObjectMapper.Map<ProductDto>(updatedProduct);
        }

        public override async Task<ProductDto> GetAsync(EntityDto<int> input)
        {
            var Product = _productDomainService.GetWithDetails(input.Id);
            return await Task.FromResult(MapToEntityDto(Product));
        }




    }
}
