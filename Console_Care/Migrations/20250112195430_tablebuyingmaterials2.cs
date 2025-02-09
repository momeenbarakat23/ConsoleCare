using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class tablebuyingmaterials2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoPiece",
                table: "BuyingMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceofPiece",
                table: "BuyingMaterials",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "BuyingMaterials",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoPiece",
                table: "BuyingMaterials");

            migrationBuilder.DropColumn(
                name: "PriceofPiece",
                table: "BuyingMaterials");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "BuyingMaterials");
        }
    }
}
