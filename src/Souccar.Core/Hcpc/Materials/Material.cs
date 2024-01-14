using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System.Collections.Generic;
using Souccar.Hcpc.Warehouses;

namespace Souccar.Hcpc.Materials
{
    public class Material : FullAuditedAggregateRoot<int>, IMayHaveTenant
    {
        public Material()
        {
            Suppliers = new List<MaterialSuppliers>();
        }
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        //public int LeadTime { get; set; }
        //public double Price { get; set; }

        public virtual IList<MaterialSuppliers> Suppliers { get; set; }
        public virtual IList<WarehouseMaterial> WarehouseMaterials { get; set; }

    }
}
