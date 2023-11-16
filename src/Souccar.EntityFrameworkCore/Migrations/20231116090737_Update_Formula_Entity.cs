using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Update_Formula_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formulas_Materials_MaterialId",
                table: "Formulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Formulas_Products_ProductId",
                table: "Formulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Formulas_Units_UnitId",
                table: "Formulas");

            migrationBuilder.DropForeignKey(
                name: "FK_InputRequestMaterials_Materials_MaterialId",
                table: "InputRequestMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_InputRequestMaterials_Units_UnitId",
                table: "InputRequestMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Suppliers_SupplierId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputRequestMaterials_Materials_MaterialId",
                table: "OutputRequestMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputRequestMaterials_Units_UnitId",
                table: "OutputRequestMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseMaterials_Materials_MaterialId",
                table: "WarehouseMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseMaterials_Units_UnitId",
                table: "WarehouseMaterials");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "WarehouseMaterials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "WarehouseMaterials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WarehouseMaterialId",
                table: "OutputRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "OutputRequestMaterials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "OutputRequestMaterials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Materials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WarehouseMaterialId",
                table: "InputRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "InputRequestMaterials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "InputRequestMaterials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Formulas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Formulas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "Formulas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Formulas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OutputRequests_WarehouseMaterialId",
                table: "OutputRequests",
                column: "WarehouseMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InputRequests_WarehouseMaterialId",
                table: "InputRequests",
                column: "WarehouseMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Formulas_Materials_MaterialId",
                table: "Formulas",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Formulas_Products_ProductId",
                table: "Formulas",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Formulas_Units_UnitId",
                table: "Formulas",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputRequestMaterials_Materials_MaterialId",
                table: "InputRequestMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputRequestMaterials_Units_UnitId",
                table: "InputRequestMaterials",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InputRequests_WarehouseMaterials_WarehouseMaterialId",
                table: "InputRequests",
                column: "WarehouseMaterialId",
                principalTable: "WarehouseMaterials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Suppliers_SupplierId",
                table: "Materials",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputRequestMaterials_Materials_MaterialId",
                table: "OutputRequestMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputRequestMaterials_Units_UnitId",
                table: "OutputRequestMaterials",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OutputRequests_WarehouseMaterials_WarehouseMaterialId",
                table: "OutputRequests",
                column: "WarehouseMaterialId",
                principalTable: "WarehouseMaterials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseMaterials_Materials_MaterialId",
                table: "WarehouseMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseMaterials_Units_UnitId",
                table: "WarehouseMaterials",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Formulas_Materials_MaterialId",
                table: "Formulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Formulas_Products_ProductId",
                table: "Formulas");

            migrationBuilder.DropForeignKey(
                name: "FK_Formulas_Units_UnitId",
                table: "Formulas");

            migrationBuilder.DropForeignKey(
                name: "FK_InputRequestMaterials_Materials_MaterialId",
                table: "InputRequestMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_InputRequestMaterials_Units_UnitId",
                table: "InputRequestMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_InputRequests_WarehouseMaterials_WarehouseMaterialId",
                table: "InputRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Suppliers_SupplierId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputRequestMaterials_Materials_MaterialId",
                table: "OutputRequestMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputRequestMaterials_Units_UnitId",
                table: "OutputRequestMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputRequests_WarehouseMaterials_WarehouseMaterialId",
                table: "OutputRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseMaterials_Materials_MaterialId",
                table: "WarehouseMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseMaterials_Units_UnitId",
                table: "WarehouseMaterials");

            migrationBuilder.DropIndex(
                name: "IX_OutputRequests_WarehouseMaterialId",
                table: "OutputRequests");

            migrationBuilder.DropIndex(
                name: "IX_InputRequests_WarehouseMaterialId",
                table: "InputRequests");

            migrationBuilder.DropColumn(
                name: "WarehouseMaterialId",
                table: "OutputRequests");

            migrationBuilder.DropColumn(
                name: "WarehouseMaterialId",
                table: "InputRequests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Formulas");

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "WarehouseMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "WarehouseMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "OutputRequestMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "OutputRequestMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "Materials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "InputRequestMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "InputRequestMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UnitId",
                table: "Formulas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Formulas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "Formulas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Formulas_Materials_MaterialId",
                table: "Formulas",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Formulas_Products_ProductId",
                table: "Formulas",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Formulas_Units_UnitId",
                table: "Formulas",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputRequestMaterials_Materials_MaterialId",
                table: "InputRequestMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputRequestMaterials_Units_UnitId",
                table: "InputRequestMaterials",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Suppliers_SupplierId",
                table: "Materials",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputRequestMaterials_Materials_MaterialId",
                table: "OutputRequestMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputRequestMaterials_Units_UnitId",
                table: "OutputRequestMaterials",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseMaterials_Materials_MaterialId",
                table: "WarehouseMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseMaterials_Units_UnitId",
                table: "WarehouseMaterials",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
