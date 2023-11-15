using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.InputRequests.Dto
{
    public class PagedInputRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}
