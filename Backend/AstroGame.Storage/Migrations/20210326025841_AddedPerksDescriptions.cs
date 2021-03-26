using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AddedPerksDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-b9b49624f255"));

            migrationBuilder.UpdateData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-326db14a91f9"),
                column: "Description",
                value: "\"We're good at everything, but not with something specific.\" Well..");

            migrationBuilder.UpdateData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-551336d46b5d"),
                column: "Description",
                value: "Absolute nerds, which love robots and automatism. Hopefully not too much");

            migrationBuilder.UpdateData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-6712d7115748"),
                column: "Description",
                value: "Building big constructs is a no-brainer for your species.");

            migrationBuilder.UpdateData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-cb67c0894e44"),
                columns: new[] { "Description", "EngineersResearchSpeedMultiplier", "PhysicsResearchSpeedMultiplier", "Title" },
                values: new object[] { "Ever wanted to fly into a black hole? Well your species does!", 0.0, 0.84999999999999998, "Natural Physicists" });

            migrationBuilder.UpdateData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-dadcd19d28e3"),
                column: "Description",
                value: "Your species loves to inspect other creatures, and so does with species from other planets.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-326db14a91f9"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-551336d46b5d"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-6712d7115748"),
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-cb67c0894e44"),
                columns: new[] { "Description", "EngineersResearchSpeedMultiplier", "PhysicsResearchSpeedMultiplier", "Title" },
                values: new object[] { "", 0.84999999999999998, 0.0, "Natural Sociologists" });

            migrationBuilder.UpdateData(
                table: "Perks",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-dadcd19d28e3"),
                column: "Description",
                value: "");

            migrationBuilder.InsertData(
                table: "Perks",
                columns: new[] { "Id", "BiologicalResearchSpeedMultiplier", "Description", "EngineersResearchSpeedMultiplier", "PhysicsResearchSpeedMultiplier", "Title" },
                values: new object[] { new Guid("00000000-0000-1111-0000-b9b49624f255"), 0.94999999999999996, "", 0.94999999999999996, 0.94999999999999996, "Intelligent" });
        }
    }
}
