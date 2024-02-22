using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Materials.Dto.MaterialDetailsDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Materials.Services
{
    public interface IMaterialAppService : IAsyncSouccarAppService<MaterialDto, int, FullPagedRequestDto, CreateMaterialDto, UpdateMaterialDto>
    {

        IList<MaterialNameForDropdownDto> GetNameForDropdown();
        IList<MaterialCodeForDropdownDto> GetCodeForDropdown();
        public Task<MaterialDetailDto> GetMaterialDetails(int materialId);
        IList<MaterialsOfSupplierDto> GetMaterialsOfSupplier(int materialId);
        Task<IList<MaterialCodeForDropdownDto>> GetByProductsIdsAsync(int[] productsIds);
        IList<MaterialincludeWarehouseMaterialDto> GetIncludeWarehouseMaterials(int[] warehouseMaterialsIds);
    }
}
