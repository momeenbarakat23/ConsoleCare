using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Console_Care.Migrations
{
    /// <inheritdoc />
    public partial class empl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMaterials",
                columns: table => new
                {
                    Employeesid = table.Column<int>(type: "int", nullable: false),
                    materialsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMaterials", x => new { x.Employeesid, x.materialsId });
                    table.ForeignKey(
                        name: "FK_EmployeeMaterials_Employee_Employeesid",
                        column: x => x.Employeesid,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeMaterials_materials_materialsId",
                        column: x => x.materialsId,
                        principalTable: "materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeMaterials_materialsId",
                table: "EmployeeMaterials",
                column: "materialsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeMaterials");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
