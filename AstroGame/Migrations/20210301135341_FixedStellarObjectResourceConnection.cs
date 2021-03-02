using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class FixedStellarObjectResourceConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_Planets_StellarObjectId",
                table: "StellarObjectResources");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_Stars_StarId",
                table: "StellarObjectResources");

            migrationBuilder.RenameColumn(
                name: "StarId",
                table: "StellarObjectResources",
                newName: "PlanetId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarObjectResources_StarId",
                table: "StellarObjectResources",
                newName: "IX_StellarObjectResources_PlanetId");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_Planets_PlanetId",
                table: "StellarObjectResources",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_Stars_StellarObjectId",
                table: "StellarObjectResources",
                column: "StellarObjectId",
                principalTable: "Stars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_Planets_PlanetId",
                table: "StellarObjectResources");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_Stars_StellarObjectId",
                table: "StellarObjectResources");

            migrationBuilder.RenameColumn(
                name: "PlanetId",
                table: "StellarObjectResources",
                newName: "StarId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarObjectResources_PlanetId",
                table: "StellarObjectResources",
                newName: "IX_StellarObjectResources_StarId");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_Planets_StellarObjectId",
                table: "StellarObjectResources",
                column: "StellarObjectId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_Stars_StarId",
                table: "StellarObjectResources",
                column: "StarId",
                principalTable: "Stars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
