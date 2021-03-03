using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class ConnectedStellarObjectWithResource : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StellarObjectResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    StellarObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarObjectResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StellarObjectResources_Moons_MoonId",
                        column: x => x.MoonId,
                        principalTable: "Moons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StellarObjectResources_Planets_StellarObjectId",
                        column: x => x.StellarObjectId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StellarObjectResources_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StellarObjectResources_Stars_StarId",
                        column: x => x.StarId,
                        principalTable: "Stars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjectResources_MoonId",
                table: "StellarObjectResources",
                column: "MoonId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StellarObjectResources");
        }
    }
}
