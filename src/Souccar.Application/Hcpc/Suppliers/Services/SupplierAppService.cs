using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Suppliers.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Souccar.Hcpc.Suppliers.Services
{
    public class SupplierAppService :
        AsyncSouccarAppService<Supplier, SupplierDto, int, PagedSupplierRequestDto, CreateSupplierDto, UpdateSupplierDto>, ISupplierAppService
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
    }
}
