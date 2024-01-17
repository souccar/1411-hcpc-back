using Abp.Application.Services.Dto;
using Souccar.Core.Filter;

namespace Souccar.Hcpc.Products.Dto.Products
{
    public class PagedProductRequestDto : PagedResultRequestDto, ISortedResultRequest, IFilterResultRequest
    {
        public string Keyword { get; set; }
        public FilterDto Filtering { get; set; }
        public string Sorting { get; set; }

    }
}
