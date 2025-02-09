using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class invandemprel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeMaterials",
                table: "EmployeeMaterials");


            migrationBuilder.AddColumn<string>(
                name: "EmployeeMaterialsid",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");


            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeMaterials",
                table: "EmployeeMaterials",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_EmployeeMaterialsid",
                table: "Invoices",
                column: "EmployeeMaterialsid");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMaterials_materialsId",
                table: "EmployeeMaterials",
                column: "materialsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_EmployeeMaterials_EmployeeMaterialsid",
                table: "Invoices",
                column: "EmployeeMaterialsid",
                principalTable: "EmployeeMaterials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_EmployeeMaterials_EmployeeMaterialsid",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_EmployeeMaterialsid",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeMaterials",
                table: "EmployeeMaterials");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeMaterials_materialsId",
                table: "EmployeeMaterials");

            migrationBuilder.DropColumn(
                name: "EmployeeMaterialsid",
                table: "Invoices");


            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeMaterials",
                table: "EmployeeMaterials",
                columns: new[] { "materialsId", "Employeesid", "id" });
        }
    }
}
