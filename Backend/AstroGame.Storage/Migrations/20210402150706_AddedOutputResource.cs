using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AddedOutputResource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OutputResources",
                columns: new[] { "Id", "BaseValue", "BuildingId", "Multiplier", "ResourceId" },
                values: new object[] { new Guid("24a0efe4-27d2-43c6-bb7b-61b36c129b00"), 60.0, new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OutputResources",
                keyColumn: "Id",
                keyValue: new Guid("24a0efe4-27d2-43c6-bb7b-61b36c129b00"));
        }
    }
}
