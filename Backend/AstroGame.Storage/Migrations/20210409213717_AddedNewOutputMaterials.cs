using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AddedNewOutputMaterials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OutputResources",
                columns: new[] { "Id", "BaseValue", "BuildingId", "Multiplier", "ResourceId" },
                values: new object[,]
                {
                    { new Guid("792f2b69-3726-42ca-9ef3-015fb5b2e486"), 35.0, new Guid("8a0a5dab-f877-4714-8e6b-1b578f480268"), 1.1799999999999999, new Guid("00000000-1111-0000-0000-000000000001") },
                    { new Guid("a53e9771-e133-431b-9471-9dbd0ca5d245"), 38.0, new Guid("e200ef94-6eb9-46c8-ba08-3dd86ac3b373"), 1.0800000000000001, new Guid("00000000-1111-0000-0000-000000000011") },
                    { new Guid("f2486781-2189-49a4-a644-e6d93e0ff7c4"), 37.0, new Guid("8dde001b-a19d-43a1-b151-cde09a85c214"), 1.1499999999999999, new Guid("00000000-1111-0000-0000-000000000002") },
                    { new Guid("a49f760c-3168-410b-9f8a-39bffcc766e8"), 37.0, new Guid("44517245-cb20-4324-a275-4d8642207ad4"), 1.1000000000000001, new Guid("00000000-1111-0000-0000-000000000010") },
                    { new Guid("dd746ce3-b795-4700-8e7f-0f82e7bfe80f"), 30.0, new Guid("b8063d0e-d06e-4b2e-a7e6-4812d7dd5a3e"), 1.1000000000000001, new Guid("00000000-1111-0000-0000-000000000015") },
                    { new Guid("2825a2ee-2c89-4eb3-a2fa-ecc20c2a8602"), 35.0, new Guid("9b09d3f5-fbca-4148-b6a3-355ce7b75240"), 1.0800000000000001, new Guid("00000000-1111-0000-0000-000000000026") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OutputResources",
                keyColumn: "Id",
                keyValue: new Guid("2825a2ee-2c89-4eb3-a2fa-ecc20c2a8602"));

            migrationBuilder.DeleteData(
                table: "OutputResources",
                keyColumn: "Id",
                keyValue: new Guid("792f2b69-3726-42ca-9ef3-015fb5b2e486"));

            migrationBuilder.DeleteData(
                table: "OutputResources",
                keyColumn: "Id",
                keyValue: new Guid("a49f760c-3168-410b-9f8a-39bffcc766e8"));

            migrationBuilder.DeleteData(
                table: "OutputResources",
                keyColumn: "Id",
                keyValue: new Guid("a53e9771-e133-431b-9471-9dbd0ca5d245"));

            migrationBuilder.DeleteData(
                table: "OutputResources",
                keyColumn: "Id",
                keyValue: new Guid("dd746ce3-b795-4700-8e7f-0f82e7bfe80f"));

            migrationBuilder.DeleteData(
                table: "OutputResources",
                keyColumn: "Id",
                keyValue: new Guid("f2486781-2189-49a4-a644-e6d93e0ff7c4"));
        }
    }
}
