using Souccar.Core.Services;
using Souccar.Hcpc.OutputRequests.Dto;
using Souccar.Hcpc.Warehouses.Services;

namespace Souccar.Hcpc.OutputRequests.Services
{
    public class OutputRequestAppService :
        AsyncSouccarAppService<Souccar.Hcpc.Warehouses.OutputRequest, OutputRequestDto, int, PagedOutputRequestDto, CreateOutputRequestDto, UpdateOutputRequestDto>, IOutputRequestAppService
    {
        private readonly IOutputRequestManager _supplierDomainService;
        public OutputRequestAppService(IOutputRequestManager supplierDomainService) : base(supplierDomainService)
        {
            _supplierDomainService = supplierDomainService;
        }

    }
}
