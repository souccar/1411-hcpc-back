using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Add_Plan_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    TotalItems = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    TotalQuantity = table.Column<double>(type: "float", nullable: false),
                    InventoryQuantity = table.Column<double>(type: "float", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    PlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanMaterials_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanMaterials_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlanProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    NumberOfItems = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanProducts_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanProductMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    RequiredQuantity = table.Column<double>(type: "float", nullable: false),
                    UnitId = table.Column<int>(type: "int", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    PlanProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanProductMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanProductMaterials_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanProductMaterials_PlanProducts_PlanProductId",
                        column: x => x.PlanProductId,
                        principalTable: "PlanProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanProductMaterials_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanMaterials_MaterialId",
                table: "PlanMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMaterials_PlanId",
                table: "PlanMaterials",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanMaterials_UnitId",
                table: "PlanMaterials",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanProductMaterials_MaterialId",
                table: "PlanProductMaterials",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanProductMaterials_PlanProductId",
                table: "PlanProductMaterials",
                column: "PlanProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanProductMaterials_UnitId",
                table: "PlanProductMaterials",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanProducts_PlanId",
                table: "PlanProducts",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanProducts_ProductId",
                table: "PlanProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanMaterials");

            migrationBuilder.DropTable(
                name: "PlanProductMaterials");

            migrationBuilder.DropTable(
                name: "PlanProducts");

            migrationBuilder.DropTable(
                name: "Plans");
        }
    }
}
