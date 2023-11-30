using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.GeneralSettings.Dto
{
    public class PagedGeneralSettingRequestDto : PagedResultRequestDto, ISortedResultRequest
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
    }
}
