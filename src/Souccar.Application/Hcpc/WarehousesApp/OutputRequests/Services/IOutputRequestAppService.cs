using Souccar.Core.Services;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.WarehousesApp.OutputRequests.Dto;
using System.Collections.Generic;

namespace Souccar.Hcpc.WarehousesApp.OutputRequests.Services
{
    public interface IOutputRequestAppService : IAsyncSouccarAppService<OutputRequestDto, int, PagedOutputRequestDto, CreateOutputRequestDto, UpdateOutputRequestDto>
    {
        public IList<OutputRequestDto> GetPlanOutputRequests(int planId);
    }
}
