using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class ExtendedPerkClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerkPlayerSpecies");

            migrationBuilder.AddColumn<Guid>(
                name: "PerkId",
                table: "PlayerSpecies",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "PlayerSpeciesPerks",
                columns: new[] { "Id", "PerkId", "PlayerSpeciesId" },
                values: new object[] { new Guid("11110000-0000-0000-0000-000000000000"), new Guid("00000000-0000-1111-0000-000000000000"), new Guid("22222222-1111-0000-0000-000000000000") });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSpecies_PerkId",
                table: "PlayerSpecies",
                column: "PerkId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSpeciesPerks_PerkId",
                table: "PlayerSpeciesPerks",
                column: "PerkId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSpeciesPerks_PlayerSpeciesId",
                table: "PlayerSpeciesPerks",
                column: "PlayerSpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerSpecies_Perks_PerkId",
                table: "PlayerSpecies",
                column: "PerkId",
                principalTable: "Perks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerSpecies_Perks_PerkId",
                table: "PlayerSpecies");

            migrationBuilder.DropTable(
                name: "PlayerSpeciesPerks");

            migrationBuilder.DropIndex(
                name: "IX_PlayerSpecies_PerkId",
                table: "PlayerSpecies");

            migrationBuilder.DropColumn(
                name: "PerkId",
                table: "PlayerSpecies");

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

            migrationBuilder.CreateIndex(
                name: "IX_PerkPlayerSpecies_PlayerSpeciesId",
                table: "PerkPlayerSpecies",
                column: "PlayerSpeciesId");
        }
    }
}
