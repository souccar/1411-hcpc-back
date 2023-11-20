using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Add_Material_Supplier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Materials_MaterialId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_MaterialId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Suppliers");

            migrationBuilder.CreateTable(
                name: "MaterialSuppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialSuppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialSuppliers_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialSuppliers_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSuppliers_MaterialId",
                table: "MaterialSuppliers",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialSuppliers_SupplierId",
                table: "MaterialSuppliers",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialSuppliers");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_MaterialId",
                table: "Suppliers",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Materials_MaterialId",
                table: "Suppliers",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");
        }
    }
}
