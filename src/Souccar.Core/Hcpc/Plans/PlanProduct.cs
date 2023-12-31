﻿using Abp.Domain.Entities;
using Souccar.Hcpc.Products;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Souccar.Hcpc.Plans
{
    public class PlanProduct: Entity<int>, IMayHaveTenant
    {
        public PlanProduct()
        {
            PlanProductMaterials = new List<PlanProductMaterial>();
        }
        public int? TenantId { get; set; }
        public int NumberOfItems { get; set; }
        public PriorityInPlan Priority { get; set; }

        public virtual IList<PlanProductMaterial> PlanProductMaterials { get; set; }

        #region Product
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        #endregion

        #region Plan
        public int? PlanId { get; set; }

        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }
        #endregion
    }
}
