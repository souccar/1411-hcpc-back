using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using Souccar.Hcpc.Materials;
using System.Collections.Generic;

namespace Souccar.Hcpc.Suppliers
{
    public class Supplier : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IList<MaterialSuppliers> MaterialSuppliers { get; set; }
    }
}
