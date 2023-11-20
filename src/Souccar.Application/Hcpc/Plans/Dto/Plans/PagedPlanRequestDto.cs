using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Plans.Dto.Plans
{
    public class PagedPlanRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}
