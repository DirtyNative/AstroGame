using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class MigratedAssetNameProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetName",
                table: "Stars");

            migrationBuilder.DropColumn(
                name: "AssetName",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "AssetName",
                table: "Moons");

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                table: "StellarObjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetName",
                table: "StellarObjects");

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                table: "Stars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                table: "Moons",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
