﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Souccar.Hcpc.Materials;
using Souccar.Hcpc.Suppliers;
using Souccar.Hcpc.Units;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Warehouses
{
    public class WarehouseMaterial : FullAuditedAggregateRoot, IMayHaveTenant
    {

        public WarehouseMaterial()
        {
            OutputRequestMaterilas = new List<OutputRequestMaterial>();
        }
        public int? TenantId { get; set; }
        public DateTime? EntryDate { get; set; }
        public double InitialQuantity { get; set; }
        public double CurrentQuantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Code { get; set; }
        public double Price { get; set; }

        #region Unit
        public int? UnitId { get; set; }

        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }
        #endregion

        #region UnitPrice
        public int? UnitPriceId { get; set; }

        [ForeignKey("UnitPriceId")]
        public virtual Unit UnitPrice { get; set; }
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

        public virtual IList<OutputRequestMaterial> OutputRequestMaterilas { get; set; }

    }
}
