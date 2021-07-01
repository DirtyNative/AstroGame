using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.Id);
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
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
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
                name: "ConversationMessages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConversationMessages_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConversationMessages_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConversationParticipants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JoinedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastSeenDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationParticipants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConversationParticipants_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConversationParticipants_Players_PlayerId",
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
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingCosts", x => x.Id);
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
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsBaseResource = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StructuralIntegrity = table.Column<long>(type: "bigint", nullable: false),
                    ShieldPower = table.Column<long>(type: "bigint", nullable: false),
                    WeaponPower = table.Column<long>(type: "bigint", nullable: false),
                    CargoCapacity = table.Column<long>(type: "bigint", nullable: false),
                    StellarSpeed = table.Column<long>(type: "bigint", nullable: false),
                    InterstellarSpeed = table.Column<long>(type: "bigint", nullable: false),
                    FuelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuelConsumption = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_Resources_FuelId",
                        column: x => x.FuelId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingType = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    BuildableOn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_Technologies_Id",
                        column: x => x.Id,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    TechnologyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NeededTechnologyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conditions_Technologies_NeededTechnologyId",
                        column: x => x.NeededTechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Conditions_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Researches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResearchType = table.Column<int>(type: "int", nullable: false),
                    BuildingTimeMultiplier = table.Column<double>(type: "float", nullable: false),
                    BuildingCostMultiplier = table.Column<double>(type: "float", nullable: false),
                    BuildingProductionMultiplier = table.Column<double>(type: "float", nullable: false),
                    BuildingConsumptionMultiplier = table.Column<double>(type: "float", nullable: false),
                    StructuralIntegrityMultiplier = table.Column<double>(type: "float", nullable: false),
                    ShieldPowerMultiplier = table.Column<double>(type: "float", nullable: false),
                    WeaponPowerMultiplier = table.Column<double>(type: "float", nullable: false),
                    CargoCapacityMultiplier = table.Column<double>(type: "float", nullable: false),
                    StellarSpeedMultiplier = table.Column<double>(type: "float", nullable: false),
                    InterstellarSpeedMultiplier = table.Column<double>(type: "float", nullable: false),
                    FuelConsumptionMultiplier = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Researches_Technologies_Id",
                        column: x => x.Id,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DynamicBuildingCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    BaseValue = table.Column<double>(type: "float", nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicBuildingCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicBuildingCosts_BuildingCosts_Id",
                        column: x => x.Id,
                        principalTable: "BuildingCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FixedBuildingCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedBuildingCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixedBuildingCosts_BuildingCosts_Id",
                        column: x => x.Id,
                        principalTable: "BuildingCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShipConstructionCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipConstructionCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipConstructionCosts_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipConstructionCosts_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "BuiltBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColonizedStellarObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<long>(type: "bigint", nullable: false)
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
                name: "FixedBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixedBuildings_Buildings_Id",
                        column: x => x.Id,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_InputResources_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
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
                name: "LevelableBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelableBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelableBuildings_Buildings_Id",
                        column: x => x.Id,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_OutputResources_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
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
                name: "LevelableConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    NeededLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelableConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelableConditions_Conditions_Id",
                        column: x => x.Id,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OneTimeConditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneTimeConditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneTimeConditions_Conditions_Id",
                        column: x => x.Id,
                        principalTable: "Conditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LevelableResearches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelableResearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelableResearches_Researches_Id",
                        column: x => x.Id,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OneTimeResearches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneTimeResearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneTimeResearches_Researches_Id",
                        column: x => x.Id,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResearchCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ResearchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchCosts_Researches_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResearchCosts_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResearchStudies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ResearchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HangfireJobId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchStudies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchStudies_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResearchStudies_Researches_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudiedResearches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ResearchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudiedResearches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudiedResearches_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudiedResearches_Researches_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DynamicResearchCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    BaseValue = table.Column<double>(type: "float", nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false),
                    LevelableResearchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicResearchCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicResearchCosts_LevelableResearches_LevelableResearchId",
                        column: x => x.LevelableResearchId,
                        principalTable: "LevelableResearches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DynamicResearchCosts_ResearchCosts_Id",
                        column: x => x.Id,
                        principalTable: "ResearchCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OneTimeResearchCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    OneTimeResearchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneTimeResearchCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneTimeResearchCosts_OneTimeResearches_OneTimeResearchId",
                        column: x => x.OneTimeResearchId,
                        principalTable: "OneTimeResearches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OneTimeResearchCosts_ResearchCosts_Id",
                        column: x => x.Id,
                        principalTable: "ResearchCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "StellarObjectResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    StellarObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_StellarObjectResources_StellarObjects_StellarObjectId",
                        column: x => x.StellarObjectId,
                        principalTable: "StellarObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "Perks",
                columns: new[] { "Id", "BuildingSpeedMultiplier", "Description", "Title" },
                values: new object[] { new Guid("00000000-0000-1111-0000-6712d7115748"), 0.90000000000000002, "Building big constructs is a no-brainer for your species.", "Fast builder" });

            migrationBuilder.InsertData(
                table: "Perks",
                columns: new[] { "Id", "BiologicalResearchSpeedMultiplier", "Description", "Title" },
                values: new object[] { new Guid("00000000-0000-1111-0000-dadcd19d28e3"), 0.84999999999999998, "Your species loves to inspect other creatures, and so does with species from other planets.", "Natural Sociologists" });

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
                columns: new[] { "Id", "BiologicalResearchSpeedMultiplier", "Description", "EngineersResearchSpeedMultiplier", "PhysicsResearchSpeedMultiplier", "Title" },
                values: new object[] { new Guid("00000000-0000-1111-0000-326db14a91f9"), 0.94999999999999996, "\"We're good at everything, but not with something specific.\" Well..", 0.94999999999999996, 0.94999999999999996, "Intelligent" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BuildingChainId", "ConfirmationToken", "PlayerSpeciesId", "Username" },
                values: new object[,]
                {
                    { new Guid("22222222-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("22222222-1111-0000-0000-000000000000"), "Test2" },
                    { new Guid("22222222-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("22222222-1111-0000-0000-000000000000"), "DirtyNative" },
                    { new Guid("22222222-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("22222222-1111-0000-0000-000000000000"), "Test1" }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "NaturalOccurrenceWeight" },
                values: new object[,]
                {
                    { new Guid("00000000-1111-0000-0000-000000000014"), "Chlorine", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000013"), "Sulfur", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000012"), "Phosphorus", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000015"), "Titanium", 1L },
                    { new Guid("00000000-5555-1111-0000-000000000002"), "Antimatter", 0L },
                    { new Guid("00000000-1111-0000-0000-000000000010"), "Aluminum", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000009"), "Magnesium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000008"), "Oxygen", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000007"), "Nitrogen", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000006"), "Carbon", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000004"), "Beryllium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000003"), "Lithium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000002"), "Helium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000001"), "Hydrogen", 1L },
                    { new Guid("00000000-5555-1111-0000-000000000001"), "Dark matter", 0L },
                    { new Guid("00000000-1111-0000-0000-000000000011"), "Silicon", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000016"), "Iron", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000005"), "Boron", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000018"), "Nickel", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000017"), "Cobalt", 1L },
                    { new Guid("00000000-4444-1111-0000-000000000002"), "Nano alloys", 0L },
                    { new Guid("00000000-4444-1111-0000-000000000001"), "Reactive alloys", 0L },
                    { new Guid("00000000-3333-1111-0000-000000000003"), "Nanites", 0L },
                    { new Guid("00000000-2222-1111-0000-000000000002"), "Tritium", 1L },
                    { new Guid("00000000-2222-1111-0000-000000000001"), "Deuterium", 1L },
                    { new Guid("00000000-1111-1111-0000-000000000003"), "Supra conductors", 1L },
                    { new Guid("00000000-1111-1111-0000-000000000002"), "Conductive Components", 1L },
                    { new Guid("00000000-1111-1111-0000-000000000001"), "Conductive Components", 1L },
                    { new Guid("00000000-0000-1111-0000-000000000003"), "Luxury Goods", 1L },
                    { new Guid("00000000-0000-1111-0000-000000000002"), "Food", 1L },
                    { new Guid("00000000-3333-1111-0000-000000000002"), "Steel", 0L },
                    { new Guid("00000000-1111-0000-0000-000000000029"), "Plutonium", 1L },
                    { new Guid("00000000-0000-1111-0000-000000000001"), "Water", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000020"), "Zinc", 1L }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "NaturalOccurrenceWeight" },
                values: new object[,]
                {
                    { new Guid("00000000-1111-0000-0000-000000000021"), "Gallium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000023"), "Palladium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000022"), "Germanium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000025"), "Tin", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000026"), "Iridium", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000027"), "Platinum", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000028"), "Gold", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000024"), "Silver", 1L },
                    { new Guid("00000000-1111-0000-0000-000000000019"), "Copper", 1L }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName", "SpeciesType" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-0000-0005-91d757ea0e3f"), "Molluscoid_slender_02.png", 6 },
                    { new Guid("22222222-2222-0000-0005-9e9b2ac7b9e4"), "Molluscoid_slender_03.png", 6 },
                    { new Guid("22222222-2222-0000-0005-8cce2081284a"), "Necroids_04_portrait_purple.png", 7 },
                    { new Guid("22222222-2222-0000-0005-7f1c48f5ede1"), "Molluscoid_slender_04.png", 6 },
                    { new Guid("22222222-2222-0000-0005-78fce4d1996c"), "Molluscoid_slender_05.png", 6 },
                    { new Guid("22222222-2222-0000-0005-63f6fd064a0a"), "Necroids_01_portrait_purple.png", 7 },
                    { new Guid("22222222-2222-0000-0005-23339f3ea8d5"), "Necroids_02_portrait_brass.png", 7 },
                    { new Guid("22222222-2222-0000-0005-eabafe68ff0f"), "Necroids_03_portrait_green.png", 7 },
                    { new Guid("22222222-2222-0000-0005-a97029d805e0"), "Necroids_09_portrait_teal.png", 7 },
                    { new Guid("22222222-2222-0000-0005-244d34cb4118"), "Necroids_06_portrait_blue.png", 7 },
                    { new Guid("22222222-2222-0000-0005-2def3762d45b"), "Necroids_07_portrait_black.png", 7 },
                    { new Guid("22222222-2222-0000-0005-c848de3cf30f"), "Necroids_08_portrait_orange.png", 7 },
                    { new Guid("22222222-2222-0000-0005-7e353a1cb111"), "Necroids_10_portrait_blue.png", 7 },
                    { new Guid("22222222-2222-0000-0005-6cc0c4862ff4"), "Necroids_11_portrait_v3.png", 7 },
                    { new Guid("22222222-2222-0000-0005-331a6a65c25a"), "Necroids_12_portrait_green.png", 7 },
                    { new Guid("22222222-2222-0000-0005-70189ead7e9a"), "Molluscoid_slender_01.png", 6 },
                    { new Guid("22222222-2222-0000-0005-ea5d9cd4c132"), "Necroids_13_portrait_blue.png", 7 },
                    { new Guid("22222222-2222-0000-0005-981bd9a023d2"), "Necroids_05_portrait_green.png", 7 },
                    { new Guid("22222222-2222-0000-0005-b56b180bd974"), "Molluscoid_normal_08.png", 6 },
                    { new Guid("22222222-2222-0000-0005-0d1116d2e2fd"), "Mammalian_slender_04.png", 5 },
                    { new Guid("22222222-2222-0000-0005-caf576baecb8"), "Molluscoid_normal_06.png", 6 },
                    { new Guid("22222222-2222-0000-0005-f164258d5e8f"), "Necroids_14_portrait_blue.png", 7 },
                    { new Guid("22222222-2222-0000-0005-6be3708f70d8"), "Mammalian_normal_08.png", 5 },
                    { new Guid("22222222-2222-0000-0005-e9aa91d69f33"), "Mammalian_normal_09.png", 5 },
                    { new Guid("22222222-2222-0000-0005-8de4db2a895d"), "Mammalian_normal_10.png", 5 },
                    { new Guid("22222222-2222-0000-0005-56f1b8279079"), "Mammalian_ratling.png", 5 },
                    { new Guid("22222222-2222-0000-0005-f3a13f95e0b9"), "Mammalian_slender_01.png", 5 },
                    { new Guid("22222222-2222-0000-0005-95ca149e3a4c"), "Mammalian_slender_02.png", 5 },
                    { new Guid("22222222-2222-0000-0005-9f3280cc0fcd"), "Mammalian_slender_03.png", 5 },
                    { new Guid("22222222-2222-0000-0005-7c282c3ab5fd"), "Mammalian_slender_05.png", 5 },
                    { new Guid("22222222-2222-0000-0005-9adcf9c7ae35"), "Molluscoid_17.png", 6 },
                    { new Guid("22222222-2222-0000-0005-97c37af24f37"), "Molluscoid_18.png", 6 },
                    { new Guid("22222222-2222-0000-0005-3353eec706e9"), "Molluscoid_massive_11.png", 6 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName", "SpeciesType" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-0000-0005-c3deb1b54c6b"), "Molluscoid_massive_12.png", 6 },
                    { new Guid("22222222-2222-0000-0005-82af9750923a"), "Molluscoid_massive_13.png", 6 },
                    { new Guid("22222222-2222-0000-0005-19022b56b981"), "Molluscoid_massive_14.png", 6 },
                    { new Guid("22222222-2222-0000-0005-96cd63952f82"), "Molluscoid_massive_15.png", 6 },
                    { new Guid("22222222-2222-0000-0005-c602cfc55bac"), "Molluscoid_massive_16.png", 6 },
                    { new Guid("22222222-2222-0000-0005-e2fa58654045"), "Molluscoid_normal_07.png", 6 },
                    { new Guid("22222222-2222-0000-0005-b193d0a19107"), "Necroids_15_portrait_grey.png", 7 },
                    { new Guid("22222222-2222-0000-0005-3b9f9a7f1159"), "Reptilian_normal_06.png", 9 },
                    { new Guid("22222222-2222-0000-0005-2f31841ab4c8"), "Plantoid_01.png", 8 },
                    { new Guid("22222222-2222-0000-0005-59a7222370b2"), "Mammalian_normal_06.png", 5 },
                    { new Guid("22222222-2222-0000-0005-14abe8b79d4b"), "Reptilian_normal_07.png", 9 },
                    { new Guid("22222222-2222-0000-0005-ca1fe0e018fa"), "Reptilian_normal_08.png", 9 },
                    { new Guid("22222222-2222-0000-0005-1ff761c80d42"), "Reptilian_normal_09.png", 9 },
                    { new Guid("22222222-2222-0000-0005-499bb7f8f6a4"), "Reptilian_normal_10.png", 9 },
                    { new Guid("22222222-2222-0000-0005-cd69dc75eafe"), "Reptilian_slender_01.png", 9 },
                    { new Guid("22222222-2222-0000-0005-48118bebafbc"), "Reptilian_slender_02.png", 9 },
                    { new Guid("22222222-2222-0000-0005-31415b8ca46c"), "Reptilian_slender_03.png", 9 },
                    { new Guid("22222222-2222-0000-0005-17dddf6838c0"), "Reptilian_massive_15.png", 9 },
                    { new Guid("22222222-2222-0000-0005-5d88c4d28f82"), "Reptilian_slender_04.png", 9 },
                    { new Guid("22222222-2222-0000-0005-7a08ccd15f45"), "Synthetic_dawn_portrait_arthopoid.png", 10 },
                    { new Guid("22222222-2222-0000-0005-e684483c9a10"), "Synthetic_dawn_portrait_avian.png", 10 },
                    { new Guid("22222222-2222-0000-0005-3523e73dd73b"), "Synthetic_dawn_portrait_fungoid.png", 10 },
                    { new Guid("22222222-2222-0000-0005-c19d3d54e6b3"), "Synthetic_dawn_portrait_humanoid.png", 10 },
                    { new Guid("22222222-2222-0000-0005-ef50dcf55ea0"), "Synthetic_dawn_portrait_mammalian.png", 10 },
                    { new Guid("22222222-2222-0000-0005-b4c122695332"), "Synthetic_dawn_portrait_molluscoid.png", 10 },
                    { new Guid("22222222-2222-0000-0005-9d8396e9ae11"), "Synthetic_dawn_portrait_plantoid.png", 10 },
                    { new Guid("22222222-2222-0000-0005-3dab2554c31a"), "Synthetic_dawn_portrait_reptilian.png", 10 },
                    { new Guid("22222222-2222-0000-0005-0a3a9a135a64"), "Reptilian_slender_05.png", 9 },
                    { new Guid("22222222-2222-0000-0005-3278ace6f46b"), "Necroids_machine_portrait_red.png", 7 },
                    { new Guid("22222222-2222-0000-0005-a6ad7d9f57d4"), "Reptilian_massive_14.png", 9 },
                    { new Guid("22222222-2222-0000-0005-79db1e8cde80"), "Reptilian_massive_12.png", 9 },
                    { new Guid("22222222-2222-0000-0005-b5380a53a13b"), "Plantoid_02.png", 8 },
                    { new Guid("22222222-2222-0000-0005-4725dd08e0a4"), "Plantoid_03.png", 8 },
                    { new Guid("22222222-2222-0000-0005-6d781b55eafa"), "Plantoid_04.png", 8 },
                    { new Guid("22222222-2222-0000-0005-e7642dc2baef"), "Plantoid_05.png", 8 },
                    { new Guid("22222222-2222-0000-0005-8f57c287cbc1"), "Plantoid_06.png", 8 },
                    { new Guid("22222222-2222-0000-0005-be709b1b6b50"), "Plantoid_07.png", 8 },
                    { new Guid("22222222-2222-0000-0005-7826f5f2f44c"), "Plantoid_08.png", 8 },
                    { new Guid("22222222-2222-0000-0005-5a3142b959c0"), "Plantoid_09.png", 8 },
                    { new Guid("22222222-2222-0000-0005-a39ce2042ab3"), "Reptilian_massive_13.png", 9 },
                    { new Guid("22222222-2222-0000-0005-01554a52ad30"), "Plantoid_10.png", 8 },
                    { new Guid("22222222-2222-0000-0005-e4be2cfb9669"), "Plantoid_12.png", 8 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName", "SpeciesType" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-0000-0005-12f5a268ea73"), "Plantoid_13.png", 8 },
                    { new Guid("22222222-2222-0000-0005-0a053a0bb1ad"), "Plantoid_14.png", 8 },
                    { new Guid("22222222-2222-0000-0005-7ca378911564"), "Plantoid_15.png", 8 },
                    { new Guid("22222222-2222-0000-0005-e7bdfe9602a4"), "Plantoid_hivemind.png", 8 },
                    { new Guid("22222222-2222-0000-0005-0dfba808b2e1"), "Reptilian_16.png", 9 },
                    { new Guid("22222222-2222-0000-0005-1134f66f5ec3"), "Reptilian_17.png", 9 },
                    { new Guid("22222222-2222-0000-0005-30f42f709914"), "Reptilian_massive_11.png", 9 },
                    { new Guid("22222222-2222-0000-0005-0c5c26e55699"), "Plantoid_11.png", 8 },
                    { new Guid("22222222-2222-0000-0005-252076fdcc03"), "Mammalian_massive_17.png", 5 },
                    { new Guid("22222222-2222-0000-0005-9b7cd58a7118"), "Mammalian_normal_07.png", 5 },
                    { new Guid("22222222-2222-0000-0005-ccce22d92c71"), "Mammalian_massive_15.png", 5 },
                    { new Guid("22222222-2222-0000-0005-a65bbcd295e6"), "Mammalian_massive_16.png", 5 },
                    { new Guid("22222222-2222-0000-0004-461e17de2b81"), "Avian_massive_11.png", 4 },
                    { new Guid("22222222-2222-0000-0004-beb2f37aabca"), "Avian_massive_12.png", 4 },
                    { new Guid("22222222-2222-0000-0004-d9b3206f5bde"), "Avian_massive_13.png", 4 },
                    { new Guid("22222222-2222-0000-0004-df4f7fa13342"), "Avian_massive_14.png", 4 },
                    { new Guid("22222222-2222-0000-0004-26e3d161cc91"), "Avian_massive_15.png", 4 },
                    { new Guid("22222222-2222-0000-0004-009e992f1667"), "Avian_massive_16.png", 4 },
                    { new Guid("22222222-2222-0000-0004-e4561c11b129"), "Avian_massive_17.png", 4 },
                    { new Guid("22222222-2222-0000-0004-59b4a036598a"), "Avian_normal_06.png", 4 },
                    { new Guid("22222222-2222-0000-0003-25c639b710ed"), "Arthropoid_slender_05.png", 2 },
                    { new Guid("22222222-2222-0000-0004-ba43849d85ac"), "Avian_normal_07.png", 4 },
                    { new Guid("22222222-2222-0000-0004-c94ddb578e15"), "Avian_normal_09.png", 4 },
                    { new Guid("22222222-2222-0000-0004-f2d51ca358e1"), "Avian_normal_10.png", 4 },
                    { new Guid("22222222-2222-0000-0004-79f7dc57a6ef"), "Avian_slender_01.png", 4 },
                    { new Guid("22222222-2222-0000-0004-d1abb18ac955"), "Avian_slender_02.png", 4 },
                    { new Guid("22222222-2222-0000-0004-e9b1c9f53b00"), "Avian_slender_03.png", 4 },
                    { new Guid("22222222-2222-0000-0004-eca3989cff8c"), "Avian_slender_04.png", 4 },
                    { new Guid("22222222-2222-0000-0004-3dc61d3ec887"), "Avian_slender_05.png", 4 },
                    { new Guid("22222222-2222-0000-0005-d7b41cfdaf76"), "Fungoid_17.png", 11 },
                    { new Guid("22222222-2222-0000-0005-99013cb95bbd"), "Fungoid_massive_11.png", 11 },
                    { new Guid("22222222-2222-0000-0004-a41cbfc3a2d0"), "Avian_normal_08.png", 4 },
                    { new Guid("22222222-2222-0000-0003-f8e74a276650"), "Arthropoid_slender_03.png", 2 },
                    { new Guid("22222222-2222-0000-0003-0bd8bc8b5c04"), "Arthropoid_slender_01.png", 2 },
                    { new Guid("22222222-2222-0000-0003-62f458ececf0"), "Arthropoid_normal_10.png", 2 },
                    { new Guid("22222222-2222-0000-0001-f767e933b649"), "Alien_AI.png", 3 },
                    { new Guid("22222222-2222-0000-0001-ee1bd82b1062"), "Alien_AI_red.png", 3 },
                    { new Guid("22222222-2222-0000-0001-e78d009741ad"), "Alien_extradimensional_01.png", 3 },
                    { new Guid("22222222-2222-0000-0001-be5807e86491"), "Alien_extradimensional_02.png", 3 },
                    { new Guid("22222222-2222-0000-0001-305c25f034d7"), "Alien_extradimensional_03.png", 3 },
                    { new Guid("22222222-2222-0000-0001-a4bea66e94c2"), "Alien_Swarm.png", 3 },
                    { new Guid("22222222-2222-0000-0003-5cedabc2eb68"), "Arthropoid_18.png", 2 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName", "SpeciesType" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-0000-0003-292ed1175ce1"), "Arthropoid_19.png", 2 },
                    { new Guid("22222222-2222-0000-0003-5aaeb4e06b38"), "Arthropoid_20.png", 2 },
                    { new Guid("22222222-2222-0000-0003-5b960184b0db"), "Arthropoid_massive_11.png", 2 },
                    { new Guid("22222222-2222-0000-0003-a783cc04fafa"), "Arthropoid_massive_12.png", 2 },
                    { new Guid("22222222-2222-0000-0003-0ea9d5234afb"), "Arthropoid_massive_13.png", 2 },
                    { new Guid("22222222-2222-0000-0003-6d2c7313dcf6"), "Arthropoid_massive_14.png", 2 },
                    { new Guid("22222222-2222-0000-0003-7268b02c24eb"), "Arthropoid_massive_15.png", 2 },
                    { new Guid("22222222-2222-0000-0003-ed8d781ff41b"), "Arthropoid_massive_16.png", 2 },
                    { new Guid("22222222-2222-0000-0003-2a9b2afc1a1e"), "Arthropoid_massive_17.png", 2 },
                    { new Guid("22222222-2222-0000-0003-e1a194845eda"), "Arthropoid_normal_06.png", 2 },
                    { new Guid("22222222-2222-0000-0003-5edf18e174ef"), "Arthropoid_normal_07.png", 2 },
                    { new Guid("22222222-2222-0000-0003-f801ce1701fc"), "Arthropoid_normal_08.png", 2 },
                    { new Guid("22222222-2222-0000-0003-111c578bbf31"), "Arthropoid_normal_08.png", 2 },
                    { new Guid("22222222-2222-0000-0003-8a190f13b5dd"), "Arthropoid_normal_09.png", 2 },
                    { new Guid("22222222-2222-0000-0005-321b094f5762"), "Fungoid_massive_12.png", 11 },
                    { new Guid("22222222-2222-0000-0005-8788d5f3e35d"), "Fungoid_massive_13.png", 11 },
                    { new Guid("22222222-2222-0000-0004-579805ddbf3e"), "Avian_18.png", 4 },
                    { new Guid("22222222-2222-0000-0005-ea718adf8cba"), "Fungoid_massive_15.png", 11 },
                    { new Guid("22222222-2222-0000-0000-3d38f15ceb53"), "800px-Lithoid_02.png", 0 },
                    { new Guid("22222222-2222-0000-0005-9b54ce119f41"), "Lithoid_01.png", 0 },
                    { new Guid("22222222-2222-0000-0005-900dfed3ffb3"), "Lithoid_03.png", 0 },
                    { new Guid("22222222-2222-0000-0005-61ea12c85a2c"), "Lithoid_04.png", 0 },
                    { new Guid("22222222-2222-0000-0005-272873c8b411"), "Lithoid_05.png", 0 },
                    { new Guid("22222222-2222-0000-0005-6ea926a2b0c6"), "Lithoid_06.png", 0 },
                    { new Guid("22222222-2222-0000-0005-1dde173a0d72"), "Lithoid_07.png", 0 },
                    { new Guid("22222222-2222-0000-0005-3201f2777c5c"), "Lithoid_09.png", 0 },
                    { new Guid("22222222-2222-0000-0005-14430c731dc2"), "Fungoid_massive_14.png", 11 },
                    { new Guid("22222222-2222-0000-0005-fa500ed000ad"), "Humanoid_hp_13.png", 1 },
                    { new Guid("22222222-2222-0000-0005-cb94dd8d78d0"), "Lithoid_10.png", 0 },
                    { new Guid("22222222-2222-0000-0005-f6b64797af4c"), "Lithoid_12.png", 0 },
                    { new Guid("22222222-2222-0000-0005-4b55bc7c7346"), "Lithoid_13.png", 0 },
                    { new Guid("22222222-2222-0000-0005-7fbbd7e6992a"), "Lithoid_14.png", 0 },
                    { new Guid("22222222-2222-0000-0005-a58f567804b0"), "Lithoid_15.png", 0 },
                    { new Guid("22222222-2222-0000-0005-ae4531fe98bc"), "Lithoid_machine.png", 0 },
                    { new Guid("22222222-2222-0000-0005-72178817ffaa"), "Mammalian_massive_11.png", 5 },
                    { new Guid("22222222-2222-0000-0005-42c24127daa8"), "Mammalian_massive_12.png", 5 },
                    { new Guid("22222222-2222-0000-0005-1faa52038f22"), "Mammalian_massive_13.png", 5 },
                    { new Guid("22222222-2222-0000-0005-e16843b2e2d4"), "Mammalian_massive_14.png", 5 },
                    { new Guid("22222222-2222-0000-0005-5da0041f1c23"), "Lithoid_11.png", 0 },
                    { new Guid("22222222-2222-0000-0005-d890407c0aee"), "Humanoid_hp_12.png", 1 },
                    { new Guid("22222222-2222-0000-0005-ce568aa409cf"), "Lithoid_08.png", 0 },
                    { new Guid("22222222-2222-0000-0005-45a446592796"), "Humanoid_hp_10.png", 1 }
                });

            migrationBuilder.InsertData(
                table: "Species",
                columns: new[] { "Id", "AssetName", "SpeciesType" },
                values: new object[,]
                {
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
                    { new Guid("22222222-2222-0000-0005-16ba70b3283c"), "Humanoid_hp_11.png", 1 },
                    { new Guid("22222222-2222-0000-0005-689e44079a1d"), "Humanoid_02.png", 1 },
                    { new Guid("22222222-2222-0000-0005-a9ecea6c70f0"), "Humanoid_05.png", 1 },
                    { new Guid("22222222-2222-0000-0005-0f7c49113abd"), "Humanoid_hp_09.png", 1 },
                    { new Guid("22222222-2222-0000-0005-eff52ae02db1"), "Humanoid_hp_08.png", 1 },
                    { new Guid("22222222-2222-0000-0005-000ec530cb8b"), "Humanoid_hp_07.png", 1 },
                    { new Guid("22222222-2222-0000-0005-8da311f350e4"), "Humanoid_03.png", 1 },
                    { new Guid("22222222-2222-0000-0005-7a0a13c31b24"), "Humanoid_hp_06.png", 1 },
                    { new Guid("22222222-2222-0000-0005-a824f3b7650f"), "Humanoid_04.png", 1 },
                    { new Guid("22222222-2222-0000-0005-f75660d2b48c"), "Humanoid_hp_02.png", 1 },
                    { new Guid("22222222-2222-0000-0005-ab24503fa348"), "Humanoid_hp_01.png", 1 }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                column: "Id",
                values: new object[]
                {
                    new Guid("c8d6228c-4c68-444d-bdf9-bb16279a5eb8"),
                    new Guid("a0500eb9-8f5c-4fd0-90af-4be209939464"),
                    new Guid("b8d93f41-d6c2-4ce8-9763-840ecb53bf44"),
                    new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                    new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"),
                    new Guid("89b6448b-ca4e-43d4-a8bb-69b6f5c55211"),
                    new Guid("6d519575-bcfb-49f7-aef9-15a4b8364b32"),
                    new Guid("81b33a6b-c9a6-446c-bf61-441931a9f2ab"),
                    new Guid("4df104b3-64b6-4843-ba43-4b5b98f08c2b"),
                    new Guid("8a0a5dab-f877-4714-8e6b-1b578f480268"),
                    new Guid("e5c2c36b-3393-4599-b054-77458c7e74e8"),
                    new Guid("e200ef94-6eb9-46c8-ba08-3dd86ac3b373"),
                    new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"),
                    new Guid("44517245-cb20-4324-a275-4d8642207ad4"),
                    new Guid("bdcae1cc-d8e2-4dd5-97b6-8cde1162f6ee"),
                    new Guid("adab9b7c-53e7-4f89-aa62-61b8a6d8b60f"),
                    new Guid("35c9d3c1-bb03-4c2a-b6dd-eb34c0bfcf0d"),
                    new Guid("08f6708b-dd2a-427a-9e49-e24810452421"),
                    new Guid("7d3b17d6-3084-4725-a259-cff46fc3a554"),
                    new Guid("20ef5beb-8d80-4ea1-980a-1b77649b4249")
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                column: "Id",
                values: new object[]
                {
                    new Guid("626d4d9b-f90e-4e24-8f84-054e709afa2a"),
                    new Guid("8efb2b99-2132-4510-8d24-ff80b86223db"),
                    new Guid("405a352f-943d-40f7-9e8a-359872d25e84"),
                    new Guid("4f692196-4c30-4af0-9813-03cfe4c35e15"),
                    new Guid("73488326-4f47-418c-a5bd-7d31095fb539"),
                    new Guid("233c1c99-cda1-4d90-ad8b-834903b455f3"),
                    new Guid("12f1450b-5ad5-4799-98c4-8a63c0f79da2"),
                    new Guid("e193ba9c-4b8c-4e21-8c5c-e15421de26f4"),
                    new Guid("113dc4ed-4272-4577-8b55-92780e0751ff"),
                    new Guid("f19fc99c-2db1-4877-9ac3-32974174f970"),
                    new Guid("5966224b-f201-4a6a-8b86-d7cf36856e06"),
                    new Guid("9b4d8661-7811-4324-a6bf-ee30cd83c3cd"),
                    new Guid("08b9feac-851b-4f76-87ca-b97d1a9f1a78"),
                    new Guid("4139a914-6958-482a-9fab-6291426e075f"),
                    new Guid("fcc5c51a-5705-4517-9890-f5fa8d8bde25"),
                    new Guid("f09e72d5-28d8-4390-bdf5-3b589b61fc15"),
                    new Guid("357f7740-3ca7-4ff8-81c6-9cf22289a709"),
                    new Guid("a6a8f230-dde3-464d-9edd-76cfc9882cbb"),
                    new Guid("31b2747d-ff1b-49b1-bf97-782bdb28cba2"),
                    new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"),
                    new Guid("45168d04-86cb-499c-aec9-a8255580071e"),
                    new Guid("428801f4-4777-4589-9a64-cb97bcef71cb"),
                    new Guid("0998d19e-c02f-41e2-b2fd-ba5c6fc7def1"),
                    new Guid("75021a39-c0c1-46f0-b155-f1cdfb9fbc00")
                });

            migrationBuilder.InsertData(
                table: "BuildingCosts",
                columns: new[] { "Id", "BuildingId", "ResourceId" },
                values: new object[,]
                {
                    { new Guid("4d6ddf71-901c-4734-b6cd-23fd2d701002"), new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("18f5c558-4ff8-483d-812c-b0e9e49eb9f6"), new Guid("4df104b3-64b6-4843-ba43-4b5b98f08c2b"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("40f3accc-ba71-4306-95f5-67421aeb89f0"), new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"), new Guid("00000000-1111-0000-0000-000000000011") },
                    { new Guid("36ddec13-5b03-4e09-b1d4-eb9865fa3ec6"), new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"), new Guid("00000000-1111-0000-0000-000000000011") },
                    { new Guid("01951251-4fdb-4ad6-98f1-ae001e779b04"), new Guid("44517245-cb20-4324-a275-4d8642207ad4"), new Guid("00000000-1111-0000-0000-000000000011") },
                    { new Guid("9c85b65c-72e6-4e41-9106-d35580c0f9ab"), new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"), new Guid("00000000-1111-0000-0000-000000000011") },
                    { new Guid("1b7ccec7-f828-4c20-81ed-08472bea2486"), new Guid("626d4d9b-f90e-4e24-8f84-054e709afa2a"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("daee009b-8819-4ccf-944a-0e5e35a95d3f"), new Guid("c8d6228c-4c68-444d-bdf9-bb16279a5eb8"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("261c88ea-3595-4a65-9823-a3c245d0e9c6"), new Guid("0998d19e-c02f-41e2-b2fd-ba5c6fc7def1"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("b385d85d-7dc0-48e6-b9f0-b84ac3a26540"), new Guid("428801f4-4777-4589-9a64-cb97bcef71cb"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("ef756673-3ae1-4e35-951b-5bf3ef24a6f0"), new Guid("45168d04-86cb-499c-aec9-a8255580071e"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("ea28699a-c944-48a1-b6ff-30f8536cb840"), new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("41333116-1ce5-4625-96b6-1f7c75f1bd38"), new Guid("31b2747d-ff1b-49b1-bf97-782bdb28cba2"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("651e720f-9c3a-4f1f-9095-fcc82ccc0d36"), new Guid("a6a8f230-dde3-464d-9edd-76cfc9882cbb"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("1f147721-9f55-4856-b160-6be4b097b2f6"), new Guid("357f7740-3ca7-4ff8-81c6-9cf22289a709"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("f9814f8d-6dce-4f44-818b-63426ae1bc27"), new Guid("405a352f-943d-40f7-9e8a-359872d25e84"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("bd87afe1-192e-4618-a34c-7a6e8ed7eb0b"), new Guid("75021a39-c0c1-46f0-b155-f1cdfb9fbc00"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("7d09ed30-8fa3-4e8d-bfa2-8702539f6ae9"), new Guid("a0500eb9-8f5c-4fd0-90af-4be209939464"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("0e521620-3a9d-4f1a-9822-e7a1fb746246"), new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"), new Guid("00000000-1111-0000-0000-000000000015") },
                    { new Guid("8f367705-7c4e-4a3d-9761-1b91dbb1aa55"), new Guid("6d519575-bcfb-49f7-aef9-15a4b8364b32"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("15474d59-20c5-463c-bdf0-bc9b09f7e08a"), new Guid("e5c2c36b-3393-4599-b054-77458c7e74e8"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("778a6f92-e76d-4c0a-a03f-fa5e1d31bca2"), new Guid("e200ef94-6eb9-46c8-ba08-3dd86ac3b373"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("daface0d-0bbc-4e5b-a11e-55bce19c4b0b"), new Guid("44517245-cb20-4324-a275-4d8642207ad4"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("8ff89127-91e6-4dc0-a375-7dd3d9125870"), new Guid("bdcae1cc-d8e2-4dd5-97b6-8cde1162f6ee"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("6fd807b8-043a-4e62-b9c9-6b8dff135da0"), new Guid("adab9b7c-53e7-4f89-aa62-61b8a6d8b60f"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("f4b92197-1eca-4003-94ff-eb47ae854ceb"), new Guid("b8d93f41-d6c2-4ce8-9763-840ecb53bf44"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("0a0e9ef7-6926-4871-9f51-7ad94e8dc8e1"), new Guid("35c9d3c1-bb03-4c2a-b6dd-eb34c0bfcf0d"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("2f921c53-c7ba-426b-8c37-553f9cf37bef"), new Guid("7d3b17d6-3084-4725-a259-cff46fc3a554"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("760dc621-3bab-4e9a-ae53-fed5dcd76f85"), new Guid("81b33a6b-c9a6-446c-bf61-441931a9f2ab"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("ec330d07-7dcd-40ac-9151-1d53bc6ce6d4"), new Guid("20ef5beb-8d80-4ea1-980a-1b77649b4249"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("df3f2c81-7bb8-4913-8817-57c352c07aed"), new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("58d5be3e-1d49-4c0a-ae2c-f46791d0e919"), new Guid("8a0a5dab-f877-4714-8e6b-1b578f480268"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("76f6afe9-670a-4ba5-90d8-01891f15a6a2"), new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("1eba7135-5378-4276-b163-5e631fb6a2c2"), new Guid("08f6708b-dd2a-427a-9e49-e24810452421"), new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("306a853b-8583-4a1e-8ace-c49ec34ef991"), new Guid("89b6448b-ca4e-43d4-a8bb-69b6f5c55211"), new Guid("00000000-1111-0000-0000-000000000016") }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "AssetName", "BuildableOn", "BuildingType", "Description", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("75021a39-c0c1-46f0-b155-f1cdfb9fbc00"), "9.jpg", 2, 0, "TODO", "Small Shipyard", 1 },
                    { new Guid("0998d19e-c02f-41e2-b2fd-ba5c6fc7def1"), "2.jpg", 2, 1, "TODO", "Germanium Dissolver", 22 },
                    { new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"), "17.jpg", 2, 1, "TODO", "Titanium Mine", 15 },
                    { new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"), "2.jpg", 2, 1, "Produces the most basic building material ever seen in space.. But we all need it everywhere.", "Iron Mine", 16 },
                    { new Guid("b8d93f41-d6c2-4ce8-9763-840ecb53bf44"), "2.jpg", 2, 1, "TODO", "Cobalt Melting Plant", 17 },
                    { new Guid("a0500eb9-8f5c-4fd0-90af-4be209939464"), "2.jpg", 2, 1, "TODO", "Nickel Melting Plant", 18 },
                    { new Guid("c8d6228c-4c68-444d-bdf9-bb16279a5eb8"), "2.jpg", 2, 1, "TODO", "Copper Melting Plant", 19 }
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "AssetName", "BuildableOn", "BuildingType", "Description", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("4df104b3-64b6-4843-ba43-4b5b98f08c2b"), "2.jpg", 2, 1, "TODO", "Zinc Mine", 20 },
                    { new Guid("626d4d9b-f90e-4e24-8f84-054e709afa2a"), "2.jpg", 2, 1, "TODO", "Gallium smelting plant", 21 },
                    { new Guid("e5c2c36b-3393-4599-b054-77458c7e74e8"), "7.jpg", 2, 1, "TODO", "Phosphorus Miner", 12 },
                    { new Guid("405a352f-943d-40f7-9e8a-359872d25e84"), "2.jpg", 2, 1, "TODO", "Palladium Mine", 23 },
                    { new Guid("428801f4-4777-4589-9a64-cb97bcef71cb"), "2.jpg", 2, 1, "TODO", "Silver Mine", 24 },
                    { new Guid("45168d04-86cb-499c-aec9-a8255580071e"), "2.jpg", 2, 1, "TODO", "Tin Mine", 25 },
                    { new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"), "18.jpg", 2, 1, "TODO", "Iridium Mine", 26 },
                    { new Guid("31b2747d-ff1b-49b1-bf97-782bdb28cba2"), "2.jpg", 2, 1, "TODO", "Platinum Mine", 27 },
                    { new Guid("a6a8f230-dde3-464d-9edd-76cfc9882cbb"), "2.jpg", 2, 1, "TODO", "Gold Mine", 28 },
                    { new Guid("89b6448b-ca4e-43d4-a8bb-69b6f5c55211"), "7.jpg", 2, 1, "TODO", "Chlorine Dissolver", 14 },
                    { new Guid("357f7740-3ca7-4ff8-81c6-9cf22289a709"), "2.jpg", 2, 1, "TODO", "Plutonium Reactor", 29 },
                    { new Guid("e200ef94-6eb9-46c8-ba08-3dd86ac3b373"), "7.jpg", 2, 1, "We need silicon to produce electronics which we need for quiet all of our constructs.", "Silicon Mine", 11 },
                    { new Guid("44517245-cb20-4324-a275-4d8642207ad4"), "11.jpg", 2, 1, "TODO", "Aluminum smelting plant", 10 },
                    { new Guid("bdcae1cc-d8e2-4dd5-97b6-8cde1162f6ee"), "9.jpg", 2, 1, "TODO", "Magnesium Reductor", 9 },
                    { new Guid("adab9b7c-53e7-4f89-aa62-61b8a6d8b60f"), "9.jpg", 2, 1, "TODO", "Oxygen Extractor", 8 },
                    { new Guid("35c9d3c1-bb03-4c2a-b6dd-eb34c0bfcf0d"), "9.jpg", 2, 1, "TODO", "Nitrogen Destillator", 7 },
                    { new Guid("08f6708b-dd2a-427a-9e49-e24810452421"), "9.jpg", 2, 1, "TODO", "Carbon Extractor", 6 },
                    { new Guid("7d3b17d6-3084-4725-a259-cff46fc3a554"), "9.jpg", 2, 1, "TODO", "Boron Reductor", 5 },
                    { new Guid("81b33a6b-c9a6-446c-bf61-441931a9f2ab"), "9.jpg", 2, 1, "TODO", "Beryllium Reductor", 4 },
                    { new Guid("20ef5beb-8d80-4ea1-980a-1b77649b4249"), "9.jpg", 2, 1, "TODO", "Lithium Extractor", 3 },
                    { new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"), "9.jpg", 2, 1, "Helium is one of the most important parts to generate fuels.", "Helium Extractor", 2 },
                    { new Guid("8a0a5dab-f877-4714-8e6b-1b578f480268"), "6.jpg", 2, 1, "Extracts Hydrogen molecules from within the atmosphere to produce an industrial product.", "Hydrogen Extractor", 1 },
                    { new Guid("f09e72d5-28d8-4390-bdf5-3b589b61fc15"), "19.jpg", 2, 5, "TODO", "Iron Store", 1 },
                    { new Guid("6d519575-bcfb-49f7-aef9-15a4b8364b32"), "7.jpg", 2, 1, "TODO", "Sulfur Mine", 13 }
                });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "Id", "Email", "Password", "PlayerId", "Salt" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-1110-000000000000"), "daniel@dirtyandnative.de", new byte[] { 214, 212, 211, 33, 140, 160, 231, 162, 57, 199, 64, 131, 187, 201, 119, 192, 203, 109, 243, 123, 229, 56, 47, 180, 17, 5, 138, 178, 72, 221, 137, 25, 69, 173, 181, 157, 202, 130, 182, 172, 20, 121, 129, 43, 136, 74, 120, 242, 126, 100, 62, 207, 24, 9, 244, 206, 7, 166, 63, 155, 128, 118, 47, 81 }, new Guid("22222222-0000-0000-0000-000000000000"), new byte[] { 193, 79, 225, 80, 112, 24, 191, 243, 40, 86, 90, 75, 6, 166, 103, 215, 30, 13, 70, 153, 161, 73, 23, 145, 154, 13, 46, 5, 245, 103, 100, 241 } },
                    { new Guid("00000000-0000-0000-1110-000000000001"), "test1@dirtyandnative.de", new byte[] { 214, 212, 211, 33, 140, 160, 231, 162, 57, 199, 64, 131, 187, 201, 119, 192, 203, 109, 243, 123, 229, 56, 47, 180, 17, 5, 138, 178, 72, 221, 137, 25, 69, 173, 181, 157, 202, 130, 182, 172, 20, 121, 129, 43, 136, 74, 120, 242, 126, 100, 62, 207, 24, 9, 244, 206, 7, 166, 63, 155, 128, 118, 47, 81 }, new Guid("22222222-0000-0000-0000-000000000001"), new byte[] { 193, 79, 225, 80, 112, 24, 191, 243, 40, 86, 90, 75, 6, 166, 103, 215, 30, 13, 70, 153, 161, 73, 23, 145, 154, 13, 46, 5, 245, 103, 100, 241 } },
                    { new Guid("00000000-0000-0000-1110-000000000002"), "test2@dirtyandnative.de", new byte[] { 214, 212, 211, 33, 140, 160, 231, 162, 57, 199, 64, 131, 187, 201, 119, 192, 203, 109, 243, 123, 229, 56, 47, 180, 17, 5, 138, 178, 72, 221, 137, 25, 69, 173, 181, 157, 202, 130, 182, 172, 20, 121, 129, 43, 136, 74, 120, 242, 126, 100, 62, 207, 24, 9, 244, 206, 7, 166, 63, 155, 128, 118, 47, 81 }, new Guid("22222222-0000-0000-0000-000000000002"), new byte[] { 193, 79, 225, 80, 112, 24, 191, 243, 40, 86, 90, 75, 6, 166, 103, 215, 30, 13, 70, 153, 161, 73, 23, 145, 154, 13, 46, 5, 245, 103, 100, 241 } }
                });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "IsBaseResource", "Symbol", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-1111-0000-0000-000000000027"), false, "Pt", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000016"), true, "Fe", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000017"), false, "Co", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000018"), false, "Ni", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000019"), false, "Cu", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000020"), false, "Zn", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000021"), false, "Ga", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000029"), false, "Pu", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000023"), false, "Pd", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000024"), false, "Ag", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000025"), false, "Sn", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000026"), false, "Ir", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000028"), false, "Au", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000022"), false, "Ge", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000011"), true, "Si", 1 }
                });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "IsBaseResource", "Symbol", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-1111-0000-0000-000000000014"), false, "Cl", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000015"), false, "Ti", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000001"), true, "H", 0 },
                    { new Guid("00000000-1111-0000-0000-000000000003"), false, "Li", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000004"), false, "Be", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000005"), false, "B", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000006"), false, "C", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000002"), true, "He", 0 },
                    { new Guid("00000000-1111-0000-0000-000000000008"), true, "O", 0 },
                    { new Guid("00000000-1111-0000-0000-000000000009"), false, "Mg", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000010"), false, "Al", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000012"), false, "P", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000013"), false, "S", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000007"), false, "N", 1 }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-1111-0000-000000000003"), 1 },
                    { new Guid("00000000-1111-1111-0000-000000000001"), 2 },
                    { new Guid("00000000-1111-1111-0000-000000000002"), 2 },
                    { new Guid("00000000-1111-1111-0000-000000000003"), 2 },
                    { new Guid("00000000-3333-1111-0000-000000000002"), 0 },
                    { new Guid("00000000-2222-1111-0000-000000000002"), 4 },
                    { new Guid("00000000-3333-1111-0000-000000000003"), 0 },
                    { new Guid("00000000-4444-1111-0000-000000000001"), 3 },
                    { new Guid("00000000-0000-1111-0000-000000000002"), 1 },
                    { new Guid("00000000-4444-1111-0000-000000000002"), 3 },
                    { new Guid("00000000-2222-1111-0000-000000000001"), 4 },
                    { new Guid("00000000-0000-1111-0000-000000000001"), 1 },
                    { new Guid("00000000-5555-1111-0000-000000000002"), 4 },
                    { new Guid("00000000-5555-1111-0000-000000000001"), 4 }
                });

            migrationBuilder.InsertData(
                table: "Researches",
                columns: new[] { "Id", "AssetName", "BuildingConsumptionMultiplier", "BuildingCostMultiplier", "BuildingProductionMultiplier", "BuildingTimeMultiplier", "CargoCapacityMultiplier", "Description", "FuelConsumptionMultiplier", "InterstellarSpeedMultiplier", "Name", "Order", "ResearchType", "ShieldPowerMultiplier", "StellarSpeedMultiplier", "StructuralIntegrityMultiplier", "WeaponPowerMultiplier" },
                values: new object[,]
                {
                    { new Guid("4f692196-4c30-4af0-9813-03cfe4c35e15"), "1.jpg", 0.0, 0.0, 0.0, 0.0, 0.0, "TODO", 0.0, 0.0, "Quantum Theory", 0, 0, 0.0, 0.0, 0.0, 0.0 },
                    { new Guid("233c1c99-cda1-4d90-ad8b-834903b455f3"), "1.jpg", 0.0, 0.0, 0.0, 0.0, 0.0, "TODO", 0.0, 0.0, "Weapon Engineering", 0, 6, 0.0, 0.0, 0.0, 0.0 },
                    { new Guid("12f1450b-5ad5-4799-98c4-8a63c0f79da2"), "1.jpg", 0.0, 0.0, 0.0, 0.0, 0.0, "TODO", 0.0, 0.0, "Shield Engineering", 0, 6, 0.0, 0.0, 0.0, 0.0 },
                    { new Guid("e193ba9c-4b8c-4e21-8c5c-e15421de26f4"), "1.jpg", 0.0, 0.0, 0.0, 0.0, 0.0, "TODO", 0.0, 0.0, "Armor Engineering", 0, 6, 0.0, 0.0, 0.0, 0.0 },
                    { new Guid("113dc4ed-4272-4577-8b55-92780e0751ff"), "1.jpg", 0.0, 0.0, 0.0, 0.0, 0.0, "TODO", 0.0, 0.0, "Impulse Thruster", 0, 1, 0.0, 0.0, 0.0, 0.0 },
                    { new Guid("f19fc99c-2db1-4877-9ac3-32974174f970"), "1.jpg", 0.0, 0.0, 0.0, 0.0, 0.0, "TODO", 0.0, 0.0, "Ion Thruster", 0, 1, 0.0, 0.0, 0.0, 0.0 },
                    { new Guid("9b4d8661-7811-4324-a6bf-ee30cd83c3cd"), "1.jpg", 0.0, 0.0, 0.0, 0.0, 0.0, "TODO", 0.0, 0.0, "Dark Matter Thruster", 0, 1, 0.0, 0.0, 0.0, 0.0 },
                    { new Guid("08b9feac-851b-4f76-87ca-b97d1a9f1a78"), "1.jpg", 0.0, 0.0, 0.0, 0.0, 0.0, "TODO", 0.0, 0.0, "Dark Matter Thruster", 0, 3, 0.0, 0.0, 0.0, 0.0 },
                    { new Guid("8efb2b99-2132-4510-8d24-ff80b86223db"), "1.jpg", 0.0, 0.0, 0.0, 0.0, 0.0, "TODO", 0.0, 0.0, "Efficient Workplaces", 0, 5, 0.0, 0.0, 0.0, 0.0 },
                    { new Guid("4139a914-6958-482a-9fab-6291426e075f"), "1.jpg", 0.0, 0.0, 0.0, 0.0, 0.0, "TODO", 0.0, 0.0, "Planet colonization", 0, 7, 0.0, 0.0, 0.0, 0.0 },
                    { new Guid("fcc5c51a-5705-4517-9890-f5fa8d8bde25"), "1.jpg", 0.0, 0.0, 0.0, 0.0, 0.0, "TODO", 0.0, 0.0, "Moon colonization", 0, 7, 0.0, 0.0, 0.0, 0.0 },
                    { new Guid("73488326-4f47-418c-a5bd-7d31095fb539"), "1.jpg", 0.0, 0.0, 0.0, 0.0, 0.0, "TODO", 0.0, 0.0, "Espionage Technology", 0, 1, 0.0, 0.0, 0.0, 0.0 },
                    { new Guid("5966224b-f201-4a6a-8b86-d7cf36856e06"), "1.jpg", 0.0, 0.0, 0.0, 0.0, 0.0, "TODO", 0.0, 0.0, "Plasma Thruster", 0, 1, 0.0, 0.0, 0.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "CargoCapacity", "Description", "FuelConsumption", "FuelId", "InterstellarSpeed", "Name", "ShieldPower", "StellarSpeed", "StructuralIntegrity", "WeaponPower" },
                values: new object[] { new Guid("d11e09e0-e058-4e2e-8cf0-65a0a79b81be"), 2000L, "A small pod to transport some resources", 10L, new Guid("00000000-1111-0000-0000-000000000001"), 50000L, "Cargo pod", 10L, 5000L, 4000L, 0L });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[,]
                {
                    { new Guid("15474d59-20c5-463c-bdf0-bc9b09f7e08a"), 300.0, 1.3999999999999999 },
                    { new Guid("daface0d-0bbc-4e5b-a11e-55bce19c4b0b"), 500.0, 1.6000000000000001 },
                    { new Guid("8ff89127-91e6-4dc0-a375-7dd3d9125870"), 250.0, 1.55 },
                    { new Guid("6fd807b8-043a-4e62-b9c9-6b8dff135da0"), 250.0, 1.55 },
                    { new Guid("0a0e9ef7-6926-4871-9f51-7ad94e8dc8e1"), 250.0, 1.55 },
                    { new Guid("1eba7135-5378-4276-b163-5e631fb6a2c2"), 250.0, 1.55 },
                    { new Guid("2f921c53-c7ba-426b-8c37-553f9cf37bef"), 250.0, 1.55 },
                    { new Guid("778a6f92-e76d-4c0a-a03f-fa5e1d31bca2"), 300.0, 1.3999999999999999 },
                    { new Guid("760dc621-3bab-4e9a-ae53-fed5dcd76f85"), 250.0, 1.55 },
                    { new Guid("df3f2c81-7bb8-4913-8817-57c352c07aed"), 250.0, 1.55 },
                    { new Guid("58d5be3e-1d49-4c0a-ae2c-f46791d0e919"), 68.0, 1.5 },
                    { new Guid("0e521620-3a9d-4f1a-9822-e7a1fb746246"), 500.0, 1.6000000000000001 },
                    { new Guid("40f3accc-ba71-4306-95f5-67421aeb89f0"), 600.0, 1.5 },
                    { new Guid("36ddec13-5b03-4e09-b1d4-eb9865fa3ec6"), 900.0, 1.6000000000000001 },
                    { new Guid("01951251-4fdb-4ad6-98f1-ae001e779b04"), 400.0, 1.5 },
                    { new Guid("ec330d07-7dcd-40ac-9151-1d53bc6ce6d4"), 250.0, 1.55 },
                    { new Guid("9c85b65c-72e6-4e41-9106-d35580c0f9ab"), 100.0, 1.3999999999999999 },
                    { new Guid("1f147721-9f55-4856-b160-6be4b097b2f6"), 60.0, 1.5 },
                    { new Guid("306a853b-8583-4a1e-8ace-c49ec34ef991"), 300.0, 1.3999999999999999 },
                    { new Guid("651e720f-9c3a-4f1f-9095-fcc82ccc0d36"), 60.0, 1.5 },
                    { new Guid("41333116-1ce5-4625-96b6-1f7c75f1bd38"), 60.0, 1.5 },
                    { new Guid("ea28699a-c944-48a1-b6ff-30f8536cb840"), 700.0, 1.25 },
                    { new Guid("ef756673-3ae1-4e35-951b-5bf3ef24a6f0"), 60.0, 1.5 },
                    { new Guid("b385d85d-7dc0-48e6-b9f0-b84ac3a26540"), 60.0, 1.5 },
                    { new Guid("f9814f8d-6dce-4f44-818b-63426ae1bc27"), 60.0, 1.5 },
                    { new Guid("8f367705-7c4e-4a3d-9761-1b91dbb1aa55"), 300.0, 1.3999999999999999 },
                    { new Guid("261c88ea-3595-4a65-9823-a3c245d0e9c6"), 60.0, 1.5 },
                    { new Guid("18f5c558-4ff8-483d-812c-b0e9e49eb9f6"), 60.0, 1.5 },
                    { new Guid("daee009b-8819-4ccf-944a-0e5e35a95d3f"), 60.0, 1.5 },
                    { new Guid("7d09ed30-8fa3-4e8d-bfa2-8702539f6ae9"), 60.0, 1.5 },
                    { new Guid("f4b92197-1eca-4003-94ff-eb47ae854ceb"), 60.0, 1.5 },
                    { new Guid("76f6afe9-670a-4ba5-90d8-01891f15a6a2"), 60.0, 1.5 },
                    { new Guid("4d6ddf71-901c-4734-b6cd-23fd2d701002"), 800.0, 1.3 },
                    { new Guid("1b7ccec7-f828-4c20-81ed-08472bea2486"), 60.0, 1.5 }
                });

            migrationBuilder.InsertData(
                table: "FixedBuildingCosts",
                columns: new[] { "Id", "Amount" },
                values: new object[] { new Guid("bd87afe1-192e-4618-a34c-7a6e8ed7eb0b"), 2000.0 });

            migrationBuilder.InsertData(
                table: "FixedBuildings",
                column: "Id",
                value: new Guid("75021a39-c0c1-46f0-b155-f1cdfb9fbc00"));

            migrationBuilder.InsertData(
                table: "LevelableBuildings",
                column: "Id",
                values: new object[]
                {
                    new Guid("a6a8f230-dde3-464d-9edd-76cfc9882cbb"),
                    new Guid("a0500eb9-8f5c-4fd0-90af-4be209939464"),
                    new Guid("31b2747d-ff1b-49b1-bf97-782bdb28cba2"),
                    new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                    new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"),
                    new Guid("89b6448b-ca4e-43d4-a8bb-69b6f5c55211")
                });

            migrationBuilder.InsertData(
                table: "LevelableBuildings",
                column: "Id",
                values: new object[]
                {
                    new Guid("6d519575-bcfb-49f7-aef9-15a4b8364b32"),
                    new Guid("e5c2c36b-3393-4599-b054-77458c7e74e8"),
                    new Guid("e200ef94-6eb9-46c8-ba08-3dd86ac3b373"),
                    new Guid("c8d6228c-4c68-444d-bdf9-bb16279a5eb8"),
                    new Guid("44517245-cb20-4324-a275-4d8642207ad4"),
                    new Guid("adab9b7c-53e7-4f89-aa62-61b8a6d8b60f"),
                    new Guid("35c9d3c1-bb03-4c2a-b6dd-eb34c0bfcf0d"),
                    new Guid("08f6708b-dd2a-427a-9e49-e24810452421"),
                    new Guid("7d3b17d6-3084-4725-a259-cff46fc3a554"),
                    new Guid("81b33a6b-c9a6-446c-bf61-441931a9f2ab"),
                    new Guid("20ef5beb-8d80-4ea1-980a-1b77649b4249"),
                    new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"),
                    new Guid("8a0a5dab-f877-4714-8e6b-1b578f480268"),
                    new Guid("bdcae1cc-d8e2-4dd5-97b6-8cde1162f6ee"),
                    new Guid("4df104b3-64b6-4843-ba43-4b5b98f08c2b"),
                    new Guid("b8d93f41-d6c2-4ce8-9763-840ecb53bf44"),
                    new Guid("0998d19e-c02f-41e2-b2fd-ba5c6fc7def1"),
                    new Guid("405a352f-943d-40f7-9e8a-359872d25e84"),
                    new Guid("428801f4-4777-4589-9a64-cb97bcef71cb"),
                    new Guid("45168d04-86cb-499c-aec9-a8255580071e"),
                    new Guid("357f7740-3ca7-4ff8-81c6-9cf22289a709"),
                    new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"),
                    new Guid("f09e72d5-28d8-4390-bdf5-3b589b61fc15"),
                    new Guid("626d4d9b-f90e-4e24-8f84-054e709afa2a")
                });

            migrationBuilder.InsertData(
                table: "LevelableResearches",
                column: "Id",
                values: new object[]
                {
                    new Guid("4f692196-4c30-4af0-9813-03cfe4c35e15"),
                    new Guid("73488326-4f47-418c-a5bd-7d31095fb539"),
                    new Guid("233c1c99-cda1-4d90-ad8b-834903b455f3"),
                    new Guid("12f1450b-5ad5-4799-98c4-8a63c0f79da2"),
                    new Guid("113dc4ed-4272-4577-8b55-92780e0751ff"),
                    new Guid("f19fc99c-2db1-4877-9ac3-32974174f970"),
                    new Guid("5966224b-f201-4a6a-8b86-d7cf36856e06"),
                    new Guid("9b4d8661-7811-4324-a6bf-ee30cd83c3cd"),
                    new Guid("08b9feac-851b-4f76-87ca-b97d1a9f1a78"),
                    new Guid("8efb2b99-2132-4510-8d24-ff80b86223db"),
                    new Guid("e193ba9c-4b8c-4e21-8c5c-e15421de26f4")
                });

            migrationBuilder.InsertData(
                table: "OneTimeResearches",
                column: "Id",
                values: new object[]
                {
                    new Guid("4139a914-6958-482a-9fab-6291426e075f"),
                    new Guid("fcc5c51a-5705-4517-9890-f5fa8d8bde25")
                });

            migrationBuilder.InsertData(
                table: "OutputResources",
                columns: new[] { "Id", "BaseValue", "BuildingId", "Multiplier", "ResourceId" },
                values: new object[,]
                {
                    { new Guid("f2486784-2189-49a4-a644-e6d93e0ff7f4"), 37.0, new Guid("adab9b7c-53e7-4f89-aa62-61b8a6d8b60f"), 1.1299999999999999, new Guid("00000000-1111-0000-0000-000000000008") },
                    { new Guid("a53e9771-e133-431b-9471-9dbd0ca5d245"), 38.0, new Guid("e200ef94-6eb9-46c8-ba08-3dd86ac3b373"), 1.0800000000000001, new Guid("00000000-1111-0000-0000-000000000011") },
                    { new Guid("2825a2ee-2c89-4eb3-a2fa-ecc20c2a8602"), 35.0, new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"), 1.0800000000000001, new Guid("00000000-1111-0000-0000-000000000026") },
                    { new Guid("f2486781-2189-49a4-a644-e6d93e0ff7c4"), 37.0, new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"), 1.1499999999999999, new Guid("00000000-1111-0000-0000-000000000002") },
                    { new Guid("dd746ce3-b795-4700-8e7f-0f82e7bfe80f"), 30.0, new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"), 1.1000000000000001, new Guid("00000000-1111-0000-0000-000000000015") }
                });

            migrationBuilder.InsertData(
                table: "OutputResources",
                columns: new[] { "Id", "BaseValue", "BuildingId", "Multiplier", "ResourceId" },
                values: new object[] { new Guid("792f2b69-3726-42ca-9ef3-015fb5b2e486"), 35.0, new Guid("8a0a5dab-f877-4714-8e6b-1b578f480268"), 1.1799999999999999, new Guid("00000000-1111-0000-0000-000000000001") });

            migrationBuilder.InsertData(
                table: "OutputResources",
                columns: new[] { "Id", "BaseValue", "BuildingId", "Multiplier", "ResourceId" },
                values: new object[] { new Guid("24a0efe4-27d2-43c6-bb7b-61b36c129b00"), 40.0, new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"), 1.1000000000000001, new Guid("00000000-1111-0000-0000-000000000016") });

            migrationBuilder.InsertData(
                table: "OutputResources",
                columns: new[] { "Id", "BaseValue", "BuildingId", "Multiplier", "ResourceId" },
                values: new object[] { new Guid("a49f760c-3168-410b-9f8a-39bffcc766e8"), 37.0, new Guid("44517245-cb20-4324-a275-4d8642207ad4"), 1.1000000000000001, new Guid("00000000-1111-0000-0000-000000000010") });

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
                name: "IX_Conditions_NeededTechnologyId",
                table: "Conditions",
                column: "NeededTechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_TechnologyId",
                table: "Conditions",
                column: "TechnologyId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationMessages_ConversationId",
                table: "ConversationMessages",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationMessages_PlayerId",
                table: "ConversationMessages",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationParticipants_ConversationId",
                table: "ConversationParticipants",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationParticipants_PlayerId",
                table: "ConversationParticipants",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_PlayerId",
                table: "Credentials",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DynamicResearchCosts_LevelableResearchId",
                table: "DynamicResearchCosts",
                column: "LevelableResearchId");

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
                name: "IX_OneTimeResearchCosts_OneTimeResearchId",
                table: "OneTimeResearchCosts",
                column: "OneTimeResearchId");

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
                name: "IX_ResearchCosts_ResearchId",
                table: "ResearchCosts",
                column: "ResearchId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchCosts_ResourceId",
                table: "ResearchCosts",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchStudies_PlayerId",
                table: "ResearchStudies",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResearchStudies_ResearchId",
                table: "ResearchStudies",
                column: "ResearchId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceSnapshots_StellarObjectId",
                table: "ResourceSnapshots",
                column: "StellarObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipConstructionCosts_ResourceId",
                table: "ShipConstructionCosts",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipConstructionCosts_ShipId",
                table: "ShipConstructionCosts",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_FuelId",
                table: "Ships",
                column: "FuelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SolarSystems_ParentId",
                table: "SolarSystems",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_ResourceId",
                table: "StellarObjectResources",
                column: "ResourceId");

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

            migrationBuilder.CreateIndex(
                name: "IX_StudiedResearches_PlayerId",
                table: "StudiedResearches",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_StudiedResearches_ResearchId",
                table: "StudiedResearches",
                column: "ResearchId");

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
                name: "BlackHoles");

            migrationBuilder.DropTable(
                name: "BuildingConstructions");

            migrationBuilder.DropTable(
                name: "BuiltBuildings");

            migrationBuilder.DropTable(
                name: "ConversationMessages");

            migrationBuilder.DropTable(
                name: "ConversationParticipants");

            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropTable(
                name: "DynamicBuildingCosts");

            migrationBuilder.DropTable(
                name: "DynamicResearchCosts");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "FixedBuildingCosts");

            migrationBuilder.DropTable(
                name: "FixedBuildings");

            migrationBuilder.DropTable(
                name: "InputResources");

            migrationBuilder.DropTable(
                name: "LevelableBuildings");

            migrationBuilder.DropTable(
                name: "LevelableConditions");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Moons");

            migrationBuilder.DropTable(
                name: "MultiObjectSystems");

            migrationBuilder.DropTable(
                name: "OneTimeConditions");

            migrationBuilder.DropTable(
                name: "OneTimeResearchCosts");

            migrationBuilder.DropTable(
                name: "OutputResources");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "PlayerSpeciesPerks");

            migrationBuilder.DropTable(
                name: "ResearchStudies");

            migrationBuilder.DropTable(
                name: "ShipConstructionCosts");

            migrationBuilder.DropTable(
                name: "SolarSystems");

            migrationBuilder.DropTable(
                name: "Stars");

            migrationBuilder.DropTable(
                name: "StellarObjectResources");

            migrationBuilder.DropTable(
                name: "StoredResources");

            migrationBuilder.DropTable(
                name: "StudiedResearches");

            migrationBuilder.DropTable(
                name: "BuildingChains");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "LevelableResearches");

            migrationBuilder.DropTable(
                name: "BuildingCosts");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "OneTimeResearches");

            migrationBuilder.DropTable(
                name: "ResearchCosts");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "ColonizableStellarObjects");

            migrationBuilder.DropTable(
                name: "Perks");

            migrationBuilder.DropTable(
                name: "PlayerSpecies");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropTable(
                name: "ResourceSnapshots");

            migrationBuilder.DropTable(
                name: "Researches");

            migrationBuilder.DropTable(
                name: "ColonizedStellarObjects");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "StellarObjects");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "StellarSystems");

            migrationBuilder.DropTable(
                name: "Galaxies");
        }
    }
}
