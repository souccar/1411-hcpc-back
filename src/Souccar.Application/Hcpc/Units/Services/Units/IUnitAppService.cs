using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Hcpc.Units.Dto.Units;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Units.Services.Units
{
    public interface IUnitAppService : IAsyncSouccarAppService<UnitDto, int, FullPagedRequestDto, CreateUnitDto, UpdateUnitDto>
    {
        IList<UnitNameForDropdownDto> GetNameForDropdown();
        Task<UnitDto> GetIncludeParentAsync(int id);
        Task<IList<UnitNameForDropdownDto>> GetAllParentUnitsAsync();
        Task<IList<UnitNameForDropdownDto>> GetAllRelatedUnits(int id);
        Task<IList<UnitNameForDropdownDto>> GetAllForMaterialAsync(int materialId);
    }
}
