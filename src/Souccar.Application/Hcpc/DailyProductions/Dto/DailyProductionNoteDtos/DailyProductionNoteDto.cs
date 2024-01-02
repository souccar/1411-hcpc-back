using Abp.Application.Services.Dto;
using System;

namespace Souccar.Hcpc.DailyProductions.Dto.DailyProductionNoteDtos
{
    public class DailyProductionNoteDto: EntityDto
    {
        public string Note { get; set; }
        public DateTime CreationTime { get; set; }
        public long? CreatorUserId { get; set; }
    }
}
