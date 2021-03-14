using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class ImplementedCoordinates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolarSystems_MultiObjectSystems_Id",
                table: "SolarSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjects_MultiObjectSystems_ParentSystemId",
                table: "StellarObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_MultiObjectSystems_MultiObjectSystemId",
                table: "StellarSystems");

            migrationBuilder.RenameColumn(
                name: "MultiObjectSystemId",
                table: "StellarSystems",
                newName: "StellarSystemId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystems_MultiObjectSystemId",
                table: "StellarSystems",
                newName: "IX_StellarSystems_StellarSystemId");

            migrationBuilder.AddColumn<string>(
                name: "Coordinates",
                table: "StellarObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Coordinates",
                table: "SolarSystems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "SolarSystems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SolarSystems_ParentId",
                table: "SolarSystems",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolarSystems_StellarSystems_Id",
                table: "SolarSystems",
                column: "Id",
                principalTable: "StellarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolarSystems_StellarSystems_ParentId",
                table: "SolarSystems",
                column: "ParentId",
                principalTable: "StellarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjects_StellarSystems_ParentSystemId",
                table: "StellarObjects",
                column: "ParentSystemId",
                principalTable: "StellarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystems_StellarSystems_StellarSystemId",
                table: "StellarSystems",
                column: "StellarSystemId",
                principalTable: "StellarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolarSystems_StellarSystems_Id",
                table: "SolarSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_SolarSystems_StellarSystems_ParentId",
                table: "SolarSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjects_StellarSystems_ParentSystemId",
                table: "StellarObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_StellarSystems_StellarSystemId",
                table: "StellarSystems");

            migrationBuilder.DropIndex(
                name: "IX_SolarSystems_ParentId",
                table: "SolarSystems");

            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "StellarObjects");

            migrationBuilder.DropColumn(
                name: "Coordinates",
                table: "SolarSystems");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "SolarSystems");

            migrationBuilder.RenameColumn(
                name: "StellarSystemId",
                table: "StellarSystems",
                newName: "MultiObjectSystemId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystems_StellarSystemId",
                table: "StellarSystems",
                newName: "IX_StellarSystems_MultiObjectSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolarSystems_MultiObjectSystems_Id",
                table: "SolarSystems",
                column: "Id",
                principalTable: "MultiObjectSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjects_MultiObjectSystems_ParentSystemId",
                table: "StellarObjects",
                column: "ParentSystemId",
                principalTable: "MultiObjectSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystems_MultiObjectSystems_MultiObjectSystemId",
                table: "StellarSystems",
                column: "MultiObjectSystemId",
                principalTable: "MultiObjectSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
