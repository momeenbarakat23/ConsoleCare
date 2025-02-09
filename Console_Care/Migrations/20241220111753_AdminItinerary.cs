using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class AdminItinerary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminItinerary_Admins_AdminsId",
                table: "AdminItinerary");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminItinerary_itineraries_itinerariesId",
                table: "AdminItinerary");

            migrationBuilder.DropForeignKey(
                name: "FK_customer_itineraries_ItineraryId",
                table: "customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminItinerary",
                table: "AdminItinerary");

            migrationBuilder.RenameColumn(
                name: "itinerariesId",
                table: "AdminItinerary",
                newName: "ItineraryId");

            migrationBuilder.RenameColumn(
                name: "AdminsId",
                table: "AdminItinerary",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminItinerary_itinerariesId",
                table: "AdminItinerary",
                newName: "IX_AdminItinerary_ItineraryId");

            migrationBuilder.AlterColumn<int>(
                name: "ItineraryId",
                table: "customer",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "itinerarieId",
                table: "AdminItinerary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminItinerary",
                table: "AdminItinerary",
                columns: new[] { "itinerarieId", "AdminId" });

            migrationBuilder.CreateIndex(
                name: "IX_AdminItinerary_AdminId",
                table: "AdminItinerary",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminItinerary_Admins_AdminId",
                table: "AdminItinerary",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminItinerary_itineraries_ItineraryId",
                table: "AdminItinerary",
                column: "ItineraryId",
                principalTable: "itineraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customer_itineraries_ItineraryId",
                table: "customer",
                column: "ItineraryId",
                principalTable: "itineraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminItinerary_Admins_AdminId",
                table: "AdminItinerary");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminItinerary_itineraries_ItineraryId",
                table: "AdminItinerary");

            migrationBuilder.DropForeignKey(
                name: "FK_customer_itineraries_ItineraryId",
                table: "customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminItinerary",
                table: "AdminItinerary");

            migrationBuilder.DropIndex(
                name: "IX_AdminItinerary_AdminId",
                table: "AdminItinerary");

            migrationBuilder.DropColumn(
                name: "itinerarieId",
                table: "AdminItinerary");

            migrationBuilder.RenameColumn(
                name: "ItineraryId",
                table: "AdminItinerary",
                newName: "itinerariesId");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "AdminItinerary",
                newName: "AdminsId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminItinerary_ItineraryId",
                table: "AdminItinerary",
                newName: "IX_AdminItinerary_itinerariesId");

            migrationBuilder.AlterColumn<int>(
                name: "ItineraryId",
                table: "customer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminItinerary",
                table: "AdminItinerary",
                columns: new[] { "AdminsId", "itinerariesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AdminItinerary_Admins_AdminsId",
                table: "AdminItinerary",
                column: "AdminsId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminItinerary_itineraries_itinerariesId",
                table: "AdminItinerary",
                column: "itinerariesId",
                principalTable: "itineraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customer_itineraries_ItineraryId",
                table: "customer",
                column: "ItineraryId",
                principalTable: "itineraries",
                principalColumn: "Id");
        }
    }
}
