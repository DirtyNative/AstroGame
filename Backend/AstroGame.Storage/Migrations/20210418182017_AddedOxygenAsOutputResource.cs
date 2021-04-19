using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AddedOxygenAsOutputResource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OutputResources",
                columns: new[] { "Id", "BaseValue", "BuildingId", "Multiplier", "ResourceId" },
                values: new object[] { new Guid("f2486784-2189-49a4-a644-e6d93e0ff7f4"), 37.0, new Guid("adab9b7c-53e7-4f89-aa62-61b8a6d8b60f"), 1.1299999999999999, new Guid("00000000-1111-0000-0000-000000000008") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OutputResources",
                keyColumn: "Id",
                keyValue: new Guid("f2486784-2189-49a4-a644-e6d93e0ff7f4"));
        }
    }
}
