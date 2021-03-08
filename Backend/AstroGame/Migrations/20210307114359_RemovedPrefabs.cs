using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class RemovedPrefabs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moons_MoonPrefabs_PrefabId",
                table: "Moons");

            migrationBuilder.DropForeignKey(
                name: "FK_Moons_RingsPrefabs_RingsPrefabId",
                table: "Moons");

            migrationBuilder.DropForeignKey(
                name: "FK_Planets_CloudsPrefabs_CloudsPrefabId",
                table: "Planets");

            migrationBuilder.DropForeignKey(
                name: "FK_Planets_PlanetAtmospherePrefabs_AtmospherePrefabId",
                table: "Planets");

            migrationBuilder.DropForeignKey(
                name: "FK_Planets_PlanetPrefabs_PrefabId",
                table: "Planets");

            migrationBuilder.DropForeignKey(
                name: "FK_Planets_RingsPrefabs_RingPrefabId",
                table: "Planets");

            migrationBuilder.DropForeignKey(
                name: "FK_Stars_StarPrefabs_PrefabId",
                table: "Stars");

            migrationBuilder.DropTable(
                name: "CloudsPrefabs");

            migrationBuilder.DropTable(
                name: "MoonPrefabs");

            migrationBuilder.DropTable(
                name: "PlanetAtmospherePrefabs");

            migrationBuilder.DropTable(
                name: "PlanetPrefabs");

            migrationBuilder.DropTable(
                name: "RingsPrefabs");

            migrationBuilder.DropTable(
                name: "StarPrefabs");

            migrationBuilder.DropTable(
                name: "Prefab");

            migrationBuilder.DropIndex(
                name: "IX_Stars_PrefabId",
                table: "Stars");

            migrationBuilder.DropIndex(
                name: "IX_Planets_AtmospherePrefabId",
                table: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_Planets_CloudsPrefabId",
                table: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_Planets_PrefabId",
                table: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_Planets_RingPrefabId",
                table: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_Moons_PrefabId",
                table: "Moons");

            migrationBuilder.DropIndex(
                name: "IX_Moons_RingsPrefabId",
                table: "Moons");

            migrationBuilder.DropColumn(
                name: "PrefabId",
                table: "Stars");

            migrationBuilder.DropColumn(
                name: "AtmospherePrefabId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "CloudsPrefabId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "PrefabId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "RingPrefabId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "PrefabId",
                table: "Moons");

            migrationBuilder.DropColumn(
                name: "RingPrefabId",
                table: "Moons");

            migrationBuilder.DropColumn(
                name: "RingsPrefabId",
                table: "Moons");

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                table: "Stars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasAtmosphere",
                table: "Planets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasClouds",
                table: "Planets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasRings",
                table: "Planets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                table: "Moons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasRings",
                table: "Moons",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssetName",
                table: "Stars");

            migrationBuilder.DropColumn(
                name: "AssetName",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "HasAtmosphere",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "HasClouds",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "HasRings",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "AssetName",
                table: "Moons");

            migrationBuilder.DropColumn(
                name: "HasRings",
                table: "Moons");

            migrationBuilder.AddColumn<Guid>(
                name: "PrefabId",
                table: "Stars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AtmospherePrefabId",
                table: "Planets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CloudsPrefabId",
                table: "Planets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PrefabId",
                table: "Planets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RingPrefabId",
                table: "Planets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PrefabId",
                table: "Moons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RingPrefabId",
                table: "Moons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RingsPrefabId",
                table: "Moons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prefab",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Offset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rotation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scale = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefab", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CloudsPrefabs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloudsPrefabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CloudsPrefabs_Prefab_Id",
                        column: x => x.Id,
                        principalTable: "Prefab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MoonPrefabs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
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
                name: "PlanetAtmospherePrefabs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PlanetTypes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetAtmospherePrefabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanetAtmospherePrefabs_Prefab_Id",
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
                    PlanetType = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "RingsPrefabs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RingsPrefabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RingsPrefabs_Prefab_Id",
                        column: x => x.Id,
                        principalTable: "Prefab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StarPrefabs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    StarType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarPrefabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StarPrefabs_Prefab_Id",
                        column: x => x.Id,
                        principalTable: "Prefab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Prefab",
                columns: new[] { "Id", "Name", "Offset", "Rotation", "Scale" },
                values: new object[,]
                {
                    { new Guid("00000000-1111-0000-0000-000000000001"), "Clouds_1", "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("30000000-0000-0000-0000-000000000002"), "Planet_Rock_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("30000000-0000-0000-0000-000000000003"), "Planet_Rock_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("40000000-0000-0000-0000-000000000001"), "Planet_Gaia_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("40000000-0000-0000-0000-000000000002"), "Planet_Gaia_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("40000000-0000-0000-0000-000000000003"), "Planet_Gaia_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("50000000-0000-0000-0000-000000000001"), "Planet_Gas_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("30000000-0000-0000-0000-000000000001"), "Planet_Rock_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("50000000-0000-0000-0000-000000000002"), "Planet_Gas_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("60000000-0000-0000-0000-000000000001"), "Planet_Ocean_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("60000000-0000-0000-0000-000000000002"), "Planet_Ocean_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("60000000-0000-0000-0000-000000000003"), "Planet_Ocean_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("70000000-0000-0000-0000-000000000001"), "Planet_Ice_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("70000000-0000-0000-0000-000000000002"), "Planet_Ice_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("70000000-0000-0000-0000-000000000003"), "Planet_Ice_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("50000000-0000-0000-0000-000000000003"), "Planet_Gas_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("00000000-4444-0000-0000-000000000001"), "Rings_1", "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("20000000-0000-0000-0000-000000000003"), "Planet_Continental_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("20000000-0000-0000-0000-000000000001"), "Planet_Continental_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("00000000-2222-0000-0000-000000000001"), "Moon_1", "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("00000000-2222-0000-0000-000000000002"), "Moon_2", "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("00000000-2222-0000-0000-000000000003"), "Moon_3", "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("00000000-3333-0000-0000-000000000001"), "PlanetAtmosphere_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("00000000-3333-0000-0000-000000000002"), "PlanetAtmosphere_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("00000000-3333-0000-0000-000000000003"), "PlanetAtmosphere_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("20000000-0000-0000-0000-000000000002"), "Planet_Continental_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("00000000-3333-0000-0000-000000000004"), "PlanetAtmosphere_4", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("00000000-0000-0000-0000-000000000001"), "Planet_Volcano_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "Planet_Volcano_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "Planet_Volcano_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("10000000-0000-0000-0000-000000000001"), "Planet_Desert_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "Planet_Desert_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Planet_Desert_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("00000000-3333-0000-0000-000000000005"), "PlanetAtmosphere_5", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("00000000-5555-0000-0000-000000000001"), "Test_Prefab", "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" }
                });

            migrationBuilder.InsertData(
                table: "CloudsPrefabs",
                column: "Id",
                value: new Guid("00000000-1111-0000-0000-000000000001"));

            migrationBuilder.InsertData(
                table: "MoonPrefabs",
                column: "Id",
                values: new object[]
                {
                    new Guid("00000000-2222-0000-0000-000000000001"),
                    new Guid("00000000-2222-0000-0000-000000000002"),
                    new Guid("00000000-2222-0000-0000-000000000003")
                });

            migrationBuilder.InsertData(
                table: "PlanetAtmospherePrefabs",
                columns: new[] { "Id", "PlanetTypes" },
                values: new object[,]
                {
                    { new Guid("00000000-3333-0000-0000-000000000001"), "Volcano;Desert" },
                    { new Guid("00000000-3333-0000-0000-000000000002"), "Volcano;Desert" },
                    { new Guid("00000000-3333-0000-0000-000000000003"), "Continental;Rock" },
                    { new Guid("00000000-3333-0000-0000-000000000004"), "Gaia;Gas" },
                    { new Guid("00000000-3333-0000-0000-000000000005"), "Ocean;Ice" }
                });

            migrationBuilder.InsertData(
                table: "PlanetPrefabs",
                columns: new[] { "Id", "PlanetType" },
                values: new object[,]
                {
                    { new Guid("40000000-0000-0000-0000-000000000003"), 7 },
                    { new Guid("50000000-0000-0000-0000-000000000001"), 5 },
                    { new Guid("50000000-0000-0000-0000-000000000002"), 5 },
                    { new Guid("50000000-0000-0000-0000-000000000003"), 5 },
                    { new Guid("60000000-0000-0000-0000-000000000001"), 3 },
                    { new Guid("70000000-0000-0000-0000-000000000002"), 6 },
                    { new Guid("60000000-0000-0000-0000-000000000003"), 3 },
                    { new Guid("70000000-0000-0000-0000-000000000001"), 6 },
                    { new Guid("40000000-0000-0000-0000-000000000002"), 7 },
                    { new Guid("70000000-0000-0000-0000-000000000003"), 6 },
                    { new Guid("60000000-0000-0000-0000-000000000002"), 3 },
                    { new Guid("40000000-0000-0000-0000-000000000001"), 7 },
                    { new Guid("20000000-0000-0000-0000-000000000003"), 2 },
                    { new Guid("30000000-0000-0000-0000-000000000002"), 4 },
                    { new Guid("30000000-0000-0000-0000-000000000001"), 4 },
                    { new Guid("20000000-0000-0000-0000-000000000002"), 2 },
                    { new Guid("20000000-0000-0000-0000-000000000001"), 2 },
                    { new Guid("10000000-0000-0000-0000-000000000003"), 1 },
                    { new Guid("10000000-0000-0000-0000-000000000002"), 1 },
                    { new Guid("10000000-0000-0000-0000-000000000001"), 1 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), 0 },
                    { new Guid("00000000-0000-0000-0000-000000000001"), 0 },
                    { new Guid("30000000-0000-0000-0000-000000000003"), 4 }
                });

            migrationBuilder.InsertData(
                table: "RingsPrefabs",
                column: "Id",
                value: new Guid("00000000-4444-0000-0000-000000000001"));

            migrationBuilder.InsertData(
                table: "StarPrefabs",
                columns: new[] { "Id", "StarType" },
                values: new object[] { new Guid("00000000-5555-0000-0000-000000000001"), 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Stars_PrefabId",
                table: "Stars",
                column: "PrefabId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_AtmospherePrefabId",
                table: "Planets",
                column: "AtmospherePrefabId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_CloudsPrefabId",
                table: "Planets",
                column: "CloudsPrefabId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_PrefabId",
                table: "Planets",
                column: "PrefabId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_RingPrefabId",
                table: "Planets",
                column: "RingPrefabId");

            migrationBuilder.CreateIndex(
                name: "IX_Moons_PrefabId",
                table: "Moons",
                column: "PrefabId");

            migrationBuilder.CreateIndex(
                name: "IX_Moons_RingsPrefabId",
                table: "Moons",
                column: "RingsPrefabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moons_MoonPrefabs_PrefabId",
                table: "Moons",
                column: "PrefabId",
                principalTable: "MoonPrefabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Moons_RingsPrefabs_RingsPrefabId",
                table: "Moons",
                column: "RingsPrefabId",
                principalTable: "RingsPrefabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_CloudsPrefabs_CloudsPrefabId",
                table: "Planets",
                column: "CloudsPrefabId",
                principalTable: "CloudsPrefabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_PlanetAtmospherePrefabs_AtmospherePrefabId",
                table: "Planets",
                column: "AtmospherePrefabId",
                principalTable: "PlanetAtmospherePrefabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_PlanetPrefabs_PrefabId",
                table: "Planets",
                column: "PrefabId",
                principalTable: "PlanetPrefabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_RingsPrefabs_RingPrefabId",
                table: "Planets",
                column: "RingPrefabId",
                principalTable: "RingsPrefabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stars_StarPrefabs_PrefabId",
                table: "Stars",
                column: "PrefabId",
                principalTable: "StarPrefabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
