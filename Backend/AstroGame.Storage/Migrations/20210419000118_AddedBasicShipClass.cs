using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AddedBasicShipClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StructuralIntegrity = table.Column<long>(type: "bigint", nullable: false),
                    ShieldPower = table.Column<long>(type: "bigint", nullable: false),
                    WeaponPower = table.Column<long>(type: "bigint", nullable: false),
                    CargoCapacity = table.Column<long>(type: "bigint", nullable: false),
                    StellarSpeed = table.Column<long>(type: "bigint", nullable: false),
                    InterstellarSpeed = table.Column<long>(type: "bigint", nullable: false),
                    FuelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuelConsumption = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ships_Resources_FuelId",
                        column: x => x.FuelId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipConstructionCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipConstructionCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipConstructionCosts_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShipConstructionCosts_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "AssetName", "BuildableOn", "Description", "Name", "Order" },
                values: new object[] { new Guid("75021a39-c0c1-46f0-b155-f1cdfb9fbc00"), "9.jpg", 2, "TODO", "Small Shipyard", 1 });

            migrationBuilder.InsertData(
                table: "Ships",
                columns: new[] { "Id", "CargoCapacity", "Description", "FuelConsumption", "FuelId", "InterstellarSpeed", "Name", "ShieldPower", "StellarSpeed", "StructuralIntegrity", "WeaponPower" },
                values: new object[] { new Guid("d11e09e0-e058-4e2e-8cf0-65a0a79b81be"), 2000L, "A small pod to transport some resources", 10L, new Guid("00000000-1111-0000-0000-000000000001"), 50000L, "Cargo pod", 10L, 5000L, 4000L, 0L });

            migrationBuilder.InsertData(
                table: "CivilBuildings",
                column: "Id",
                value: new Guid("75021a39-c0c1-46f0-b155-f1cdfb9fbc00"));

            migrationBuilder.CreateIndex(
                name: "IX_ShipConstructionCosts_ResourceId",
                table: "ShipConstructionCosts",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipConstructionCosts_ShipId",
                table: "ShipConstructionCosts",
                column: "ShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Ships_FuelId",
                table: "Ships",
                column: "FuelId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShipConstructionCosts");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DeleteData(
                table: "CivilBuildings",
                keyColumn: "Id",
                keyValue: new Guid("75021a39-c0c1-46f0-b155-f1cdfb9fbc00"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("75021a39-c0c1-46f0-b155-f1cdfb9fbc00"));
        }
    }
}
