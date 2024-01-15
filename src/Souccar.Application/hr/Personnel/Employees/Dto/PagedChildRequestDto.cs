using Abp.Application.Services.Dto;
using Souccar.Core.Filter;
using Souccar.Core.Search;

namespace Souccar.hr.Personnel.Employees.Dto
{
    public class PagedChildRequestDto : PagedResultRequestDto, ISortedResultRequest, ISearchResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}
