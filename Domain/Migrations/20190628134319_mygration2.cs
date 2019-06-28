using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class mygration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairHistories_Techs_TechId",
                table: "RepairHistories");

            migrationBuilder.DropTable(
                name: "Techs");

            migrationBuilder.RenameColumn(
                name: "TechId",
                table: "RepairHistories",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_RepairHistories_TechId",
                table: "RepairHistories",
                newName: "IX_RepairHistories_EmployeeId");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    EmployeeNumber = table.Column<int>(nullable: false),
                    EmployeeRole = table.Column<string>(nullable: true),
                    applicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_applicationUserId",
                table: "Employees",
                column: "applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairHistories_Employees_EmployeeId",
                table: "RepairHistories",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairHistories_Employees_EmployeeId",
                table: "RepairHistories");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "RepairHistories",
                newName: "TechId");

            migrationBuilder.RenameIndex(
                name: "IX_RepairHistories_EmployeeId",
                table: "RepairHistories",
                newName: "IX_RepairHistories_TechId");

            migrationBuilder.CreateTable(
                name: "Techs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    TechId = table.Column<int>(nullable: false),
                    applicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Techs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Techs_AspNetUsers_applicationUserId",
                        column: x => x.applicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Techs_applicationUserId",
                table: "Techs",
                column: "applicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairHistories_Techs_TechId",
                table: "RepairHistories",
                column: "TechId",
                principalTable: "Techs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
