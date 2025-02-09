using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class removecol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_EmployeeMaterials_EmployeeMaterialsid",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_EmployeeMaterialsid",
                table: "Invoices");


            migrationBuilder.DropColumn(
                name: "EmployeeMaterialsid",
                table: "Invoices");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeMaterialsEmployeesid",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeMaterialsid",
                table: "Invoices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeMaterialsmaterialsId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_EmployeeMaterialsid",
                table: "Invoices",
                column: "EmployeeMaterialsid");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_EmployeeMaterials_EmployeeMaterialsid",
                table: "Invoices",
                column: "EmployeeMaterialsid",
                principalTable: "EmployeeMaterials",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
