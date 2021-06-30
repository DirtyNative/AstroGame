using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AddedNewPlayersInSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastSeenDateTime",
                table: "ConversationParticipants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BuildingChainId", "ConfirmationToken", "PlayerSpeciesId", "Username" },
                values: new object[] { new Guid("22222222-0000-0000-0000-000000000001"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("22222222-1111-0000-0000-000000000000"), "Test1" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BuildingChainId", "ConfirmationToken", "PlayerSpeciesId", "Username" },
                values: new object[] { new Guid("22222222-0000-0000-0000-000000000002"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("22222222-1111-0000-0000-000000000000"), "Test2" });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "Id", "Email", "Password", "PlayerId", "Salt" },
                values: new object[] { new Guid("00000000-0000-0000-1110-000000000001"), "test1@dirtyandnative.de", new byte[] { 214, 212, 211, 33, 140, 160, 231, 162, 57, 199, 64, 131, 187, 201, 119, 192, 203, 109, 243, 123, 229, 56, 47, 180, 17, 5, 138, 178, 72, 221, 137, 25, 69, 173, 181, 157, 202, 130, 182, 172, 20, 121, 129, 43, 136, 74, 120, 242, 126, 100, 62, 207, 24, 9, 244, 206, 7, 166, 63, 155, 128, 118, 47, 81 }, new Guid("22222222-0000-0000-0000-000000000001"), new byte[] { 193, 79, 225, 80, 112, 24, 191, 243, 40, 86, 90, 75, 6, 166, 103, 215, 30, 13, 70, 153, 161, 73, 23, 145, 154, 13, 46, 5, 245, 103, 100, 241 } });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "Id", "Email", "Password", "PlayerId", "Salt" },
                values: new object[] { new Guid("00000000-0000-0000-1110-000000000002"), "test2@dirtyandnative.de", new byte[] { 214, 212, 211, 33, 140, 160, 231, 162, 57, 199, 64, 131, 187, 201, 119, 192, 203, 109, 243, 123, 229, 56, 47, 180, 17, 5, 138, 178, 72, 221, 137, 25, 69, 173, 181, 157, 202, 130, 182, 172, 20, 121, 129, 43, 136, 74, 120, 242, 126, 100, 62, 207, 24, 9, 244, 206, 7, 166, 63, 155, 128, 118, 47, 81 }, new Guid("22222222-0000-0000-0000-000000000002"), new byte[] { 193, 79, 225, 80, 112, 24, 191, 243, 40, 86, 90, 75, 6, 166, 103, 215, 30, 13, 70, 153, 161, 73, 23, 145, 154, 13, 46, 5, 245, 103, 100, 241 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Credentials",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1110-000000000001"));

            migrationBuilder.DeleteData(
                table: "Credentials",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-1110-000000000002"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000002"));

            migrationBuilder.DropColumn(
                name: "LastSeenDateTime",
                table: "ConversationParticipants");
        }
    }
}
