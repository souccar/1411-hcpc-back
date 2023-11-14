using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Souccar.Hcpc.Materials;
using Souccar.Hcpc.Units;

namespace Souccar.Hcpc.Products
{
    public class Formula : Entity<int>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public double Quantity { get; set; }

        #region Unit
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        #endregion

        #region Material
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        #endregion

        #region Product
        public int ProductId { get; set; }
        public Product Product { get; set; }
        #endregion
    }
}
