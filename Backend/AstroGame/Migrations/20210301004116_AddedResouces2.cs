using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class AddedResouces2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-000000000001"),
                column: "ManufactionId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-000000000001"),
                column: "ManufactionId",
                value: null);
        }
    }
}
