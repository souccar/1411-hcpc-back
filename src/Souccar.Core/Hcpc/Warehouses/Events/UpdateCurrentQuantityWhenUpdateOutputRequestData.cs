using Abp.Events.Bus;

namespace Souccar.Hcpc.Warehouses.Events
{
    public class UpdateCurrentQuantityWhenUpdateOutputRequestData : EventData
    {
        public int? OuputRequstId { get; set; }
    }
}
