using Abp.Application.Services.Dto;
using Abp.UI;
using Souccar.Core.Services;
using Souccar.Hcpc.Materials.Dto;
using Souccar.Hcpc.Materials.Dto.MaterialDetailsDtos;
using Souccar.Hcpc.Products.Dto.Products;
using Souccar.Hcpc.Products.Services;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Services.OutputRequestServices;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
using Souccar.Hcpc.WarehousesApp.WarehouseMaterials.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Souccar.Hcpc.Suppliers.Services;
using Abp.Authorization;
using Souccar.Authorization;
using Souccar.Core.Dto.PagedRequests;

namespace Souccar.Hcpc.Materials.Services
{
    [AbpAuthorize(PermissionNames.Setting_Materials)]
    public class MaterialAppService : AsyncSouccarAppService<Material, MaterialDto, int, PagedMaterialRequestDto, CreateMaterialDto, UpdateMaterialDto>, IMaterialAppService
    {
        private readonly IMaterialManager _materialManager;
        private readonly IWarehouseMaterialManager _warehouseMaterialManager;
        private readonly IProductManager _productManager;
        private readonly IOutputRequestManager _outputRequestManager;
        private readonly ISupplierManager _supplierManager;

        public MaterialAppService(IMaterialManager materialDomainService, IWarehouseMaterialManager warehouseMaterialManager, IOutputRequestManager outputRequestManager, IProductManager productManager, ISupplierManager supplierManager) : base(materialDomainService)
        {
            _materialManager = materialDomainService;
            _warehouseMaterialManager = warehouseMaterialManager;
            _productManager = productManager;
            _outputRequestManager = outputRequestManager;
            _supplierManager = supplierManager;
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

        public async Task<MaterialDetailDto> GetMaterialDetails(int materialId)
        {
            try
            {
                //Get Material
                if(materialId == 0)
                {
                    throw new UserFriendlyException("PleaseEnterMaterialId");
                }
                var material = _materialManager.GetWithDetails(materialId);
                var materialDetails = ObjectMapper.Map<MaterialDetailDto>(material);
                var products = ObjectMapper.Map<List<ProductOfMaterialDto>>(_productManager.GetProductsFromMaterial(materialId).ToList());

                //Get warehouse materials
                var warehouseMaterials = _warehouseMaterialManager.GetAllWithIncluding("Warehouse,Unit").Where(x => x.MaterialId.Equals(materialId)).ToList();

                foreach (var warehouseMaterial in warehouseMaterials)
                {
                    var outputRequests = _outputRequestManager.GetAllWithIncluding("OutputRequestMaterials").Where(x => x.OutputRequestMaterials.Any(y => y.WarehouseMaterialId == warehouseMaterial.Id)).ToList();

                    var warehouseMaterialDto = ObjectMapper.Map<WarehouseMaterialDto>(warehouseMaterial);

                    foreach (var outputRequest in outputRequests)
                    {
                        foreach (var OutputRequestMaterial in outputRequest.OutputRequestMaterials)
                        {
                            if (OutputRequestMaterial.WarehouseMaterialId == warehouseMaterial.Id)
                            {
                                warehouseMaterialDto.outputRequests
                                    .Add(new OutputRequestForWarehouseMaterialDto() { Id = outputRequest.Id, Title = outputRequest.Title, OutputDate = (DateTime)outputRequest.OutputDate, Quantity = OutputRequestMaterial.Quantity });
                            }
                        }

                    }                 
                    materialDetails.WarehouseMaterials.Add(warehouseMaterialDto);
                }
               
                materialDetails.RelatedProducts = products;

                return materialDetails;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }


        }

        public override async Task<MaterialDto> UpdateAsync(UpdateMaterialDto input)
        {
            var material = _materialManager.GetWithDetails(input.Id);

            ObjectMapper.Map<UpdateMaterialDto, Material>(input, material);

            var updatedMaterial = await _materialManager.UpdateAsync(material);

            return ObjectMapper.Map<MaterialDto>(updatedMaterial);
        }

        public IList<MaterialsOfSupplierDto> GetMaterialsOfSupplier(int materialId)
        {
            IList<MaterialsOfSupplierDto> materialsOfSupplierDtos= new List<MaterialsOfSupplierDto>();
            var suppliers = _supplierManager.GetSuppliersWithDetails(materialId);
            foreach (var supplier in suppliers)
            {
                var materialsOfSupplierDto = new MaterialsOfSupplierDto();
                materialsOfSupplierDto.SupplierId = supplier.Id;
                foreach (var item in supplier.MaterialSuppliers.Where(x=>x.Material != null))
                {
                    var MaterialOfSupplierInfoDto = new MaterialOfSupplierInfoDto()
                    {
                        LeadTime = item.LeadTime,
                        MaterialName = item.Material?.Name
                    };
                    materialsOfSupplierDto.MaterialNames.Add(MaterialOfSupplierInfoDto);
                }
                materialsOfSupplierDtos.Add(materialsOfSupplierDto);
            }
            return materialsOfSupplierDtos;
        }

        public async Task<IList<MaterialCodeForDropdownDto>> GetByProductsIdsAsync(int[] productsIds)
        {
            var materials = await _materialManager.GetByProductsIds(productsIds);
            return ObjectMapper.Map<List<MaterialCodeForDropdownDto>>(materials);
        }

        public IList<MaterialincludeWarehouseMaterialDto> GetIncludeWarehouseMaterials(int[] warehouseMaterialsIds)
        {
            var materials = _materialManager.GetAllWithIncluding("WarehouseMaterials")
                .Where(x=>x.WarehouseMaterials.Any(z=>warehouseMaterialsIds.Contains(z.Id))).ToList();
            var materilaDto = ObjectMapper.Map<List<MaterialincludeWarehouseMaterialDto>>(materials);
            return materilaDto;
        }

        public IList<MaterialCodeForDropdownDto> GetCodeForDropdown()
        {
            var materials = _materialManager.GetAll().ToList();

            return ObjectMapper.Map<List<MaterialCodeForDropdownDto>>(materials);
        }
    }
}
