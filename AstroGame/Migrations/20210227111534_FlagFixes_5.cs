using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class FlagFixes_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("2d017ee3-eb4c-4407-89a5-fd6ed44a7aa6"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("545f9a69-714b-459a-ae19-79a252002733"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("6146a8a2-396d-44c9-9518-dbc8096d1bfc"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("75f35538-07dc-4b36-b346-35093bf6f627"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("cb33f83a-d9f4-4951-a96b-99c7a1eb4975"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("0cd9ee22-25c6-4908-b619-c062b0008d1a"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("b9142578-71d5-4dde-a4a7-e1c5e8b5005c"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("d51de9bd-630e-4f62-b0f7-20677f1aadc7"));

            migrationBuilder.DeleteData(
                table: "StarPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("65cefac0-a0d6-4df9-a776-24fe542caeef"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("2d017ee3-eb4c-4407-89a5-fd6ed44a7aa6"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("545f9a69-714b-459a-ae19-79a252002733"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("6146a8a2-396d-44c9-9518-dbc8096d1bfc"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("75f35538-07dc-4b36-b346-35093bf6f627"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("cb33f83a-d9f4-4951-a96b-99c7a1eb4975"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("0cd9ee22-25c6-4908-b619-c062b0008d1a"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("b9142578-71d5-4dde-a4a7-e1c5e8b5005c"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("d51de9bd-630e-4f62-b0f7-20677f1aadc7"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("65cefac0-a0d6-4df9-a776-24fe542caeef"));

            migrationBuilder.AlterColumn<string>(
                name: "PlanetTypes",
                table: "PlanetAtmospherePrefabs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Prefabs",
                columns: new[] { "Id", "Name", "Offset", "Rotation", "Scale" },
                values: new object[,]
                {
                    { new Guid("6f0bae29-758a-4d04-99c4-89b4ae5f07aa"), "PlanetAtmosphere_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("676ab611-f1c5-43e4-a827-5a4b200feac5"), "PlanetAtmosphere_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("70e241c2-8928-4cfe-9838-7c54e0f32679"), "PlanetAtmosphere_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("e512efe1-b7f0-4c2f-96d0-5bca717a84fe"), "PlanetAtmosphere_4", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("29af04ad-d340-4e18-b999-7508ad5f9b6f"), "PlanetAtmosphere_5", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("a5f6805d-7ffd-48ba-9f9f-c3d5c9b174e1"), "Planet_Volcano_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("493ffc24-8d16-4327-81f1-b2655f078835"), "Planet_Volcano_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("ad9bfa87-913b-431b-ad12-7b1c46f653f7"), "Planet_Volcano_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("a2db60f9-9a8d-49c7-bc71-678280b3cb9e"), "Test_Prefab", "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" }
                });

            migrationBuilder.InsertData(
                table: "PlanetAtmospherePrefabs",
                columns: new[] { "Id", "PlanetTypes" },
                values: new object[,]
                {
                    { new Guid("6f0bae29-758a-4d04-99c4-89b4ae5f07aa"), "Volcano;Desert" },
                    { new Guid("676ab611-f1c5-43e4-a827-5a4b200feac5"), "Volcano;Desert" },
                    { new Guid("70e241c2-8928-4cfe-9838-7c54e0f32679"), "Continental;Rock" },
                    { new Guid("e512efe1-b7f0-4c2f-96d0-5bca717a84fe"), "Gaia;Gas" },
                    { new Guid("29af04ad-d340-4e18-b999-7508ad5f9b6f"), "Ocean;Ice" }
                });

            migrationBuilder.InsertData(
                table: "PlanetPrefabs",
                columns: new[] { "Id", "PlanetType" },
                values: new object[,]
                {
                    { new Guid("a5f6805d-7ffd-48ba-9f9f-c3d5c9b174e1"), 0 },
                    { new Guid("493ffc24-8d16-4327-81f1-b2655f078835"), 0 },
                    { new Guid("ad9bfa87-913b-431b-ad12-7b1c46f653f7"), 0 }
                });

            migrationBuilder.InsertData(
                table: "StarPrefabs",
                columns: new[] { "Id", "StarType" },
                values: new object[] { new Guid("a2db60f9-9a8d-49c7-bc71-678280b3cb9e"), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("29af04ad-d340-4e18-b999-7508ad5f9b6f"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("676ab611-f1c5-43e4-a827-5a4b200feac5"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("6f0bae29-758a-4d04-99c4-89b4ae5f07aa"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("70e241c2-8928-4cfe-9838-7c54e0f32679"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("e512efe1-b7f0-4c2f-96d0-5bca717a84fe"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("493ffc24-8d16-4327-81f1-b2655f078835"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("a5f6805d-7ffd-48ba-9f9f-c3d5c9b174e1"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("ad9bfa87-913b-431b-ad12-7b1c46f653f7"));

            migrationBuilder.DeleteData(
                table: "StarPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("a2db60f9-9a8d-49c7-bc71-678280b3cb9e"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("29af04ad-d340-4e18-b999-7508ad5f9b6f"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("676ab611-f1c5-43e4-a827-5a4b200feac5"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("6f0bae29-758a-4d04-99c4-89b4ae5f07aa"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("70e241c2-8928-4cfe-9838-7c54e0f32679"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("e512efe1-b7f0-4c2f-96d0-5bca717a84fe"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("493ffc24-8d16-4327-81f1-b2655f078835"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("a5f6805d-7ffd-48ba-9f9f-c3d5c9b174e1"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("ad9bfa87-913b-431b-ad12-7b1c46f653f7"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("a2db60f9-9a8d-49c7-bc71-678280b3cb9e"));

            migrationBuilder.AlterColumn<string>(
                name: "PlanetTypes",
                table: "PlanetAtmospherePrefabs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Prefabs",
                columns: new[] { "Id", "Name", "Offset", "Rotation", "Scale" },
                values: new object[,]
                {
                    { new Guid("6146a8a2-396d-44c9-9518-dbc8096d1bfc"), "PlanetAtmosphere_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("75f35538-07dc-4b36-b346-35093bf6f627"), "PlanetAtmosphere_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("cb33f83a-d9f4-4951-a96b-99c7a1eb4975"), "PlanetAtmosphere_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("2d017ee3-eb4c-4407-89a5-fd6ed44a7aa6"), "PlanetAtmosphere_4", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("545f9a69-714b-459a-ae19-79a252002733"), "PlanetAtmosphere_5", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("b9142578-71d5-4dde-a4a7-e1c5e8b5005c"), "Planet_Volcano_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("0cd9ee22-25c6-4908-b619-c062b0008d1a"), "Planet_Volcano_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("d51de9bd-630e-4f62-b0f7-20677f1aadc7"), "Planet_Volcano_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("65cefac0-a0d6-4df9-a776-24fe542caeef"), "Test_Prefab", "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" }
                });

            migrationBuilder.InsertData(
                table: "PlanetAtmospherePrefabs",
                columns: new[] { "Id", "PlanetTypes" },
                values: new object[,]
                {
                    { new Guid("6146a8a2-396d-44c9-9518-dbc8096d1bfc"), "Desert" },
                    { new Guid("75f35538-07dc-4b36-b346-35093bf6f627"), "Desert" },
                    { new Guid("cb33f83a-d9f4-4951-a96b-99c7a1eb4975"), "Ice" },
                    { new Guid("2d017ee3-eb4c-4407-89a5-fd6ed44a7aa6"), "Gaia" },
                    { new Guid("545f9a69-714b-459a-ae19-79a252002733"), "Gaia" }
                });

            migrationBuilder.InsertData(
                table: "PlanetPrefabs",
                columns: new[] { "Id", "PlanetType" },
                values: new object[,]
                {
                    { new Guid("b9142578-71d5-4dde-a4a7-e1c5e8b5005c"), 0 },
                    { new Guid("0cd9ee22-25c6-4908-b619-c062b0008d1a"), 0 },
                    { new Guid("d51de9bd-630e-4f62-b0f7-20677f1aadc7"), 0 }
                });

            migrationBuilder.InsertData(
                table: "StarPrefabs",
                columns: new[] { "Id", "StarType" },
                values: new object[] { new Guid("65cefac0-a0d6-4df9-a776-24fe542caeef"), 0 });
        }
    }
}
