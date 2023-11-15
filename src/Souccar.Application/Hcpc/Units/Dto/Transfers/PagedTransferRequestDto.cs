using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Units.Dto.Transfers
{
    public class PagedTransferRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}

