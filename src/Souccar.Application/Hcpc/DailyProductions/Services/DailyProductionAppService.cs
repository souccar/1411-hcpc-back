using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.DailyProductions.Services
{
    public class DailyProductionAppService : AsyncSouccarAppService<DailyProduction, DailyProductionDto, int, PagedDailyProductionRequestDto, CreateDailyProductionDto, UpdateDailyProductionDto>, IDailyProductionAppService
    {
        private readonly IDailyProductionManager _dailyProductionManager;

        public DailyProductionAppService(IDailyProductionManager dailyProductionManager) : base(dailyProductionManager)
        {
            _dailyProductionManager = dailyProductionManager;
        }

        public override async Task<DailyProductionDto> GetAsync(EntityDto<int> input)
        {
            var dailyProduction = _dailyProductionManager.GetWithDetails(input.Id);
            return MapToEntityDto(dailyProduction);
        }

        public override async Task<PagedResultDto<DailyProductionDto>> GetAllAsync(PagedDailyProductionRequestDto input)
        {
            PagedResultDto<DailyProductionDto> result = new PagedResultDto<DailyProductionDto>();

            List<DailyProductionDto> dtos = new List<DailyProductionDto>();

            var allDailyProductions = _dailyProductionManager.GetAllIncluding();

            result.TotalCount = allDailyProductions.Count;

            foreach (var allDailyProduction in allDailyProductions)
            {
                var itemDto = ObjectMapper.Map<DailyProductionDto>(allDailyProduction);
                dtos.Add(itemDto);
            }

            result.Items = dtos;
            return result;
        }

        public override async Task<DailyProductionDto> CreateAsync(CreateDailyProductionDto input)
        {
            var createdDailyProductionDto = await base.CreateAsync(input);

            var id= new EntityDto<int>(createdDailyProductionDto.Id);

            var DailyProductionDto = await GetAsync(id);

            return DailyProductionDto;
        }

        public override async Task<DailyProductionDto> UpdateAsync(UpdateDailyProductionDto input)
        {
            var updatedDailyProductionDto = await base.UpdateAsync(input);

            var id = new EntityDto<int>(updatedDailyProductionDto.Id);

            var DailyProductionDto = await GetAsync(id);

            return DailyProductionDto;
        }

        public Dictionary<int, int> GetAllProductionsCountForPlan(int PlanId)
        {
            var result = _dailyProductionManager.GetAllProductionsCountForPlan(PlanId);

            return result;
        }
    }
}
