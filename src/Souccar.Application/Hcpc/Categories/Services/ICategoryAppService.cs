using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Hcpc.Categories.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.Categories.Services
{
    public interface ICategoryAppService : IAsyncSouccarAppService<CategoryDto, int, FullPagedRequestDto, CreateCategoryDto, UpdateCategoryDto>
    {
        IList<CategoryNameForDropdownDto> GetNameForDropdown();
    }
}
