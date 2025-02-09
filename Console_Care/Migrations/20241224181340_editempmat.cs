using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class editempmat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeMaterials",
                table: "EmployeeMaterials");



            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "EmployeeMaterials",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeMaterials",
                table: "EmployeeMaterials",
                columns: new[] { "materialsId", "Employeesid", "id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeMaterials",
                table: "EmployeeMaterials");

            migrationBuilder.DropColumn(
                name: "id",
                table: "EmployeeMaterials");



            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeMaterials",
                table: "EmployeeMaterials",
                columns: new[] { "materialsId", "Employeesid" });
        }
    }
}
