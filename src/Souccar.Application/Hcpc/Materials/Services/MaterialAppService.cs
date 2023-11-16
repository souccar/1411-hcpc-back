using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Materials.Dto;

namespace Souccar.Hcpc.Materials.Services
{
    public class MaterialAppService : AsyncSouccarAppService<Material, MaterialDto, int, PagedMaterialRequestDto, CreateMaterialDto, UpdateMaterialDto>, IMaterialAppService
    {
        private readonly IMaterialManager _materialDomainService;
        public MaterialAppService(IMaterialManager materialDomainService) : base(materialDomainService)
        {
            _materialDomainService = materialDomainService;
        }
    }
}
