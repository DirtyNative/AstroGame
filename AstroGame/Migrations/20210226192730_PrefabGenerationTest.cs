using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class PrefabGenerationTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stars_StarPrefabs_PrefabId",
                table: "Stars");

            migrationBuilder.DropColumn(
                name: "PrefabName",
                table: "Stars");

            migrationBuilder.DropColumn(
                name: "PrefabName",
                table: "Moons");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrefabId",
                table: "Stars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PrefabId",
                table: "Planets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PrefabId",
                table: "Moons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "MoonPrefabs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Offset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rotation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scale = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoonPrefabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoonPrefabs_Prefab_Id",
                        column: x => x.Id,
                        principalTable: "Prefab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanetPrefabs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PlanetType = table.Column<int>(type: "int", nullable: false),
                    Offset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rotation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scale = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetPrefabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanetPrefabs_Prefab_Id",
                        column: x => x.Id,
                        principalTable: "Prefab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Stars_StarPrefabs_PrefabId",
                table: "Stars",
                column: "PrefabId",
                principalTable: "StarPrefabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stars_StarPrefabs_PrefabId",
                table: "Stars");

            migrationBuilder.DropTable(
                name: "MoonPrefabs");

            migrationBuilder.DropTable(
                name: "PlanetPrefabs");

            migrationBuilder.DropColumn(
                name: "PrefabId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "PrefabId",
                table: "Moons");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrefabId",
                table: "Stars",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "PrefabName",
                table: "Stars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrefabName",
                table: "Moons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stars_StarPrefabs_PrefabId",
                table: "Stars",
                column: "PrefabId",
                principalTable: "StarPrefabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
