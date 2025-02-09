using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class edittabmat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "minQuantity",
                table: "materials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "price",
                table: "materials",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "minQuantity",
                table: "materials");

            migrationBuilder.DropColumn(
                name: "price",
                table: "materials");
        }
    }
}
