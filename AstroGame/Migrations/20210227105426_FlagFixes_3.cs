using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class FlagFixes_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "PlanetTypes",
                table: "PlanetAtmospherePrefabs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "PlanetTypes",
                table: "PlanetAtmospherePrefabs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
    }
}
