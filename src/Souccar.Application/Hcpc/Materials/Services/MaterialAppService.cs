using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Materials.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.Hcpc.Materials.Services
{
    public class MaterialAppService : AsyncSouccarAppService<Material, MaterialDto, int, PagedMaterialRequestDto, CreateMaterialDto, UpdateMaterialDto, MaterialDto, EntityDto<int>>, IMaterialAppService
    {
        private readonly IMaterialManager _materialDomainService;
        public MaterialAppService(IMaterialManager materialDomainService) : base(materialDomainService)
        {
            _materialDomainService = materialDomainService;
        }
        public IList<MaterialNameForDropdownDto> GetNameForDropdown()
        {
            return _materialDomainService.GetAll()
                .Select(x => new MaterialNameForDropdownDto(x.Id, x.Name)).ToList();
        }
    }
}
