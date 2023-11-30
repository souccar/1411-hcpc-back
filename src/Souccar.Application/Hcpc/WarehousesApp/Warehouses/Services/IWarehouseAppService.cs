using Souccar.Core.Services;
using Souccar.Hcpc.WarehousesApp.Warehouses.Dto;

namespace Souccar.Hcpc.WarehousesApp.Warehouses.Services
{
    public interface IWarehouseAppService : IAsyncSouccarAppService<WarehouseDto, int, PagedWarehouseRequestDto, CreateWarehouseDto, UpdateWarehouseDto>
    {
    }
}
