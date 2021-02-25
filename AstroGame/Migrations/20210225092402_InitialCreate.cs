using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StellarObject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PrefabName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scale = table.Column<double>(type: "float", nullable: false),
                    RotationSpeed = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarObject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AverageTemperate = table.Column<int>(type: "int", nullable: false),
                    DistanceToCenter = table.Column<double>(type: "float", nullable: false),
                    HasRings = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moons_StellarObject_Id",
                        column: x => x.Id,
                        principalTable: "StellarObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AverageTemperature = table.Column<int>(type: "int", nullable: false),
                    DistanceToCenter = table.Column<double>(type: "float", nullable: false),
                    HasAtmosphere = table.Column<bool>(type: "bit", nullable: false),
                    HasRings = table.Column<bool>(type: "bit", nullable: false),
                    PlanetType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planets_StellarObject_Id",
                        column: x => x.Id,
                        principalTable: "StellarObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    StarType = table.Column<int>(type: "int", nullable: false),
                    AverageTemperature = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stars_StellarObject_Id",
                        column: x => x.Id,
                        principalTable: "StellarObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolarSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StellarSystem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    MultiObjectSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StellarSystemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StellarSystem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StellarSystem_StellarSystem_ParentId",
                        column: x => x.ParentId,
                        principalTable: "StellarSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StellarSystem_StellarSystem_StellarSystemId",
                        column: x => x.StellarSystemId,
                        principalTable: "StellarSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MultiObjectSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiObjectSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiObjectSystems_StellarSystem_Id",
                        column: x => x.Id,
                        principalTable: "StellarSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SingleObjectSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CenterObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleObjectSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleObjectSystems_StellarObject_CenterObjectId",
                        column: x => x.CenterObjectId,
                        principalTable: "StellarObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SingleObjectSystems_StellarSystem_Id",
                        column: x => x.Id,
                        principalTable: "StellarSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SingleObjectSystems_CenterObjectId",
                table: "SingleObjectSystems",
                column: "CenterObjectId",
                unique: true,
                filter: "[CenterObjectId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystem_MultiObjectSystemId",
                table: "StellarSystem",
                column: "MultiObjectSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystem_ParentId",
                table: "StellarSystem",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystem_StellarSystemId",
                table: "StellarSystem",
                column: "StellarSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolarSystems_MultiObjectSystems_Id",
                table: "SolarSystems",
                column: "Id",
                principalTable: "MultiObjectSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystem_MultiObjectSystems_MultiObjectSystemId",
                table: "StellarSystem",
                column: "MultiObjectSystemId",
                principalTable: "MultiObjectSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MultiObjectSystems_StellarSystem_Id",
                table: "MultiObjectSystems");

            migrationBuilder.DropTable(
                name: "Moons");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "SingleObjectSystems");

            migrationBuilder.DropTable(
                name: "SolarSystems");

            migrationBuilder.DropTable(
                name: "Stars");

            migrationBuilder.DropTable(
                name: "StellarObject");

            migrationBuilder.DropTable(
                name: "StellarSystem");

            migrationBuilder.DropTable(
                name: "MultiObjectSystems");
        }
    }
}
