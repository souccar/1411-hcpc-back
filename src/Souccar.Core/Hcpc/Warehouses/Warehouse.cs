using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

namespace Souccar.Hcpc.Warehouses
{
    public class Warehouse : FullAuditedAggregateRoot, IMayHaveTenant
    {
        public Warehouse()
        {
            WarehouseMaterials= new List<WarehouseMaterial>();
        }
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string WarehouseKeeper { get; set; }
        public virtual IList<WarehouseMaterial> WarehouseMaterials { get; set; }
    }
}
