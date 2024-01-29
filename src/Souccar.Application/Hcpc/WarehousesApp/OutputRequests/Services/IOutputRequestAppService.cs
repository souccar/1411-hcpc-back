using Souccar.Core.Dto.PagedRequests;
using Souccar.Core.Services;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Services
{
    public interface IOutputRequestAppService : IAsyncSouccarAppService<OutputRequestDto, int, FullPagedRequestDto, CreateOutputRequestDto, UpdateOutputRequestDto>
    {
        Task<List<OutputRequestWithDetailDto>> GetWithDetail(int plan);
        IList<OutputRequestDto> GetPlanOutputRequests(int planId);
        
        Task<OutputRequestDto> ChangeStatusAsync(int status, int id);
    }
}
