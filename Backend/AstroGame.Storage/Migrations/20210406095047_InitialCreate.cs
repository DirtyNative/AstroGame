using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    BuildableOn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingSpeedMultiplier = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    EngineersResearchSpeedMultiplier = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    PhysicsResearchSpeedMultiplier = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    BiologicalResearchSpeedMultiplier = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    BuildingMaterialsProductionSpeed = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    ConsumablesProductionSpeedMultiplier = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    ComponentsProductionSpeedMultiplier = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    AlloysProductionSpeedMultiplier = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    FuelsProductionSpeedMultiplier = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    BuildingMaterialsProductionValueMultiplier = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    ConsumablesProductionValueMultiplier = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    ComponentsProductionValueMultiplier = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    AlloysProductionValueMultiplier = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0),
                    FuelsProductionValueMultiplier = table.Column<double>(type: "float", nullable: false, defaultValue: 1.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerSpeciesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BuildingChainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
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
                    SpeciesType = table.Column<int>(type: "int", nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionBuildings_Buildings_Id",
                        column: x => x.Id,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StorageBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageBuildings_Buildings_Id",
                        column: x => x.Id,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuildingChains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChainLength = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingChains", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingChains_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
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
                name: "Credentials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credentials_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuildingCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseValue = table.Column<double>(type: "float", nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingCosts_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingCosts_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Type = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_PlayerSpecies_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerSpecies_Species_SpeciesId",
                        column: x => x.SpeciesId,
                        principalTable: "Species",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InputResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseValue = table.Column<double>(type: "float", nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputResources_ProductionBuildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "ProductionBuildings",
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
                name: "OutputResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseValue = table.Column<double>(type: "float", nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputResources_ProductionBuildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "ProductionBuildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutputResources_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BuiltBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColonizedStellarObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuiltBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuiltBuildings_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuiltBuildings_ColonizedStellarObjects_ColonizedStellarObjectId",
                        column: x => x.ColonizedStellarObjectId,
                        principalTable: "ColonizedStellarObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSpeciesPerks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PlayerSpeciesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerkId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSpeciesPerks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerSpeciesPerks_Perks_PerkId",
                        column: x => x.PerkId,
                        principalTable: "Perks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerSpeciesPerks_PlayerSpecies_PlayerSpeciesId",
                        column: x => x.PlayerSpeciesId,
                        principalTable: "PlayerSpecies",
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
                name: "BuildingConstructions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    BuildingChainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StellarObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HangfireJobId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingConstructions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingConstructions_BuildingChains_BuildingChainId",
                        column: x => x.BuildingChainId,
                        principalTable: "BuildingChains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingConstructions_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
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
                        name: "FK_ColonizableStellarObjects_ColonizedStellarObjects_ColonizedStellarObjectId",
                        column: x => x.ColonizedStellarObjectId,
                        principalTable: "ColonizedStellarObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "ResourceSnapshots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    StellarObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SnapshotTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceSnapshots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceSnapshots_StellarObjects_StellarObjectId",
                        column: x => x.StellarObjectId,
                        principalTable: "StellarObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "StoredResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourceSnapshotId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    HourlyAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoredResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoredResources_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoredResources_ResourceSnapshots_ResourceSnapshotId",
                        column: x => x.ResourceSnapshotId,
                        principalTable: "ResourceSnapshots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "AssetName", "BuildableOn", "Description", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"), "2.jpg", 2, "Produces the most basic building material ever seen in space.. But we all need it everywhere.", "Iron Mine", 1 },
                    { new Guid("8a0a5dab-f877-4714-8e6b-1b578f480268"), "6.jpg", 2, "Extracts Hydrogen molecules from within the atmosphere to produce an industrial product.", "Hydrogen Extractor", 2 },
                    { new Guid("e200ef94-6eb9-46c8-ba08-3dd86ac3b373"), "7.jpg", 2, "We need silicon to produce electronics which we need for quiet all of our constructs.", "Silicon Mine", 3 },
                    { new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"), "9.jpg", 2, "Helium is one of the most important parts to generate fuels.", "Helium Extractor", 4 },
                    { new Guid("44517245-cb20-4324-a275-4d8642207ad4"), "11.jpg", 2, "TODO", "Aluminum smelting plant", 4 },
                    { new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"), "17.jpg", 2, "TODO", "Titanium Mine", 4 },
                    { new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"), "18.jpg", 2, "TODO", "Iridium Mine", 4 },
                    { new Guid("f09e72d5-28d8-4390-bdf5-3b589b61fc15"), "19.jpg", 2, "TODO", "Iron Store", 1 }
                });

            migrationBuilder.InsertData(
                table: "Perks",
                columns: new[] { "Id", "BiologicalResearchSpeedMultiplier", "Description", "EngineersResearchSpeedMultiplier", "PhysicsResearchSpeedMultiplier", "Title" },
                values: new object[] { new Guid("00000000-0000-1111-0000-326db14a91f9"), 0.94999999999999996, "\"We're good at everything, but not with something specific.\" Well..", 0.94999999999999996, 0.94999999999999996, "Intelligent" });

            migrationBuilder.InsertData(
                table: "Perks",
                columns: new[] { "Id", "Description", "PhysicsResearchSpeedMultiplier", "Title" },
                values: new object[] { new Guid("00000000-0000-1111-0000-cb67c0894e44"), "Ever wanted to fly into a black hole? Well your species does!", 0.84999999999999998, "Natural Physicists" });

            migrationBuilder.InsertData(
                table: "Perks",
                columns: new[] { "Id", "Description", "EngineersResearchSpeedMultiplier", "Title" },
                values: new object[] { new Guid("00000000-0000-1111-0000-551336d46b5d"), "Absolute nerds, which love robots and automatism. Hopefully not too much", 0.84999999999999998, "Natural Engineers" });

            migrationBuilder.InsertData(
                table: "Perks",
                columns: new[] { "Id", "BuildingSpeedMultiplier", "Description", "Title" },
                values: new object[] { new Guid("00000000-0000-1111-0000-6712d7115748"), 0.90000000000000002, "Building big constructs is a no-brainer for your species.", "Fast builder" });

            migrationBuilder.InsertData(
                table: "Perks",
                columns: new[] { "Id", "BiologicalResearchSpeedMultiplier", "Description", "Title" },
                values: new object[] { new Guid("00000000-0000-1111-0000-dadcd19d28e3"), 0.84999999999999998, "Your species loves to inspect other creatures, and so does with species from other planets.", "Natural Sociologists" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BuildingChainId", "ConfirmationToken", "PlayerSpeciesId", "Username" },
                values: new object[] { new Guid("22222222-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("22222222-1111-0000-0000-000000000000"), "DirtyNative" });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "NaturalOccurrenceWeight" },
                values: new object[,]
                {
                    { new Guid("00000000-1111-0000-0000-000000000012"), "Phosphorus", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000019"), "Copper", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000018"), "Nickel", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000017"), "Cobalt", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000016"), "Iron", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000015"), "Titanium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000014"), "Chlorine", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000013"), "Sulfur", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000011"), "Silicon", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000004"), "Beryllium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000009"), "Magnesium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000008"), "Oxygen", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000007"), "Nitrogen", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000006"), "Carbon", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000005"), "Boron", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000020"), "Zinc", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000003"), "Lithium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000002"), "Helium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000010"), "Aluminum", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000021"), "Gallium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000028"), "Gold", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000023"), "Palladium", 1L },
                    { new Guid("00000000-4444-1111-0000-000000000002"), "Nano alloys", 0L },
                    { new Guid("00000000-4444-1111-0000-000000000001"), "Reactive alloys", 0L },
                    { new Guid("00000000-3333-1111-0000-000000000003"), "Nanites", 0L },
                    { new Guid("00000000-3333-1111-0000-000000000002"), "Steel", 0L },
                    { new Guid("00000000-2222-1111-0000-000000000002"), "Tritium", 1L },
                    { new Guid("00000000-2222-1111-0000-000000000001"), "Deuterium", 1L }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "NaturalOccurrenceWeight" },
                values: new object[,]
                {
                    { new Guid("00000000-1111-1111-0000-000000000003"), "Supra conductors", 1L },
                    { new Guid("00000000-1111-1111-0000-000000000002"), "Conductive Components", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000022"), "Germanium", 1L },
                    { new Guid("00000000-1111-1111-0000-000000000001"), "Conductive Components", 1L },
                    { new Guid("00000000-0000-1111-0000-000000000002"), "Food", 1L },
                    { new Guid("00000000-0000-1111-0000-000000000001"), "Water", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000029"), "Plutonium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000001"), "Hydrogen", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000027"), "Platinum", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000026"), "Iridium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000025"), "Tin", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000024"), "Silver", 1L },
                    { new Guid("00000000-0000-1111-0000-000000000003"), "Luxury Goods", 1L },
                    { new Guid("00000000-5555-1111-0000-000000000001"), "Dark matter", 0L },
                    { new Guid("00000000-5555-1111-0000-000000000002"), "Antimatter", 0L }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName", "SpeciesType" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-0000-0005-d7b41cfdaf76"), "Fungoid_17.png", 11 },
                    { new Guid("22222222-2222-0000-0005-30f42f709914"), "Reptilian_massive_11.png", 9 },
                    { new Guid("22222222-2222-0000-0005-79db1e8cde80"), "Reptilian_massive_12.png", 9 },
                    { new Guid("22222222-2222-0000-0005-a39ce2042ab3"), "Reptilian_massive_13.png", 9 },
                    { new Guid("22222222-2222-0000-0005-a6ad7d9f57d4"), "Reptilian_massive_14.png", 9 },
                    { new Guid("22222222-2222-0000-0005-17dddf6838c0"), "Reptilian_massive_15.png", 9 },
                    { new Guid("22222222-2222-0000-0005-3b9f9a7f1159"), "Reptilian_normal_06.png", 9 },
                    { new Guid("22222222-2222-0000-0005-14abe8b79d4b"), "Reptilian_normal_07.png", 9 },
                    { new Guid("22222222-2222-0000-0005-ca1fe0e018fa"), "Reptilian_normal_08.png", 9 },
                    { new Guid("22222222-2222-0000-0005-1134f66f5ec3"), "Reptilian_17.png", 9 },
                    { new Guid("22222222-2222-0000-0005-1ff761c80d42"), "Reptilian_normal_09.png", 9 },
                    { new Guid("22222222-2222-0000-0005-cd69dc75eafe"), "Reptilian_slender_01.png", 9 },
                    { new Guid("22222222-2222-0000-0005-48118bebafbc"), "Reptilian_slender_02.png", 9 },
                    { new Guid("22222222-2222-0000-0005-31415b8ca46c"), "Reptilian_slender_03.png", 9 },
                    { new Guid("22222222-2222-0000-0005-5d88c4d28f82"), "Reptilian_slender_04.png", 9 },
                    { new Guid("22222222-2222-0000-0005-0a3a9a135a64"), "Reptilian_slender_05.png", 9 },
                    { new Guid("22222222-2222-0000-0005-7a08ccd15f45"), "Synthetic_dawn_portrait_arthopoid.png", 10 },
                    { new Guid("22222222-2222-0000-0005-e684483c9a10"), "Synthetic_dawn_portrait_avian.png", 10 },
                    { new Guid("22222222-2222-0000-0005-3523e73dd73b"), "Synthetic_dawn_portrait_fungoid.png", 10 },
                    { new Guid("22222222-2222-0000-0005-499bb7f8f6a4"), "Reptilian_normal_10.png", 9 },
                    { new Guid("22222222-2222-0000-0005-0dfba808b2e1"), "Reptilian_16.png", 9 },
                    { new Guid("22222222-2222-0000-0005-e7bdfe9602a4"), "Plantoid_hivemind.png", 8 },
                    { new Guid("22222222-2222-0000-0005-7ca378911564"), "Plantoid_15.png", 8 },
                    { new Guid("22222222-2222-0000-0005-331a6a65c25a"), "Necroids_12_portrait_green.png", 7 },
                    { new Guid("22222222-2222-0000-0005-ea5d9cd4c132"), "Necroids_13_portrait_blue.png", 7 },
                    { new Guid("22222222-2222-0000-0005-f164258d5e8f"), "Necroids_14_portrait_blue.png", 7 },
                    { new Guid("22222222-2222-0000-0005-b193d0a19107"), "Necroids_15_portrait_grey.png", 7 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName", "SpeciesType" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-0000-0005-3278ace6f46b"), "Necroids_machine_portrait_red.png", 7 },
                    { new Guid("22222222-2222-0000-0005-2f31841ab4c8"), "Plantoid_01.png", 8 },
                    { new Guid("22222222-2222-0000-0005-b5380a53a13b"), "Plantoid_02.png", 8 },
                    { new Guid("22222222-2222-0000-0005-4725dd08e0a4"), "Plantoid_03.png", 8 },
                    { new Guid("22222222-2222-0000-0005-6d781b55eafa"), "Plantoid_04.png", 8 },
                    { new Guid("22222222-2222-0000-0005-e7642dc2baef"), "Plantoid_05.png", 8 },
                    { new Guid("22222222-2222-0000-0005-8f57c287cbc1"), "Plantoid_06.png", 8 },
                    { new Guid("22222222-2222-0000-0005-be709b1b6b50"), "Plantoid_07.png", 8 },
                    { new Guid("22222222-2222-0000-0005-7826f5f2f44c"), "Plantoid_08.png", 8 },
                    { new Guid("22222222-2222-0000-0005-5a3142b959c0"), "Plantoid_09.png", 8 },
                    { new Guid("22222222-2222-0000-0005-01554a52ad30"), "Plantoid_10.png", 8 },
                    { new Guid("22222222-2222-0000-0005-0c5c26e55699"), "Plantoid_11.png", 8 },
                    { new Guid("22222222-2222-0000-0005-e4be2cfb9669"), "Plantoid_12.png", 8 },
                    { new Guid("22222222-2222-0000-0005-12f5a268ea73"), "Plantoid_13.png", 8 },
                    { new Guid("22222222-2222-0000-0005-0a053a0bb1ad"), "Plantoid_14.png", 8 },
                    { new Guid("22222222-2222-0000-0005-c19d3d54e6b3"), "Synthetic_dawn_portrait_humanoid.png", 10 },
                    { new Guid("22222222-2222-0000-0005-ef50dcf55ea0"), "Synthetic_dawn_portrait_mammalian.png", 10 },
                    { new Guid("22222222-2222-0000-0005-b4c122695332"), "Synthetic_dawn_portrait_molluscoid.png", 10 },
                    { new Guid("22222222-2222-0000-0005-9d8396e9ae11"), "Synthetic_dawn_portrait_plantoid.png", 10 },
                    { new Guid("22222222-2222-0000-0003-f801ce1701fc"), "Arthropoid_normal_08.png", 2 },
                    { new Guid("22222222-2222-0000-0003-5edf18e174ef"), "Arthropoid_normal_07.png", 2 },
                    { new Guid("22222222-2222-0000-0003-e1a194845eda"), "Arthropoid_normal_06.png", 2 },
                    { new Guid("22222222-2222-0000-0003-2a9b2afc1a1e"), "Arthropoid_massive_17.png", 2 },
                    { new Guid("22222222-2222-0000-0003-ed8d781ff41b"), "Arthropoid_massive_16.png", 2 },
                    { new Guid("22222222-2222-0000-0003-7268b02c24eb"), "Arthropoid_massive_15.png", 2 },
                    { new Guid("22222222-2222-0000-0003-6d2c7313dcf6"), "Arthropoid_massive_14.png", 2 },
                    { new Guid("22222222-2222-0000-0003-0ea9d5234afb"), "Arthropoid_massive_13.png", 2 },
                    { new Guid("22222222-2222-0000-0003-a783cc04fafa"), "Arthropoid_massive_12.png", 2 },
                    { new Guid("22222222-2222-0000-0003-5b960184b0db"), "Arthropoid_massive_11.png", 2 },
                    { new Guid("22222222-2222-0000-0003-5aaeb4e06b38"), "Arthropoid_20.png", 2 },
                    { new Guid("22222222-2222-0000-0003-292ed1175ce1"), "Arthropoid_19.png", 2 },
                    { new Guid("22222222-2222-0000-0003-5cedabc2eb68"), "Arthropoid_18.png", 2 },
                    { new Guid("22222222-2222-0000-0001-a4bea66e94c2"), "Alien_Swarm.png", 3 },
                    { new Guid("22222222-2222-0000-0001-305c25f034d7"), "Alien_extradimensional_03.png", 3 },
                    { new Guid("22222222-2222-0000-0001-be5807e86491"), "Alien_extradimensional_02.png", 3 },
                    { new Guid("22222222-2222-0000-0001-e78d009741ad"), "Alien_extradimensional_01.png", 3 },
                    { new Guid("22222222-2222-0000-0001-ee1bd82b1062"), "Alien_AI_red.png", 3 },
                    { new Guid("22222222-2222-0000-0001-f767e933b649"), "Alien_AI.png", 3 },
                    { new Guid("22222222-2222-0000-0003-111c578bbf31"), "Arthropoid_normal_08.png", 2 },
                    { new Guid("22222222-2222-0000-0005-6cc0c4862ff4"), "Necroids_11_portrait_v3.png", 7 },
                    { new Guid("22222222-2222-0000-0003-8a190f13b5dd"), "Arthropoid_normal_09.png", 2 },
                    { new Guid("22222222-2222-0000-0003-0bd8bc8b5c04"), "Arthropoid_slender_01.png", 2 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName", "SpeciesType" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-0000-0005-3dab2554c31a"), "Synthetic_dawn_portrait_reptilian.png", 10 },
                    { new Guid("22222222-2222-0000-0004-e9b1c9f53b00"), "Avian_slender_03.png", 4 },
                    { new Guid("22222222-2222-0000-0004-d1abb18ac955"), "Avian_slender_02.png", 4 },
                    { new Guid("22222222-2222-0000-0004-79f7dc57a6ef"), "Avian_slender_01.png", 4 },
                    { new Guid("22222222-2222-0000-0004-f2d51ca358e1"), "Avian_normal_10.png", 4 },
                    { new Guid("22222222-2222-0000-0004-c94ddb578e15"), "Avian_normal_09.png", 4 },
                    { new Guid("22222222-2222-0000-0004-a41cbfc3a2d0"), "Avian_normal_08.png", 4 },
                    { new Guid("22222222-2222-0000-0004-ba43849d85ac"), "Avian_normal_07.png", 4 },
                    { new Guid("22222222-2222-0000-0004-59b4a036598a"), "Avian_normal_06.png", 4 },
                    { new Guid("22222222-2222-0000-0004-e4561c11b129"), "Avian_massive_17.png", 4 },
                    { new Guid("22222222-2222-0000-0004-009e992f1667"), "Avian_massive_16.png", 4 },
                    { new Guid("22222222-2222-0000-0004-26e3d161cc91"), "Avian_massive_15.png", 4 },
                    { new Guid("22222222-2222-0000-0004-df4f7fa13342"), "Avian_massive_14.png", 4 },
                    { new Guid("22222222-2222-0000-0004-d9b3206f5bde"), "Avian_massive_13.png", 4 },
                    { new Guid("22222222-2222-0000-0004-beb2f37aabca"), "Avian_massive_12.png", 4 },
                    { new Guid("22222222-2222-0000-0004-461e17de2b81"), "Avian_massive_11.png", 4 },
                    { new Guid("22222222-2222-0000-0004-579805ddbf3e"), "Avian_18.png", 4 },
                    { new Guid("22222222-2222-0000-0003-25c639b710ed"), "Arthropoid_slender_05.png", 2 },
                    { new Guid("22222222-2222-0000-0003-f8e74a276650"), "Arthropoid_slender_03.png", 2 },
                    { new Guid("22222222-2222-0000-0003-62f458ececf0"), "Arthropoid_normal_10.png", 2 },
                    { new Guid("22222222-2222-0000-0004-3dc61d3ec887"), "Avian_slender_05.png", 4 },
                    { new Guid("22222222-2222-0000-0005-7e353a1cb111"), "Necroids_10_portrait_blue.png", 7 },
                    { new Guid("22222222-2222-0000-0005-c848de3cf30f"), "Necroids_08_portrait_orange.png", 7 },
                    { new Guid("22222222-2222-0000-0005-000ec530cb8b"), "Humanoid_hp_07.png", 1 },
                    { new Guid("22222222-2222-0000-0005-eff52ae02db1"), "Humanoid_hp_08.png", 1 },
                    { new Guid("22222222-2222-0000-0005-0f7c49113abd"), "Humanoid_hp_09.png", 1 },
                    { new Guid("22222222-2222-0000-0005-45a446592796"), "Humanoid_hp_10.png", 1 },
                    { new Guid("22222222-2222-0000-0005-16ba70b3283c"), "Humanoid_hp_11.png", 1 },
                    { new Guid("22222222-2222-0000-0005-d890407c0aee"), "Humanoid_hp_12.png", 1 },
                    { new Guid("22222222-2222-0000-0005-fa500ed000ad"), "Humanoid_hp_13.png", 1 },
                    { new Guid("22222222-2222-0000-0000-3d38f15ceb53"), "800px-Lithoid_02.png", 0 },
                    { new Guid("22222222-2222-0000-0005-7a0a13c31b24"), "Humanoid_hp_06.png", 1 },
                    { new Guid("22222222-2222-0000-0005-9b54ce119f41"), "Lithoid_01.png", 0 },
                    { new Guid("22222222-2222-0000-0005-61ea12c85a2c"), "Lithoid_04.png", 0 },
                    { new Guid("22222222-2222-0000-0005-272873c8b411"), "Lithoid_05.png", 0 },
                    { new Guid("22222222-2222-0000-0005-6ea926a2b0c6"), "Lithoid_06.png", 0 },
                    { new Guid("22222222-2222-0000-0005-1dde173a0d72"), "Lithoid_07.png", 0 },
                    { new Guid("22222222-2222-0000-0005-ce568aa409cf"), "Lithoid_08.png", 0 },
                    { new Guid("22222222-2222-0000-0005-3201f2777c5c"), "Lithoid_09.png", 0 },
                    { new Guid("22222222-2222-0000-0005-cb94dd8d78d0"), "Lithoid_10.png", 0 },
                    { new Guid("22222222-2222-0000-0005-5da0041f1c23"), "Lithoid_11.png", 0 },
                    { new Guid("22222222-2222-0000-0005-900dfed3ffb3"), "Lithoid_03.png", 0 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName", "SpeciesType" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-0000-0005-f75660d2b48c"), "Humanoid_hp_02.png", 1 },
                    { new Guid("22222222-2222-0000-0005-ab24503fa348"), "Humanoid_hp_01.png", 1 },
                    { new Guid("22222222-2222-0000-0005-a9ecea6c70f0"), "Humanoid_05.png", 1 },
                    { new Guid("22222222-2222-0000-0005-99013cb95bbd"), "Fungoid_massive_11.png", 11 },
                    { new Guid("22222222-2222-0000-0005-321b094f5762"), "Fungoid_massive_12.png", 11 },
                    { new Guid("22222222-2222-0000-0005-8788d5f3e35d"), "Fungoid_massive_13.png", 11 },
                    { new Guid("22222222-2222-0000-0005-14430c731dc2"), "Fungoid_massive_14.png", 11 },
                    { new Guid("22222222-2222-0000-0005-ea718adf8cba"), "Fungoid_massive_15.png", 11 },
                    { new Guid("22222222-2222-0000-0005-0fabe7ca981f"), "Fungoid_massive_16.png", 11 },
                    { new Guid("22222222-2222-0000-0005-b04304969301"), "Fungoid_normal_06.png", 11 },
                    { new Guid("22222222-2222-0000-0005-4458e73a842c"), "Fungoid_normal_07.png", 11 },
                    { new Guid("22222222-2222-0000-0005-576f665de7d2"), "Fungoid_normal_08.png", 11 },
                    { new Guid("22222222-2222-0000-0005-5127456c421d"), "Fungoid_normal_09.png", 11 },
                    { new Guid("22222222-2222-0000-0005-4dba51dc2901"), "Fungoid_normal_10.png", 11 },
                    { new Guid("22222222-2222-0000-0005-3255c2b6bb8e"), "Fungoid_slender_01.png", 11 },
                    { new Guid("22222222-2222-0000-0005-5c4b5de19471"), "Fungoid_slender_02.png", 11 },
                    { new Guid("22222222-2222-0000-0005-674c0cd12909"), "Fungoid_slender_03.png", 11 },
                    { new Guid("22222222-2222-0000-0005-7366ab557689"), "Fungoid_slender_04.png", 11 },
                    { new Guid("22222222-2222-0000-0005-3fd3c71477e3"), "Human.png", 1 },
                    { new Guid("22222222-2222-0000-0005-689e44079a1d"), "Humanoid_02.png", 1 },
                    { new Guid("22222222-2222-0000-0005-8da311f350e4"), "Humanoid_03.png", 1 },
                    { new Guid("22222222-2222-0000-0005-a824f3b7650f"), "Humanoid_04.png", 1 },
                    { new Guid("22222222-2222-0000-0005-f6b64797af4c"), "Lithoid_12.png", 0 },
                    { new Guid("22222222-2222-0000-0005-4b55bc7c7346"), "Lithoid_13.png", 0 },
                    { new Guid("22222222-2222-0000-0005-7fbbd7e6992a"), "Lithoid_14.png", 0 },
                    { new Guid("22222222-2222-0000-0005-a58f567804b0"), "Lithoid_15.png", 0 },
                    { new Guid("22222222-2222-0000-0005-82af9750923a"), "Molluscoid_massive_13.png", 6 },
                    { new Guid("22222222-2222-0000-0005-19022b56b981"), "Molluscoid_massive_14.png", 6 },
                    { new Guid("22222222-2222-0000-0005-96cd63952f82"), "Molluscoid_massive_15.png", 6 },
                    { new Guid("22222222-2222-0000-0005-c602cfc55bac"), "Molluscoid_massive_16.png", 6 },
                    { new Guid("22222222-2222-0000-0005-caf576baecb8"), "Molluscoid_normal_06.png", 6 },
                    { new Guid("22222222-2222-0000-0005-e2fa58654045"), "Molluscoid_normal_07.png", 6 },
                    { new Guid("22222222-2222-0000-0005-b56b180bd974"), "Molluscoid_normal_08.png", 6 },
                    { new Guid("22222222-2222-0000-0005-70189ead7e9a"), "Molluscoid_slender_01.png", 6 },
                    { new Guid("22222222-2222-0000-0005-91d757ea0e3f"), "Molluscoid_slender_02.png", 6 },
                    { new Guid("22222222-2222-0000-0005-9e9b2ac7b9e4"), "Molluscoid_slender_03.png", 6 },
                    { new Guid("22222222-2222-0000-0005-7f1c48f5ede1"), "Molluscoid_slender_04.png", 6 },
                    { new Guid("22222222-2222-0000-0005-78fce4d1996c"), "Molluscoid_slender_05.png", 6 },
                    { new Guid("22222222-2222-0000-0005-63f6fd064a0a"), "Necroids_01_portrait_purple.png", 7 },
                    { new Guid("22222222-2222-0000-0005-23339f3ea8d5"), "Necroids_02_portrait_brass.png", 7 },
                    { new Guid("22222222-2222-0000-0005-eabafe68ff0f"), "Necroids_03_portrait_green.png", 7 },
                    { new Guid("22222222-2222-0000-0005-8cce2081284a"), "Necroids_04_portrait_purple.png", 7 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName", "SpeciesType" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-0000-0005-981bd9a023d2"), "Necroids_05_portrait_green.png", 7 },
                    { new Guid("22222222-2222-0000-0005-244d34cb4118"), "Necroids_06_portrait_blue.png", 7 },
                    { new Guid("22222222-2222-0000-0005-2def3762d45b"), "Necroids_07_portrait_black.png", 7 },
                    { new Guid("22222222-2222-0000-0005-c3deb1b54c6b"), "Molluscoid_massive_12.png", 6 },
                    { new Guid("22222222-2222-0000-0005-a97029d805e0"), "Necroids_09_portrait_teal.png", 7 },
                    { new Guid("22222222-2222-0000-0005-3353eec706e9"), "Molluscoid_massive_11.png", 6 },
                    { new Guid("22222222-2222-0000-0005-9adcf9c7ae35"), "Molluscoid_17.png", 6 },
                    { new Guid("22222222-2222-0000-0005-ae4531fe98bc"), "Lithoid_machine.png", 0 },
                    { new Guid("22222222-2222-0000-0005-72178817ffaa"), "Mammalian_massive_11.png", 5 },
                    { new Guid("22222222-2222-0000-0005-42c24127daa8"), "Mammalian_massive_12.png", 5 },
                    { new Guid("22222222-2222-0000-0005-1faa52038f22"), "Mammalian_massive_13.png", 5 },
                    { new Guid("22222222-2222-0000-0005-e16843b2e2d4"), "Mammalian_massive_14.png", 5 },
                    { new Guid("22222222-2222-0000-0005-ccce22d92c71"), "Mammalian_massive_15.png", 5 },
                    { new Guid("22222222-2222-0000-0005-a65bbcd295e6"), "Mammalian_massive_16.png", 5 },
                    { new Guid("22222222-2222-0000-0005-252076fdcc03"), "Mammalian_massive_17.png", 5 },
                    { new Guid("22222222-2222-0000-0005-59a7222370b2"), "Mammalian_normal_06.png", 5 },
                    { new Guid("22222222-2222-0000-0005-9b7cd58a7118"), "Mammalian_normal_07.png", 5 },
                    { new Guid("22222222-2222-0000-0005-6be3708f70d8"), "Mammalian_normal_08.png", 5 },
                    { new Guid("22222222-2222-0000-0005-e9aa91d69f33"), "Mammalian_normal_09.png", 5 },
                    { new Guid("22222222-2222-0000-0005-8de4db2a895d"), "Mammalian_normal_10.png", 5 },
                    { new Guid("22222222-2222-0000-0005-56f1b8279079"), "Mammalian_ratling.png", 5 },
                    { new Guid("22222222-2222-0000-0005-f3a13f95e0b9"), "Mammalian_slender_01.png", 5 },
                    { new Guid("22222222-2222-0000-0004-eca3989cff8c"), "Avian_slender_04.png", 4 },
                    { new Guid("22222222-2222-0000-0005-9f3280cc0fcd"), "Mammalian_slender_03.png", 5 },
                    { new Guid("22222222-2222-0000-0005-0d1116d2e2fd"), "Mammalian_slender_04.png", 5 },
                    { new Guid("22222222-2222-0000-0005-7c282c3ab5fd"), "Mammalian_slender_05.png", 5 },
                    { new Guid("22222222-2222-0000-0005-97c37af24f37"), "Molluscoid_18.png", 6 },
                    { new Guid("22222222-2222-0000-0005-95ca149e3a4c"), "Mammalian_slender_02.png", 5 }
                });

            migrationBuilder.InsertData(
                table: "BuildingCosts",
                columns: new[] { "Id", "BaseValue", "BuildingId", "Multiplier", "ResourceId" },
                values: new object[,]
                {
                    { new Guid("778a6f92-e76d-4c0a-a03f-fa5e1d31bca2"), 300.0, new Guid("e200ef94-6eb9-46c8-ba08-3dd86ac3b373"), 1.3999999999999999, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("76f6afe9-670a-4ba5-90d8-01891f15a6a2"), 60.0, new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("58d5be3e-1d49-4c0a-ae2c-f46791d0e919"), 68.0, new Guid("8a0a5dab-f877-4714-8e6b-1b578f480268"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("df3f2c81-7bb8-4913-8817-57c352c07aed"), 250.0, new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"), 1.55, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("40f3accc-ba71-4306-95f5-67421aeb89f0"), 600.0, new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"), 1.5, new Guid("00000000-1111-0000-0000-000000000011") },
                    { new Guid("36ddec13-5b03-4e09-b1d4-eb9865fa3ec6"), 900.0, new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"), 1.6000000000000001, new Guid("00000000-1111-0000-0000-000000000011") },
                    { new Guid("01951251-4fdb-4ad6-98f1-ae001e779b04"), 400.0, new Guid("44517245-cb20-4324-a275-4d8642207ad4"), 1.5, new Guid("00000000-1111-0000-0000-000000000011") },
                    { new Guid("9c85b65c-72e6-4e41-9106-d35580c0f9ab"), 100.0, new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"), 1.3999999999999999, new Guid("00000000-1111-0000-0000-000000000011") },
                    { new Guid("daface0d-0bbc-4e5b-a11e-55bce19c4b0b"), 500.0, new Guid("44517245-cb20-4324-a275-4d8642207ad4"), 1.6000000000000001, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("4d6ddf71-901c-4734-b6cd-23fd2d701002"), 800.0, new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"), 1.3, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("ea28699a-c944-48a1-b6ff-30f8536cb840"), 700.0, new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"), 1.25, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("0e521620-3a9d-4f1a-9822-e7a1fb746246"), 500.0, new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"), 1.6000000000000001, new Guid("00000000-1111-0000-0000-000000000015") }
                });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "Id", "Email", "Password", "PlayerId", "Salt" },
                values: new object[] { new Guid("00000000-0000-0000-1110-000000000000"), "daniel@dirtyandnative.de", new byte[] { 214, 212, 211, 33, 140, 160, 231, 162, 57, 199, 64, 131, 187, 201, 119, 192, 203, 109, 243, 123, 229, 56, 47, 180, 17, 5, 138, 178, 72, 221, 137, 25, 69, 173, 181, 157, 202, 130, 182, 172, 20, 121, 129, 43, 136, 74, 120, 242, 126, 100, 62, 207, 24, 9, 244, 206, 7, 166, 63, 155, 128, 118, 47, 81 }, new Guid("22222222-0000-0000-0000-000000000000"), new byte[] { 193, 79, 225, 80, 112, 24, 191, 243, 40, 86, 90, 75, 6, 166, 103, 215, 30, 13, 70, 153, 161, 73, 23, 145, 154, 13, 46, 5, 245, 103, 100, 241 } });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Symbol", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-1111-0000-0000-000000000019"), "Cu", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000015"), "Ti", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000017"), "Co", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000016"), "Fe", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000021"), "Ga", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000022"), "Ge", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000023"), "Pd", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000024"), "Ag", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000025"), "Sn", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000026"), "Ir", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000027"), "Pt", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000028"), "Au", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000029"), "Pu", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000020"), "Zn", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000018"), "Ni", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000013"), "S", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000003"), "Li", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000001"), "H", 0 },
                    { new Guid("00000000-1111-0000-0000-000000000002"), "He", 0 },
                    { new Guid("00000000-1111-0000-0000-000000000014"), "Cl", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000004"), "Be", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000005"), "B", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000007"), "N", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000006"), "C", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000009"), "Mg", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000010"), "Al", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000011"), "Si", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000012"), "P", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000008"), "O", 0 }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-3333-1111-0000-000000000003"), 0 },
                    { new Guid("00000000-4444-1111-0000-000000000002"), 3 },
                    { new Guid("00000000-4444-1111-0000-000000000001"), 3 },
                    { new Guid("00000000-3333-1111-0000-000000000002"), 0 },
                    { new Guid("00000000-1111-1111-0000-000000000001"), 2 },
                    { new Guid("00000000-2222-1111-0000-000000000001"), 4 },
                    { new Guid("00000000-1111-1111-0000-000000000003"), 2 },
                    { new Guid("00000000-1111-1111-0000-000000000002"), 2 },
                    { new Guid("00000000-2222-1111-0000-000000000002"), 4 },
                    { new Guid("00000000-0000-1111-0000-000000000003"), 1 },
                    { new Guid("00000000-5555-1111-0000-000000000002"), 4 },
                    { new Guid("00000000-0000-1111-0000-000000000001"), 1 },
                    { new Guid("00000000-5555-1111-0000-000000000001"), 4 },
                    { new Guid("00000000-0000-1111-0000-000000000002"), 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductionBuildings",
                column: "Id",
                values: new object[]
                {
                    new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"),
                    new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"),
                    new Guid("44517245-cb20-4324-a275-4d8642207ad4"),
                    new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"),
                    new Guid("e200ef94-6eb9-46c8-ba08-3dd86ac3b373"),
                    new Guid("8a0a5dab-f877-4714-8e6b-1b578f480268"),
                    new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb")
                });

            migrationBuilder.InsertData(
                table: "StorageBuildings",
                column: "Id",
                value: new Guid("f09e72d5-28d8-4390-bdf5-3b589b61fc15"));

            migrationBuilder.InsertData(
                table: "OutputResources",
                columns: new[] { "Id", "BaseValue", "BuildingId", "Multiplier", "ResourceId" },
                values: new object[] { new Guid("24a0efe4-27d2-43c6-bb7b-61b36c129b00"), 60.0, new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingChains_PlayerId",
                table: "BuildingChains",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingConstructions_BuildingChainId",
                table: "BuildingConstructions",
                column: "BuildingChainId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingConstructions_BuildingId",
                table: "BuildingConstructions",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingConstructions_StellarObjectId",
                table: "BuildingConstructions",
                column: "StellarObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingCosts_BuildingId",
                table: "BuildingCosts",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingCosts_ResourceId",
                table: "BuildingCosts",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_BuiltBuildings_BuildingId",
                table: "BuiltBuildings",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuiltBuildings_ColonizedStellarObjectId",
                table: "BuiltBuildings",
                column: "ColonizedStellarObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ColonizableStellarObjects_ColonizedStellarObjectId",
                table: "ColonizableStellarObjects",
                column: "ColonizedStellarObjectId",
                unique: true,
                filter: "[ColonizedStellarObjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ColonizedStellarObjects_PlayerId",
                table: "ColonizedStellarObjects",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_PlayerId",
                table: "Credentials",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InputResources_BuildingId",
                table: "InputResources",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_InputResources_ResourceId",
                table: "InputResources",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiObjectSystems_ParentId",
                table: "MultiObjectSystems",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputResources_BuildingId",
                table: "OutputResources",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputResources_ResourceId",
                table: "OutputResources",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSpecies_PlayerId",
                table: "PlayerSpecies",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSpecies_SpeciesId",
                table: "PlayerSpecies",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSpeciesPerks_PerkId",
                table: "PlayerSpeciesPerks",
                column: "PerkId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSpeciesPerks_PlayerSpeciesId",
                table: "PlayerSpeciesPerks",
                column: "PlayerSpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceSnapshots_StellarObjectId",
                table: "ResourceSnapshots",
                column: "StellarObjectId");

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

            migrationBuilder.CreateIndex(
                name: "IX_StoredResources_ResourceId",
                table: "StoredResources",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_StoredResources_ResourceSnapshotId",
                table: "StoredResources",
                column: "ResourceSnapshotId");

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
                name: "FK_BuildingConstructions_StellarObjects_StellarObjectId",
                table: "BuildingConstructions",
                column: "StellarObjectId",
                principalTable: "StellarObjects",
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
                name: "FK_ColonizableStellarObjects_StellarObjects_Id",
                table: "ColonizableStellarObjects",
                column: "Id",
                principalTable: "StellarObjects",
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
                name: "BuildingConstructions");

            migrationBuilder.DropTable(
                name: "BuildingCosts");

            migrationBuilder.DropTable(
                name: "BuiltBuildings");

            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "InputResources");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "MultiObjectSystems");

            migrationBuilder.DropTable(
                name: "OutputResources");

            migrationBuilder.DropTable(
                name: "PlayerSpeciesPerks");

            migrationBuilder.DropTable(
                name: "SolarSystems");

            migrationBuilder.DropTable(
                name: "StellarObjectResources");

            migrationBuilder.DropTable(
                name: "StorageBuildings");

            migrationBuilder.DropTable(
                name: "StoredResources");

            migrationBuilder.DropTable(
                name: "BuildingChains");

            migrationBuilder.DropTable(
                name: "ProductionBuildings");

            migrationBuilder.DropTable(
                name: "Perks");

            migrationBuilder.DropTable(
                name: "PlayerSpecies");

            migrationBuilder.DropTable(
                name: "BlackHoles");

            migrationBuilder.DropTable(
                name: "Moons");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "Stars");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "ResourceSnapshots");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "ColonizableStellarObjects");

            migrationBuilder.DropTable(
                name: "ColonizedStellarObjects");

            migrationBuilder.DropTable(
                name: "StellarObjects");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "StellarSystems");

            migrationBuilder.DropTable(
                name: "Galaxies");
        }
    }
}
