using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class ExtendedPlanetObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StarPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DropColumn(
                name: "HasAtmosphere",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "HasRings",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "PrefabName",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "HasRings",
                table: "Moons");

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
                name: "RingPrefabId",
                table: "Planets",
                type: "uniqueidentifier",
                nullable: true);

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
                name: "CloudsPrefabs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CloudsPrefabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CloudsPrefabs_Prefabs_Id",
                        column: x => x.Id,
                        principalTable: "Prefabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlanetAtmospherePrefabs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PlanetTypes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetAtmospherePrefabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanetAtmospherePrefabs_Prefabs_Id",
                        column: x => x.Id,
                        principalTable: "Prefabs",
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
                        name: "FK_RingsPrefabs_Prefabs_Id",
                        column: x => x.Id,
                        principalTable: "Prefabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Prefabs",
                columns: new[] { "Id", "Name", "Offset", "Rotation", "Scale" },
                values: new object[,]
                {
                    { new Guid("3d1dd449-6013-4e6e-9b28-a171029d5597"), "PlanetAtmosphere_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("2593675a-859b-4a4a-8678-3d2801ffbcc5"), "PlanetAtmosphere_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("bd1aa007-b63a-4d74-8ae4-f786df609b71"), "PlanetAtmosphere_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("6eef040c-4483-45cf-8641-07217891baeb"), "Planet_Volcano_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("3f0a097c-38f4-4077-802e-266af980176c"), "Planet_Volcano_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("e2c10703-fe4d-4673-a90a-acf9c502cf27"), "Planet_Volcano_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("b147a06d-d9f2-4606-b014-7cc2998a8d36"), "Test_Prefab", "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" }
                });

            migrationBuilder.InsertData(
                table: "PlanetAtmospherePrefabs",
                columns: new[] { "Id", "PlanetTypes" },
                values: new object[,]
                {
                    { new Guid("3d1dd449-6013-4e6e-9b28-a171029d5597"), 1 },
                    { new Guid("2593675a-859b-4a4a-8678-3d2801ffbcc5"), 1 },
                    { new Guid("bd1aa007-b63a-4d74-8ae4-f786df609b71"), 6 }
                });

            migrationBuilder.InsertData(
                table: "PlanetPrefabs",
                columns: new[] { "Id", "PlanetType" },
                values: new object[,]
                {
                    { new Guid("6eef040c-4483-45cf-8641-07217891baeb"), 0 },
                    { new Guid("3f0a097c-38f4-4077-802e-266af980176c"), 0 },
                    { new Guid("e2c10703-fe4d-4673-a90a-acf9c502cf27"), 0 }
                });

            migrationBuilder.InsertData(
                table: "StarPrefabs",
                columns: new[] { "Id", "StarType" },
                values: new object[] { new Guid("b147a06d-d9f2-4606-b014-7cc2998a8d36"), 0 });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "CloudsPrefabs");

            migrationBuilder.DropTable(
                name: "PlanetAtmospherePrefabs");

            migrationBuilder.DropTable(
                name: "RingsPrefabs");

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

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("3f0a097c-38f4-4077-802e-266af980176c"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("6eef040c-4483-45cf-8641-07217891baeb"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("e2c10703-fe4d-4673-a90a-acf9c502cf27"));

            migrationBuilder.DeleteData(
                table: "StarPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("b147a06d-d9f2-4606-b014-7cc2998a8d36"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("2593675a-859b-4a4a-8678-3d2801ffbcc5"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("3d1dd449-6013-4e6e-9b28-a171029d5597"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("bd1aa007-b63a-4d74-8ae4-f786df609b71"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("3f0a097c-38f4-4077-802e-266af980176c"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("6eef040c-4483-45cf-8641-07217891baeb"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("e2c10703-fe4d-4673-a90a-acf9c502cf27"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("b147a06d-d9f2-4606-b014-7cc2998a8d36"));

            migrationBuilder.DropColumn(
                name: "AtmospherePrefabId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "CloudsPrefabId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "RingPrefabId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "RingPrefabId",
                table: "Moons");

            migrationBuilder.DropColumn(
                name: "RingsPrefabId",
                table: "Moons");

            migrationBuilder.AddColumn<bool>(
                name: "HasAtmosphere",
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
                name: "PrefabName",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasRings",
                table: "Moons",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Prefabs",
                columns: new[] { "Id", "Name", "Offset", "Rotation", "Scale" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "Test_Prefab", "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" });

            migrationBuilder.InsertData(
                table: "StarPrefabs",
                columns: new[] { "Id", "StarType" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), 0 });
        }
    }
}
