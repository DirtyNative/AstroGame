using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class ExtractedCredentials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credentials_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Credentials",
                columns: new[] { "Id", "Email", "Password", "PlayerId", "Salt" },
                values: new object[] { new Guid("00000000-0000-0000-1110-000000000000"), "daniel@dirtyandnative.de", new byte[] { 214, 212, 211, 33, 140, 160, 231, 162, 57, 199, 64, 131, 187, 201, 119, 192, 203, 109, 243, 123, 229, 56, 47, 180, 17, 5, 138, 178, 72, 221, 137, 25, 69, 173, 181, 157, 202, 130, 182, 172, 20, 121, 129, 43, 136, 74, 120, 242, 126, 100, 62, 207, 24, 9, 244, 206, 7, 166, 63, 155, 128, 118, 47, 81 }, new Guid("22222222-0000-0000-0000-000000000000"), new byte[] { 193, 79, 225, 80, 112, 24, 191, 243, 40, 86, 90, 75, 6, 166, 103, 215, 30, 13, 70, 153, 161, 73, 23, 145, 154, 13, 46, 5, 245, 103, 100, 241 } });

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_PlayerId",
                table: "Credentials",
                column: "PlayerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Players",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "Players",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Salt",
                table: "Players",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Players",
                keyColumn: "Id",
                keyValue: new Guid("22222222-0000-0000-0000-000000000000"),
                columns: new[] { "Email", "Password", "Salt" },
                values: new object[] { "daniel@dirtyandnative.de", new byte[] { 214, 212, 211, 33, 140, 160, 231, 162, 57, 199, 64, 131, 187, 201, 119, 192, 203, 109, 243, 123, 229, 56, 47, 180, 17, 5, 138, 178, 72, 221, 137, 25, 69, 173, 181, 157, 202, 130, 182, 172, 20, 121, 129, 43, 136, 74, 120, 242, 126, 100, 62, 207, 24, 9, 244, 206, 7, 166, 63, 155, 128, 118, 47, 81 }, new byte[] { 193, 79, 225, 80, 112, 24, 191, 243, 40, 86, 90, 75, 6, 166, 103, 215, 30, 13, 70, 153, 161, 73, 23, 145, 154, 13, 46, 5, 245, 103, 100, 241 } });
        }
    }
}
