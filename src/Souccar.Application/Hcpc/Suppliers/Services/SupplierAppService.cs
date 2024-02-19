using Abp.Authorization;
using Souccar.Authorization;
using Abp.Application.Services.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Hcpc.Suppliers.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.Hcpc.Suppliers.Services
{
    [AbpAuthorize(PermissionNames.Setting_Suppliers)]
    public class SupplierAppService :
        AsyncSouccarAppService<Supplier, SupplierDto, int, FullPagedRequestDto, CreateSupplierDto, UpdateSupplierDto>, ISupplierAppService
    {
        private readonly ISupplierManager _supplierDomainService;
        public SupplierAppService(ISupplierManager supplierDomainService) : base(supplierDomainService)
        {
            _supplierDomainService = supplierDomainService;
        }
        public IList<SupplierNameForDropdownDto> GetNameForDropdown()
        {
            return _supplierDomainService.GetAll()
                .Select(x => new SupplierNameForDropdownDto(x.Id, x.Name)).ToList();
        }

        public IList<SupplierNameForDropdownDto> GetSuppliersByMaterialIdForDropdown(int materialId)
        {
            var suppliers = _supplierDomainService.GetSuppliersByMaterialId(materialId);
            return ObjectMapper.Map<List<SupplierNameForDropdownDto>>(suppliers);
        }
    }
}
