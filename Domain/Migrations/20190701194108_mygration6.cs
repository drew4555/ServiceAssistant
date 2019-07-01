using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class mygration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tech",
                table: "Quotes");

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_TechId",
                table: "Quotes",
                column: "TechId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Employees_TechId",
                table: "Quotes",
                column: "TechId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Employees_TechId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_TechId",
                table: "Quotes");

            migrationBuilder.AddColumn<int>(
                name: "Tech",
                table: "Quotes",
                nullable: false,
                defaultValue: 0);
        }
    }
}
