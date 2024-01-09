using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class modify_warehouse_material_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "WarehouseMaterials");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "WarehouseMaterials",
                newName: "PriceUSD");

            migrationBuilder.AddColumn<double>(
                name: "PriceSYP",
                table: "WarehouseMaterials",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceSYP",
                table: "WarehouseMaterials");

            migrationBuilder.RenameColumn(
                name: "PriceUSD",
                table: "WarehouseMaterials",
                newName: "Price");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "WarehouseMaterials",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
