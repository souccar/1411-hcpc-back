using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.OutputRequests.Dto
{
    public class PagedOutputRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}
