using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class staticexpenses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DevelopmentManagement",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "Installments",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "Management",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "NameOfMonth",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "OperationSection",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "Rent",
                table: "static_expenses");

            migrationBuilder.RenameColumn(
                name: "marketing",
                table: "static_expenses",
                newName: "Employee");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Target",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "static_expenses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<decimal>(
                name: "April",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "August",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "December",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "February",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "January",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "July",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "June",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "March",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "May",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfDepartment",
                table: "static_expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "November",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "October",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "September",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalOfMonth",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "salary",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "April",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "August",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "December",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "February",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "January",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "July",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "June",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "March",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "May",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "NameOfDepartment",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "November",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "October",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "September",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "TotalOfMonth",
                table: "static_expenses");

            migrationBuilder.DropColumn(
                name: "salary",
                table: "static_expenses");

            migrationBuilder.RenameColumn(
                name: "Employee",
                table: "static_expenses",
                newName: "marketing");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Target",
                table: "static_expenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "static_expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DevelopmentManagement",
                table: "static_expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Installments",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Management",
                table: "static_expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfMonth",
                table: "static_expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperationSection",
                table: "static_expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Rent",
                table: "static_expenses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
