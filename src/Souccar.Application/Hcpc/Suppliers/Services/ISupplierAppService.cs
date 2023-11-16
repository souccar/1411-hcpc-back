using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.Suppliers.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.Suppliers.Services
{
    public interface ISupplierAppService: IAsyncSouccarAppService<SupplierDto,int,PagedSupplierRequestDto,CreateSupplierDto,UpdateSupplierDto>
    {
        IList<SupplierNameForDropdownDto> GetNameForDropdown();
    }
}
