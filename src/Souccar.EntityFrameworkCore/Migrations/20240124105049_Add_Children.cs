using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Souccar.Migrations
{
    /// <inheritdoc />
    public partial class Add_Children : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Child_Employees_EmployeeId",
                table: "Child");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Child",
                table: "Child");

            migrationBuilder.RenameTable(
                name: "Child",
                newName: "Children");

            migrationBuilder.RenameIndex(
                name: "IX_Child_EmployeeId",
                table: "Children",
                newName: "IX_Children_EmployeeId");

          

            migrationBuilder.AddPrimaryKey(
                name: "PK_Children",
                table: "Children",
                column: "Id");

           
            migrationBuilder.AddForeignKey(
                name: "FK_Children_Employees_EmployeeId",
                table: "Children",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Children_Employees_EmployeeId",
                table: "Children");

          
         
            migrationBuilder.DropPrimaryKey(
                name: "PK_Children",
                table: "Children");

          

            migrationBuilder.RenameTable(
                name: "Children",
                newName: "Child");

            migrationBuilder.RenameIndex(
                name: "IX_Children_EmployeeId",
                table: "Child",
                newName: "IX_Child_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Child",
                table: "Child",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Child_Employees_EmployeeId",
                table: "Child",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
