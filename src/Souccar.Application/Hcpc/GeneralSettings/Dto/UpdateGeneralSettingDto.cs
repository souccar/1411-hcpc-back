using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.GeneralSettings.Dto
{
    public class UpdateGeneralSettingDto : IEntityDto
    {
        public int Id { get; set; }
        public int ExpiryDurationNotify { get; set; }
    }
}
