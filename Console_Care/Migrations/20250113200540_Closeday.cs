using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class Closeday : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Closeday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Origins = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cash = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sales = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaidSales = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remainingsales = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Procurement = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaidPurchases = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Remainingpurchases = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Expenses = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Closeday", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Closeday");
        }
    }
}
