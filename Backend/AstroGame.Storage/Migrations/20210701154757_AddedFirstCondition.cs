using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AddedFirstCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Technologies",
                column: "Id",
                value: new Guid("0233326e-2b2a-4170-993e-835417e293c6"));

            migrationBuilder.InsertData(
                table: "Technologies",
                column: "Id",
                value: new Guid("a3058710-e6fe-4db1-98d2-f7d93874ff5a"));

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "AssetName", "BuildableOn", "BuildingType", "Description", "Name", "Order" },
                values: new object[] { new Guid("0233326e-2b2a-4170-993e-835417e293c6"), "19.jpg", 2, 0, "TODO", "Building Grounds", 1 });

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "Id", "NeededTechnologyId", "TechnologyId" },
                values: new object[] { new Guid("5ce36df3-90d7-477a-9278-b2d9100f6b2f"), new Guid("0233326e-2b2a-4170-993e-835417e293c6"), new Guid("a3058710-e6fe-4db1-98d2-f7d93874ff5a") });

            migrationBuilder.InsertData(
                table: "Researches",
                columns: new[] { "Id", "AssetName", "BuildingConsumptionMultiplier", "BuildingCostMultiplier", "BuildingProductionMultiplier", "BuildingTimeMultiplier", "CargoCapacityMultiplier", "Description", "FuelConsumptionMultiplier", "InterstellarSpeedMultiplier", "Name", "Order", "ResearchType", "ShieldPowerMultiplier", "StellarSpeedMultiplier", "StructuralIntegrityMultiplier", "WeaponPowerMultiplier" },
                values: new object[] { new Guid("a3058710-e6fe-4db1-98d2-f7d93874ff5a"), "2.jpg", 0.0, 0.0, 0.0, 0.0, 0.0, "TODO", 0.0, 0.0, "Efficient living places", 1, 3, 0.0, 0.0, 0.0, 0.0 });

            migrationBuilder.InsertData(
                table: "LevelableBuildings",
                column: "Id",
                value: new Guid("0233326e-2b2a-4170-993e-835417e293c6"));

            migrationBuilder.InsertData(
                table: "LevelableConditions",
                columns: new[] { "Id", "NeededLevel" },
                values: new object[] { new Guid("5ce36df3-90d7-477a-9278-b2d9100f6b2f"), 5 });

            migrationBuilder.InsertData(
                table: "LevelableResearches",
                column: "Id",
                value: new Guid("a3058710-e6fe-4db1-98d2-f7d93874ff5a"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LevelableBuildings",
                keyColumn: "Id",
                keyValue: new Guid("0233326e-2b2a-4170-993e-835417e293c6"));

            migrationBuilder.DeleteData(
                table: "LevelableConditions",
                keyColumn: "Id",
                keyValue: new Guid("5ce36df3-90d7-477a-9278-b2d9100f6b2f"));

            migrationBuilder.DeleteData(
                table: "LevelableResearches",
                keyColumn: "Id",
                keyValue: new Guid("a3058710-e6fe-4db1-98d2-f7d93874ff5a"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("0233326e-2b2a-4170-993e-835417e293c6"));

            migrationBuilder.DeleteData(
                table: "Conditions",
                keyColumn: "Id",
                keyValue: new Guid("5ce36df3-90d7-477a-9278-b2d9100f6b2f"));

            migrationBuilder.DeleteData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("a3058710-e6fe-4db1-98d2-f7d93874ff5a"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0233326e-2b2a-4170-993e-835417e293c6"));

            migrationBuilder.DeleteData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a3058710-e6fe-4db1-98d2-f7d93874ff5a"));
        }
    }
}
