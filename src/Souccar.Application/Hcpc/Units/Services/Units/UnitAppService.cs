using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Units.Dto.Units;

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

    }
}
