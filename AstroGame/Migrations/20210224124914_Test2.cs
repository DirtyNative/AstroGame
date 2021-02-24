using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class Test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjects_StellarSystems_ParentId",
                table: "StellarObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_StellarObjects_CenterObjectId",
                table: "StellarSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_StellarSystems_ParentId",
                table: "StellarSystems");

            migrationBuilder.DropIndex(
                name: "IX_StellarSystems_ParentId",
                table: "StellarSystems");

            migrationBuilder.DropIndex(
                name: "IX_StellarObjects_ParentId",
                table: "StellarObjects");

            migrationBuilder.RenameColumn(
                name: "CenterObjectId",
                table: "StellarSystems",
                newName: "ParentId1");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystems_CenterObjectId",
                table: "StellarSystems",
                newName: "IX_StellarSystems_ParentId1");

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystems_ParentId",
                table: "StellarSystems",
                column: "ParentId",
                unique: true,
                filter: "[ParentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystems_StellarObjects_ParentId",
                table: "StellarSystems",
                column: "ParentId",
                principalTable: "StellarObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystems_StellarSystems_ParentId1",
                table: "StellarSystems",
                column: "ParentId1",
                principalTable: "StellarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_StellarObjects_ParentId",
                table: "StellarSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_StellarSystems_ParentId1",
                table: "StellarSystems");

            migrationBuilder.DropIndex(
                name: "IX_StellarSystems_ParentId",
                table: "StellarSystems");

            migrationBuilder.RenameColumn(
                name: "ParentId1",
                table: "StellarSystems",
                newName: "CenterObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystems_ParentId1",
                table: "StellarSystems",
                newName: "IX_StellarSystems_CenterObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystems_ParentId",
                table: "StellarSystems",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjects_ParentId",
                table: "StellarObjects",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjects_StellarSystems_ParentId",
                table: "StellarObjects",
                column: "ParentId",
                principalTable: "StellarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystems_StellarObjects_CenterObjectId",
                table: "StellarSystems",
                column: "CenterObjectId",
                principalTable: "StellarObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystems_StellarSystems_ParentId",
                table: "StellarSystems",
                column: "ParentId",
                principalTable: "StellarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
