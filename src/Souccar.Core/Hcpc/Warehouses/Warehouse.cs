using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Souccar.Authorization.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        #region WarehouseKeeper
        public long? WarehouseKeeperId { get; set; }

        [ForeignKey("WarehouseKeeperId")]
        public virtual User WarehouseKeeper { get; set; }
        #endregion

        public virtual IList<WarehouseMaterial> WarehouseMaterials { get; set; }
    }
}
