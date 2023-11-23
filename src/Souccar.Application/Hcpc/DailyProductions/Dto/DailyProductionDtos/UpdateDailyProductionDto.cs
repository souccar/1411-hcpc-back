using Abp.Application.Services.Dto;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDetailsDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos
{
    public class UpdateDailyProductionDto : EntityDto<int>
    {
        public UpdateDailyProductionDto()
        {
            DailyProductionDetails = new List<UpdateDailyProductionDetailsDto>();
        }
        public int PlanId { get; set; }
        public IList<UpdateDailyProductionDetailsDto> DailyProductionDetails { get; set; }
    }
}
