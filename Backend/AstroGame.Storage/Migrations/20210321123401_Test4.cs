using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class Test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerSpecies_Players_PlayerId",
                table: "PlayerSpecies");

            migrationBuilder.DropIndex(
                name: "IX_PlayerSpecies_PlayerId",
                table: "PlayerSpecies");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerSpeciesId",
                table: "Players",
                column: "PlayerSpeciesId",
                unique: true,
                filter: "[PlayerSpeciesId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_PlayerSpecies_PlayerSpeciesId",
                table: "Players",
                column: "PlayerSpeciesId",
                principalTable: "PlayerSpecies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_PlayerSpecies_PlayerSpeciesId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerSpeciesId",
                table: "Players");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSpecies_PlayerId",
                table: "PlayerSpecies",
                column: "PlayerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerSpecies_Players_PlayerId",
                table: "PlayerSpecies",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
