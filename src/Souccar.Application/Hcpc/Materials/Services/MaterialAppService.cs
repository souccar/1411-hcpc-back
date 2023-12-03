using Abp.Application.Services.Dto;
using AutoMapper;
using Souccar.Core.Services;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Materials.Dto.MaterialDetailsDtos;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Materials.Services
{
    public class MaterialAppService : AsyncSouccarAppService<Material, MaterialDto, int, PagedMaterialRequestDto, CreateMaterialDto, UpdateMaterialDto>, IMaterialAppService
    {
        private readonly IMaterialManager _materialManager;

        private readonly IWarehouseMaterialManager _warehouseMaterialManager;
        public MaterialAppService(IMaterialManager materialDomainService, IWarehouseMaterialManager warehouseMaterialManager) : base(materialDomainService)
        {
            _materialManager = materialDomainService;
            _warehouseMaterialManager = warehouseMaterialManager;
        }
        public IList<MaterialNameForDropdownDto> GetNameForDropdown()
        {
            return _materialManager.GetAll()
                .Select(x => new MaterialNameForDropdownDto(x.Id, x.Name)).ToList();
        }

        public override async Task<MaterialDto> GetAsync(EntityDto<int> input)
        {
            var material = _materialManager.GetWithDetails(input.Id);
            var materialDto = MapToEntityDto(material);
            return materialDto;
        }

        public async Task<MaterialDetailDto> GetWarehouseMaterialDetails(int materialId)
        {
            //Get Material
            var material =  _materialManager.GetWithDetails(materialId);
            var materialDetails = ObjectMapper.Map<MaterialDetailDto>(material);

            //Get warehouse materials
            var warehouseMaterials = _warehouseMaterialManager.GetAllWithIncluding("OutputRequestMaterilas").Where(x => x.MaterialId.Equals(materialId)).ToList();

            materialDetails.WarehouseMaterials = ObjectMapper.Map<IList<WarehouseMaterialDto>>(warehouseMaterials);

            return materialDetails;

        }


    }
}
