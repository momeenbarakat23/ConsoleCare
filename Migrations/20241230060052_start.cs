using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesToMaintenanceTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RouteDistributionOfficer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "itineraries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nameoftech = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfAssistant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemainingTeam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitClassification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultStatement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusOfOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itineraries", x => x.Id);
                });

           

            migrationBuilder.CreateTable(
                name: "materials",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminEmployee",
                columns: table => new
                {
                    Employeeid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    adminId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminEmployee", x => new { x.Employeeid, x.adminId });
                    table.ForeignKey(
                        name: "FK_AdminEmployee_Admins_adminId",
                        column: x => x.adminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminEmployee_Employee_Employeeid",
                        column: x => x.Employeeid,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminItinerary",
                columns: table => new
                {
                    itinerarieId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItineraryId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminItinerary", x => new { x.itinerarieId, x.AdminId });
                    table.ForeignKey(
                        name: "FK_AdminItinerary_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminItinerary_itineraries_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "itineraries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfCustomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ps4OrPs5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateOfOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItineraryId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_customer_itineraries_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "itineraries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeItinerary",
                columns: table => new
                {
                    ItineraryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Employeeid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeItinerary", x => new { x.ItineraryId, x.Employeeid });
                    table.ForeignKey(
                        name: "FK_EmployeeItinerary_Employee_Employeeid",
                        column: x => x.Employeeid,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeItinerary_itineraries_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "itineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMaterials",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Employeesid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    materialsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuantityUsed = table.Column<int>(type: "int", nullable: true),
                    Quantities = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMaterials", x => new { x.materialsId, x.Employeesid, x.id });
                    table.ForeignKey(
                        name: "FK_EmployeeMaterials_Employee_Employeesid",
                        column: x => x.Employeesid,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeMaterials_materials_materialsId",
                        column: x => x.materialsId,
                        principalTable: "materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdminCustomers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminCustomers", x => new { x.CustomerId, x.AdminId });
                    table.ForeignKey(
                        name: "FK_AdminCustomers_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdminCustomers_customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "followUp",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FaultStatement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maintenance_Implementation_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextFollowUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastFollowUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SuggestionsAndIssues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stateOfFolowUp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarrantyTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdOfCustomer = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdOfEmployee = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_followUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_followUp_Employee_IdOfEmployee",
                        column: x => x.IdOfEmployee,
                        principalTable: "Employee",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_followUp_customer_IdOfCustomer",
                        column: x => x.IdOfCustomer,
                        principalTable: "customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminCustomers_AdminId",
                table: "AdminCustomers",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminEmployee_adminId",
                table: "AdminEmployee",
                column: "adminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminItinerary_AdminId",
                table: "AdminItinerary",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AdminItinerary_ItineraryId",
                table: "AdminItinerary",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_customer_ItineraryId",
                table: "customer",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeItinerary_Employeeid",
                table: "EmployeeItinerary",
                column: "Employeeid");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMaterials_Employeesid",
                table: "EmployeeMaterials",
                column: "Employeesid");

            migrationBuilder.CreateIndex(
                name: "IX_followUp_IdOfCustomer",
                table: "followUp",
                column: "IdOfCustomer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_followUp_IdOfEmployee",
                table: "followUp",
                column: "IdOfEmployee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminCustomers");

            migrationBuilder.DropTable(
                name: "AdminEmployee");

            migrationBuilder.DropTable(
                name: "AdminItinerary");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EmployeeItinerary");

            migrationBuilder.DropTable(
                name: "EmployeeMaterials");

            migrationBuilder.DropTable(
                name: "followUp");

            migrationBuilder.DropTable(
                name: "ItineraryViewModel");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "materials");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "itineraries");
        }
    }
}
