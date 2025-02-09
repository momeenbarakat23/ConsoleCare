using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class countinvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "countinvoice",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "paid",
                table: "Employee",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "countinvoice",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "paid",
                table: "Employee");
        }
    }
}
