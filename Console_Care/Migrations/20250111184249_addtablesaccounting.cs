using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class addtablesaccounting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cash",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    paid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Outgoing = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfProcess = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Statement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cash", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Other_expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DisbursementName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Other_expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Invoicenumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "static_expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Installments = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Target = table.Column<int>(type: "int", nullable: false),
                    Management = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOfMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DevelopmentManagement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    marketing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OperationSection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_static_expenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaticAssets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Statement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticAssets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cash");

            migrationBuilder.DropTable(
                name: "Other_expenses");

            migrationBuilder.DropTable(
                name: "Purchase_Payments");

            migrationBuilder.DropTable(
                name: "static_expenses");

            migrationBuilder.DropTable(
                name: "StaticAssets");
        }
    }
}
