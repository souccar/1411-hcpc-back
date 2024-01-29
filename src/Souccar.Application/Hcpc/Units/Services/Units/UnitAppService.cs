using Abp.Application.Services.Dto;
using Abp.UI;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Hcpc.Units.Dto.Units;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Units.Services.Units
{
    public class UnitAppService :
        AsyncSouccarAppService<Unit, UnitDto, int, FullPagedRequestDto, CreateUnitDto, UpdateUnitDto>, IUnitAppService
    {
        private readonly IUnitManager _unitDomainService;
        public UnitAppService(IUnitManager unitDomainService) : base(unitDomainService)
        {
            _unitDomainService = unitDomainService;
        }

        public async Task<IList<UnitNameForDropdownDto>> GetAllForMaterialAsync(int materialId)
        {
            var units = await _unitDomainService.GetAllForMaterialAsync(materialId);
            return ObjectMapper.Map<List<UnitNameForDropdownDto>>(units);
        }

        public async Task<IList<UnitNameForDropdownDto>> GetAllParentUnitsAsync()
        {
            var units = await _unitDomainService.GetAllParentUnitsAsync();
            return ObjectMapper.Map<List<UnitNameForDropdownDto>>(units);
        }

        public async Task<IList<UnitNameForDropdownDto>> GetAllRelatedUnits(int id)
        {
            var relatedUnits = await _unitDomainService.GetAllRelatedUnitsAsync(id);
            return ObjectMapper.Map<List<UnitNameForDropdownDto>>(relatedUnits);
        }

        public async Task<UnitDto> GetIncludeParentAsync(int id)
        {
            var unit = await _unitDomainService.GetIncludeParentAsync(id);
            return ObjectMapper.Map<UnitDto>(unit);
        }

        public IList<UnitNameForDropdownDto> GetNameForDropdown()
        {
            var units = _unitDomainService.GetAll().ToList();
            return ObjectMapper.Map<List<UnitNameForDropdownDto>>(units);
        }

        public override async Task<UnitDto> UpdateAsync(UpdateUnitDto input)
        {
            if(input.ParentUnitId == input.Id)
            {
                throw new UserFriendlyException("Unit cannot choose a father for herself");
            }

            var oldUnit = await GetIncludeParentAsync(input.Id);

            if (oldUnit.ParentUnitId == null && input.ParentUnitId != null)
            {
                var relatedUnites = await _unitDomainService.GetAllRelatedUnitsAsync(input.Id);                
                foreach (var relatedUnite in relatedUnites)
                {
                    relatedUnite.ParentUnitId = input.ParentUnitId;
                    await _unitDomainService.UpdateAsync(relatedUnite);
                }
                return await base.UpdateAsync(input);
            }
            else
            {
                return await base.UpdateAsync(input);
            }

            
        }
    }
}
