using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace Souccar.Hcpc.Products
{
    public class Product : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual IList<Formula> Formula { get; set; }
    }
}
