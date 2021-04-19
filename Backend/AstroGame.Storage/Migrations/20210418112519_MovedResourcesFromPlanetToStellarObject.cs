using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class MovedResourcesFromPlanetToStellarObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_BlackHoles_BlackHoleId",
                table: "StellarObjectResources");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_Moons_MoonId",
                table: "StellarObjectResources");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_Planets_PlanetId",
                table: "StellarObjectResources");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_Stars_StarId",
                table: "StellarObjectResources");

            migrationBuilder.DropIndex(
                name: "IX_StellarObjectResources_BlackHoleId",
                table: "StellarObjectResources");

            migrationBuilder.DropIndex(
                name: "IX_StellarObjectResources_MoonId",
                table: "StellarObjectResources");

            migrationBuilder.DropIndex(
                name: "IX_StellarObjectResources_PlanetId",
                table: "StellarObjectResources");

            migrationBuilder.DropIndex(
                name: "IX_StellarObjectResources_StarId",
                table: "StellarObjectResources");

            migrationBuilder.DropColumn(
                name: "BlackHoleId",
                table: "StellarObjectResources");

            migrationBuilder.DropColumn(
                name: "MoonId",
                table: "StellarObjectResources");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "StellarObjectResources");

            migrationBuilder.DropColumn(
                name: "StarId",
                table: "StellarObjectResources");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BlackHoleId",
                table: "StellarObjectResources",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MoonId",
                table: "StellarObjectResources",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlanetId",
                table: "StellarObjectResources",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StarId",
                table: "StellarObjectResources",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_BlackHoleId",
                table: "StellarObjectResources",
                column: "BlackHoleId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_MoonId",
                table: "StellarObjectResources",
                column: "MoonId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_PlanetId",
                table: "StellarObjectResources",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_StarId",
                table: "StellarObjectResources",
                column: "StarId");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_BlackHoles_BlackHoleId",
                table: "StellarObjectResources",
                column: "BlackHoleId",
                principalTable: "BlackHoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_Moons_MoonId",
                table: "StellarObjectResources",
                column: "MoonId",
                principalTable: "Moons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_Planets_PlanetId",
                table: "StellarObjectResources",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
