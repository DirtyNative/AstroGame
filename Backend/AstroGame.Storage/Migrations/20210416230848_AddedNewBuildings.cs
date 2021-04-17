using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AddedNewBuildings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("44517245-cb20-4324-a275-4d8642207ad4"),
                column: "Order",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                column: "Order",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("8a0a5dab-f877-4714-8e6b-1b578f480268"),
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"),
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"),
                column: "Order",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"),
                column: "Order",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("e200ef94-6eb9-46c8-ba08-3dd86ac3b373"),
                column: "Order",
                value: 11);

            migrationBuilder.InsertData(
                table: "Buildings",
                columns: new[] { "Id", "AssetName", "BuildableOn", "Description", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("20ef5beb-8d80-4ea1-980a-1b77649b4249"), "9.jpg", 2, "TODO", "Lithium Extractor", 3 },
                    { new Guid("357f7740-3ca7-4ff8-81c6-9cf22289a709"), "2.jpg", 2, "TODO", "Plutonium Reactor", 29 },
                    { new Guid("a6a8f230-dde3-464d-9edd-76cfc9882cbb"), "2.jpg", 2, "TODO", "Gold Mine", 28 },
                    { new Guid("31b2747d-ff1b-49b1-bf97-782bdb28cba2"), "2.jpg", 2, "TODO", "Platinum Mine", 27 },
                    { new Guid("45168d04-86cb-499c-aec9-a8255580071e"), "2.jpg", 2, "TODO", "Tin Mine", 25 },
                    { new Guid("405a352f-943d-40f7-9e8a-359872d25e84"), "2.jpg", 2, "TODO", "Palladium Mine", 23 },
                    { new Guid("0998d19e-c02f-41e2-b2fd-ba5c6fc7def1"), "2.jpg", 2, "TODO", "Germanium Dissolver", 22 },
                    { new Guid("428801f4-4777-4589-9a64-cb97bcef71cb"), "2.jpg", 2, "TODO", "Silver Mine", 24 },
                    { new Guid("4df104b3-64b6-4843-ba43-4b5b98f08c2b"), "2.jpg", 2, "TODO", "Zinc Mine", 20 },
                    { new Guid("c8d6228c-4c68-444d-bdf9-bb16279a5eb8"), "2.jpg", 2, "TODO", "Copper Melting Plant", 19 },
                    { new Guid("a0500eb9-8f5c-4fd0-90af-4be209939464"), "2.jpg", 2, "TODO", "Nickel Melting Plant", 18 },
                    { new Guid("b8d93f41-d6c2-4ce8-9763-840ecb53bf44"), "2.jpg", 2, "TODO", "Cobalt Melting Plant", 17 },
                    { new Guid("89b6448b-ca4e-43d4-a8bb-69b6f5c55211"), "7.jpg", 2, "TODO", "Chlorine Dissolver", 14 },
                    { new Guid("6d519575-bcfb-49f7-aef9-15a4b8364b32"), "7.jpg", 2, "TODO", "Sulfur Mine", 13 },
                    { new Guid("e5c2c36b-3393-4599-b054-77458c7e74e8"), "7.jpg", 2, "TODO", "Phosphorus Miner", 12 },
                    { new Guid("bdcae1cc-d8e2-4dd5-97b6-8cde1162f6ee"), "9.jpg", 2, "TODO", "Magnesium Reductor", 9 },
                    { new Guid("adab9b7c-53e7-4f89-aa62-61b8a6d8b60f"), "9.jpg", 2, "TODO", "Oxygen Extractor", 8 },
                    { new Guid("626d4d9b-f90e-4e24-8f84-054e709afa2a"), "2.jpg", 2, "TODO", "Gallium smelting plant", 21 },
                    { new Guid("35c9d3c1-bb03-4c2a-b6dd-eb34c0bfcf0d"), "9.jpg", 2, "TODO", "Nitrogen Destillator", 7 },
                    { new Guid("81b33a6b-c9a6-446c-bf61-441931a9f2ab"), "9.jpg", 2, "TODO", "Beryllium Reductor", 4 },
                    { new Guid("08f6708b-dd2a-427a-9e49-e24810452421"), "9.jpg", 2, "TODO", "Carbon Extractor", 6 },
                    { new Guid("7d3b17d6-3084-4725-a259-cff46fc3a554"), "9.jpg", 2, "TODO", "Boron Reductor", 5 }
                });

            migrationBuilder.InsertData(
                table: "BuildingCosts",
                columns: new[] { "Id", "BaseValue", "BuildingId", "Multiplier", "ResourceId" },
                values: new object[,]
                {
                    { new Guid("ec330d07-7dcd-40ac-9151-1d53bc6ce6d4"), 250.0, new Guid("20ef5beb-8d80-4ea1-980a-1b77649b4249"), 1.55, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("18f5c558-4ff8-483d-812c-b0e9e49eb9f6"), 60.0, new Guid("4df104b3-64b6-4843-ba43-4b5b98f08c2b"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("261c88ea-3595-4a65-9823-a3c245d0e9c6"), 60.0, new Guid("0998d19e-c02f-41e2-b2fd-ba5c6fc7def1"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("daee009b-8819-4ccf-944a-0e5e35a95d3f"), 60.0, new Guid("c8d6228c-4c68-444d-bdf9-bb16279a5eb8"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("7d09ed30-8fa3-4e8d-bfa2-8702539f6ae9"), 60.0, new Guid("a0500eb9-8f5c-4fd0-90af-4be209939464"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("1f147721-9f55-4856-b160-6be4b097b2f6"), 60.0, new Guid("357f7740-3ca7-4ff8-81c6-9cf22289a709"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("f4b92197-1eca-4003-94ff-eb47ae854ceb"), 60.0, new Guid("b8d93f41-d6c2-4ce8-9763-840ecb53bf44"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("f9814f8d-6dce-4f44-818b-63426ae1bc27"), 60.0, new Guid("405a352f-943d-40f7-9e8a-359872d25e84"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("306a853b-8583-4a1e-8ace-c49ec34ef991"), 300.0, new Guid("89b6448b-ca4e-43d4-a8bb-69b6f5c55211"), 1.3999999999999999, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("8f367705-7c4e-4a3d-9761-1b91dbb1aa55"), 300.0, new Guid("6d519575-bcfb-49f7-aef9-15a4b8364b32"), 1.3999999999999999, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("b385d85d-7dc0-48e6-b9f0-b84ac3a26540"), 60.0, new Guid("428801f4-4777-4589-9a64-cb97bcef71cb"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("8ff89127-91e6-4dc0-a375-7dd3d9125870"), 250.0, new Guid("bdcae1cc-d8e2-4dd5-97b6-8cde1162f6ee"), 1.55, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("15474d59-20c5-463c-bdf0-bc9b09f7e08a"), 300.0, new Guid("e5c2c36b-3393-4599-b054-77458c7e74e8"), 1.3999999999999999, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("6fd807b8-043a-4e62-b9c9-6b8dff135da0"), 250.0, new Guid("adab9b7c-53e7-4f89-aa62-61b8a6d8b60f"), 1.55, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("0a0e9ef7-6926-4871-9f51-7ad94e8dc8e1"), 250.0, new Guid("35c9d3c1-bb03-4c2a-b6dd-eb34c0bfcf0d"), 1.55, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("41333116-1ce5-4625-96b6-1f7c75f1bd38"), 60.0, new Guid("31b2747d-ff1b-49b1-bf97-782bdb28cba2"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("1eba7135-5378-4276-b163-5e631fb6a2c2"), 250.0, new Guid("08f6708b-dd2a-427a-9e49-e24810452421"), 1.55, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("2f921c53-c7ba-426b-8c37-553f9cf37bef"), 250.0, new Guid("7d3b17d6-3084-4725-a259-cff46fc3a554"), 1.55, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("651e720f-9c3a-4f1f-9095-fcc82ccc0d36"), 60.0, new Guid("a6a8f230-dde3-464d-9edd-76cfc9882cbb"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("760dc621-3bab-4e9a-ae53-fed5dcd76f85"), 250.0, new Guid("81b33a6b-c9a6-446c-bf61-441931a9f2ab"), 1.55, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("ef756673-3ae1-4e35-951b-5bf3ef24a6f0"), 60.0, new Guid("45168d04-86cb-499c-aec9-a8255580071e"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") },
                    { new Guid("1b7ccec7-f828-4c20-81ed-08472bea2486"), 60.0, new Guid("626d4d9b-f90e-4e24-8f84-054e709afa2a"), 1.5, new Guid("00000000-1111-0000-0000-000000000016") }
                });

            migrationBuilder.InsertData(
                table: "ConveyorBuildings",
                column: "Id",
                values: new object[]
                {
                    new Guid("428801f4-4777-4589-9a64-cb97bcef71cb"),
                    new Guid("626d4d9b-f90e-4e24-8f84-054e709afa2a"),
                    new Guid("45168d04-86cb-499c-aec9-a8255580071e"),
                    new Guid("405a352f-943d-40f7-9e8a-359872d25e84"),
                    new Guid("31b2747d-ff1b-49b1-bf97-782bdb28cba2"),
                    new Guid("0998d19e-c02f-41e2-b2fd-ba5c6fc7def1"),
                    new Guid("a6a8f230-dde3-464d-9edd-76cfc9882cbb"),
                    new Guid("b8d93f41-d6c2-4ce8-9763-840ecb53bf44"),
                    new Guid("c8d6228c-4c68-444d-bdf9-bb16279a5eb8"),
                    new Guid("a0500eb9-8f5c-4fd0-90af-4be209939464"),
                    new Guid("89b6448b-ca4e-43d4-a8bb-69b6f5c55211"),
                    new Guid("6d519575-bcfb-49f7-aef9-15a4b8364b32"),
                    new Guid("e5c2c36b-3393-4599-b054-77458c7e74e8"),
                    new Guid("bdcae1cc-d8e2-4dd5-97b6-8cde1162f6ee"),
                    new Guid("adab9b7c-53e7-4f89-aa62-61b8a6d8b60f"),
                    new Guid("35c9d3c1-bb03-4c2a-b6dd-eb34c0bfcf0d"),
                    new Guid("08f6708b-dd2a-427a-9e49-e24810452421"),
                    new Guid("7d3b17d6-3084-4725-a259-cff46fc3a554"),
                    new Guid("81b33a6b-c9a6-446c-bf61-441931a9f2ab"),
                    new Guid("20ef5beb-8d80-4ea1-980a-1b77649b4249")
                });

            migrationBuilder.InsertData(
                table: "ConveyorBuildings",
                column: "Id",
                value: new Guid("4df104b3-64b6-4843-ba43-4b5b98f08c2b"));

            migrationBuilder.InsertData(
                table: "ConveyorBuildings",
                column: "Id",
                value: new Guid("357f7740-3ca7-4ff8-81c6-9cf22289a709"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("0a0e9ef7-6926-4871-9f51-7ad94e8dc8e1"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("15474d59-20c5-463c-bdf0-bc9b09f7e08a"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("18f5c558-4ff8-483d-812c-b0e9e49eb9f6"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("1b7ccec7-f828-4c20-81ed-08472bea2486"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("1eba7135-5378-4276-b163-5e631fb6a2c2"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("1f147721-9f55-4856-b160-6be4b097b2f6"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("261c88ea-3595-4a65-9823-a3c245d0e9c6"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("2f921c53-c7ba-426b-8c37-553f9cf37bef"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("306a853b-8583-4a1e-8ace-c49ec34ef991"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("41333116-1ce5-4625-96b6-1f7c75f1bd38"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("651e720f-9c3a-4f1f-9095-fcc82ccc0d36"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("6fd807b8-043a-4e62-b9c9-6b8dff135da0"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("760dc621-3bab-4e9a-ae53-fed5dcd76f85"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("7d09ed30-8fa3-4e8d-bfa2-8702539f6ae9"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("8f367705-7c4e-4a3d-9761-1b91dbb1aa55"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("8ff89127-91e6-4dc0-a375-7dd3d9125870"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("b385d85d-7dc0-48e6-b9f0-b84ac3a26540"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("daee009b-8819-4ccf-944a-0e5e35a95d3f"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("ec330d07-7dcd-40ac-9151-1d53bc6ce6d4"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("ef756673-3ae1-4e35-951b-5bf3ef24a6f0"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("f4b92197-1eca-4003-94ff-eb47ae854ceb"));

            migrationBuilder.DeleteData(
                table: "BuildingCosts",
                keyColumn: "Id",
                keyValue: new Guid("f9814f8d-6dce-4f44-818b-63426ae1bc27"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("08f6708b-dd2a-427a-9e49-e24810452421"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("0998d19e-c02f-41e2-b2fd-ba5c6fc7def1"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("20ef5beb-8d80-4ea1-980a-1b77649b4249"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("31b2747d-ff1b-49b1-bf97-782bdb28cba2"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("357f7740-3ca7-4ff8-81c6-9cf22289a709"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("35c9d3c1-bb03-4c2a-b6dd-eb34c0bfcf0d"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("405a352f-943d-40f7-9e8a-359872d25e84"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("428801f4-4777-4589-9a64-cb97bcef71cb"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("45168d04-86cb-499c-aec9-a8255580071e"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("4df104b3-64b6-4843-ba43-4b5b98f08c2b"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("626d4d9b-f90e-4e24-8f84-054e709afa2a"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("6d519575-bcfb-49f7-aef9-15a4b8364b32"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("7d3b17d6-3084-4725-a259-cff46fc3a554"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("81b33a6b-c9a6-446c-bf61-441931a9f2ab"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("89b6448b-ca4e-43d4-a8bb-69b6f5c55211"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("a0500eb9-8f5c-4fd0-90af-4be209939464"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("a6a8f230-dde3-464d-9edd-76cfc9882cbb"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("adab9b7c-53e7-4f89-aa62-61b8a6d8b60f"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("b8d93f41-d6c2-4ce8-9763-840ecb53bf44"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("bdcae1cc-d8e2-4dd5-97b6-8cde1162f6ee"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("c8d6228c-4c68-444d-bdf9-bb16279a5eb8"));

            migrationBuilder.DeleteData(
                table: "ConveyorBuildings",
                keyColumn: "Id",
                keyValue: new Guid("e5c2c36b-3393-4599-b054-77458c7e74e8"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("08f6708b-dd2a-427a-9e49-e24810452421"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("0998d19e-c02f-41e2-b2fd-ba5c6fc7def1"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("20ef5beb-8d80-4ea1-980a-1b77649b4249"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("31b2747d-ff1b-49b1-bf97-782bdb28cba2"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("357f7740-3ca7-4ff8-81c6-9cf22289a709"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("35c9d3c1-bb03-4c2a-b6dd-eb34c0bfcf0d"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("405a352f-943d-40f7-9e8a-359872d25e84"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("428801f4-4777-4589-9a64-cb97bcef71cb"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("45168d04-86cb-499c-aec9-a8255580071e"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("4df104b3-64b6-4843-ba43-4b5b98f08c2b"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("626d4d9b-f90e-4e24-8f84-054e709afa2a"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("6d519575-bcfb-49f7-aef9-15a4b8364b32"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("7d3b17d6-3084-4725-a259-cff46fc3a554"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("81b33a6b-c9a6-446c-bf61-441931a9f2ab"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("89b6448b-ca4e-43d4-a8bb-69b6f5c55211"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("a0500eb9-8f5c-4fd0-90af-4be209939464"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("a6a8f230-dde3-464d-9edd-76cfc9882cbb"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("adab9b7c-53e7-4f89-aa62-61b8a6d8b60f"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("b8d93f41-d6c2-4ce8-9763-840ecb53bf44"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("bdcae1cc-d8e2-4dd5-97b6-8cde1162f6ee"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("c8d6228c-4c68-444d-bdf9-bb16279a5eb8"));

            migrationBuilder.DeleteData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("e5c2c36b-3393-4599-b054-77458c7e74e8"));

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("44517245-cb20-4324-a275-4d8642207ad4"),
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("5b2aa6bc-9754-42eb-b519-39edd989f9bb"),
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("8a0a5dab-f877-4714-8e6b-1b578f480268"),
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"),
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"),
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"),
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Buildings",
                keyColumn: "Id",
                keyValue: new Guid("e200ef94-6eb9-46c8-ba08-3dd86ac3b373"),
                column: "Order",
                value: 3);
        }
    }
}
