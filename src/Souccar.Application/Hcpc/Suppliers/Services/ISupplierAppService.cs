using Abp.Application.Services.Dto;
using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Hcpc.Suppliers.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.Suppliers.Services
{
    public interface ISupplierAppService: IAsyncSouccarAppService<SupplierDto,int, FullPagedRequestDto, CreateSupplierDto,UpdateSupplierDto>
    {
        IList<SupplierNameForDropdownDto> GetNameForDropdown();
        IList<SupplierNameForDropdownDto> GetSuppliersByMaterialIdForDropdown(int materialId);
    }
}
