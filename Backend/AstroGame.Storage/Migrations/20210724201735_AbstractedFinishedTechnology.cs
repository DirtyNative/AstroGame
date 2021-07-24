using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Storage.Migrations
{
    public partial class AbstractedFinishedTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "FinishedTechnologies");

            migrationBuilder.CreateTable(
                name: "LevelablePlayerDependentFinishedTechnologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Level = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelablePlayerDependentFinishedTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelablePlayerDependentFinishedTechnologies_PlayerDependentFinishedTechnologies_Id",
                        column: x => x.Id,
                        principalTable: "PlayerDependentFinishedTechnologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LevelableStellarObjectDependentFinishedTechnologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Level = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelableStellarObjectDependentFinishedTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelableStellarObjectDependentFinishedTechnologies_StellarObjectDependentFinishedTechnologies_Id",
                        column: x => x.Id,
                        principalTable: "StellarObjectDependentFinishedTechnologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OneTimePlayerDependentFinishedTechnologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneTimePlayerDependentFinishedTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneTimePlayerDependentFinishedTechnologies_PlayerDependentFinishedTechnologies_Id",
                        column: x => x.Id,
                        principalTable: "PlayerDependentFinishedTechnologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OneTimeStellarObjectDependentFinishedTechnologies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneTimeStellarObjectDependentFinishedTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneTimeStellarObjectDependentFinishedTechnologies_StellarObjectDependentFinishedTechnologies_Id",
                        column: x => x.Id,
                        principalTable: "StellarObjectDependentFinishedTechnologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LevelablePlayerDependentFinishedTechnologies");

            migrationBuilder.DropTable(
                name: "LevelableStellarObjectDependentFinishedTechnologies");

            migrationBuilder.DropTable(
                name: "OneTimePlayerDependentFinishedTechnologies");

            migrationBuilder.DropTable(
                name: "OneTimeStellarObjectDependentFinishedTechnologies");

            migrationBuilder.AddColumn<long>(
                name: "Level",
                table: "FinishedTechnologies",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
