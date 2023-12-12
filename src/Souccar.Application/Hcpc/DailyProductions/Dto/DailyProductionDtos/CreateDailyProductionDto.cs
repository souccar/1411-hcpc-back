using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDetailsDtos;
using System.Collections.Generic;

namespace Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos
{
    public class CreateDailyProductionDto
    {
        public CreateDailyProductionDto()
        {
            DailyProductionDetails = new List<CreateDailyProductionDetailsDto>();
        }
        public int? PlanId { get; set; }
        public int? OutputRequestId { get; set; }
        public IList<CreateDailyProductionDetailsDto> DailyProductionDetails { get; set; }
    }
}
