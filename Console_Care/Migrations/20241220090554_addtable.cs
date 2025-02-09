using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class addtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "ConvertToEmployee",
                table: "Admins");

            migrationBuilder.CreateTable(
                name: "AdminCustomers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_AdminCustomers_AdminId",
                table: "AdminCustomers",
                column: "AdminId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminCustomers");

            migrationBuilder.AddColumn<string>(
                name: "ConvertToEmployee",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

           

         
        }
    }
}
