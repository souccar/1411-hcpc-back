using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.Products.Dto.Formulas
{
    public class PagedFormulaRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}
