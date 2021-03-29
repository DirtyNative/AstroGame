using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AddedBuildingCosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingCosts_Buildings_BuildingId",
                table: "BuildingCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_InputResources_Buildings_BuildingId",
                table: "InputResources");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputResources_Buildings_BuildingId",
                table: "OutputResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings");

            migrationBuilder.RenameTable(
                name: "Buildings",
                newName: "PlanetBuildings");

            migrationBuilder.AddColumn<int>(
                name: "BuildableOn",
                table: "PlanetBuildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlanetBuildings",
                table: "PlanetBuildings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BuiltBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColonizedStellarObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuiltBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuiltBuildings_ColonizedStellarObjects_ColonizedStellarObjectId",
                        column: x => x.ColonizedStellarObjectId,
                        principalTable: "ColonizedStellarObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuiltBuildings_PlanetBuildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "PlanetBuildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "PlanetBuildings",
                keyColumn: "Id",
                keyValue: new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                column: "BuildableOn",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_BuiltBuildings_BuildingId",
                table: "BuiltBuildings",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuiltBuildings_ColonizedStellarObjectId",
                table: "BuiltBuildings",
                column: "ColonizedStellarObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingCosts_PlanetBuildings_BuildingId",
                table: "BuildingCosts",
                column: "BuildingId",
                principalTable: "PlanetBuildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputResources_PlanetBuildings_BuildingId",
                table: "InputResources",
                column: "BuildingId",
                principalTable: "PlanetBuildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputResources_PlanetBuildings_BuildingId",
                table: "OutputResources",
                column: "BuildingId",
                principalTable: "PlanetBuildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingCosts_PlanetBuildings_BuildingId",
                table: "BuildingCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_InputResources_PlanetBuildings_BuildingId",
                table: "InputResources");

            migrationBuilder.DropForeignKey(
                name: "FK_OutputResources_PlanetBuildings_BuildingId",
                table: "OutputResources");

            migrationBuilder.DropTable(
                name: "BuiltBuildings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlanetBuildings",
                table: "PlanetBuildings");

            migrationBuilder.DropColumn(
                name: "BuildableOn",
                table: "PlanetBuildings");

            migrationBuilder.RenameTable(
                name: "PlanetBuildings",
                newName: "Buildings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingCosts_Buildings_BuildingId",
                table: "BuildingCosts",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InputResources_Buildings_BuildingId",
                table: "InputResources",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OutputResources_Buildings_BuildingId",
                table: "OutputResources",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
