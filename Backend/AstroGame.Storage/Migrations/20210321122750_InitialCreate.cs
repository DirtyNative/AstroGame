using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ConfirmationToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSpecies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SpeciesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpireName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredPlanetType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSpecies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NaturalOccurrenceWeight = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elements_Resources_Id",
                        column: x => x.Id,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ManufactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Resources_Id",
                        column: x => x.Id,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResourceManufactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    OutputMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutputValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceManufactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceManufactions_Materials_OutputMaterialId",
                        column: x => x.OutputMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutputMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InputValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputResources_ResourceManufactions_OutputMaterialId",
                        column: x => x.OutputMaterialId,
                        principalTable: "ResourceManufactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputResources_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StellarObjectResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    StellarObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false),
                    BlackHoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MoonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlanetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarObjectResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StellarObjectResources_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ColonizedStellarObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColonizedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StellarObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColonizedStellarObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColonizedStellarObjects_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PlanetType = table.Column<int>(type: "int", nullable: false),
                    Scale = table.Column<double>(type: "float", nullable: false),
                    AxialTilt = table.Column<double>(type: "float", nullable: false),
                    HasHabitableAtmosphere = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StellarSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    GalaxyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StellarSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StellarSystems_StellarSystems_StellarSystemId",
                        column: x => x.StellarSystemId,
                        principalTable: "StellarSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Galaxies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galaxies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Galaxies_StellarSystems_Id",
                        column: x => x.Id,
                        principalTable: "StellarSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MultiObjectSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiObjectSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiObjectSystems_StellarSystems_Id",
                        column: x => x.Id,
                        principalTable: "StellarSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MultiObjectSystems_StellarSystems_ParentId",
                        column: x => x.ParentId,
                        principalTable: "StellarSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolarSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGenerated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolarSystems_StellarSystems_Id",
                        column: x => x.Id,
                        principalTable: "StellarSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolarSystems_StellarSystems_ParentId",
                        column: x => x.ParentId,
                        principalTable: "StellarSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StellarObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ParentSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AverageDistanceToCenter = table.Column<double>(type: "float", nullable: true),
                    RotationSpeed = table.Column<double>(type: "float", nullable: false),
                    AverageTemperature = table.Column<int>(type: "int", nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coordinates = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StellarObjects_StellarSystems_ParentSystemId",
                        column: x => x.ParentSystemId,
                        principalTable: "StellarSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlackHoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlackHoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlackHoles_StellarObjects_Id",
                        column: x => x.Id,
                        principalTable: "StellarObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColonizableStellarObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ColonizedStellarObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColonizableStellarObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColonizableStellarObjects_StellarObjects_Id",
                        column: x => x.Id,
                        principalTable: "StellarObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Moons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Scale = table.Column<double>(type: "float", nullable: false),
                    AxialTilt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moons_StellarObjects_Id",
                        column: x => x.Id,
                        principalTable: "StellarObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    StarType = table.Column<int>(type: "int", nullable: false),
                    Scale = table.Column<double>(type: "float", nullable: false),
                    AxialTilt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stars_StellarObjects_Id",
                        column: x => x.Id,
                        principalTable: "StellarObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "ConfirmationToken", "Email", "Password", "Salt", "Username" },
                values: new object[] { new Guid("22222222-0000-0000-0000-000000000000"), null, "daniel@dirtyandnative.de", new byte[] { 214, 212, 211, 33, 140, 160, 231, 162, 57, 199, 64, 131, 187, 201, 119, 192, 203, 109, 243, 123, 229, 56, 47, 180, 17, 5, 138, 178, 72, 221, 137, 25, 69, 173, 181, 157, 202, 130, 182, 172, 20, 121, 129, 43, 136, 74, 120, 242, 126, 100, 62, 207, 24, 9, 244, 206, 7, 166, 63, 155, 128, 118, 47, 81 }, new byte[] { 193, 79, 225, 80, 112, 24, 191, 243, 40, 86, 90, 75, 6, 166, 103, 215, 30, 13, 70, 153, 161, 73, 23, 145, 154, 13, 46, 5, 245, 103, 100, 241 }, "DirtyNative" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "NaturalOccurrenceWeight" },
                values: new object[,]
                {
                    { new Guid("00000000-1111-0000-0000-000000000023"), "Palladium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000024"), "Silver", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000025"), "Tin", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000026"), "Iridium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000027"), "Platinum", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000028"), "Gold", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000029"), "Plutonium", 1L },
                    { new Guid("00000000-0000-1111-0000-000000000001"), "Water", 1L },
                    { new Guid("00000000-0000-1111-0000-000000000002"), "Food", 1L },
                    { new Guid("00000000-0000-1111-0000-000000000003"), "Luxury Goods", 1L },
                    { new Guid("00000000-1111-1111-0000-000000000001"), "Conductive Components", 1L },
                    { new Guid("00000000-1111-1111-0000-000000000002"), "Conductive Components", 1L },
                    { new Guid("00000000-1111-1111-0000-000000000003"), "Supra conductors", 1L },
                    { new Guid("00000000-2222-1111-0000-000000000001"), "Deuterium", 1L },
                    { new Guid("00000000-2222-1111-0000-000000000002"), "Tritium", 1L },
                    { new Guid("00000000-3333-1111-0000-000000000001"), "Hardened Iron", 0L },
                    { new Guid("00000000-3333-1111-0000-000000000002"), "Steel", 0L },
                    { new Guid("00000000-3333-1111-0000-000000000003"), "Nanites", 0L },
                    { new Guid("00000000-4444-1111-0000-000000000001"), "Reactive alloys", 0L },
                    { new Guid("00000000-1111-0000-0000-000000000022"), "Germanium", 1L },
                    { new Guid("00000000-4444-1111-0000-000000000002"), "Nano alloys", 0L },
                    { new Guid("00000000-1111-0000-0000-000000000021"), "Gallium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000019"), "Copper", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000001"), "Hydrogen", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000002"), "Helium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000003"), "Lithium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000004"), "Beryllium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000005"), "Boron", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000006"), "Carbon", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000007"), "Nitrogen", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000008"), "Oxygen", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000020"), "Zinc", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000009"), "Magnesium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000011"), "Silicon", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000012"), "Phosphorus", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000013"), "Sulfur", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000014"), "Chlorine", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000015"), "Titanium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000016"), "Iron", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000017"), "Cobalt", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000018"), "Nickel", 1L }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "NaturalOccurrenceWeight" },
                values: new object[] { new Guid("00000000-1111-0000-0000-000000000010"), "Aluminium", 1L });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "NaturalOccurrenceWeight" },
                values: new object[] { new Guid("00000000-5555-1111-0000-000000000001"), "Dark matter", 0L });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName" },
                values: new object[] { new Guid("22222222-2222-0000-0000-000000000000"), "image_1" });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Symbol", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-1111-0000-0000-000000000001"), "H", 0 },
                    { new Guid("00000000-1111-0000-0000-000000000029"), "Pu", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000028"), "Au", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000027"), "Pt", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000026"), "Ir", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000025"), "Sn", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000024"), "Ag", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000023"), "Pd", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000021"), "Ga", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000020"), "Zn", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000019"), "Cu", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000018"), "Ni", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000017"), "Co", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000016"), "Fe", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000022"), "Ge", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000014"), "Cl", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000015"), "Ti", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000003"), "Li", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000004"), "Be", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000005"), "B", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000006"), "C", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000007"), "N", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000002"), "He", 0 },
                    { new Guid("00000000-1111-0000-0000-000000000009"), "Mg", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000010"), "Al", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000011"), "Si", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000012"), "P", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000013"), "S", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000008"), "O", 0 }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "ManufactionId", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-4444-1111-0000-000000000002"), null, 3 },
                    { new Guid("00000000-4444-1111-0000-000000000001"), null, 3 },
                    { new Guid("00000000-3333-1111-0000-000000000003"), null, 0 },
                    { new Guid("00000000-3333-1111-0000-000000000002"), null, 0 },
                    { new Guid("00000000-3333-1111-0000-000000000001"), null, 0 },
                    { new Guid("00000000-2222-1111-0000-000000000002"), null, 4 },
                    { new Guid("00000000-1111-1111-0000-000000000001"), null, 2 },
                    { new Guid("00000000-1111-1111-0000-000000000003"), null, 2 },
                    { new Guid("00000000-1111-1111-0000-000000000002"), null, 2 },
                    { new Guid("00000000-0000-1111-0000-000000000003"), null, 1 },
                    { new Guid("00000000-0000-1111-0000-000000000002"), null, 1 },
                    { new Guid("00000000-0000-1111-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000001"), 1 },
                    { new Guid("00000000-2222-1111-0000-000000000001"), null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "ManufactionId", "Type" },
                values: new object[] { new Guid("00000000-5555-1111-0000-000000000001"), null, 0 });

            migrationBuilder.InsertData(
                table: "ResourceManufactions",
                columns: new[] { "Id", "OutputMaterialId", "OutputValue" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-1111-0000-000000000001"), 1.0 });

            migrationBuilder.InsertData(
                table: "InputResources",
                columns: new[] { "Id", "InputValue", "OutputMaterialId", "ResourceId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), 2.0, new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-1111-0000-0000-000000000001") });

            migrationBuilder.InsertData(
                table: "InputResources",
                columns: new[] { "Id", "InputValue", "OutputMaterialId", "ResourceId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), 2.0, new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-1111-0000-0000-000000000008") });

            migrationBuilder.CreateIndex(
                name: "IX_ColonizedStellarObjects_PlayerId",
                table: "ColonizedStellarObjects",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ColonizedStellarObjects_StellarObjectId",
                table: "ColonizedStellarObjects",
                column: "StellarObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InputResources_OutputMaterialId",
                table: "InputResources",
                column: "OutputMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InputResources_ResourceId",
                table: "InputResources",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiObjectSystems_ParentId",
                table: "MultiObjectSystems",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceManufactions_OutputMaterialId",
                table: "ResourceManufactions",
                column: "OutputMaterialId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolarSystems_ParentId",
                table: "SolarSystems",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_BlackHoleId",
                table: "StellarObjectResources",
                column: "BlackHoleId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_MoonId",
                table: "StellarObjectResources",
                column: "MoonId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_PlanetId",
                table: "StellarObjectResources",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_ResourceId",
                table: "StellarObjectResources",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_StarId",
                table: "StellarObjectResources",
                column: "StarId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_StellarObjectId",
                table: "StellarObjectResources",
                column: "StellarObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjects_ParentSystemId",
                table: "StellarObjects",
                column: "ParentSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystems_GalaxyId",
                table: "StellarSystems",
                column: "GalaxyId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystems_StellarSystemId",
                table: "StellarSystems",
                column: "StellarSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_BlackHoles_BlackHoleId",
                table: "StellarObjectResources",
                column: "BlackHoleId",
                principalTable: "BlackHoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_Moons_MoonId",
                table: "StellarObjectResources",
                column: "MoonId",
                principalTable: "Moons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_Planets_PlanetId",
                table: "StellarObjectResources",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_Stars_StarId",
                table: "StellarObjectResources",
                column: "StarId",
                principalTable: "Stars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_StellarObjects_StellarObjectId",
                table: "StellarObjectResources",
                column: "StellarObjectId",
                principalTable: "StellarObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ColonizedStellarObjects_ColonizableStellarObjects_StellarObjectId",
                table: "ColonizedStellarObjects",
                column: "StellarObjectId",
                principalTable: "ColonizableStellarObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_ColonizableStellarObjects_Id",
                table: "Planets",
                column: "Id",
                principalTable: "ColonizableStellarObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystems_Galaxies_GalaxyId",
                table: "StellarSystems",
                column: "GalaxyId",
                principalTable: "Galaxies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Galaxies_StellarSystems_Id",
                table: "Galaxies");

            migrationBuilder.DropTable(
                name: "ColonizedStellarObjects");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "InputResources");

            migrationBuilder.DropTable(
                name: "MultiObjectSystems");

            migrationBuilder.DropTable(
                name: "PlayerSpecies");

            migrationBuilder.DropTable(
                name: "SolarSystems");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "StellarObjectResources");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "ResourceManufactions");

            migrationBuilder.DropTable(
                name: "BlackHoles");

            migrationBuilder.DropTable(
                name: "Moons");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "Stars");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "ColonizableStellarObjects");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "StellarObjects");

            migrationBuilder.DropTable(
                name: "StellarSystems");

            migrationBuilder.DropTable(
                name: "Galaxies");
        }
    }
}
