using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_Moons_MoonId",
                table: "StellarObjectResources");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_Planets_PlanetId",
                table: "StellarObjectResources");

            migrationBuilder.DropIndex(
                name: "IX_StellarObjectResources_MoonId",
                table: "StellarObjectResources");

            migrationBuilder.DropIndex(
                name: "IX_StellarObjectResources_PlanetId",
                table: "StellarObjectResources");

            migrationBuilder.DropColumn(
                name: "MoonId",
                table: "StellarObjectResources");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "StellarObjectResources");

            migrationBuilder.AddColumn<Guid>(
                name: "StellarObjectId1",
                table: "StellarObjectResources",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_StellarObjectId1",
                table: "StellarObjectResources",
                column: "StellarObjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_Moons_StellarObjectId",
                table: "StellarObjectResources",
                column: "StellarObjectId",
                principalTable: "Moons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_Planets_StellarObjectId",
                table: "StellarObjectResources",
                column: "StellarObjectId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_StellarObject_StellarObjectId1",
                table: "StellarObjectResources",
                column: "StellarObjectId1",
                principalTable: "StellarObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_Moons_StellarObjectId",
                table: "StellarObjectResources");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_Planets_StellarObjectId",
                table: "StellarObjectResources");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_StellarObject_StellarObjectId1",
                table: "StellarObjectResources");

            migrationBuilder.DropIndex(
                name: "IX_StellarObjectResources_StellarObjectId1",
                table: "StellarObjectResources");

            migrationBuilder.DropColumn(
                name: "StellarObjectId1",
                table: "StellarObjectResources");

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

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_MoonId",
                table: "StellarObjectResources",
                column: "MoonId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_PlanetId",
                table: "StellarObjectResources",
                column: "PlanetId");

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
        }
    }
}
