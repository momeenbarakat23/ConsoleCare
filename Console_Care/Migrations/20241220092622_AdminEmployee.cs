using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class AdminEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminEmployee_Admins_adminsId",
                table: "AdminEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminEmployee_Employee_Employeesid",
                table: "AdminEmployee");

            migrationBuilder.RenameColumn(
                name: "adminsId",
                table: "AdminEmployee",
                newName: "adminId");

            migrationBuilder.RenameColumn(
                name: "Employeesid",
                table: "AdminEmployee",
                newName: "Employeeid");

            migrationBuilder.RenameIndex(
                name: "IX_AdminEmployee_adminsId",
                table: "AdminEmployee",
                newName: "IX_AdminEmployee_adminId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminEmployee_Admins_adminId",
                table: "AdminEmployee",
                column: "adminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminEmployee_Employee_Employeeid",
                table: "AdminEmployee",
                column: "Employeeid",
                principalTable: "Employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminEmployee_Admins_adminId",
                table: "AdminEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminEmployee_Employee_Employeeid",
                table: "AdminEmployee");

            migrationBuilder.RenameColumn(
                name: "adminId",
                table: "AdminEmployee",
                newName: "adminsId");

            migrationBuilder.RenameColumn(
                name: "Employeeid",
                table: "AdminEmployee",
                newName: "Employeesid");

            migrationBuilder.RenameIndex(
                name: "IX_AdminEmployee_adminId",
                table: "AdminEmployee",
                newName: "IX_AdminEmployee_adminsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminEmployee_Admins_adminsId",
                table: "AdminEmployee",
                column: "adminsId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminEmployee_Employee_Employeesid",
                table: "AdminEmployee",
                column: "Employeesid",
                principalTable: "Employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
