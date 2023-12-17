using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class add_fullAudited_to_note : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "DailyProductionNotes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "DailyProductionNotes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "DailyProductionNotes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "DailyProductionNotes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DailyProductionNotes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "DailyProductionNotes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "DailyProductionNotes",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "DailyProductionNotes");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "DailyProductionNotes");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "DailyProductionNotes");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "DailyProductionNotes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DailyProductionNotes");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "DailyProductionNotes");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "DailyProductionNotes");
        }
    }
}
