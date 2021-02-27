using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class TestPrefabObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PrefabId",
                table: "Stars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prefab",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefab", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StarPrefabs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Offset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rotation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scale = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StarType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarPrefabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StarPrefabs_Prefab_Id",
                        column: x => x.Id,
                        principalTable: "Prefab",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stars_PrefabId",
                table: "Stars",
                column: "PrefabId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stars_StarPrefabs_PrefabId",
                table: "Stars",
                column: "PrefabId",
                principalTable: "StarPrefabs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stars_StarPrefabs_PrefabId",
                table: "Stars");

            migrationBuilder.DropTable(
                name: "StarPrefabs");

            migrationBuilder.DropTable(
                name: "Prefab");

            migrationBuilder.DropIndex(
                name: "IX_Stars_PrefabId",
                table: "Stars");

            migrationBuilder.DropColumn(
                name: "PrefabId",
                table: "Stars");
        }
    }
}
