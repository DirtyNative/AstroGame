using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class RemovedBuildingChains : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingConstructions");

            migrationBuilder.DropTable(
                name: "ResearchStudies");

            migrationBuilder.DropTable(
                name: "BuildingChains");

            migrationBuilder.DropColumn(
                name: "BuildingChainId",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "PlayerDependentTechnologyUpgrades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerDependentTechnologyUpgrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerDependentTechnologyUpgrades_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerDependentTechnologyUpgrades_TechnologyUpgrades_Id",
                        column: x => x.Id,
                        principalTable: "TechnologyUpgrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StellarObjectDependentTechnologyUpgrades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    StellarObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarObjectDependentTechnologyUpgrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StellarObjectDependentTechnologyUpgrades_StellarObjects_StellarObjectId",
                        column: x => x.StellarObjectId,
                        principalTable: "StellarObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StellarObjectDependentTechnologyUpgrades_TechnologyUpgrades_Id",
                        column: x => x.Id,
                        principalTable: "TechnologyUpgrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerDependentTechnologyUpgrades_PlayerId",
                table: "PlayerDependentTechnologyUpgrades",
                column: "PlayerId",
                unique: true,
                filter: "[PlayerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectDependentTechnologyUpgrades_StellarObjectId",
                table: "StellarObjectDependentTechnologyUpgrades",
                column: "StellarObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerDependentTechnologyUpgrades");

            migrationBuilder.DropTable(
                name: "StellarObjectDependentTechnologyUpgrades");

            migrationBuilder.AddColumn<Guid>(
                name: "BuildingChainId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "BuildingChains",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ChainLength = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "ResearchStudies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                        name: "FK_ResearchStudies_TechnologyUpgrades_Id",
                        column: x => x.Id,
                        principalTable: "TechnologyUpgrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuildingConstructions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    BuildingChainId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StellarObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                        name: "FK_BuildingConstructions_StellarObjects_StellarObjectId",
                        column: x => x.StellarObjectId,
                        principalTable: "StellarObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingConstructions_TechnologyUpgrades_Id",
                        column: x => x.Id,
                        principalTable: "TechnologyUpgrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_BuildingConstructions_StellarObjectId",
                table: "BuildingConstructions",
                column: "StellarObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchStudies_PlayerId",
                table: "ResearchStudies",
                column: "PlayerId",
                unique: true,
                filter: "[PlayerId] IS NOT NULL");
        }
    }
}
