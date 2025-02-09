using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerDataBasesInvoice_CustomerDataBases_CustomerDataBasesid",
                table: "CustomerDataBasesInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerDataBasesInvoice_Invoices_Invoicesid",
                table: "CustomerDataBasesInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerDataBasesInvoice",
                table: "CustomerDataBasesInvoice");

            migrationBuilder.RenameTable(
                name: "CustomerDataBasesInvoice",
                newName: "CustomerDataBasessInvoice");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerDataBasesInvoice_Invoicesid",
                table: "CustomerDataBasessInvoice",
                newName: "IX_CustomerDataBasessInvoice_Invoicesid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerDataBasessInvoice",
                table: "CustomerDataBasessInvoice",
                columns: new[] { "CustomerDataBasesid", "Invoicesid" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerDataBasessInvoice_CustomerDataBases_CustomerDataBasesid",
                table: "CustomerDataBasessInvoice",
                column: "CustomerDataBasesid",
                principalTable: "CustomerDataBases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerDataBasessInvoice_Invoices_Invoicesid",
                table: "CustomerDataBasessInvoice",
                column: "Invoicesid",
                principalTable: "Invoices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerDataBasessInvoice_CustomerDataBases_CustomerDataBasesid",
                table: "CustomerDataBasessInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerDataBasessInvoice_Invoices_Invoicesid",
                table: "CustomerDataBasessInvoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerDataBasessInvoice",
                table: "CustomerDataBasessInvoice");

            migrationBuilder.RenameTable(
                name: "CustomerDataBasessInvoice",
                newName: "CustomerDataBasesInvoice");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerDataBasessInvoice_Invoicesid",
                table: "CustomerDataBasesInvoice",
                newName: "IX_CustomerDataBasesInvoice_Invoicesid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerDataBasesInvoice",
                table: "CustomerDataBasesInvoice",
                columns: new[] { "CustomerDataBasesid", "Invoicesid" });

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerDataBasesInvoice_CustomerDataBases_CustomerDataBasesid",
                table: "CustomerDataBasesInvoice",
                column: "CustomerDataBasesid",
                principalTable: "CustomerDataBases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerDataBasesInvoice_Invoices_Invoicesid",
                table: "CustomerDataBasesInvoice",
                column: "Invoicesid",
                principalTable: "Invoices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
