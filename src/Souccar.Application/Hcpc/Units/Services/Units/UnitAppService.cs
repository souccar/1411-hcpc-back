using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Units.Dto.Units;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Units.Services.Units
{
    public class UnitAppService :
        AsyncSouccarAppService<Unit, UnitDto, int, PagedUnitRequestDto, CreateUnitDto, UpdateUnitDto, UnitDto, EntityDto<int>>, IUnitAppService
    {
        private readonly IUnitManager _unitDomainService;
        public UnitAppService(IUnitManager unitDomainService) : base(unitDomainService)
        {
            _unitDomainService = unitDomainService;
        }

        public IList<UnitNameForDropdownDto> GetNameForDropdown()
        {
            return _unitDomainService.GetAll()
                .Select(x=>new UnitNameForDropdownDto(x.Id,x.Name)).ToList();
        }
    }
}
