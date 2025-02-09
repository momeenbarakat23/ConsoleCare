using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class edittableadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "NameOfAssistant",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "NameOfTechnician",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "RemainingTeam",
                table: "Admins");

            migrationBuilder.AddColumn<string>(
                name: "NameOfAssistant",
                table: "itineraries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemainingTeam",
                table: "itineraries",
                type: "nvarchar(max)",
                nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "NameOfAssistant",
                table: "itineraries");

            migrationBuilder.DropColumn(
                name: "RemainingTeam",
                table: "itineraries");


            migrationBuilder.AddColumn<string>(
                name: "NameOfAssistant",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameOfTechnician",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemainingTeam",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
