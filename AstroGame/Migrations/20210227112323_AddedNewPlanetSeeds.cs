using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class AddedNewPlanetSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Prefabs",
                columns: new[] { "Id", "Name", "Offset", "Rotation", "Scale" },
                values: new object[,]
                {
                    { new Guid("0b8890de-871e-4311-aece-2f21753729e1"), "PlanetAtmosphere_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("09922780-2cc3-488f-9c13-4af2d22d33ff"), "Planet_Ice_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("354bbd15-0c08-4aea-80b9-209ab83e927b"), "Planet_Ice_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("c2acb104-da0c-478c-9f3a-2d3a57a515f3"), "Planet_Ocean_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("e09a7f0c-257c-48b3-be44-2d4c2afce354"), "Planet_Ocean_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("1670f160-8a03-4f8d-b27d-80eb6e0ecba1"), "Planet_Ocean_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("fc5a8037-2d52-40a2-9826-1596a6a4e082"), "Planet_Gas_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("57148810-014d-443b-8527-71d6cec2fe03"), "Planet_Gas_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("6fa513cb-805d-45ae-a160-c5fa44665927"), "Planet_Gas_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("6fa22d3a-0f7a-4393-b018-77fecb105d85"), "Planet_Gaia_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("56104a60-24a2-425c-ad30-bd2ae0ba090e"), "Planet_Gaia_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("a291133c-382b-4f39-a6f0-2e6f169c0e83"), "Planet_Gaia_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("7624981b-256b-450a-ac9c-0f9f1478515f"), "Planet_Rock_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("2f200a89-e250-4b8d-9a7f-8524e3e1c543"), "Planet_Rock_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("04c70207-f837-4b5e-b084-6a2e4a75e995"), "Planet_Rock_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("d765f76b-4077-497c-89b4-34ddad873836"), "Planet_Continental_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("6eefab37-6adf-4426-ac6b-56ac863d1f5d"), "Planet_Continental_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("ad491dc6-8110-48e3-b88b-c049ce075156"), "Planet_Continental_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("d86f58a5-a331-46ca-945f-009fbef3a340"), "Planet_Desert_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("91ce3322-93eb-4de9-99c2-d64d966297e5"), "Planet_Desert_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("952b27f4-5973-47ea-bbf5-9ebe4ba6be4b"), "Planet_Desert_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("9c29d7f1-2849-4f75-88f1-a52781ef7f74"), "Planet_Volcano_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("fd0f193d-7a61-478b-85d7-a6e0f3475452"), "Planet_Volcano_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("45a16db0-05a1-4ea9-bcaa-0c5b59b09213"), "Planet_Volcano_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("6735c3b7-86ed-45d6-909a-ed825f9dfda6"), "PlanetAtmosphere_5", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("e12a9841-e36d-4436-b60d-868abf86c95c"), "PlanetAtmosphere_4", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("e41f15ec-441c-4c2b-8cd2-bb8e6acecde7"), "PlanetAtmosphere_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("79acdded-e2a6-4d69-9d59-cd08ee35c011"), "PlanetAtmosphere_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("3e982d58-019c-4f97-9dd7-9fa20068573d"), "Planet_Ice_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("ca86d224-4247-428f-a7dd-d5088ef0f634"), "Test_Prefab", "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" }
                });

            migrationBuilder.InsertData(
                table: "PlanetAtmospherePrefabs",
                columns: new[] { "Id", "PlanetTypes" },
                values: new object[,]
                {
                    { new Guid("0b8890de-871e-4311-aece-2f21753729e1"), "Volcano;Desert" },
                    { new Guid("79acdded-e2a6-4d69-9d59-cd08ee35c011"), "Volcano;Desert" },
                    { new Guid("e41f15ec-441c-4c2b-8cd2-bb8e6acecde7"), "Continental;Rock" },
                    { new Guid("e12a9841-e36d-4436-b60d-868abf86c95c"), "Gaia;Gas" },
                    { new Guid("6735c3b7-86ed-45d6-909a-ed825f9dfda6"), "Ocean;Ice" }
                });

            migrationBuilder.InsertData(
                table: "PlanetPrefabs",
                columns: new[] { "Id", "PlanetType" },
                values: new object[,]
                {
                    { new Guid("09922780-2cc3-488f-9c13-4af2d22d33ff"), 6 },
                    { new Guid("354bbd15-0c08-4aea-80b9-209ab83e927b"), 6 },
                    { new Guid("c2acb104-da0c-478c-9f3a-2d3a57a515f3"), 3 },
                    { new Guid("e09a7f0c-257c-48b3-be44-2d4c2afce354"), 3 },
                    { new Guid("1670f160-8a03-4f8d-b27d-80eb6e0ecba1"), 3 },
                    { new Guid("fc5a8037-2d52-40a2-9826-1596a6a4e082"), 5 },
                    { new Guid("57148810-014d-443b-8527-71d6cec2fe03"), 5 },
                    { new Guid("6fa513cb-805d-45ae-a160-c5fa44665927"), 5 },
                    { new Guid("6fa22d3a-0f7a-4393-b018-77fecb105d85"), 7 },
                    { new Guid("56104a60-24a2-425c-ad30-bd2ae0ba090e"), 7 },
                    { new Guid("a291133c-382b-4f39-a6f0-2e6f169c0e83"), 7 },
                    { new Guid("04c70207-f837-4b5e-b084-6a2e4a75e995"), 4 },
                    { new Guid("2f200a89-e250-4b8d-9a7f-8524e3e1c543"), 4 },
                    { new Guid("3e982d58-019c-4f97-9dd7-9fa20068573d"), 6 },
                    { new Guid("d765f76b-4077-497c-89b4-34ddad873836"), 2 },
                    { new Guid("6eefab37-6adf-4426-ac6b-56ac863d1f5d"), 2 },
                    { new Guid("ad491dc6-8110-48e3-b88b-c049ce075156"), 2 },
                    { new Guid("d86f58a5-a331-46ca-945f-009fbef3a340"), 1 },
                    { new Guid("91ce3322-93eb-4de9-99c2-d64d966297e5"), 1 },
                    { new Guid("952b27f4-5973-47ea-bbf5-9ebe4ba6be4b"), 1 },
                    { new Guid("9c29d7f1-2849-4f75-88f1-a52781ef7f74"), 0 },
                    { new Guid("fd0f193d-7a61-478b-85d7-a6e0f3475452"), 0 },
                    { new Guid("45a16db0-05a1-4ea9-bcaa-0c5b59b09213"), 0 },
                    { new Guid("7624981b-256b-450a-ac9c-0f9f1478515f"), 4 }
                });

            migrationBuilder.InsertData(
                table: "StarPrefabs",
                columns: new[] { "Id", "StarType" },
                values: new object[] { new Guid("ca86d224-4247-428f-a7dd-d5088ef0f634"), 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("0b8890de-871e-4311-aece-2f21753729e1"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("6735c3b7-86ed-45d6-909a-ed825f9dfda6"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("79acdded-e2a6-4d69-9d59-cd08ee35c011"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("e12a9841-e36d-4436-b60d-868abf86c95c"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("e41f15ec-441c-4c2b-8cd2-bb8e6acecde7"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("04c70207-f837-4b5e-b084-6a2e4a75e995"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("09922780-2cc3-488f-9c13-4af2d22d33ff"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("1670f160-8a03-4f8d-b27d-80eb6e0ecba1"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("2f200a89-e250-4b8d-9a7f-8524e3e1c543"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("354bbd15-0c08-4aea-80b9-209ab83e927b"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("3e982d58-019c-4f97-9dd7-9fa20068573d"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("45a16db0-05a1-4ea9-bcaa-0c5b59b09213"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("56104a60-24a2-425c-ad30-bd2ae0ba090e"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("57148810-014d-443b-8527-71d6cec2fe03"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("6eefab37-6adf-4426-ac6b-56ac863d1f5d"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("6fa22d3a-0f7a-4393-b018-77fecb105d85"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("6fa513cb-805d-45ae-a160-c5fa44665927"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("7624981b-256b-450a-ac9c-0f9f1478515f"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("91ce3322-93eb-4de9-99c2-d64d966297e5"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("952b27f4-5973-47ea-bbf5-9ebe4ba6be4b"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("9c29d7f1-2849-4f75-88f1-a52781ef7f74"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("a291133c-382b-4f39-a6f0-2e6f169c0e83"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("ad491dc6-8110-48e3-b88b-c049ce075156"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("c2acb104-da0c-478c-9f3a-2d3a57a515f3"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("d765f76b-4077-497c-89b4-34ddad873836"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("d86f58a5-a331-46ca-945f-009fbef3a340"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("e09a7f0c-257c-48b3-be44-2d4c2afce354"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("fc5a8037-2d52-40a2-9826-1596a6a4e082"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("fd0f193d-7a61-478b-85d7-a6e0f3475452"));

            migrationBuilder.DeleteData(
                table: "StarPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("ca86d224-4247-428f-a7dd-d5088ef0f634"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("0b8890de-871e-4311-aece-2f21753729e1"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("6735c3b7-86ed-45d6-909a-ed825f9dfda6"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("79acdded-e2a6-4d69-9d59-cd08ee35c011"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("e12a9841-e36d-4436-b60d-868abf86c95c"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("e41f15ec-441c-4c2b-8cd2-bb8e6acecde7"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("04c70207-f837-4b5e-b084-6a2e4a75e995"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("09922780-2cc3-488f-9c13-4af2d22d33ff"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("1670f160-8a03-4f8d-b27d-80eb6e0ecba1"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("2f200a89-e250-4b8d-9a7f-8524e3e1c543"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("354bbd15-0c08-4aea-80b9-209ab83e927b"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("3e982d58-019c-4f97-9dd7-9fa20068573d"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("45a16db0-05a1-4ea9-bcaa-0c5b59b09213"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("56104a60-24a2-425c-ad30-bd2ae0ba090e"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("57148810-014d-443b-8527-71d6cec2fe03"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("6eefab37-6adf-4426-ac6b-56ac863d1f5d"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("6fa22d3a-0f7a-4393-b018-77fecb105d85"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("6fa513cb-805d-45ae-a160-c5fa44665927"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("7624981b-256b-450a-ac9c-0f9f1478515f"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("91ce3322-93eb-4de9-99c2-d64d966297e5"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("952b27f4-5973-47ea-bbf5-9ebe4ba6be4b"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("9c29d7f1-2849-4f75-88f1-a52781ef7f74"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("a291133c-382b-4f39-a6f0-2e6f169c0e83"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("ad491dc6-8110-48e3-b88b-c049ce075156"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("c2acb104-da0c-478c-9f3a-2d3a57a515f3"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("d765f76b-4077-497c-89b4-34ddad873836"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("d86f58a5-a331-46ca-945f-009fbef3a340"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("e09a7f0c-257c-48b3-be44-2d4c2afce354"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("fc5a8037-2d52-40a2-9826-1596a6a4e082"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("fd0f193d-7a61-478b-85d7-a6e0f3475452"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("ca86d224-4247-428f-a7dd-d5088ef0f634"));

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
    }
}
