using Abp.Application.Services.Dto;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDetailsDtos;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionNoteDtos;
using Souccar.Hcpc.Plans.Dto.Plans;
using System.Collections.Generic;

namespace Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos
{
    public class DailyProductionDto : EntityDto<int>
    {
        public DailyProductionDto()
        {
            DailyProductionDetails = new List<DailyProductionDetailsDto>();
            DailyProductionNotes = new List<DailyProductionNoteDto>();
        }
        public string CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public int? OutputRequestId { get; set; }

        public int? PlanId { get; set; }
        public PlanDto Plan { get; set; }
        public IList<DailyProductionDetailsDto> DailyProductionDetails { get; set; }
        public IList<DailyProductionNoteDto> DailyProductionNotes { get; set; }
    }
}
