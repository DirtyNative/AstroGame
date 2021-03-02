using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class RemovedParentFromGalaxy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_StellarSystems_ParentId",
                table: "StellarSystems");

            migrationBuilder.DropIndex(
                name: "IX_StellarSystems_ParentId",
                table: "StellarSystems");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "StellarSystems");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "SolarSystems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "SingleObjectSystems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "MultiObjectSystems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SolarSystems_ParentId",
                table: "SolarSystems",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleObjectSystems_ParentId",
                table: "SingleObjectSystems",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiObjectSystems_ParentId",
                table: "MultiObjectSystems",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MultiObjectSystems_StellarSystems_ParentId",
                table: "MultiObjectSystems",
                column: "ParentId",
                principalTable: "StellarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleObjectSystems_StellarSystems_ParentId",
                table: "SingleObjectSystems",
                column: "ParentId",
                principalTable: "StellarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolarSystems_StellarSystems_ParentId",
                table: "SolarSystems",
                column: "ParentId",
                principalTable: "StellarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MultiObjectSystems_StellarSystems_ParentId",
                table: "MultiObjectSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_SingleObjectSystems_StellarSystems_ParentId",
                table: "SingleObjectSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_SolarSystems_StellarSystems_ParentId",
                table: "SolarSystems");

            migrationBuilder.DropIndex(
                name: "IX_SolarSystems_ParentId",
                table: "SolarSystems");

            migrationBuilder.DropIndex(
                name: "IX_SingleObjectSystems_ParentId",
                table: "SingleObjectSystems");

            migrationBuilder.DropIndex(
                name: "IX_MultiObjectSystems_ParentId",
                table: "MultiObjectSystems");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "SolarSystems");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "SingleObjectSystems");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "MultiObjectSystems");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "StellarSystems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystems_ParentId",
                table: "StellarSystems",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystems_StellarSystems_ParentId",
                table: "StellarSystems",
                column: "ParentId",
                principalTable: "StellarSystems",
                principalColumn: "Id");
        }
    }
}
