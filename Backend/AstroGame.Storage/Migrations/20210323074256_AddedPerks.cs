using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AddedPerks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "PerkPlayerSpecies",
                columns: table => new
                {
                    PerksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerSpeciesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerkPlayerSpecies", x => new { x.PerksId, x.PlayerSpeciesId });
                    table.ForeignKey(
                        name: "FK_PerkPlayerSpecies_Perks_PerksId",
                        column: x => x.PerksId,
                        principalTable: "Perks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerkPlayerSpecies_PlayerSpecies_PlayerSpeciesId",
                        column: x => x.PlayerSpeciesId,
                        principalTable: "PlayerSpecies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Perks",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { new Guid("00000000-0000-1111-0000-000000000000"), "", "Fast builder" });

            migrationBuilder.CreateIndex(
                name: "IX_PerkPlayerSpecies_PlayerSpeciesId",
                table: "PerkPlayerSpecies",
                column: "PlayerSpeciesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerkPlayerSpecies");

            migrationBuilder.DropTable(
                name: "Perks");
        }
    }
}
