using Abp.Application.Services.Dto;

namespace Souccar.Hcpc.DailyProductions.Dto.DailyProductionDetailsDtos
{
    public class UpdateDailyProductionDetailsDto : EntityDto<int>
    {
        public int Quantity { get; set; }
        public int? ProductId { get; set; }
    }
}
