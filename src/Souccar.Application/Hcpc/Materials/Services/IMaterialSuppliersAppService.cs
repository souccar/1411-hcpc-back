using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos;

namespace Souccar.Hcpc.Materials.Services
{
    public interface IMaterialSuppliersAppService : IAsyncSouccarAppService<MaterialSuppliersDto, int, FullPagedRequestDto, CreateMaterialSuppliersDto, UpdateMaterialSuppliersDto>
    {
    }
}
