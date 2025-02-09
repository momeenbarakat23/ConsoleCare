using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeMaterials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeMaterials",
                table: "EmployeeMaterials");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeMaterials_materialsId",
                table: "EmployeeMaterials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeMaterials",
                table: "EmployeeMaterials",
                columns: new[] { "materialsId", "Employeesid" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMaterials_Employeesid",
                table: "EmployeeMaterials",
                column: "Employeesid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeMaterials",
                table: "EmployeeMaterials");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeMaterials_Employeesid",
                table: "EmployeeMaterials");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeMaterials",
                table: "EmployeeMaterials",
                columns: new[] { "Employeesid", "materialsId" });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMaterials_materialsId",
                table: "EmployeeMaterials",
                column: "materialsId");
        }
    }
}
