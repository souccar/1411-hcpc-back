using Abp.Application.Services.Dto;
using Souccar.Core.Includes;

namespace Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos
{
    public class PagedDailyProductionRequestDto : PagedResultRequestDto, ISortedResultRequest,IIncludeResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
        public string Including { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
