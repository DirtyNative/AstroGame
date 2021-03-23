using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlayerSpeciesId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerSpecies_Players_PlayerId",
                table: "PlayerSpecies");

            migrationBuilder.DropIndex(
                name: "IX_PlayerSpecies_PlayerId",
                table: "PlayerSpecies");

            migrationBuilder.DropColumn(
                name: "PlayerSpeciesId",
                table: "Players");
        }
    }
}
