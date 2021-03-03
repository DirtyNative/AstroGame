using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "StellarObject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ParentSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AverageDistanceToCenter = table.Column<double>(type: "float", nullable: true),
                    RotationSpeed = table.Column<double>(type: "float", nullable: false),
                    AverageTemperature = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarObject", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "Moons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Scale = table.Column<double>(type: "float", nullable: false),
                    AxialTilt = table.Column<double>(type: "float", nullable: false),
                    PrefabId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RingPrefabId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RingsPrefabId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moons_MoonPrefabs_PrefabId",
                        column: x => x.PrefabId,
                        principalTable: "MoonPrefabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Moons_RingsPrefabs_RingsPrefabId",
                        column: x => x.RingsPrefabId,
                        principalTable: "RingsPrefabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moons_StellarObject_Id",
                        column: x => x.Id,
                        principalTable: "StellarObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PlanetType = table.Column<int>(type: "int", nullable: false),
                    PrefabId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Scale = table.Column<double>(type: "float", nullable: false),
                    AxialTilt = table.Column<double>(type: "float", nullable: false),
                    AtmospherePrefabId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RingPrefabId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CloudsPrefabId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planets_CloudsPrefabs_CloudsPrefabId",
                        column: x => x.CloudsPrefabId,
                        principalTable: "CloudsPrefabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planets_PlanetAtmospherePrefabs_AtmospherePrefabId",
                        column: x => x.AtmospherePrefabId,
                        principalTable: "PlanetAtmospherePrefabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planets_PlanetPrefabs_PrefabId",
                        column: x => x.PrefabId,
                        principalTable: "PlanetPrefabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Planets_RingsPrefabs_RingPrefabId",
                        column: x => x.RingPrefabId,
                        principalTable: "RingsPrefabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planets_StellarObject_Id",
                        column: x => x.Id,
                        principalTable: "StellarObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    StarType = table.Column<int>(type: "int", nullable: false),
                    PrefabId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Scale = table.Column<double>(type: "float", nullable: false),
                    AxialTilt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stars_StarPrefabs_PrefabId",
                        column: x => x.PrefabId,
                        principalTable: "StarPrefabs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stars_StellarObject_Id",
                        column: x => x.Id,
                        principalTable: "StellarObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolarSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StellarSystem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    MultiObjectSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StellarSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarSystem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StellarSystem_StellarSystem_ParentId",
                        column: x => x.ParentId,
                        principalTable: "StellarSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StellarSystem_StellarSystem_StellarSystemId",
                        column: x => x.StellarSystemId,
                        principalTable: "StellarSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MultiObjectSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiObjectSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiObjectSystems_StellarSystem_Id",
                        column: x => x.Id,
                        principalTable: "StellarSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SingleObjectSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CenterObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleObjectSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleObjectSystems_StellarObject_CenterObjectId",
                        column: x => x.CenterObjectId,
                        principalTable: "StellarObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SingleObjectSystems_StellarSystem_Id",
                        column: x => x.Id,
                        principalTable: "StellarSystem",
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
                name: "IX_Moons_PrefabId",
                table: "Moons",
                column: "PrefabId");

            migrationBuilder.CreateIndex(
                name: "IX_Moons_RingsPrefabId",
                table: "Moons",
                column: "RingsPrefabId");

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
                name: "IX_SingleObjectSystems_CenterObjectId",
                table: "SingleObjectSystems",
                column: "CenterObjectId",
                unique: true,
                filter: "[CenterObjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Stars_PrefabId",
                table: "Stars",
                column: "PrefabId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystem_MultiObjectSystemId",
                table: "StellarSystem",
                column: "MultiObjectSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystem_ParentId",
                table: "StellarSystem",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystem_StellarSystemId",
                table: "StellarSystem",
                column: "StellarSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolarSystems_MultiObjectSystems_Id",
                table: "SolarSystems",
                column: "Id",
                principalTable: "MultiObjectSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystem_MultiObjectSystems_MultiObjectSystemId",
                table: "StellarSystem",
                column: "MultiObjectSystemId",
                principalTable: "MultiObjectSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MultiObjectSystems_StellarSystem_Id",
                table: "MultiObjectSystems");

            migrationBuilder.DropTable(
                name: "Moons");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "SingleObjectSystems");

            migrationBuilder.DropTable(
                name: "SolarSystems");

            migrationBuilder.DropTable(
                name: "Stars");

            migrationBuilder.DropTable(
                name: "MoonPrefabs");

            migrationBuilder.DropTable(
                name: "CloudsPrefabs");

            migrationBuilder.DropTable(
                name: "PlanetAtmospherePrefabs");

            migrationBuilder.DropTable(
                name: "PlanetPrefabs");

            migrationBuilder.DropTable(
                name: "RingsPrefabs");

            migrationBuilder.DropTable(
                name: "StarPrefabs");

            migrationBuilder.DropTable(
                name: "StellarObject");

            migrationBuilder.DropTable(
                name: "Prefab");

            migrationBuilder.DropTable(
                name: "StellarSystem");

            migrationBuilder.DropTable(
                name: "MultiObjectSystems");
        }
    }
}
