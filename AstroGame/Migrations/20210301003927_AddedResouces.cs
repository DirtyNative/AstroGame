using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class AddedResouces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NaturalOccurrenceWeight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elements_Resources_Id",
                        column: x => x.Id,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ManufactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Resources_Id",
                        column: x => x.Id,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "InputResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutputMaterialId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InputValue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputResources_ResourceManufactions_OutputMaterialId",
                        column: x => x.OutputMaterialId,
                        principalTable: "ResourceManufactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InputResources_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "NaturalOccurrenceWeight" },
                values: new object[,]
                {
                    { new Guid("00000000-1111-0000-0000-000000000001"), "Hydrogen", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000024"), "Silver", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000025"), "Tin", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000026"), "Iridium", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000027"), "Platinum", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000028"), "Gold", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000029"), "Plutonium", 1.0 },
                    { new Guid("00000000-0000-1111-0000-000000000001"), "Water", 1.0 },
                    { new Guid("00000000-0000-1111-0000-000000000002"), "Food", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000023"), "Palladium", 1.0 },
                    { new Guid("00000000-0000-1111-0000-000000000003"), "Luxury Goods", 1.0 },
                    { new Guid("00000000-1111-1111-0000-000000000002"), "Conductive Components", 1.0 },
                    { new Guid("00000000-1111-1111-0000-000000000003"), "Supra conductors", 1.0 },
                    { new Guid("00000000-2222-1111-0000-000000000001"), "Deuterium", 1.0 },
                    { new Guid("00000000-2222-1111-0000-000000000002"), "Tritium", 1.0 },
                    { new Guid("00000000-3333-1111-0000-000000000001"), "Hardened Iron", 0.0 },
                    { new Guid("00000000-3333-1111-0000-000000000002"), "Steel", 0.0 },
                    { new Guid("00000000-3333-1111-0000-000000000003"), "Nanites", 0.0 },
                    { new Guid("00000000-4444-1111-0000-000000000001"), "Reactive alloys", 0.0 },
                    { new Guid("00000000-1111-1111-0000-000000000001"), "Conductive Components", 1.0 },
                    { new Guid("00000000-4444-1111-0000-000000000002"), "Nano alloys", 0.0 },
                    { new Guid("00000000-1111-0000-0000-000000000022"), "Germanium", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000020"), "Zinc", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000002"), "Helium", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000003"), "Lithium", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000004"), "Beryllium", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000005"), "Boron", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000006"), "Carbon", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000007"), "Nitrogen", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000008"), "Oxygen", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000009"), "Magnesium", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000021"), "Gallium", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000010"), "Aluminium", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000012"), "Phosphorus", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000013"), "Sulfur", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000014"), "Chlorine", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000015"), "Titanium", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000016"), "Iron", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000017"), "Cobalt", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000018"), "Nickel", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000019"), "Copper", 1.0 },
                    { new Guid("00000000-1111-0000-0000-000000000011"), "Silicon", 1.0 }
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "NaturalOccurrenceWeight" },
                values: new object[] { new Guid("00000000-5555-1111-0000-000000000001"), "Dark matter", 0.0 });

            migrationBuilder.InsertData(
                table: "Elements",
                columns: new[] { "Id", "Symbol", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-1111-0000-0000-000000000001"), "H", 0 },
                    { new Guid("00000000-1111-0000-0000-000000000029"), "Pu", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000028"), "Au", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000027"), "Pt", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000026"), "Ir", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000025"), "Sn", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000024"), "Ag", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000023"), "Pd", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000021"), "Ga", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000020"), "Zn", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000019"), "Cu", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000018"), "Ni", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000017"), "Co", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000016"), "Fe", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000022"), "Ge", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000014"), "Cl", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000015"), "Ti", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000003"), "Li", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000004"), "Be", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000005"), "B", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000006"), "C", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000007"), "N", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000002"), "He", 0 },
                    { new Guid("00000000-1111-0000-0000-000000000009"), "Mg", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000010"), "Al", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000011"), "Si", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000012"), "P", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000013"), "S", 1 },
                    { new Guid("00000000-1111-0000-0000-000000000008"), "O", 0 }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "ManufactionId", "Type" },
                values: new object[,]
                {
                    { new Guid("00000000-4444-1111-0000-000000000002"), null, 3 },
                    { new Guid("00000000-4444-1111-0000-000000000001"), null, 3 },
                    { new Guid("00000000-3333-1111-0000-000000000003"), null, 0 },
                    { new Guid("00000000-3333-1111-0000-000000000002"), null, 0 },
                    { new Guid("00000000-3333-1111-0000-000000000001"), null, 0 },
                    { new Guid("00000000-2222-1111-0000-000000000002"), null, 4 },
                    { new Guid("00000000-1111-1111-0000-000000000001"), null, 2 },
                    { new Guid("00000000-1111-1111-0000-000000000003"), null, 2 },
                    { new Guid("00000000-1111-1111-0000-000000000002"), null, 2 },
                    { new Guid("00000000-0000-1111-0000-000000000003"), null, 1 },
                    { new Guid("00000000-0000-1111-0000-000000000002"), null, 1 },
                    { new Guid("00000000-0000-1111-0000-000000000001"), null, 1 },
                    { new Guid("00000000-2222-1111-0000-000000000001"), null, 4 }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "ManufactionId", "Type" },
                values: new object[] { new Guid("00000000-5555-1111-0000-000000000001"), null, 0 });

            migrationBuilder.InsertData(
                table: "ResourceManufactions",
                columns: new[] { "Id", "OutputMaterialId", "OutputValue" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-0000-1111-0000-000000000001"), 1.0 });

            migrationBuilder.InsertData(
                table: "InputResources",
                columns: new[] { "Id", "InputValue", "OutputMaterialId", "ResourceId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), 2.0, new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-1111-0000-0000-000000000001") });

            migrationBuilder.InsertData(
                table: "InputResources",
                columns: new[] { "Id", "InputValue", "OutputMaterialId", "ResourceId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000002"), 2.0, new Guid("00000000-0000-0000-0000-000000000001"), new Guid("00000000-1111-0000-0000-000000000008") });

            migrationBuilder.CreateIndex(
                name: "IX_InputResources_OutputMaterialId",
                table: "InputResources",
                column: "OutputMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_InputResources_ResourceId",
                table: "InputResources",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceManufactions_OutputMaterialId",
                table: "ResourceManufactions",
                column: "OutputMaterialId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "InputResources");

            migrationBuilder.DropTable(
                name: "ResourceManufactions");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
