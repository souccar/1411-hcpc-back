using Abp.Application.Services.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Core.Services.Interfaces;
using Souccar.Hcpc.Categories.Dto;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Products.Services;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Categories.Services
{
    public class CategoryAppService : AsyncSouccarAppService<Category, CategoryDto, int, FullPagedRequestDto, CreateCategoryDto, UpdateCategoryDto>, ICategoryAppService
    {
        private readonly ICategoryManager _categoryManager;
        public CategoryAppService(ISouccarDomainService<Category, int> domainService) : base(domainService)
        {
        }
        public CategoryAppService(ICategoryManager categoryDomainService) : base(categoryDomainService)
        {
            _categoryManager = categoryDomainService;
        }
        public override async Task<CategoryDto> GetAsync(EntityDto<int> input)
        {
            var category = await _categoryManager.GetWithDetailsAsync(input.Id);
            var categoryDto = MapToEntityDto(category);
            return categoryDto;
        }

        public IList<CategoryNameForDropdownDto> GetNameForDropdown()
        {
            return _categoryManager.GetAll()
               .Select(x => new CategoryNameForDropdownDto(x.Id, x.Name )).ToList();

        }
    }
}
