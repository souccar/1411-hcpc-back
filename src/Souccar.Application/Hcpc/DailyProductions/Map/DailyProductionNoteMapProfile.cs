using AutoMapper;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionNoteDtos;

namespace Souccar.Hcpc.DailyProductions.Map
{
    public class DailyProductionNoteMapProfile: Profile
    {
        public DailyProductionNoteMapProfile()
        {
            CreateMap<DailyProductionNote, DailyProductionNoteDto>();
        }
    }
}
