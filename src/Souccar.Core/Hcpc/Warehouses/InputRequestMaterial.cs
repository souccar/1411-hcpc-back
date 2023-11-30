using Abp.Domain.Entities;
using Souccar.Hcpc.Materials;
using Souccar.Hcpc.Suppliers;
using Souccar.Hcpc.Units;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Warehouses
{
    public class InputRequestMaterial : Entity<int>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public double Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }

        #region Unit
        public int? UnitId { get; set; }

        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }
        #endregion

        #region Material
        public int? MaterialId { get; set; }

        [ForeignKey("MaterialId")]
        public virtual Material Material { get; set; }
        #endregion

        #region Supplier
        public int? SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier Supplier { get; set; }
        #endregion

        #region Warehouse
        public int? WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }
        #endregion
    }
}
