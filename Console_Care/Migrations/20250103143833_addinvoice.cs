using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class addinvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Invoiceid",
                table: "customer",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(type: "int", nullable: false),
                    item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Discountwarranty = table.Column<int>(type: "int", nullable: true),
                    specialDiscount = table.Column<int>(type: "int", nullable: true),
                    Total_Amount = table.Column<int>(type: "int", nullable: false),
                    Total_Amountafterdisc = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDataBasesInvoice",
                columns: table => new
                {
                    CustomerDataBasesid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Invoicesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDataBasesInvoice", x => new { x.CustomerDataBasesid, x.Invoicesid });
                    table.ForeignKey(
                        name: "FK_CustomerDataBasesInvoice_CustomerDataBases_CustomerDataBasesid",
                        column: x => x.CustomerDataBasesid,
                        principalTable: "CustomerDataBases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerDataBasesInvoice_Invoices_Invoicesid",
                        column: x => x.Invoicesid,
                        principalTable: "Invoices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_customer_Invoiceid",
                table: "customer",
                column: "Invoiceid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDataBasesInvoice_Invoicesid",
                table: "CustomerDataBasesInvoice",
                column: "Invoicesid");

            migrationBuilder.AddForeignKey(
                name: "FK_customer_Invoices_Invoiceid",
                table: "customer",
                column: "Invoiceid",
                principalTable: "Invoices",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_Invoices_Invoiceid",
                table: "customer");

            migrationBuilder.DropTable(
                name: "CustomerDataBasesInvoice");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_customer_Invoiceid",
                table: "customer");

            migrationBuilder.DropColumn(
                name: "Invoiceid",
                table: "customer");
        }
    }
}
