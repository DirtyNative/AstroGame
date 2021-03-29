using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class UpdatedAImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PlanetBuildings",
                keyColumn: "Id",
                keyValue: new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                column: "AssetName",
                value: "iron_mine.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PlanetBuildings",
                keyColumn: "Id",
                keyValue: new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                column: "AssetName",
                value: "iron_mine.png");
        }
    }
}
