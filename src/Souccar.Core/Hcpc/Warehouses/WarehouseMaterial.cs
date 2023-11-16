using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Souccar.Hcpc.Materials;
using Souccar.Hcpc.Products;
using Souccar.Hcpc.Units;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Warehouses
{
    public class WarehouseMaterial : FullAuditedAggregateRoot, IMayHaveTenant
    {

        public WarehouseMaterial()
        {
            InputRequests = new List<InputRequest>();
            OutputRequests= new List<OutputRequest>();
        }
        public int? TenantId { get; set; }
        public double Quantity { get; set; }

        #region Unit
        public int? UnitId { get; set; }

        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }
        #endregion

        #region Material
        public int? MaterialId { get; set; }

        [ForeignKey("MaterialId")]
        public Material Material { get; set; }
        #endregion


        public virtual IList<InputRequest> InputRequests { get; set; }

        public virtual IList<OutputRequest> OutputRequests { get; set; }

    }
}
