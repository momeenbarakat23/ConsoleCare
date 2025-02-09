using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class editsTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customermoderator");

            migrationBuilder.DropTable(
                name: "OrderByCustomer");

            migrationBuilder.DropTable(
                name: "moderator");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "followUp",
                newName: "stateOfFolowUp");

            migrationBuilder.RenameColumn(
                name: "MaintenanceImplementationDate",
                table: "followUp",
                newName: "Maintenance_Implementation_Date");

            migrationBuilder.AddColumn<int>(
                name: "IdOfEmployee",
                table: "followUp",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfCustomer",
                table: "followUp",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WarrantyTime",
                table: "followUp",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItineraryId",
                table: "customer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConvertToEmployee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfTechnician = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfAssistant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesToMaintenanceTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteDistributionOfficer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemainingTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sequence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvertiseDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "itineraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VisitClassification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultStatement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusOfOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itineraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nameofdataentry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOfCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeOfCall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interesting = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AdminCustomer",
                columns: table => new
                {
                    AdminsId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminCustomer", x => new { x.AdminsId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_AdminCustomer_Admins_AdminsId",
                        column: x => x.AdminsId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminCustomer_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminEmployee",
                columns: table => new
                {
                    Employeesid = table.Column<int>(type: "int", nullable: false),
                    adminsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminEmployee", x => new { x.Employeesid, x.adminsId });
                    table.ForeignKey(
                        name: "FK_AdminEmployee_Admins_adminsId",
                        column: x => x.adminsId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminEmployee_Employee_Employeesid",
                        column: x => x.Employeesid,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminItinerary",
                columns: table => new
                {
                    AdminsId = table.Column<int>(type: "int", nullable: false),
                    itinerariesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminItinerary", x => new { x.AdminsId, x.itinerariesId });
                    table.ForeignKey(
                        name: "FK_AdminItinerary_Admins_AdminsId",
                        column: x => x.AdminsId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminItinerary_itineraries_itinerariesId",
                        column: x => x.itinerariesId,
                        principalTable: "itineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeItinerary",
                columns: table => new
                {
                    Employeesid = table.Column<int>(type: "int", nullable: false),
                    itinerariesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeItinerary", x => new { x.Employeesid, x.itinerariesId });
                    table.ForeignKey(
                        name: "FK_EmployeeItinerary_Employee_Employeesid",
                        column: x => x.Employeesid,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeItinerary_itineraries_itinerariesId",
                        column: x => x.itinerariesId,
                        principalTable: "itineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_followUp_IdOfEmployee",
                table: "followUp",
                column: "IdOfEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_customer_ItineraryId",
                table: "customer",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminCustomer_CustomerId",
                table: "AdminCustomer",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminEmployee_adminsId",
                table: "AdminEmployee",
                column: "adminsId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminItinerary_itinerariesId",
                table: "AdminItinerary",
                column: "itinerariesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeItinerary_itinerariesId",
                table: "EmployeeItinerary",
                column: "itinerariesId");

            migrationBuilder.AddForeignKey(
                name: "FK_customer_itineraries_ItineraryId",
                table: "customer",
                column: "ItineraryId",
                principalTable: "itineraries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_followUp_Employee_IdOfEmployee",
                table: "followUp",
                column: "IdOfEmployee",
                principalTable: "Employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_itineraries_ItineraryId",
                table: "customer");

            migrationBuilder.DropForeignKey(
                name: "FK_followUp_Employee_IdOfEmployee",
                table: "followUp");

            migrationBuilder.DropTable(
                name: "AdminCustomer");

            migrationBuilder.DropTable(
                name: "AdminEmployee");

            migrationBuilder.DropTable(
                name: "AdminItinerary");

            migrationBuilder.DropTable(
                name: "EmployeeItinerary");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "itineraries");

            migrationBuilder.DropIndex(
                name: "IX_followUp_IdOfEmployee",
                table: "followUp");

            migrationBuilder.DropIndex(
                name: "IX_customer_ItineraryId",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "IdOfEmployee",
                table: "followUp");

            migrationBuilder.DropColumn(
                name: "TypeOfCustomer",
                table: "followUp");

            migrationBuilder.DropColumn(
                name: "WarrantyTime",
                table: "followUp");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ItineraryId",
                table: "customer");

            migrationBuilder.RenameColumn(
                name: "stateOfFolowUp",
                table: "followUp",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "Maintenance_Implementation_Date",
                table: "followUp",
                newName: "MaintenanceImplementationDate");

            migrationBuilder.CreateTable(
                name: "moderator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertiseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConvertToEmployee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultStatement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfAssistant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfDataEntry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfTechnician = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesToMaintenanceTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemainingTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteDistributionOfficer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sequence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusOfOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitClassification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VisitStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moderator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderByCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ps4OrPs5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderByCustomer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customermoderator",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    moderatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customermoderator", x => new { x.CustomerId, x.moderatorId });
                    table.ForeignKey(
                        name: "FK_Customermoderator_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customermoderator_moderator_moderatorId",
                        column: x => x.moderatorId,
                        principalTable: "moderator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customermoderator_moderatorId",
                table: "Customermoderator",
                column: "moderatorId");
        }
    }
}
