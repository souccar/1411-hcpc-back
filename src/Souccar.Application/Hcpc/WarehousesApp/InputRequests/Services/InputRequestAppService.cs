using Souccar.Core.Services;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Warehouses.Services.InputRequestServices;
using Souccar.Hcpc.WarehousesApp.InputRequests.Dto;

namespace Souccar.Hcpc.WarehousesApp.InputRequests.Services
{
    public class InputRequestAppService :
        AsyncSouccarAppService<InputRequest, InputRequestDto, int, PagedInputRequestDto, CreateInputRequestDto, UpdateInputRequestDto>, IInputRequestAppService
    {
        private readonly IInputRequestManager _supplierDomainService;
        public InputRequestAppService(IInputRequestManager supplierDomainService) : base(supplierDomainService)
        {
            _supplierDomainService = supplierDomainService;
        }

    }
}
