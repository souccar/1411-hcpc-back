using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Nullable_Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyProductionDetails_DailyProductions_DailyProductionId",
                table: "DailyProductionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyProductionDetails_Products_ProductId",
                table: "DailyProductionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSuppliers_Materials_MaterialId",
                table: "MaterialSuppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSuppliers_Suppliers_SupplierId",
                table: "MaterialSuppliers");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "MaterialSuppliers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "MaterialSuppliers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "DailyProductionDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DailyProductionId",
                table: "DailyProductionDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyProductionDetails_DailyProductions_DailyProductionId",
                table: "DailyProductionDetails",
                column: "DailyProductionId",
                principalTable: "DailyProductions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyProductionDetails_Products_ProductId",
                table: "DailyProductionDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSuppliers_Materials_MaterialId",
                table: "MaterialSuppliers",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSuppliers_Suppliers_SupplierId",
                table: "MaterialSuppliers",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyProductionDetails_DailyProductions_DailyProductionId",
                table: "DailyProductionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_DailyProductionDetails_Products_ProductId",
                table: "DailyProductionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSuppliers_Materials_MaterialId",
                table: "MaterialSuppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_MaterialSuppliers_Suppliers_SupplierId",
                table: "MaterialSuppliers");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "MaterialSuppliers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "MaterialSuppliers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "DailyProductionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DailyProductionId",
                table: "DailyProductionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyProductionDetails_DailyProductions_DailyProductionId",
                table: "DailyProductionDetails",
                column: "DailyProductionId",
                principalTable: "DailyProductions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyProductionDetails_Products_ProductId",
                table: "DailyProductionDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSuppliers_Materials_MaterialId",
                table: "MaterialSuppliers",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialSuppliers_Suppliers_SupplierId",
                table: "MaterialSuppliers",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
