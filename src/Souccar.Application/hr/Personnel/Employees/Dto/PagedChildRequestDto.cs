using Abp.Application.Services.Dto;
using Souccar.Core.Filter;

namespace Souccar.hr.Personnel.Employees.Dto
{
    public class PagedChildRequestDto : PagedResultRequestDto, ISortedResultRequest, IFilterResultRequest
    {

        public string Keyword { get; set; }
        public string Sorting { get; set; }
        public string Filtering { get; set; }
    }
}
