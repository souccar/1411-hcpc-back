using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.WarehouseMaterials.Dto
{
    public class PagedWarehouseMaterialRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}
