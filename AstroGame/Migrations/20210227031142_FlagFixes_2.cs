using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class FlagFixes_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("5d52cf31-3931-4e41-b64f-62fe06cb5973"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("743d0b5c-6f0c-44c0-b90e-4ce822821064"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("abfd9c26-7c91-4001-8e1e-6b0cb11e0632"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("53e62d02-ff0a-495c-b389-6ad85272fd1b"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("b39252b2-4d62-4b5b-9c5e-a489f8b8074e"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("ce883600-7148-40d0-b543-e21e3c9e8dc6"));

            migrationBuilder.DeleteData(
                table: "StarPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("a7b0b488-4150-4dee-8b1e-05322832aa2a"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("5d52cf31-3931-4e41-b64f-62fe06cb5973"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("743d0b5c-6f0c-44c0-b90e-4ce822821064"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("abfd9c26-7c91-4001-8e1e-6b0cb11e0632"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("53e62d02-ff0a-495c-b389-6ad85272fd1b"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("b39252b2-4d62-4b5b-9c5e-a489f8b8074e"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("ce883600-7148-40d0-b543-e21e3c9e8dc6"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("a7b0b488-4150-4dee-8b1e-05322832aa2a"));

            migrationBuilder.InsertData(
                table: "Prefabs",
                columns: new[] { "Id", "Name", "Offset", "Rotation", "Scale" },
                values: new object[,]
                {
                    { new Guid("7b9e5331-c0e7-40bd-9986-9c758bcddaad"), "PlanetAtmosphere_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("3e4b70c5-9faa-405c-81ca-ca97af39e13b"), "PlanetAtmosphere_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("e61b1aab-3424-4389-a795-6011e90f09ca"), "PlanetAtmosphere_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("eb045083-2034-4534-a840-2cfb0a1a5ba5"), "PlanetAtmosphere_4", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("5a8f946c-c61b-4e9b-bedf-e3fc507bc4ea"), "PlanetAtmosphere_5", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("b00728b7-156b-4e3a-9e64-291745f3022b"), "Planet_Volcano_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("15e9687f-5f29-4683-b970-4a9ab62b2ba5"), "Planet_Volcano_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("afe7414a-e21b-47ee-8a28-cf9bdc484e35"), "Planet_Volcano_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("e3394273-83e7-4eb4-b400-205abf8a581c"), "Test_Prefab", "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" }
                });

            migrationBuilder.InsertData(
                table: "PlanetAtmospherePrefabs",
                columns: new[] { "Id", "PlanetTypes" },
                values: new object[,]
                {
                    { new Guid("7b9e5331-c0e7-40bd-9986-9c758bcddaad"), 1 },
                    { new Guid("3e4b70c5-9faa-405c-81ca-ca97af39e13b"), 1 },
                    { new Guid("e61b1aab-3424-4389-a795-6011e90f09ca"), 6 },
                    { new Guid("eb045083-2034-4534-a840-2cfb0a1a5ba5"), 7 },
                    { new Guid("5a8f946c-c61b-4e9b-bedf-e3fc507bc4ea"), 7 }
                });

            migrationBuilder.InsertData(
                table: "PlanetPrefabs",
                columns: new[] { "Id", "PlanetType" },
                values: new object[,]
                {
                    { new Guid("b00728b7-156b-4e3a-9e64-291745f3022b"), 0 },
                    { new Guid("15e9687f-5f29-4683-b970-4a9ab62b2ba5"), 0 },
                    { new Guid("afe7414a-e21b-47ee-8a28-cf9bdc484e35"), 0 }
                });

            migrationBuilder.InsertData(
                table: "StarPrefabs",
                columns: new[] { "Id", "StarType" },
                values: new object[] { new Guid("e3394273-83e7-4eb4-b400-205abf8a581c"), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("3e4b70c5-9faa-405c-81ca-ca97af39e13b"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("5a8f946c-c61b-4e9b-bedf-e3fc507bc4ea"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("7b9e5331-c0e7-40bd-9986-9c758bcddaad"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("e61b1aab-3424-4389-a795-6011e90f09ca"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("eb045083-2034-4534-a840-2cfb0a1a5ba5"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("15e9687f-5f29-4683-b970-4a9ab62b2ba5"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("afe7414a-e21b-47ee-8a28-cf9bdc484e35"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("b00728b7-156b-4e3a-9e64-291745f3022b"));

            migrationBuilder.DeleteData(
                table: "StarPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("e3394273-83e7-4eb4-b400-205abf8a581c"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("3e4b70c5-9faa-405c-81ca-ca97af39e13b"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("5a8f946c-c61b-4e9b-bedf-e3fc507bc4ea"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("7b9e5331-c0e7-40bd-9986-9c758bcddaad"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("e61b1aab-3424-4389-a795-6011e90f09ca"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("eb045083-2034-4534-a840-2cfb0a1a5ba5"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("15e9687f-5f29-4683-b970-4a9ab62b2ba5"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("afe7414a-e21b-47ee-8a28-cf9bdc484e35"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("b00728b7-156b-4e3a-9e64-291745f3022b"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("e3394273-83e7-4eb4-b400-205abf8a581c"));

            migrationBuilder.InsertData(
                table: "Prefabs",
                columns: new[] { "Id", "Name", "Offset", "Rotation", "Scale" },
                values: new object[,]
                {
                    { new Guid("abfd9c26-7c91-4001-8e1e-6b0cb11e0632"), "PlanetAtmosphere_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("5d52cf31-3931-4e41-b64f-62fe06cb5973"), "PlanetAtmosphere_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("743d0b5c-6f0c-44c0-b90e-4ce822821064"), "PlanetAtmosphere_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("b39252b2-4d62-4b5b-9c5e-a489f8b8074e"), "Planet_Volcano_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("53e62d02-ff0a-495c-b389-6ad85272fd1b"), "Planet_Volcano_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("ce883600-7148-40d0-b543-e21e3c9e8dc6"), "Planet_Volcano_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("a7b0b488-4150-4dee-8b1e-05322832aa2a"), "Test_Prefab", "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" }
                });

            migrationBuilder.InsertData(
                table: "PlanetAtmospherePrefabs",
                columns: new[] { "Id", "PlanetTypes" },
                values: new object[,]
                {
                    { new Guid("abfd9c26-7c91-4001-8e1e-6b0cb11e0632"), 1 },
                    { new Guid("5d52cf31-3931-4e41-b64f-62fe06cb5973"), 1 },
                    { new Guid("743d0b5c-6f0c-44c0-b90e-4ce822821064"), 6 }
                });

            migrationBuilder.InsertData(
                table: "PlanetPrefabs",
                columns: new[] { "Id", "PlanetType" },
                values: new object[,]
                {
                    { new Guid("b39252b2-4d62-4b5b-9c5e-a489f8b8074e"), 0 },
                    { new Guid("53e62d02-ff0a-495c-b389-6ad85272fd1b"), 0 },
                    { new Guid("ce883600-7148-40d0-b543-e21e3c9e8dc6"), 0 }
                });

            migrationBuilder.InsertData(
                table: "StarPrefabs",
                columns: new[] { "Id", "StarType" },
                values: new object[] { new Guid("a7b0b488-4150-4dee-8b1e-05322832aa2a"), 0 });
        }
    }
}
