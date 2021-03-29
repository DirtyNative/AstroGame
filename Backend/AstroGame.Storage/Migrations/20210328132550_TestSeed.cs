using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class TestSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BuildingCosts",
                columns: new[] { "Id", "BaseValue", "BuildingId", "Multiplier", "ResourceId" },
                values: new object[] { new Guid("76f6afe9-670a-4ba5-90d8-01891f15a6a2"), 60.0, new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("76f6afe9-670a-4ba5-90d8-01891f15a6a2"));
        }
    }
}
