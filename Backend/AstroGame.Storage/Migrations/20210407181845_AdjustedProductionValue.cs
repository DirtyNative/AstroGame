using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AdjustedProductionValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OutputResources",
                keyColumn: "Id",
                keyValue: new Guid("24a0efe4-27d2-43c6-bb7b-61b36c129b00"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 40.0, 1.1000000000000001 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OutputResources",
                keyColumn: "Id",
                keyValue: new Guid("24a0efe4-27d2-43c6-bb7b-61b36c129b00"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 60.0, 1.5 });
        }
    }
}
