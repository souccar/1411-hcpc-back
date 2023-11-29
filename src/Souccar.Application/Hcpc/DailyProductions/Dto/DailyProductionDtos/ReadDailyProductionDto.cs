using Abp.Application.Services.Dto;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDetailsDtos;
using Souccar.Hcpc.Plans.Dto.Plans;
using System.Collections.Generic;

namespace Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos
{
    public class ReadDailyProductionDto : EntityDto<int>
    {
        public ReadDailyProductionDto()
        {
            DailyProductionDetails = new List<ReadDailyProductionDetailsDto>();
        }
        public string CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public int? PlanId { get; set; }
        public PlanDto Plan { get; set; }
        public IList<ReadDailyProductionDetailsDto> DailyProductionDetails { get; set; }
    }
}
