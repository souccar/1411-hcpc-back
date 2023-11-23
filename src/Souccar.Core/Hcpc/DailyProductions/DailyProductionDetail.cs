using Abp.Domain.Entities;
using Souccar.Hcpc.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.DailyProductions
{
    public class DailyProductionDetail : Entity<int>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public int Quantity { get; set; }

        #region DailyProduction
        [ForeignKey("DailyProductionId")]
        public virtual DailyProduction DailyProduction { get; set; }
        public int DailyProductionId { get; set; }
        #endregion

        #region Product
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        #endregion
    }
}
