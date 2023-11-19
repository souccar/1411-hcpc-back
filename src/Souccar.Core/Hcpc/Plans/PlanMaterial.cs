using Abp.Domain.Entities;
using Souccar.Hcpc.Materials;
using Souccar.Hcpc.Units;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Plans
{
    public class PlanMaterial : Entity<int>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public double Quantity { get; set; }
        public double InventoryQuantity { get; set; }

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

    }
}
