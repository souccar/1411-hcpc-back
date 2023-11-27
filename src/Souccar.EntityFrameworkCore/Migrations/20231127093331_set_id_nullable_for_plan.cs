using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class set_id_nullable_for_plan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanProducts_Plans_PlanId",
                table: "PlanProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanProducts_Products_ProductId",
                table: "PlanProducts");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanProducts_Plans_PlanId",
                table: "PlanProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanProducts_Products_ProductId",
                table: "PlanProducts");

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
