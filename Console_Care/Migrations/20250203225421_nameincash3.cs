using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class nameincash3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nameoftech",
                table: "Cash",
                type: "nvarchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoOfInvoice",
                table: "Cash",
                type: "nvarchar(300)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nameoftech",
                table: "Cash");

            migrationBuilder.DropColumn(
                name: "NoOfInvoice",
                table: "Cash");
        }
    }
}
