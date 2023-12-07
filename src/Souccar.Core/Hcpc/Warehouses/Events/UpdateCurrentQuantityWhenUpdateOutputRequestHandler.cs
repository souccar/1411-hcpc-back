using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Souccar.Hcpc.Warehouses.Services.OutputRequestServices;
using Souccar.Hcpc.Warehouses.Services.WarehouseServices;
using System.Threading.Tasks;

namespace Souccar.Hcpc.Warehouses.Events
{
    public class UpdateCurrentQuantityWhenUpdateOutputRequestHandler : IAsyncEventHandler<UpdateCurrentQuantityWhenUpdateOutputRequestData>, ITransientDependency
    {
        private readonly IWarehouseMaterialManager _warehouseMaterialManager;
        private readonly IOutputRequestManager _outputRequestManager;

        public UpdateCurrentQuantityWhenUpdateOutputRequestHandler(IWarehouseMaterialManager warehouseMaterialManager, IOutputRequestManager outputRequestManager)
        {
            _warehouseMaterialManager = warehouseMaterialManager;
            _outputRequestManager = outputRequestManager;
        }

        public Task HandleEventAsync(UpdateCurrentQuantityWhenUpdateOutputRequestData eventData)
        {
            throw new System.NotImplementedException();
        }
    }
}
