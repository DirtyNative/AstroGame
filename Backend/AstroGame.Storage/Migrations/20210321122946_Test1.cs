using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PlayerSpecies_SpeciesId",
                table: "PlayerSpecies",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerSpecies_Species_SpeciesId",
                table: "PlayerSpecies",
                column: "SpeciesId",
                principalTable: "Species",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerSpecies_Species_SpeciesId",
                table: "PlayerSpecies");

            migrationBuilder.DropIndex(
                name: "IX_PlayerSpecies_SpeciesId",
                table: "PlayerSpecies");
        }
    }
}
