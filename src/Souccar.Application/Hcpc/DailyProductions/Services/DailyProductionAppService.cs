using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.DailyProductions.Dto.DailyProductionDtos;
using Souccar.Hcpc.Plans.Dto.Plans;
using Souccar.Hcpc.Plans;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            //output request id that status is in prodution
            var createdDailyProductionDto = await base.CreateAsync(input);

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

    }
}
