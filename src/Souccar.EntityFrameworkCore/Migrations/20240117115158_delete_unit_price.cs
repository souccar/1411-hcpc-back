using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class delete_unit_price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseMaterials_Units_UnitPriceId",
                table: "WarehouseMaterials");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseMaterials_UnitPriceId",
                table: "WarehouseMaterials");

            migrationBuilder.DropColumn(
                name: "UnitPriceId",
                table: "WarehouseMaterials");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitPriceId",
                table: "WarehouseMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseMaterials_UnitPriceId",
                table: "WarehouseMaterials",
                column: "UnitPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseMaterials_Units_UnitPriceId",
                table: "WarehouseMaterials",
                column: "UnitPriceId",
                principalTable: "Units",
                principalColumn: "Id");
        }
    }
}
