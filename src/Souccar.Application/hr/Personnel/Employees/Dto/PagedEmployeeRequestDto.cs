using Abp.Application.Services.Dto;
using Souccar.Core.Filter;
using Souccar.Core.Includes;
using Souccar.Core.Search;

namespace Souccar.hr.Personnel.Employees.Dto
{
    public class PagedEmployeeRequestDto : PagedResultRequestDto, ISearchResultRequest, IFilterResultRequest, IIncludeResultRequest, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public FilterDto Filtering { get; set; }
        public string Including { get; set; }
        public string Sorting { get; set; }
    }
}
