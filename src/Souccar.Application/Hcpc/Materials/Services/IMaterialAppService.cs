using Souccar.Core.Services;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Materials.Dto.MaterialDetailsDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Materials.Services
{
    public interface IMaterialAppService : IAsyncSouccarAppService<MaterialDto, int, PagedMaterialRequestDto, CreateMaterialDto, UpdateMaterialDto>
    {

        IList<MaterialNameForDropdownDto> GetNameForDropdown();
        public Task<MaterialDetailDto> GetMaterialDetails(int materialId);
        IList<MaterialsOfSupplierDto> GetMaterialsOfSupplier(int materialId);
        Task<IList<MaterialCodeForDropdownDto>> GetByProductsIdsAsync(int[] productsIds);
        IList<MaterialincludeWarehouseMaterialDto> GetIncludeWarehouseMaterials(int[] warehouseMaterialsIds);
    }
}
