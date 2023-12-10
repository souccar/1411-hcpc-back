using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Production_Life_Cycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OutputDate",
                table: "OutputRequests",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OutputRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OutputRequestId",
                table: "DailyProductions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OutputRequestProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    OutputRequestId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputRequestProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputRequestProduct_OutputRequests_OutputRequestId",
                        column: x => x.OutputRequestId,
                        principalTable: "OutputRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OutputRequestProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyProductions_OutputRequestId",
                table: "DailyProductions",
                column: "OutputRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputRequestProduct_OutputRequestId",
                table: "OutputRequestProduct",
                column: "OutputRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputRequestProduct_ProductId",
                table: "OutputRequestProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyProductions_OutputRequests_OutputRequestId",
                table: "DailyProductions",
                column: "OutputRequestId",
                principalTable: "OutputRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyProductions_OutputRequests_OutputRequestId",
                table: "DailyProductions");

            migrationBuilder.DropTable(
                name: "OutputRequestProduct");

            migrationBuilder.DropIndex(
                name: "IX_DailyProductions_OutputRequestId",
                table: "DailyProductions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OutputRequests");

            migrationBuilder.DropColumn(
                name: "OutputRequestId",
                table: "DailyProductions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OutputDate",
                table: "OutputRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
