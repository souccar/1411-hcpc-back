using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.WarehousesApp.InputRequests.Dto;

namespace Souccar.Hcpc.WarehousesApp.InputRequests.Services
{
    public interface IInputRequestAppService : IAsyncSouccarAppService<InputRequestDto, int, PagedInputRequestDto, CreateInputRequestDto, UpdateInputRequestDto>
    {
    }
}
