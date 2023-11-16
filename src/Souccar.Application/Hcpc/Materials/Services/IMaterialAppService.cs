using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Materials.Dto;

namespace Souccar.Hcpc.Materials.Services
{
    public interface IMaterialAppService : IAsyncSouccarAppService<MaterialDto, int, PagedMaterialRequestDto, CreateMaterialDto, UpdateMaterialDto>
    {
    }
}
