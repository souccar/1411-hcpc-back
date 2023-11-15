using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Units.Dto.Units;

namespace Souccar.Hcpc.Units.Services.Units
{
    public interface IUnitAppService : IAsyncSouccarAppService<UnitDto, int, PagedUnitRequestDto, CreateUnitDto, UpdateUnitDto, UnitDto, EntityDto<int>>
    {
    }
}
