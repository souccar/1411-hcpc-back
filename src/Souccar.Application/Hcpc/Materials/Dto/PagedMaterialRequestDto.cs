using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Materials.Dto
{
    public class PagedMaterialRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}
