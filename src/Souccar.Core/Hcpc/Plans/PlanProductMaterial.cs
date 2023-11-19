using Abp.Domain.Entities;
using Souccar.Hcpc.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Plans
{
    public class PlanProductMaterial : Entity<int>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        /// <summary>
        /// Quentity in product
        /// Product.Count * Formula.Material.Quentity
        /// </summary>
        public double Quantity { get; set; }

        #region Formula
        public int? FormulaId { get; set; }

        [ForeignKey("FormulaId")]
        public Formula Formula { get; set; }
        #endregion
    }
}
