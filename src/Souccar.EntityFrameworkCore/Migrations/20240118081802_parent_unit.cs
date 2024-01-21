using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class parent_unit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentUnitId",
                table: "Units",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Units_ParentUnitId",
                table: "Units",
                column: "ParentUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Units_ParentUnitId",
                table: "Units",
                column: "ParentUnitId",
                principalTable: "Units",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Units_ParentUnitId",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Units_ParentUnitId",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "ParentUnitId",
                table: "Units");
        }
    }
}
