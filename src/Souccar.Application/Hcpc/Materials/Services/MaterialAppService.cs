using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Materials.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Materials.Services
{
    public class MaterialAppService : AsyncSouccarAppService<Material, MaterialDto, int, PagedMaterialRequestDto, CreateMaterialDto, UpdateMaterialDto>, IMaterialAppService
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

        public override async Task<MaterialDto> GetAsync(EntityDto<int> input)
        {
            var material = _materialDomainService.GetWithDetails(input.Id);
            var materialDto = MapToEntityDto(material);
            return materialDto;
        }


    }
}
