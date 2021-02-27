using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class FlagFixes_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("2593675a-859b-4a4a-8678-3d2801ffbcc5"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("3d1dd449-6013-4e6e-9b28-a171029d5597"));

            migrationBuilder.DeleteData(
                table: "PlanetAtmospherePrefabs",
                keyColumn: "Id",
                keyValue: new Guid("bd1aa007-b63a-4d74-8ae4-f786df609b71"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
