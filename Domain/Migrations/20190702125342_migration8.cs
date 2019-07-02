using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class migration8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Quotes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_VehicleId",
                table: "Quotes",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_Vehicles_VehicleId",
                table: "Quotes",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_Vehicles_VehicleId",
                table: "Quotes");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_VehicleId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Quotes");
        }
    }
}
