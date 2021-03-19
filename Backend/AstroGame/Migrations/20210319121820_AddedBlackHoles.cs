using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class AddedBlackHoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BlackHoleId",
                table: "StellarObjectResources",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_BlackHoleId",
                table: "StellarObjectResources",
                column: "BlackHoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_BlackHoles_BlackHoleId",
                table: "StellarObjectResources",
                column: "BlackHoleId",
                principalTable: "BlackHoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_BlackHoles_BlackHoleId",
                table: "StellarObjectResources");

            migrationBuilder.DropTable(
                name: "BlackHoles");

            migrationBuilder.DropIndex(
                name: "IX_StellarObjectResources_BlackHoleId",
                table: "StellarObjectResources");

            migrationBuilder.DropColumn(
                name: "BlackHoleId",
                table: "StellarObjectResources");
        }
    }
}
