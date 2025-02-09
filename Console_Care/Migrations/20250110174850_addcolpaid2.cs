using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class addcolpaid2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paid",
                table: "CustomerDataBasessInvoice");

            migrationBuilder.DropColumn(
                name: "remaining",
                table: "CustomerDataBasessInvoice");

            migrationBuilder.AddColumn<decimal>(
                name: "Paid",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "remaining",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "remaining",
                table: "Invoices");

            migrationBuilder.AddColumn<decimal>(
                name: "Paid",
                table: "CustomerDataBasessInvoice",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "remaining",
                table: "CustomerDataBasessInvoice",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
