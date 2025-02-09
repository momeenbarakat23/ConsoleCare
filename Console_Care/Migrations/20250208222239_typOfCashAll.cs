using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class typOfCashAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "typeofcash",
                table: "StaticAssets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "typeofcash",
                table: "static_expenses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "typeofcash",
                table: "Purchase_Payments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "typeofcash",
                table: "Other_expenses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "typeofcash",
                table: "BuyingMaterials",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "typeofcash",
                table: "StaticAssets");

            migrationBuilder.DropColumn(
                name: "typeofcash",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "typeofcash",
                table: "Purchase_Payments");

            migrationBuilder.DropColumn(
                name: "typeofcash",
                table: "Other_expenses");

            migrationBuilder.AlterColumn<string>(
                name: "typeofcash",
                table: "BuyingMaterials",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
