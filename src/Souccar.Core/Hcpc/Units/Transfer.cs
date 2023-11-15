using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Souccar.Hcpc.Units
{
    public class Transfer : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public int FromId { get; set; }
        public Unit From { get; set; }
        public int ToId { get; set; }
        public Unit To { get; set; }
        public double Value { get; set; }

    }
}
