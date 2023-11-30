using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.GeneralSettings.Dto
{
    public class GeneralSettingDto : IEntityDto
    {
        public int Id { get; set; }
        public int ExpiryDurationNotify { get; set; }
    }
}
