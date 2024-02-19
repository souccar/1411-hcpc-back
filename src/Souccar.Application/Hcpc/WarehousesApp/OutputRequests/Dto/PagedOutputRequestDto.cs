using Abp.Application.Services.Dto;
using Souccar.Core.Filter;
using Souccar.Core.Includes;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Dto
{
    public class PagedOutputRequestDto : PagedResultRequestDto, ISortedResultRequest, IIncludeResultRequest, IFilterResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
        public string Including { get; set; }
        public FilterDto Filtering { get; set; }
    }
}
