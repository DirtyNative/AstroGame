using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AstroGame.Api.Migrations
{
    public partial class MadePrefabsNonAbstract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoonPrefabs_Prefab_Id",
                table: "MoonPrefabs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanetPrefabs_Prefab_Id",
                table: "PlanetPrefabs");

            migrationBuilder.DropForeignKey(
                name: "FK_StarPrefabs_Prefab_Id",
                table: "StarPrefabs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prefab",
                table: "Prefab");

            migrationBuilder.DropColumn(
                name: "Offset",
                table: "StarPrefabs");

            migrationBuilder.DropColumn(
                name: "Rotation",
                table: "StarPrefabs");

            migrationBuilder.DropColumn(
                name: "Scale",
                table: "StarPrefabs");

            migrationBuilder.DropColumn(
                name: "Offset",
                table: "PlanetPrefabs");

            migrationBuilder.DropColumn(
                name: "Rotation",
                table: "PlanetPrefabs");

            migrationBuilder.DropColumn(
                name: "Scale",
                table: "PlanetPrefabs");

            migrationBuilder.DropColumn(
                name: "Offset",
                table: "MoonPrefabs");

            migrationBuilder.DropColumn(
                name: "Rotation",
                table: "MoonPrefabs");

            migrationBuilder.DropColumn(
                name: "Scale",
                table: "MoonPrefabs");

            migrationBuilder.RenameTable(
                name: "Prefab",
                newName: "Prefabs");

            migrationBuilder.AddColumn<string>(
                name: "Offset",
                table: "Prefabs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rotation",
                table: "Prefabs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Scale",
                table: "Prefabs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prefabs",
                table: "Prefabs",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Offset", "Rotation" },
                values: new object[] { "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)" });

            migrationBuilder.AddForeignKey(
                name: "FK_MoonPrefabs_Prefabs_Id",
                table: "MoonPrefabs",
                column: "Id",
                principalTable: "Prefabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanetPrefabs_Prefabs_Id",
                table: "PlanetPrefabs",
                column: "Id",
                principalTable: "Prefabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StarPrefabs_Prefabs_Id",
                table: "StarPrefabs",
                column: "Id",
                principalTable: "Prefabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoonPrefabs_Prefabs_Id",
                table: "MoonPrefabs");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanetPrefabs_Prefabs_Id",
                table: "PlanetPrefabs");

            migrationBuilder.DropForeignKey(
                name: "FK_StarPrefabs_Prefabs_Id",
                table: "StarPrefabs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prefabs",
                table: "Prefabs");

            migrationBuilder.DropColumn(
                name: "Offset",
                table: "Prefabs");

            migrationBuilder.DropColumn(
                name: "Rotation",
                table: "Prefabs");

            migrationBuilder.DropColumn(
                name: "Scale",
                table: "Prefabs");

            migrationBuilder.RenameTable(
                name: "Prefabs",
                newName: "Prefab");

            migrationBuilder.AddColumn<string>(
                name: "Offset",
                table: "StarPrefabs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rotation",
                table: "StarPrefabs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Scale",
                table: "StarPrefabs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Offset",
                table: "PlanetPrefabs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rotation",
                table: "PlanetPrefabs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Scale",
                table: "PlanetPrefabs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Offset",
                table: "MoonPrefabs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rotation",
                table: "MoonPrefabs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Scale",
                table: "MoonPrefabs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prefab",
                table: "Prefab",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "StarPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Offset", "Rotation", "Scale" },
                values: new object[] { "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" });

            migrationBuilder.AddForeignKey(
                name: "FK_MoonPrefabs_Prefab_Id",
                table: "MoonPrefabs",
                column: "Id",
                principalTable: "Prefab",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanetPrefabs_Prefab_Id",
                table: "PlanetPrefabs",
                column: "Id",
                principalTable: "Prefab",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StarPrefabs_Prefab_Id",
                table: "StarPrefabs",
                column: "Id",
                principalTable: "Prefab",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
