using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class nameincash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfProcess",
                table: "Cash");

            migrationBuilder.AlterColumn<string>(
                name: "NoOfaccount",
                table: "Cash",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Nameofcust",
                table: "Cash",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nameofcust",
                table: "Cash");

            migrationBuilder.AlterColumn<string>(
                name: "NoOfaccount",
                table: "Cash",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoOfProcess",
                table: "Cash",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
