using Abp.Application.Services.Dto;
using Souccar.Core.Includes;

namespace Souccar.Hcpc.Plans.Dto.Plans
{
    public class PagedPlanRequestDto : PagedResultRequestDto, ISortedResultRequest ,IIncludeResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
        public string Including { get; set; }
    }
}
