using Abp.Application.Services.Dto;
using Souccar.Core.Services;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Services
{
    public interface IOutputRequestAppService : IAsyncSouccarAppService<OutputRequestDto, int, PagedOutputRequestDto, CreateOutputRequestDto, UpdateOutputRequestDto>
    {
    }
}
