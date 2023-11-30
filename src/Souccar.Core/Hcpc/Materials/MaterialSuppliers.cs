using Abp.Domain.Entities;
using Souccar.Hcpc.Suppliers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Materials
{
    public class MaterialSuppliers : Entity<int>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        #region Material
        [ForeignKey("MaterialId")]
        public virtual Material Material { get; set; }
        public int? MaterialId { get; set; }
        #endregion

        #region Supplier
        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        public int? SupplierId { get; set; }
        #endregion

        public int LeadTime { get; set; }
    }
}
