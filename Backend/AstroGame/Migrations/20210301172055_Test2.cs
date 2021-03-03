using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_Stars_StellarObjectId",
                table: "StellarObjectResources");

            migrationBuilder.AddColumn<Guid>(
                name: "StarId",
                table: "StellarObjectResources",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_StarId",
                table: "StellarObjectResources",
                column: "StarId");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_Stars_StarId",
                table: "StellarObjectResources",
                column: "StarId",
                principalTable: "Stars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_Stars_StarId",
                table: "StellarObjectResources");

            migrationBuilder.DropIndex(
                name: "IX_StellarObjectResources_StarId",
                table: "StellarObjectResources");

            migrationBuilder.DropColumn(
                name: "StarId",
                table: "StellarObjectResources");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_Stars_StellarObjectId",
                table: "StellarObjectResources",
                column: "StellarObjectId",
                principalTable: "Stars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
