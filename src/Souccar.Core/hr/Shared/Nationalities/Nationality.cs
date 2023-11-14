using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Souccar.hr.Shared.Nationalities
{
    public class Nationality : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string Name { get; set; }
    }
}
