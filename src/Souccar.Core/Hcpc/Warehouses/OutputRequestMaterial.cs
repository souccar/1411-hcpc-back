using Abp.Domain.Entities;
using Souccar.Hcpc.Materials;
using Souccar.Hcpc.Units;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Warehouses
{
    public class OutputRequestMaterial : Entity<int>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public double Quantity { get; set; }

        #region Unit
        public int? UnitId { get; set; }

        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }
        #endregion

        #region WarehouseMaterial
        public int? WarehouseMaterialId { get; set; }

        [ForeignKey("WarehouseMaterialId")]
        public virtual WarehouseMaterial WarehouseMaterial { get; set; }
        #endregion

        #region OutputRequest
        public int? OutputRequestId { get; set; }

        [ForeignKey("OutputRequestId")]
        public virtual OutputRequest OutputRequest { get; set; }
        #endregion
    }
}