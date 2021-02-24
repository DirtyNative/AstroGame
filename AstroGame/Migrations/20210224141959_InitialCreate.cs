using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StellarObjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrefabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scale = table.Column<double>(type: "float", nullable: false),
                    RotationSpeed = table.Column<double>(type: "float", nullable: false),
                    StellarObjectType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageTemperate = table.Column<int>(type: "int", nullable: true),
                    Moon_DistanceToCenter = table.Column<double>(type: "float", nullable: true),
                    Moon_HasRings = table.Column<bool>(type: "bit", nullable: true),
                    Planet_AverageTemperature = table.Column<int>(type: "int", nullable: true),
                    DistanceToCenter = table.Column<double>(type: "float", nullable: true),
                    HasAtmosphere = table.Column<bool>(type: "bit", nullable: true),
                    HasRings = table.Column<bool>(type: "bit", nullable: true),
                    PlanetType = table.Column<int>(type: "int", nullable: true),
                    StarType = table.Column<int>(type: "int", nullable: true),
                    AverageTemperature = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StellarSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    MultiObjectSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StellarSystemType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StellarSystems_StellarObjects_ParentId",
                        column: x => x.ParentId,
                        principalTable: "StellarObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StellarSystems_StellarSystems_MultiObjectSystemId",
                        column: x => x.MultiObjectSystemId,
                        principalTable: "StellarSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StellarSystems_StellarSystems_ParentId1",
                        column: x => x.ParentId1,
                        principalTable: "StellarSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystems_MultiObjectSystemId",
                table: "StellarSystems",
                column: "MultiObjectSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystems_ParentId",
                table: "StellarSystems",
                column: "ParentId",
                unique: true,
                filter: "[ParentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystems_ParentId1",
                table: "StellarSystems",
                column: "ParentId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StellarSystems");

            migrationBuilder.DropTable(
                name: "StellarObjects");
        }
    }
}
