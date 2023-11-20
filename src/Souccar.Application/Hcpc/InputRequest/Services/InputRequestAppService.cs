using Souccar.Core.Services;
using Souccar.Hcpc.InputRequests.Dto;
using Souccar.Hcpc.Warehouses.Services;

namespace Souccar.Hcpc.InputRequests.Services
{
    public class InputRequestAppService :
        AsyncSouccarAppService<Souccar.Hcpc.Warehouses.InputRequest, InputRequestDto, int, PagedInputRequestDto, CreateInputRequestDto, UpdateInputRequestDto>, IInputRequestAppService
    {
        private readonly IInputRequestManager _supplierDomainService;
        public InputRequestAppService(IInputRequestManager supplierDomainService) : base(supplierDomainService)
        {
            _supplierDomainService = supplierDomainService;
        }

    }
}
