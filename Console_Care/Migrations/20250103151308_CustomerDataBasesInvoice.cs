using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class CustomerDataBasesInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_Invoices_Invoiceid",
                table: "customer");

            migrationBuilder.DropIndex(
                name: "IX_customer_Invoiceid",
                table: "customer");

            migrationBuilder.AlterColumn<int>(
                name: "Invoiceid",
                table: "customer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_customer_Invoiceid",
                table: "customer",
                column: "Invoiceid",
                unique: true,
                filter: "[Invoiceid] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_customer_Invoices_Invoiceid",
                table: "customer",
                column: "Invoiceid",
                principalTable: "Invoices",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_Invoices_Invoiceid",
                table: "customer");

            migrationBuilder.DropIndex(
                name: "IX_customer_Invoiceid",
                table: "customer");

            migrationBuilder.AlterColumn<int>(
                name: "Invoiceid",
                table: "customer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_Invoiceid",
                table: "customer",
                column: "Invoiceid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_customer_Invoices_Invoiceid",
                table: "customer",
                column: "Invoiceid",
                principalTable: "Invoices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
