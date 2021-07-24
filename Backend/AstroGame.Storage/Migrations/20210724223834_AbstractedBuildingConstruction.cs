using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AbstractedBuildingConstruction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingConstructions_Buildings_BuildingId",
                table: "BuildingConstructions");

            migrationBuilder.DropForeignKey(
                name: "FK_ResearchStudies_Researches_ResearchId",
                table: "ResearchStudies");

            migrationBuilder.DropIndex(
                name: "IX_ResearchStudies_PlayerId",
                table: "ResearchStudies");

            migrationBuilder.DropIndex(
                name: "IX_ResearchStudies_ResearchId",
                table: "ResearchStudies");

            migrationBuilder.DropIndex(
                name: "IX_BuildingConstructions_BuildingId",
                table: "BuildingConstructions");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "ResearchStudies");

            migrationBuilder.DropColumn(
                name: "HangfireJobId",
                table: "ResearchStudies");

            migrationBuilder.DropColumn(
                name: "ResearchId",
                table: "ResearchStudies");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "ResearchStudies");

            migrationBuilder.DropColumn(
                name: "AssetName",
                table: "Researches");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Researches");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Researches");

            migrationBuilder.DropColumn(
                name: "AssetName",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "BuildingConstructions");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "BuildingConstructions");

            migrationBuilder.DropColumn(
                name: "HangfireJobId",
                table: "BuildingConstructions");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "BuildingConstructions");

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                table: "Technologies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Technologies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Technologies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TechnologyUpgrades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    TechnologyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HangfireJobId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnologyUpgrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnologyUpgrades_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("75021a39-c0c1-46f0-b155-f1cdfb9fbc00"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Small Shipyard" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0233326e-2b2a-4170-993e-835417e293c6"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "19.jpg", "TODO", "Building Grounds" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("08f6708b-dd2a-427a-9e49-e24810452421"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Carbon Extractor" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("0998d19e-c02f-41e2-b2fd-ba5c6fc7def1"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Germanium Dissolver" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("20ef5beb-8d80-4ea1-980a-1b77649b4249"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Lithium Extractor" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("31b2747d-ff1b-49b1-bf97-782bdb28cba2"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Platinum Mine" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("357f7740-3ca7-4ff8-81c6-9cf22289a709"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Plutonium Reactor" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("35c9d3c1-bb03-4c2a-b6dd-eb34c0bfcf0d"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Nitrogen Destillator" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("405a352f-943d-40f7-9e8a-359872d25e84"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Palladium Mine" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("428801f4-4777-4589-9a64-cb97bcef71cb"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Silver Mine" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("44517245-cb20-4324-a275-4d8642207ad4"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "11.jpg", "TODO", "Aluminum smelting plant" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("45168d04-86cb-499c-aec9-a8255580071e"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Tin Mine" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4df104b3-64b6-4843-ba43-4b5b98f08c2b"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Zinc Mine" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "Produces the most basic building material ever seen in space.. But we all need it everywhere.", "Iron Mine" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("626d4d9b-f90e-4e24-8f84-054e709afa2a"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Gallium smelting plant" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("6d519575-bcfb-49f7-aef9-15a4b8364b32"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "7.jpg", "TODO", "Sulfur Mine" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("7d3b17d6-3084-4725-a259-cff46fc3a554"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Boron Reductor" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("81b33a6b-c9a6-446c-bf61-441931a9f2ab"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Beryllium Reductor" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("89b6448b-ca4e-43d4-a8bb-69b6f5c55211"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "7.jpg", "TODO", "Chlorine Dissolver" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8a0a5dab-f877-4714-8e6b-1b578f480268"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "6.jpg", "Extracts Hydrogen molecules from within the atmosphere to produce an industrial product.", "Hydrogen Extractor" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "Helium is one of the most important parts to generate fuels.", "Helium Extractor" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "18.jpg", "TODO", "Iridium Mine" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a0500eb9-8f5c-4fd0-90af-4be209939464"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Nickel Melting Plant" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a6a8f230-dde3-464d-9edd-76cfc9882cbb"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Gold Mine" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("adab9b7c-53e7-4f89-aa62-61b8a6d8b60f"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Oxygen Extractor" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "17.jpg", "TODO", "Titanium Mine" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("b8d93f41-d6c2-4ce8-9763-840ecb53bf44"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Cobalt Melting Plant" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("bdcae1cc-d8e2-4dd5-97b6-8cde1162f6ee"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Magnesium Reductor" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("c8d6228c-4c68-444d-bdf9-bb16279a5eb8"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Copper Melting Plant" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e200ef94-6eb9-46c8-ba08-3dd86ac3b373"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "7.jpg", "We need silicon to produce electronics which we need for quiet all of our constructs.", "Silicon Mine" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e5c2c36b-3393-4599-b054-77458c7e74e8"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "7.jpg", "TODO", "Phosphorus Miner" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f09e72d5-28d8-4390-bdf5-3b589b61fc15"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "19.jpg", "TODO", "Iron Store" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("08b9feac-851b-4f76-87ca-b97d1a9f1a78"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Dark Matter Thruster" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("113dc4ed-4272-4577-8b55-92780e0751ff"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Impulse Thruster" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("12f1450b-5ad5-4799-98c4-8a63c0f79da2"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Shield Engineering" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("233c1c99-cda1-4d90-ad8b-834903b455f3"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Weapon Engineering" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4f692196-4c30-4af0-9813-03cfe4c35e15"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Quantum Theory" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("5966224b-f201-4a6a-8b86-d7cf36856e06"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Plasma Thruster" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("73488326-4f47-418c-a5bd-7d31095fb539"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Espionage Technology" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("8efb2b99-2132-4510-8d24-ff80b86223db"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Efficient Workplaces" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("9b4d8661-7811-4324-a6bf-ee30cd83c3cd"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Dark Matter Thruster" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("a3058710-e6fe-4db1-98d2-f7d93874ff5a"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Efficient living places" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("e193ba9c-4b8c-4e21-8c5c-e15421de26f4"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Armor Engineering" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("f19fc99c-2db1-4877-9ac3-32974174f970"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Ion Thruster" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("4139a914-6958-482a-9fab-6291426e075f"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Planet colonization" });

            migrationBuilder.UpdateData(
                table: "Technologies",
                keyColumn: "Id",
                keyValue: new Guid("fcc5c51a-5705-4517-9890-f5fa8d8bde25"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Moon colonization" });

            migrationBuilder.CreateIndex(
                name: "IX_ResearchStudies_PlayerId",
                table: "ResearchStudies",
                column: "PlayerId",
                unique: true,
                filter: "[PlayerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TechnologyUpgrades_TechnologyId",
                table: "TechnologyUpgrades",
                column: "TechnologyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingConstructions_TechnologyUpgrades_Id",
                table: "BuildingConstructions",
                column: "Id",
                principalTable: "TechnologyUpgrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchStudies_TechnologyUpgrades_Id",
                table: "ResearchStudies",
                column: "Id",
                principalTable: "TechnologyUpgrades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingConstructions_TechnologyUpgrades_Id",
                table: "BuildingConstructions");

            migrationBuilder.DropForeignKey(
                name: "FK_ResearchStudies_TechnologyUpgrades_Id",
                table: "ResearchStudies");

            migrationBuilder.DropTable(
                name: "TechnologyUpgrades");

            migrationBuilder.DropIndex(
                name: "IX_ResearchStudies_PlayerId",
                table: "ResearchStudies");

            migrationBuilder.DropColumn(
                name: "AssetName",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Technologies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Technologies");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "ResearchStudies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HangfireJobId",
                table: "ResearchStudies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ResearchId",
                table: "ResearchStudies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "ResearchStudies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                table: "Researches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Researches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Researches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssetName",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Buildings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BuildingId",
                table: "BuildingConstructions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "BuildingConstructions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "HangfireJobId",
                table: "BuildingConstructions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "BuildingConstructions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("75021a39-c0c1-46f0-b155-f1cdfb9fbc00"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Small Shipyard" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("0233326e-2b2a-4170-993e-835417e293c6"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "19.jpg", "TODO", "Building Grounds" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("08f6708b-dd2a-427a-9e49-e24810452421"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Carbon Extractor" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("0998d19e-c02f-41e2-b2fd-ba5c6fc7def1"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Germanium Dissolver" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("20ef5beb-8d80-4ea1-980a-1b77649b4249"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Lithium Extractor" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("31b2747d-ff1b-49b1-bf97-782bdb28cba2"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Platinum Mine" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("357f7740-3ca7-4ff8-81c6-9cf22289a709"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Plutonium Reactor" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("35c9d3c1-bb03-4c2a-b6dd-eb34c0bfcf0d"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Nitrogen Destillator" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("405a352f-943d-40f7-9e8a-359872d25e84"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Palladium Mine" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("428801f4-4777-4589-9a64-cb97bcef71cb"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Silver Mine" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("44517245-cb20-4324-a275-4d8642207ad4"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "11.jpg", "TODO", "Aluminum smelting plant" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("45168d04-86cb-499c-aec9-a8255580071e"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Tin Mine" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("4df104b3-64b6-4843-ba43-4b5b98f08c2b"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Zinc Mine" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "Produces the most basic building material ever seen in space.. But we all need it everywhere.", "Iron Mine" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("626d4d9b-f90e-4e24-8f84-054e709afa2a"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Gallium smelting plant" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("6d519575-bcfb-49f7-aef9-15a4b8364b32"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "7.jpg", "TODO", "Sulfur Mine" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("7d3b17d6-3084-4725-a259-cff46fc3a554"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Boron Reductor" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("81b33a6b-c9a6-446c-bf61-441931a9f2ab"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Beryllium Reductor" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("89b6448b-ca4e-43d4-a8bb-69b6f5c55211"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "7.jpg", "TODO", "Chlorine Dissolver" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("8a0a5dab-f877-4714-8e6b-1b578f480268"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "6.jpg", "Extracts Hydrogen molecules from within the atmosphere to produce an industrial product.", "Hydrogen Extractor" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "Helium is one of the most important parts to generate fuels.", "Helium Extractor" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "18.jpg", "TODO", "Iridium Mine" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("a0500eb9-8f5c-4fd0-90af-4be209939464"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Nickel Melting Plant" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("a6a8f230-dde3-464d-9edd-76cfc9882cbb"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Gold Mine" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("adab9b7c-53e7-4f89-aa62-61b8a6d8b60f"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Oxygen Extractor" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "17.jpg", "TODO", "Titanium Mine" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("b8d93f41-d6c2-4ce8-9763-840ecb53bf44"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Cobalt Melting Plant" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("bdcae1cc-d8e2-4dd5-97b6-8cde1162f6ee"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "9.jpg", "TODO", "Magnesium Reductor" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("c8d6228c-4c68-444d-bdf9-bb16279a5eb8"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Copper Melting Plant" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("e200ef94-6eb9-46c8-ba08-3dd86ac3b373"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "7.jpg", "We need silicon to produce electronics which we need for quiet all of our constructs.", "Silicon Mine" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("e5c2c36b-3393-4599-b054-77458c7e74e8"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "7.jpg", "TODO", "Phosphorus Miner" });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("f09e72d5-28d8-4390-bdf5-3b589b61fc15"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "19.jpg", "TODO", "Iron Store" });

            migrationBuilder.UpdateData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("08b9feac-851b-4f76-87ca-b97d1a9f1a78"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Dark Matter Thruster" });

            migrationBuilder.UpdateData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("113dc4ed-4272-4577-8b55-92780e0751ff"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Impulse Thruster" });

            migrationBuilder.UpdateData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("12f1450b-5ad5-4799-98c4-8a63c0f79da2"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Shield Engineering" });

            migrationBuilder.UpdateData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("233c1c99-cda1-4d90-ad8b-834903b455f3"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Weapon Engineering" });

            migrationBuilder.UpdateData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("4f692196-4c30-4af0-9813-03cfe4c35e15"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Quantum Theory" });

            migrationBuilder.UpdateData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("5966224b-f201-4a6a-8b86-d7cf36856e06"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Plasma Thruster" });

            migrationBuilder.UpdateData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("73488326-4f47-418c-a5bd-7d31095fb539"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Espionage Technology" });

            migrationBuilder.UpdateData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("8efb2b99-2132-4510-8d24-ff80b86223db"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Efficient Workplaces" });

            migrationBuilder.UpdateData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("9b4d8661-7811-4324-a6bf-ee30cd83c3cd"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Dark Matter Thruster" });

            migrationBuilder.UpdateData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("a3058710-e6fe-4db1-98d2-f7d93874ff5a"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "2.jpg", "TODO", "Efficient living places" });

            migrationBuilder.UpdateData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("e193ba9c-4b8c-4e21-8c5c-e15421de26f4"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Armor Engineering" });

            migrationBuilder.UpdateData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("f19fc99c-2db1-4877-9ac3-32974174f970"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Ion Thruster" });

            migrationBuilder.UpdateData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("4139a914-6958-482a-9fab-6291426e075f"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Planet colonization" });

            migrationBuilder.UpdateData(
                table: "Researches",
                keyColumn: "Id",
                keyValue: new Guid("fcc5c51a-5705-4517-9890-f5fa8d8bde25"),
                columns: new[] { "AssetName", "Description", "Name" },
                values: new object[] { "1.jpg", "TODO", "Moon colonization" });

            migrationBuilder.CreateIndex(
                name: "IX_ResearchStudies_PlayerId",
                table: "ResearchStudies",
                column: "PlayerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResearchStudies_ResearchId",
                table: "ResearchStudies",
                column: "ResearchId");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingConstructions_BuildingId",
                table: "BuildingConstructions",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingConstructions_Buildings_BuildingId",
                table: "BuildingConstructions",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResearchStudies_Researches_ResearchId",
                table: "ResearchStudies",
                column: "ResearchId",
                principalTable: "Researches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
