using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Add_Formula_Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Units_FromId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Units_ToId",
                table: "Transfers");

            migrationBuilder.AlterColumn<int>(
                name: "ToId",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromId",
                table: "Transfers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Formulas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Units_FromId",
                table: "Transfers",
                column: "FromId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Units_ToId",
                table: "Transfers",
                column: "ToId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Units_FromId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Units_ToId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Formulas");

            migrationBuilder.AlterColumn<int>(
                name: "ToId",
                table: "Transfers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FromId",
                table: "Transfers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Units_FromId",
                table: "Transfers",
                column: "FromId",
                principalTable: "Units",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Units_ToId",
                table: "Transfers",
                column: "ToId",
                principalTable: "Units",
                principalColumn: "Id");
        }
    }
}
