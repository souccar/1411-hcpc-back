using Abp.Domain.Entities;
using Souccar.Hcpc.Products;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Warehouses
{
    public class OutputRequestProduct : Entity<int>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        #region OutputRequest
        public int? OutputRequestId { get; set; }

        [ForeignKey("OutputRequestId")]
        public virtual OutputRequest OutputRequest { get; set; }
        #endregion

        #region Product
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        #endregion
    }
}
