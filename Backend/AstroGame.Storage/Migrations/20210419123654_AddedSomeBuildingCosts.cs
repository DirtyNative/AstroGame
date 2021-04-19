using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AddedSomeBuildingCosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BuildingCosts",
                columns: new[] { "Id", "BuildingId", "ResourceId" },
                values: new object[] { new Guid("bd87afe1-192e-4618-a34c-7a6e8ed7eb0b"), new Guid("75021a39-c0c1-46f0-b155-f1cdfb9fbc00"), new Guid("00000000-1111-0000-0000-000000000016") });

            migrationBuilder.InsertData(
                table: "FixedBuildingCosts",
                columns: new[] { "Id", "Amount" },
                values: new object[] { new Guid("bd87afe1-192e-4618-a34c-7a6e8ed7eb0b"), 2000.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FixedBuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("bd87afe1-192e-4618-a34c-7a6e8ed7eb0b"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("bd87afe1-192e-4618-a34c-7a6e8ed7eb0b"));
        }
    }
}
