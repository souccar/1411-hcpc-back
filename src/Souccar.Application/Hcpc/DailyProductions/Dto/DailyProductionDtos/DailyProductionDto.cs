using Abp.Application.Services.Dto;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDetailsDtos;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionNoteDtos;
using Souccar.Hcpc.Plans.Dto.Plans;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
using System;
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
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
        public int? OutputRequestId { get; set; }
        public OutputRequestNameForDropdownDto OutputRequest { get; set; }

        public int? PlanId { get; set; }
        public PlanDto Plan { get; set; }
        public IList<DailyProductionDetailsDto> DailyProductionDetails { get; set; }
        public IList<DailyProductionNoteDto> DailyProductionNotes { get; set; }
    }
}
