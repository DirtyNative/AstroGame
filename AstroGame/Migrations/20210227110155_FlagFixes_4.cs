using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class FlagFixes_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("237fd5fb-0e38-438c-9853-eeec215d290f"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("4ec2899f-8ba6-4bbd-a770-59e2ccb2ab87"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("53bd7280-8d81-420c-a6f8-de2b40446777"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("d3272ee8-09c5-4b14-ab71-fb0bee1043ef"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("f3c2a6f0-cf02-4924-910c-e3155d903be3"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("5cd152de-18db-4cce-a7e1-9a05917820e9"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("6f49bbb3-500f-41cb-9a97-0560a9326211"));

            migrationBuilder.DeleteData(
                table: "PlanetPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("fda627ac-5127-47c0-a572-059b4b59a307"));

            migrationBuilder.DeleteData(
                table: "StarPrefabs",
                keyColumn: "Id",
                keyValue: new Guid("69b7b900-b83e-4573-a4a6-af5507112d72"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("237fd5fb-0e38-438c-9853-eeec215d290f"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("4ec2899f-8ba6-4bbd-a770-59e2ccb2ab87"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("53bd7280-8d81-420c-a6f8-de2b40446777"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("d3272ee8-09c5-4b14-ab71-fb0bee1043ef"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("f3c2a6f0-cf02-4924-910c-e3155d903be3"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("5cd152de-18db-4cce-a7e1-9a05917820e9"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("6f49bbb3-500f-41cb-9a97-0560a9326211"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("fda627ac-5127-47c0-a572-059b4b59a307"));

            migrationBuilder.DeleteData(
                table: "Prefabs",
                keyColumn: "Id",
                keyValue: new Guid("69b7b900-b83e-4573-a4a6-af5507112d72"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Prefabs",
                columns: new[] { "Id", "Name", "Offset", "Rotation", "Scale" },
                values: new object[,]
                {
                    { new Guid("237fd5fb-0e38-438c-9853-eeec215d290f"), "PlanetAtmosphere_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("f3c2a6f0-cf02-4924-910c-e3155d903be3"), "PlanetAtmosphere_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("4ec2899f-8ba6-4bbd-a770-59e2ccb2ab87"), "PlanetAtmosphere_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("53bd7280-8d81-420c-a6f8-de2b40446777"), "PlanetAtmosphere_4", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("d3272ee8-09c5-4b14-ab71-fb0bee1043ef"), "PlanetAtmosphere_5", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("fda627ac-5127-47c0-a572-059b4b59a307"), "Planet_Volcano_1", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("5cd152de-18db-4cce-a7e1-9a05917820e9"), "Planet_Volcano_2", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("6f49bbb3-500f-41cb-9a97-0560a9326211"), "Planet_Volcano_3", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" },
                    { new Guid("69b7b900-b83e-4573-a4a6-af5507112d72"), "Test_Prefab", "(0.0, 0.0, -1.0)", "(-1.0, 0.0, 0.0)", "(0.0, 0.0, 0.0)" }
                });

            migrationBuilder.InsertData(
                table: "PlanetAtmospherePrefabs",
                columns: new[] { "Id", "PlanetTypes" },
                values: new object[,]
                {
                    { new Guid("237fd5fb-0e38-438c-9853-eeec215d290f"), "Desert" },
                    { new Guid("f3c2a6f0-cf02-4924-910c-e3155d903be3"), "Desert" },
                    { new Guid("4ec2899f-8ba6-4bbd-a770-59e2ccb2ab87"), "Ice" },
                    { new Guid("53bd7280-8d81-420c-a6f8-de2b40446777"), "Gaia" },
                    { new Guid("d3272ee8-09c5-4b14-ab71-fb0bee1043ef"), "Gaia" }
                });

            migrationBuilder.InsertData(
                table: "PlanetPrefabs",
                columns: new[] { "Id", "PlanetType" },
                values: new object[,]
                {
                    { new Guid("fda627ac-5127-47c0-a572-059b4b59a307"), 0 },
                    { new Guid("5cd152de-18db-4cce-a7e1-9a05917820e9"), 0 },
                    { new Guid("6f49bbb3-500f-41cb-9a97-0560a9326211"), 0 }
                });

            migrationBuilder.InsertData(
                table: "StarPrefabs",
                columns: new[] { "Id", "StarType" },
                values: new object[] { new Guid("69b7b900-b83e-4573-a4a6-af5507112d72"), 0 });
        }
    }
}
