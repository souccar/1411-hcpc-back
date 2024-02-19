using Abp.Authorization;
using Souccar.Authorization;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Materials.Dto.MaterialSuppliersDtos;

namespace Souccar.Hcpc.Materials.Services
{
    [AbpAuthorize(PermissionNames.Setting_Materials)]
    public class MaterialSuppliersAppService : AsyncSouccarAppService<MaterialSuppliers, MaterialSuppliersDto, int, PagedMaterialRequestDto, CreateMaterialSuppliersDto, UpdateMaterialSuppliersDto>, IMaterialSuppliersAppService
    {
        private readonly IMaterialSupplierManager _materialSuppliersDomainService;
        public MaterialSuppliersAppService(IMaterialSupplierManager materialSuppliersDomainService) : base(materialSuppliersDomainService)
        {
            _materialSuppliersDomainService = materialSuppliersDomainService;
        }
    }
}
