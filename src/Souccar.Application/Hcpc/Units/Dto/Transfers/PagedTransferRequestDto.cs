using Abp.Application.Services.Dto;
using Souccar.Core.Includes;

namespace Souccar.Hcpc.Units.Dto.Transfers
{
    public class PagedTransferRequestDto : PagedResultRequestDto, ISortedResultRequest, IIncludeResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
        public string Including { get; set; }
    }
}

