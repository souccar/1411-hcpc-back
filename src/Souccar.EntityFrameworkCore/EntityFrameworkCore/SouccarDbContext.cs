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
using Souccar.Hcpc.DailyProductions;
using Souccar.Hcpc.GeneralSettings;
using Souccar.hr.Personnel.Employees;
using Souccar.hr.Shared.Nationalities;
using Souccar.Workflows;
using Souccar.Hcpc.Categories;

namespace Souccar.EntityFrameworkCore
{
    public class SouccarDbContext : AbpZeroDbContext<Tenant, Role, User, SouccarDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanProduct> PlanProducts { get; set; }
        public DbSet<PlanProductMaterial> PlanProductMaterials { get; set; }
        public DbSet<PlanMaterial> PlanMaterials { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<FormulaItem> Formulas { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<WarehouseMaterial> WarehouseMaterials { get; set; }
        public DbSet<OutputRequest> OutputRequests { get; set; }
        public DbSet<OutputRequestMaterial> OutputRequestMaterials { get; set; }
        public DbSet<MaterialSuppliers> MaterialSuppliers { get; set; }
        public DbSet<DailyProduction> DailyProductions { get; set; }
        public DbSet<DailyProductionDetail> DailyProductionDetails { get; set; }
        public DbSet<GeneralSetting> GeneralSettings { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<DailyProductionNote> DailyProductionNotes { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<WorkflowStep> WorkflowSteps { get; set; }
        public DbSet<WorkflowStepAction> WorkflowStepActions { get; set; }
        public DbSet<WorkflowStepGroup> WorkflowStepGroups { get; set; }
        public DbSet<WorkflowStepIndex> WorkflowIndexes { get; set; }

        public SouccarDbContext(DbContextOptions<SouccarDbContext> options)
            : base(options)
        {
        }
    }
}
