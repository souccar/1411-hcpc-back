using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class class_diagram_edits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyProductions_Plans_PlanId",
                table: "DailyProductions");

            migrationBuilder.DropForeignKey(
                name: "FK_InputRequests_WarehouseMaterials_WarehouseMaterialId",
                table: "InputRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputRequestMaterials_Materials_MaterialId",
                table: "OutputRequestMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputRequests_WarehouseMaterials_WarehouseMaterialId",
                table: "OutputRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanProducts_Plans_PlanId",
                table: "PlanProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanProducts_Products_ProductId",
                table: "PlanProducts");

            migrationBuilder.DropIndex(
                name: "IX_InputRequests_WarehouseMaterialId",
                table: "InputRequests");

            migrationBuilder.DropColumn(
                name: "ExpectedProduce",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LeadTime",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "WarehouseMaterialId",
                table: "InputRequests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Formulas");

            migrationBuilder.RenameColumn(
                name: "WarehouseMaterialId",
                table: "OutputRequests",
                newName: "PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_OutputRequests_WarehouseMaterialId",
                table: "OutputRequests",
                newName: "IX_OutputRequests_PlanId");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "OutputRequestMaterials",
                newName: "WarehouseMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_OutputRequestMaterials_MaterialId",
                table: "OutputRequestMaterials",
                newName: "IX_OutputRequestMaterials_WarehouseMaterialId");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "WarehouseMaterials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "WarehouseMaterials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "InputRequestMaterialId",
                table: "WarehouseMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "WarehouseMaterials",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "WarehouseMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitPriceId",
                table: "WarehouseMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "WarehouseMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "PlanProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "PlanProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LeadTime",
                table: "MaterialSuppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "InputRequestMaterials",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpirationDate",
                table: "InputRequestMaterials",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "InputRequestMaterials",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "InputRequestMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "InputRequestMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "DailyProductions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "GeneralSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    ExpiryDurationNotify = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseKeeper = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseMaterials_InputRequestMaterialId",
                table: "WarehouseMaterials",
                column: "InputRequestMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseMaterials_SupplierId",
                table: "WarehouseMaterials",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseMaterials_UnitPriceId",
                table: "WarehouseMaterials",
                column: "UnitPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseMaterials_WarehouseId",
                table: "WarehouseMaterials",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_InputRequestMaterials_SupplierId",
                table: "InputRequestMaterials",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_InputRequestMaterials_WarehouseId",
                table: "InputRequestMaterials",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyProductions_Plans_PlanId",
                table: "DailyProductions",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputRequestMaterials_Suppliers_SupplierId",
                table: "InputRequestMaterials",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputRequestMaterials_Warehouses_WarehouseId",
                table: "InputRequestMaterials",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputRequestMaterials_WarehouseMaterials_WarehouseMaterialId",
                table: "OutputRequestMaterials",
                column: "WarehouseMaterialId",
                principalTable: "WarehouseMaterials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputRequests_Plans_PlanId",
                table: "OutputRequests",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanProducts_Plans_PlanId",
                table: "PlanProducts",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanProducts_Products_ProductId",
                table: "PlanProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseMaterials_InputRequestMaterials_InputRequestMaterialId",
                table: "WarehouseMaterials",
                column: "InputRequestMaterialId",
                principalTable: "InputRequestMaterials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseMaterials_Suppliers_SupplierId",
                table: "WarehouseMaterials",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseMaterials_Units_UnitPriceId",
                table: "WarehouseMaterials",
                column: "UnitPriceId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseMaterials_Warehouses_WarehouseId",
                table: "WarehouseMaterials",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyProductions_Plans_PlanId",
                table: "DailyProductions");

            migrationBuilder.DropForeignKey(
                name: "FK_InputRequestMaterials_Suppliers_SupplierId",
                table: "InputRequestMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_InputRequestMaterials_Warehouses_WarehouseId",
                table: "InputRequestMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputRequestMaterials_WarehouseMaterials_WarehouseMaterialId",
                table: "OutputRequestMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputRequests_Plans_PlanId",
                table: "OutputRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanProducts_Plans_PlanId",
                table: "PlanProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanProducts_Products_ProductId",
                table: "PlanProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseMaterials_InputRequestMaterials_InputRequestMaterialId",
                table: "WarehouseMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseMaterials_Suppliers_SupplierId",
                table: "WarehouseMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseMaterials_Units_UnitPriceId",
                table: "WarehouseMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseMaterials_Warehouses_WarehouseId",
                table: "WarehouseMaterials");

            migrationBuilder.DropTable(
                name: "GeneralSettings");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseMaterials_InputRequestMaterialId",
                table: "WarehouseMaterials");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseMaterials_SupplierId",
                table: "WarehouseMaterials");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseMaterials_UnitPriceId",
                table: "WarehouseMaterials");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseMaterials_WarehouseId",
                table: "WarehouseMaterials");

            migrationBuilder.DropIndex(
                name: "IX_InputRequestMaterials_SupplierId",
                table: "InputRequestMaterials");

            migrationBuilder.DropIndex(
                name: "IX_InputRequestMaterials_WarehouseId",
                table: "InputRequestMaterials");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "WarehouseMaterials");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "WarehouseMaterials");

            migrationBuilder.DropColumn(
                name: "InputRequestMaterialId",
                table: "WarehouseMaterials");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "WarehouseMaterials");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "WarehouseMaterials");

            migrationBuilder.DropColumn(
                name: "UnitPriceId",
                table: "WarehouseMaterials");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "WarehouseMaterials");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LeadTime",
                table: "MaterialSuppliers");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "InputRequestMaterials");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "InputRequestMaterials");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "InputRequestMaterials");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "InputRequestMaterials");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "InputRequestMaterials");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "OutputRequests",
                newName: "WarehouseMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_OutputRequests_PlanId",
                table: "OutputRequests",
                newName: "IX_OutputRequests_WarehouseMaterialId");

            migrationBuilder.RenameColumn(
                name: "WarehouseMaterialId",
                table: "OutputRequestMaterials",
                newName: "MaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_OutputRequestMaterials_WarehouseMaterialId",
                table: "OutputRequestMaterials",
                newName: "IX_OutputRequestMaterials_MaterialId");

            migrationBuilder.AddColumn<int>(
                name: "ExpectedProduce",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "PlanProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "PlanProducts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeadTime",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Materials",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseMaterialId",
                table: "InputRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Formulas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlanId",
                table: "DailyProductions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InputRequests_WarehouseMaterialId",
                table: "InputRequests",
                column: "WarehouseMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyProductions_Plans_PlanId",
                table: "DailyProductions",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputRequests_WarehouseMaterials_WarehouseMaterialId",
                table: "InputRequests",
                column: "WarehouseMaterialId",
                principalTable: "WarehouseMaterials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputRequestMaterials_Materials_MaterialId",
                table: "OutputRequestMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputRequests_WarehouseMaterials_WarehouseMaterialId",
                table: "OutputRequests",
                column: "WarehouseMaterialId",
                principalTable: "WarehouseMaterials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanProducts_Plans_PlanId",
                table: "PlanProducts",
                column: "PlanId",
                principalTable: "Plans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanProducts_Products_ProductId",
                table: "PlanProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
