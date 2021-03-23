using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class Test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PlayerSpecies",
                columns: new[] { "Id", "EmpireName", "PlayerId", "PreferredPlanetType", "SpeciesId" },
                values: new object[] { new Guid("22222222-1111-0000-0000-000000000000"), "Dirty's Empire", new Guid("22222222-0000-0000-0000-000000000000"), 7, new Guid("22222222-2222-0000-0000-000000000000") });

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000000"),
                column: "PlayerSpeciesId",
                value: new Guid("22222222-1111-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlayerSpecies",
                keyColumn: "Id",
                keyValue: new Guid("22222222-1111-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000000"),
                column: "PlayerSpeciesId",
                value: null);
        }
    }
}
