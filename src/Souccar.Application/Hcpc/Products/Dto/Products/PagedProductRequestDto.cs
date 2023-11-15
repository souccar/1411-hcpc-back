using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Products.Dto.Products
{
    public class PagedProductRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}
