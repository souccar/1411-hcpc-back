using Abp.Domain.Entities;
using Souccar.Hcpc.Materials;
using Souccar.Hcpc.Products;
using Souccar.Hcpc.Units;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Plans
{
    public class PlanProductMaterial : Entity<int>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        /// <summary>
        /// Required quantity for currenct product
        /// </summary>
        public double RequiredQuantity { get; set; } //Product.NumberOfItems * Formula.Material.Quentity

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

        #region Plan product
        public int? PlanProductId { get; set; }

        [ForeignKey("PlanProductId")]
        public PlanProduct PlanProduct { get; set; }
        #endregion
    }
}
