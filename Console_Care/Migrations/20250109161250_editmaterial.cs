using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class editmaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "materials",
                newName: "priceForbuy");

            migrationBuilder.AddColumn<int>(
                name: "priceForHome",
                table: "materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priceForPs",
                table: "materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "number",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "priceForHome",
                table: "materials");

            migrationBuilder.DropColumn(
                name: "priceForPs",
                table: "materials");

            migrationBuilder.RenameColumn(
                name: "priceForbuy",
                table: "materials",
                newName: "price");

            migrationBuilder.AlterColumn<string>(
                name: "number",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
