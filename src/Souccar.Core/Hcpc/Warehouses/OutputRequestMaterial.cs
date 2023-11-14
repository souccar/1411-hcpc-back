﻿using Abp.Domain.Entities;
using Souccar.Hcpc.Materials;
using Souccar.Hcpc.Units;

namespace Souccar.Hcpc.Warehouses
{
    public class OutputRequestMaterial : Entity<int>, IMayHaveTenant
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
    }
}