using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class editstaticexp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "discount",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "incentive",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "navsalary",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "predecessor",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "Quantityinstorage",
                table: "materials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "discount",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "incentive",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "navsalary",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "predecessor",
                table: "static_expenses");

            migrationBuilder.AlterColumn<int>(
                name: "Quantityinstorage",
                table: "materials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
