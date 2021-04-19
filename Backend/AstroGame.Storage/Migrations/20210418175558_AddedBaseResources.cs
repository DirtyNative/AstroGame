using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AddedBaseResources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBaseResource",
                table: "Elements",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-1111-0000-0000-000000000001"),
                column: "IsBaseResource",
                value: true);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-1111-0000-0000-000000000002"),
                column: "IsBaseResource",
                value: true);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-1111-0000-0000-000000000008"),
                column: "IsBaseResource",
                value: true);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-1111-0000-0000-000000000011"),
                column: "IsBaseResource",
                value: true);

            migrationBuilder.UpdateData(
                table: "Elements",
                keyColumn: "Id",
                keyValue: new Guid("00000000-1111-0000-0000-000000000016"),
                column: "IsBaseResource",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBaseResource",
                table: "Elements");
        }
    }
}
