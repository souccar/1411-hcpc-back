using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Update_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Suppliers_SupplierId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_SupplierId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Materials");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Materials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_SupplierId",
                table: "Materials",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Suppliers_SupplierId",
                table: "Materials",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }
    }
}
