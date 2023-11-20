﻿using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Souccar.Authorization.Roles;
using Souccar.Authorization.Users;
using Souccar.MultiTenancy;
using Souccar.Hcpc.Materials;
using Souccar.Hcpc.Products;
using Souccar.Hcpc.Suppliers;
using Souccar.Hcpc.Units;
using Souccar.Hcpc.Warehouses;
using Souccar.Hcpc.Plans;

namespace Souccar.EntityFrameworkCore
{
    public class SouccarDbContext : AbpZeroDbContext<Tenant, Role, User, SouccarDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanProduct> PlanProducts { get; set; }
        public DbSet<PlanProductMaterial> PlanProductMaterials { get; set; }
        public DbSet<PlanMaterial> PlanMaterials { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Formula> Formulas { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<WarehouseMaterial> WarehouseMaterials { get; set; }
        public DbSet<InputRequest> InputRequests { get; set; }
        public DbSet<OutputRequest> OutputRequests { get; set; }
        public DbSet<InputRequestMaterial> InputRequestMaterials { get; set; }
        public DbSet<OutputRequestMaterial> OutputRequestMaterials { get; set; }

        public SouccarDbContext(DbContextOptions<SouccarDbContext> options)
            : base(options)
        {
        }
    }
}
