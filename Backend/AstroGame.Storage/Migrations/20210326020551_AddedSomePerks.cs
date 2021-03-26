using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AddedSomePerks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Perks",
                columns: new[] { "Id", "BuildingSpeedMultiplier", "Description", "Title" },
                values: new object[] { new Guid("00000000-0000-1111-0000-6712d7115748"), 0.90000000000000002, "", "Fast builder" });

            migrationBuilder.InsertData(
                table: "Perks",
                columns: new[] { "Id", "BiologicalResearchSpeedMultiplier", "Description", "Title" },
                values: new object[] { new Guid("00000000-0000-1111-0000-dadcd19d28e3"), 0.84999999999999998, "", "Natural Sociologists" });

            migrationBuilder.InsertData(
                table: "Perks",
                columns: new[] { "Id", "Description", "EngineersResearchSpeedMultiplier", "Title" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-1111-0000-cb67c0894e44"), "", 0.84999999999999998, "Natural Sociologists" },
                    { new Guid("00000000-0000-1111-0000-551336d46b5d"), "", 0.84999999999999998, "Natural Engineers" }
                });

            migrationBuilder.InsertData(
                table: "Perks",
                columns: new[] { "Id", "BiologicalResearchSpeedMultiplier", "Description", "EngineersResearchSpeedMultiplier", "PhysicsResearchSpeedMultiplier", "Title" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-1111-0000-326db14a91f9"), 0.94999999999999996, "", 0.94999999999999996, 0.94999999999999996, "Intelligent" },
                    { new Guid("00000000-0000-1111-0000-b9b49624f255"), 0.94999999999999996, "", 0.94999999999999996, 0.94999999999999996, "Intelligent" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-326db14a91f9"));

            migrationBuilder.DeleteData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-551336d46b5d"));

            migrationBuilder.DeleteData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-6712d7115748"));

            migrationBuilder.DeleteData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-b9b49624f255"));

            migrationBuilder.DeleteData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-cb67c0894e44"));

            migrationBuilder.DeleteData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-dadcd19d28e3"));

            migrationBuilder.InsertData(
                table: "Perks",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { new Guid("00000000-0000-1111-0000-000000000000"), "", "Fast builder" });
        }
    }
}
