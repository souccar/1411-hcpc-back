using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Units.Dto.Units
{
    public class PagedUnitRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}
