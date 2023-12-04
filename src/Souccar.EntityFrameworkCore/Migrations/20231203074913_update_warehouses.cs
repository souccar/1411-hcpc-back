using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class update_warehouses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseMaterials_InputRequestMaterials_InputRequestMaterialId",
                table: "WarehouseMaterials");

            migrationBuilder.DropIndex(
                name: "IX_WarehouseMaterials_InputRequestMaterialId",
                table: "WarehouseMaterials");

            migrationBuilder.DropColumn(
                name: "InputRequestMaterialId",
                table: "WarehouseMaterials");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "WarehouseMaterials",
                newName: "InitialQuantity");

            migrationBuilder.AddColumn<double>(
                name: "CurrentQuantity",
                table: "WarehouseMaterials",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EntryDate",
                table: "WarehouseMaterials",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OutputDate",
                table: "OutputRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentQuantity",
                table: "WarehouseMaterials");

            migrationBuilder.DropColumn(
                name: "EntryDate",
                table: "WarehouseMaterials");

            migrationBuilder.DropColumn(
                name: "OutputDate",
                table: "OutputRequests");

            migrationBuilder.RenameColumn(
                name: "InitialQuantity",
                table: "WarehouseMaterials",
                newName: "Quantity");

            migrationBuilder.AddColumn<int>(
                name: "InputRequestMaterialId",
                table: "WarehouseMaterials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseMaterials_InputRequestMaterialId",
                table: "WarehouseMaterials",
                column: "InputRequestMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseMaterials_InputRequestMaterials_InputRequestMaterialId",
                table: "WarehouseMaterials",
                column: "InputRequestMaterialId",
                principalTable: "InputRequestMaterials",
                principalColumn: "Id");
        }
    }
}
