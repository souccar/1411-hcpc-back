using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using Souccar.Hcpc.Suppliers;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Souccar.Hcpc.Materials
{
    public class Material : FullAuditedAggregateRoot<int>, IMayHaveTenant
    {
        public Material()
        {
            Suppliers = new List<Supplier>();
        }
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LeadTime { get; set; }
        public double Price { get; set; }

        public virtual IList<Supplier> Suppliers { get; set; }

    }
}
