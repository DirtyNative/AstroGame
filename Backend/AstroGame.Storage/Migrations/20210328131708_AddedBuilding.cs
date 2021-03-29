using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AddedBuilding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputResources_ResourceManufactions_OutputMaterialId",
                table: "InputResources");

            migrationBuilder.DropTable(
                name: "ResourceManufactions");

            migrationBuilder.DeleteData(
                table: "InputResources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "InputResources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: new Guid("00000000-3333-1111-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-3333-1111-0000-000000000001"));

            migrationBuilder.DropColumn(
                name: "ManufactionId",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "OutputMaterialId",
                table: "InputResources",
                newName: "BuildingId");

            migrationBuilder.RenameColumn(
                name: "InputValue",
                table: "InputResources",
                newName: "Multiplier");

            migrationBuilder.RenameIndex(
                name: "IX_InputResources_OutputMaterialId",
                table: "InputResources",
                newName: "IX_InputResources_BuildingId");

            migrationBuilder.AddColumn<double>(
                name: "BaseValue",
                table: "InputResources",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseValue = table.Column<double>(type: "float", nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuildingCosts_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingCosts_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutputResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuildingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BaseValue = table.Column<double>(type: "float", nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutputResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutputResources_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutputResources_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "AssetName", "Description", "Name", "Order" },
                values: new object[] { new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"), "iron_mine.png", "", "Iron Mine", 1 });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-1111-0000-0000-000000000010"),
                column: "Name",
                value: "Aluminum");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingCosts_BuildingId",
                table: "BuildingCosts",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingCosts_ResourceId",
                table: "BuildingCosts",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputResources_BuildingId",
                table: "OutputResources",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_OutputResources_ResourceId",
                table: "OutputResources",
                column: "ResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InputResources_Buildings_BuildingId",
                table: "InputResources",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InputResources_Buildings_BuildingId",
                table: "InputResources");

            migrationBuilder.DropTable(
                name: "BuildingCosts");

            migrationBuilder.DropTable(
                name: "OutputResources");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropColumn(
                name: "BaseValue",
                table: "InputResources");

            migrationBuilder.RenameColumn(
                name: "Multiplier",
                table: "InputResources",
                newName: "InputValue");

            migrationBuilder.RenameColumn(
                name: "BuildingId",
                table: "InputResources",
                newName: "OutputMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_InputResources_BuildingId",
                table: "InputResources",
                newName: "IX_InputResources_OutputMaterialId");

            migrationBuilder.AddColumn<Guid>(
                name: "ManufactionId",
                table: "Materials",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ResourceManufactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    OutputMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutputValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceManufactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceManufactions_Materials_OutputMaterialId",
                        column: x => x.OutputMaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-1111-0000-000000000001"),
                column: "ManufactionId",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.InsertData(
                table: "ResourceManufactions",
                columns: new[] { "Id", "OutputMaterialId", "OutputValue" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-1111-0000-000000000001"), 1.0 });

            migrationBuilder.UpdateData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: new Guid("00000000-1111-0000-0000-000000000010"),
                column: "Name",
                value: "Aluminium");

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "NaturalOccurrenceWeight" },
                values: new object[] { new Guid("00000000-3333-1111-0000-000000000001"), "Hardened Iron", 0L });

            migrationBuilder.InsertData(
                table: "InputResources",
                columns: new[] { "Id", "InputValue", "OutputMaterialId", "ResourceId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), 2.0, new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-1111-0000-0000-000000000001") });

            migrationBuilder.InsertData(
                table: "InputResources",
                columns: new[] { "Id", "InputValue", "OutputMaterialId", "ResourceId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), 2.0, new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-1111-0000-0000-000000000008") });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "ManufactionId", "Type" },
                values: new object[] { new Guid("00000000-3333-1111-0000-000000000001"), null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceManufactions_OutputMaterialId",
                table: "ResourceManufactions",
                column: "OutputMaterialId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InputResources_ResourceManufactions_OutputMaterialId",
                table: "InputResources",
                column: "OutputMaterialId",
                principalTable: "ResourceManufactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
