using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Souccar.Hcpc.GeneralSettings
{
    public class GeneralSetting : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public int ExpiryDurationNotify { get; set; }
    }
}
