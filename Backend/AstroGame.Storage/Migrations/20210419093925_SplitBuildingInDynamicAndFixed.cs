using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class SplitBuildingInDynamicAndFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BuildingCosts_Buildings_BuildingId",
                table: "BuildingCosts");

            migrationBuilder.DropTable(
                name: "CivilBuildings");

            migrationBuilder.DropTable(
                name: "ConveyorBuildings");

            migrationBuilder.DropTable(
                name: "ManufacturingFacilityBuildings");

            migrationBuilder.DropTable(
                name: "RefineryBuildings");

            migrationBuilder.DropTable(
                name: "ResearchLaboratoryBuildings");

            migrationBuilder.DropTable(
                name: "StorageBuildings");

            migrationBuilder.DropIndex(
                name: "IX_BuildingCosts_BuildingId",
                table: "BuildingCosts");

            migrationBuilder.DropColumn(
                name: "BaseValue",
                table: "BuildingCosts");

            migrationBuilder.DropColumn(
                name: "Multiplier",
                table: "BuildingCosts");

            migrationBuilder.AddColumn<int>(
                name: "BuildingType",
                table: "Buildings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DynamicBuildingCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    BaseValue = table.Column<double>(type: "float", nullable: false),
                    Multiplier = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicBuildingCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicBuildingCosts_BuildingCosts_Id",
                        column: x => x.Id,
                        principalTable: "BuildingCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FixedBuildingCosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedBuildingCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixedBuildingCosts_BuildingCosts_Id",
                        column: x => x.Id,
                        principalTable: "BuildingCosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FixedBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixedBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FixedBuildings_Buildings_Id",
                        column: x => x.Id,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LevelableBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelableBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelableBuildings_Buildings_Id",
                        column: x => x.Id,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("08f6708b-dd2a-427a-9e49-e24810452421"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("0998d19e-c02f-41e2-b2fd-ba5c6fc7def1"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("20ef5beb-8d80-4ea1-980a-1b77649b4249"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("31b2747d-ff1b-49b1-bf97-782bdb28cba2"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("357f7740-3ca7-4ff8-81c6-9cf22289a709"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("35c9d3c1-bb03-4c2a-b6dd-eb34c0bfcf0d"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("405a352f-943d-40f7-9e8a-359872d25e84"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("428801f4-4777-4589-9a64-cb97bcef71cb"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("44517245-cb20-4324-a275-4d8642207ad4"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("45168d04-86cb-499c-aec9-a8255580071e"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("4df104b3-64b6-4843-ba43-4b5b98f08c2b"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("626d4d9b-f90e-4e24-8f84-054e709afa2a"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("6d519575-bcfb-49f7-aef9-15a4b8364b32"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("7d3b17d6-3084-4725-a259-cff46fc3a554"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("81b33a6b-c9a6-446c-bf61-441931a9f2ab"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("89b6448b-ca4e-43d4-a8bb-69b6f5c55211"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("8a0a5dab-f877-4714-8e6b-1b578f480268"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("a0500eb9-8f5c-4fd0-90af-4be209939464"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("a6a8f230-dde3-464d-9edd-76cfc9882cbb"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("adab9b7c-53e7-4f89-aa62-61b8a6d8b60f"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("b8d93f41-d6c2-4ce8-9763-840ecb53bf44"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("bdcae1cc-d8e2-4dd5-97b6-8cde1162f6ee"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("c8d6228c-4c68-444d-bdf9-bb16279a5eb8"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("e200ef94-6eb9-46c8-ba08-3dd86ac3b373"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("e5c2c36b-3393-4599-b054-77458c7e74e8"),
                column: "BuildingType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("f09e72d5-28d8-4390-bdf5-3b589b61fc15"),
                column: "BuildingType",
                value: 5);

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("01951251-4fdb-4ad6-98f1-ae001e779b04"), 400.0, 1.5 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("0a0e9ef7-6926-4871-9f51-7ad94e8dc8e1"), 250.0, 1.55 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("0e521620-3a9d-4f1a-9822-e7a1fb746246"), 500.0, 1.6000000000000001 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("15474d59-20c5-463c-bdf0-bc9b09f7e08a"), 300.0, 1.3999999999999999 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("18f5c558-4ff8-483d-812c-b0e9e49eb9f6"), 60.0, 1.5 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("1b7ccec7-f828-4c20-81ed-08472bea2486"), 60.0, 1.5 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("1eba7135-5378-4276-b163-5e631fb6a2c2"), 250.0, 1.55 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("1f147721-9f55-4856-b160-6be4b097b2f6"), 60.0, 1.5 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("261c88ea-3595-4a65-9823-a3c245d0e9c6"), 60.0, 1.5 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("2f921c53-c7ba-426b-8c37-553f9cf37bef"), 250.0, 1.55 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("306a853b-8583-4a1e-8ace-c49ec34ef991"), 300.0, 1.3999999999999999 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("36ddec13-5b03-4e09-b1d4-eb9865fa3ec6"), 900.0, 1.6000000000000001 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("40f3accc-ba71-4306-95f5-67421aeb89f0"), 600.0, 1.5 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("41333116-1ce5-4625-96b6-1f7c75f1bd38"), 60.0, 1.5 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("4d6ddf71-901c-4734-b6cd-23fd2d701002"), 800.0, 1.3 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("58d5be3e-1d49-4c0a-ae2c-f46791d0e919"), 68.0, 1.5 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("651e720f-9c3a-4f1f-9095-fcc82ccc0d36"), 60.0, 1.5 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("6fd807b8-043a-4e62-b9c9-6b8dff135da0"), 250.0, 1.55 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("760dc621-3bab-4e9a-ae53-fed5dcd76f85"), 250.0, 1.55 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("76f6afe9-670a-4ba5-90d8-01891f15a6a2"), 60.0, 1.5 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("778a6f92-e76d-4c0a-a03f-fa5e1d31bca2"), 300.0, 1.3999999999999999 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("7d09ed30-8fa3-4e8d-bfa2-8702539f6ae9"), 60.0, 1.5 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("8f367705-7c4e-4a3d-9761-1b91dbb1aa55"), 300.0, 1.3999999999999999 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("8ff89127-91e6-4dc0-a375-7dd3d9125870"), 250.0, 1.55 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("9c85b65c-72e6-4e41-9106-d35580c0f9ab"), 100.0, 1.3999999999999999 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("b385d85d-7dc0-48e6-b9f0-b84ac3a26540"), 60.0, 1.5 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("daee009b-8819-4ccf-944a-0e5e35a95d3f"), 60.0, 1.5 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("daface0d-0bbc-4e5b-a11e-55bce19c4b0b"), 500.0, 1.6000000000000001 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("df3f2c81-7bb8-4913-8817-57c352c07aed"), 250.0, 1.55 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("ea28699a-c944-48a1-b6ff-30f8536cb840"), 700.0, 1.25 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("ec330d07-7dcd-40ac-9151-1d53bc6ce6d4"), 250.0, 1.55 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("ef756673-3ae1-4e35-951b-5bf3ef24a6f0"), 60.0, 1.5 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("f4b92197-1eca-4003-94ff-eb47ae854ceb"), 60.0, 1.5 });

            migrationBuilder.InsertData(
                table: "DynamicBuildingCosts",
                columns: new[] { "Id", "BaseValue", "Multiplier" },
                values: new object[] { new Guid("f9814f8d-6dce-4f44-818b-63426ae1bc27"), 60.0, 1.5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicBuildingCosts");

            migrationBuilder.DropTable(
                name: "FixedBuildingCosts");

            migrationBuilder.DropTable(
                name: "FixedBuildings");

            migrationBuilder.DropTable(
                name: "LevelableBuildings");

            migrationBuilder.DropColumn(
                name: "BuildingType",
                table: "Buildings");

            migrationBuilder.AddColumn<double>(
                name: "BaseValue",
                table: "BuildingCosts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Multiplier",
                table: "BuildingCosts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "CivilBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CivilBuildings_Buildings_Id",
                        column: x => x.Id,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConveyorBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConveyorBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConveyorBuildings_Buildings_Id",
                        column: x => x.Id,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturingFacilityBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingFacilityBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManufacturingFacilityBuildings_Buildings_Id",
                        column: x => x.Id,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefineryBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefineryBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefineryBuildings_Buildings_Id",
                        column: x => x.Id,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResearchLaboratoryBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchLaboratoryBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchLaboratoryBuildings_Buildings_Id",
                        column: x => x.Id,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StorageBuildings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageBuildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageBuildings_Buildings_Id",
                        column: x => x.Id,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("01951251-4fdb-4ad6-98f1-ae001e779b04"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 400.0, 1.5 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("0a0e9ef7-6926-4871-9f51-7ad94e8dc8e1"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 250.0, 1.55 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("0e521620-3a9d-4f1a-9822-e7a1fb746246"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 500.0, 1.6000000000000001 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("15474d59-20c5-463c-bdf0-bc9b09f7e08a"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 300.0, 1.3999999999999999 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("18f5c558-4ff8-483d-812c-b0e9e49eb9f6"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 60.0, 1.5 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("1b7ccec7-f828-4c20-81ed-08472bea2486"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 60.0, 1.5 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("1eba7135-5378-4276-b163-5e631fb6a2c2"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 250.0, 1.55 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("1f147721-9f55-4856-b160-6be4b097b2f6"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 60.0, 1.5 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("261c88ea-3595-4a65-9823-a3c245d0e9c6"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 60.0, 1.5 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("2f921c53-c7ba-426b-8c37-553f9cf37bef"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 250.0, 1.55 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("306a853b-8583-4a1e-8ace-c49ec34ef991"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 300.0, 1.3999999999999999 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("36ddec13-5b03-4e09-b1d4-eb9865fa3ec6"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 900.0, 1.6000000000000001 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("40f3accc-ba71-4306-95f5-67421aeb89f0"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 600.0, 1.5 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("41333116-1ce5-4625-96b6-1f7c75f1bd38"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 60.0, 1.5 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("4d6ddf71-901c-4734-b6cd-23fd2d701002"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 800.0, 1.3 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("58d5be3e-1d49-4c0a-ae2c-f46791d0e919"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 68.0, 1.5 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("651e720f-9c3a-4f1f-9095-fcc82ccc0d36"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 60.0, 1.5 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("6fd807b8-043a-4e62-b9c9-6b8dff135da0"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 250.0, 1.55 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("760dc621-3bab-4e9a-ae53-fed5dcd76f85"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 250.0, 1.55 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("76f6afe9-670a-4ba5-90d8-01891f15a6a2"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 60.0, 1.5 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("778a6f92-e76d-4c0a-a03f-fa5e1d31bca2"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 300.0, 1.3999999999999999 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("7d09ed30-8fa3-4e8d-bfa2-8702539f6ae9"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 60.0, 1.5 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("8f367705-7c4e-4a3d-9761-1b91dbb1aa55"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 300.0, 1.3999999999999999 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("8ff89127-91e6-4dc0-a375-7dd3d9125870"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 250.0, 1.55 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("9c85b65c-72e6-4e41-9106-d35580c0f9ab"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 100.0, 1.3999999999999999 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("b385d85d-7dc0-48e6-b9f0-b84ac3a26540"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 60.0, 1.5 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("daee009b-8819-4ccf-944a-0e5e35a95d3f"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 60.0, 1.5 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("daface0d-0bbc-4e5b-a11e-55bce19c4b0b"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 500.0, 1.6000000000000001 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("df3f2c81-7bb8-4913-8817-57c352c07aed"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 250.0, 1.55 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("ea28699a-c944-48a1-b6ff-30f8536cb840"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 700.0, 1.25 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("ec330d07-7dcd-40ac-9151-1d53bc6ce6d4"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 250.0, 1.55 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("ef756673-3ae1-4e35-951b-5bf3ef24a6f0"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 60.0, 1.5 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("f4b92197-1eca-4003-94ff-eb47ae854ceb"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 60.0, 1.5 });

            migrationBuilder.UpdateData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("f9814f8d-6dce-4f44-818b-63426ae1bc27"),
                columns: new[] { "BaseValue", "Multiplier" },
                values: new object[] { 60.0, 1.5 });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingCosts_BuildingId",
                table: "BuildingCosts",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BuildingCosts_Buildings_BuildingId",
                table: "BuildingCosts",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
