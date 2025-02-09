using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeItinerary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeItinerary_Employee_Employeesid",
                table: "EmployeeItinerary");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeItinerary_itineraries_itinerariesId",
                table: "EmployeeItinerary");

            migrationBuilder.RenameColumn(
                name: "itinerariesId",
                table: "EmployeeItinerary",
                newName: "Employeeid");

            migrationBuilder.RenameColumn(
                name: "Employeesid",
                table: "EmployeeItinerary",
                newName: "ItineraryId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeItinerary_itinerariesId",
                table: "EmployeeItinerary",
                newName: "IX_EmployeeItinerary_Employeeid");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeItinerary_Employee_Employeeid",
                table: "EmployeeItinerary",
                column: "Employeeid",
                principalTable: "Employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeItinerary_itineraries_ItineraryId",
                table: "EmployeeItinerary",
                column: "ItineraryId",
                principalTable: "itineraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeItinerary_Employee_Employeeid",
                table: "EmployeeItinerary");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeItinerary_itineraries_ItineraryId",
                table: "EmployeeItinerary");

            migrationBuilder.RenameColumn(
                name: "Employeeid",
                table: "EmployeeItinerary",
                newName: "itinerariesId");

            migrationBuilder.RenameColumn(
                name: "ItineraryId",
                table: "EmployeeItinerary",
                newName: "Employeesid");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeItinerary_Employeeid",
                table: "EmployeeItinerary",
                newName: "IX_EmployeeItinerary_itinerariesId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeItinerary_Employee_Employeesid",
                table: "EmployeeItinerary",
                column: "Employeesid",
                principalTable: "Employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeItinerary_itineraries_itinerariesId",
                table: "EmployeeItinerary",
                column: "itinerariesId",
                principalTable: "itineraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
