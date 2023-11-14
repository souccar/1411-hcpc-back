using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Souccar.Hcpc.Plans
{
    public class Plan : FullAuditedAggregateRoot<int>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
    }
}
