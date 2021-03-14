using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class AddedNameToSolarSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "StellarSystems");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SolarSystems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "SolarSystems");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StellarSystems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
