using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using Souccar.Hcpc.Suppliers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Materials
{
    public class Material : FullAuditedAggregateRoot<int>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LeadTime { get; set; }
        public double Price { get; set; }

        #region Supplier
        public int SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
        #endregion

    }
}
