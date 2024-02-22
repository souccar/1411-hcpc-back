using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionNoteDtos;
using Abp.Authorization;
using Souccar.Authorization;
using Souccar.Core.Dto.PagedRequests;

namespace Souccar.Hcpc.DailyProductions.Services
{
    [AbpAuthorize(PermissionNames.Production_DailyProductions)]
    public class DailyProductionAppService : AsyncSouccarAppService<DailyProduction, DailyProductionDto, int, FullPagedRequestDto, CreateDailyProductionDto, UpdateDailyProductionDto>, IDailyProductionAppService
    {
        private readonly IDailyProductionManager _dailyProductionManager;

        public DailyProductionAppService(IDailyProductionManager dailyProductionManager) : base(dailyProductionManager)
        {
            _dailyProductionManager = dailyProductionManager;
        }

        public override async Task<DailyProductionDto> GetAsync(EntityDto<int> input)
        {
            var dailyProduction = _dailyProductionManager.GetWithDetails(input.Id);
            return await Task.FromResult(MapToEntityDto(dailyProduction));
        }

        public override async Task<PagedResultDto<DailyProductionDto>> GetAllAsync(FullPagedRequestDto input)
        {
            PagedResultDto<DailyProductionDto> result = new PagedResultDto<DailyProductionDto>();

            List<DailyProductionDto> dtos = new List<DailyProductionDto>();

            var allDailyProductions = _dailyProductionManager.GetAllWithIncluding(input.Including).ToList();

            result.TotalCount = allDailyProductions.Count;

            foreach (var allDailyProduction in allDailyProductions)
            {
                var itemDto = ObjectMapper.Map<DailyProductionDto>(allDailyProduction);
                dtos.Add(itemDto);
            }

            result.Items = dtos;
            return await Task.FromResult(result);
        }

        public override async Task<DailyProductionDto> CreateAsync(CreateDailyProductionDto input)
        {
            //output request id that status is in prodution
            var dailyProduction = ObjectMapper.Map<DailyProduction>(input);
            dailyProduction.DailyProductionNotes.Add(new DailyProductionNote() { Note = input.Note });
            var createdDailyProductionDto = await _dailyProductionManager.InsertAsync(dailyProduction);

            var id= new EntityDto<int>(createdDailyProductionDto.Id);

            var DailyProductionDto = await GetAsync(id);

            return DailyProductionDto;
        }

        public override async Task<DailyProductionDto> UpdateAsync(UpdateDailyProductionDto input)
        {
            var dailyProduction = _dailyProductionManager.GetWithDetails(input.Id);

            ObjectMapper.Map<UpdateDailyProductionDto, DailyProduction>(input, dailyProduction);

            var updatedDailyProduction = await _dailyProductionManager.UpdateAsync(dailyProduction);

            return ObjectMapper.Map<DailyProductionDto>(updatedDailyProduction);
        }

        public Dictionary<int, int> GetAllProductionsCountForPlan(int PlanId)
        {
            var result = _dailyProductionManager.GetAllProductionsCountForPlan(PlanId);

            return result;
        }

        public async Task<DailyProductionNoteDto> AddNote(string note, int dailyProductionId)
        {
            var createdNote = await _dailyProductionManager.AddNoteForDailyProductionAsync(note, dailyProductionId);
            return ObjectMapper.Map<DailyProductionNoteDto>(createdNote);
        }
    }
}
