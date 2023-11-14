using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Souccar.Hcpc.Units
{
    public class Unit : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string Name { get; set; }
        
    }
}
