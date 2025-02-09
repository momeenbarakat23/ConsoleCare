using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ps4OrPs5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateOfOrder = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "moderator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfDataEntry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VisitClassification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConvertToEmployee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfTechnician = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfAssistant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesToMaintenanceTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteDistributionOfficer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemainingTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sequence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdvertiseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultStatement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusOfOrder = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_moderator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "followUp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaultStatement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaintenanceImplementationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextFollowUpDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastFollowUpDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SuggestionsAndIssues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdOfCustomer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_followUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_followUp_customer_IdOfCustomer",
                        column: x => x.IdOfCustomer,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_followUp_IdOfCustomer",
                table: "followUp",
                column: "IdOfCustomer",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customermoderator");

            migrationBuilder.DropTable(
                name: "followUp");

            migrationBuilder.DropTable(
                name: "materials");

            migrationBuilder.DropTable(
                name: "moderator");

            migrationBuilder.DropTable(
                name: "customer");
        }
    }
}
