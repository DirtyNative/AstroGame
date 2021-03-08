using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class TestX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SingleObjectSystems_StellarObjects_CenterObjectId",
                table: "SingleObjectSystems");

            migrationBuilder.DropIndex(
                name: "IX_SingleObjectSystems_CenterObjectId",
                table: "SingleObjectSystems");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObjects_ParentSystemId",
                table: "StellarObjects",
                column: "ParentSystemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjects_SingleObjectSystems_ParentSystemId",
                table: "StellarObjects",
                column: "ParentSystemId",
                principalTable: "SingleObjectSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjects_SingleObjectSystems_ParentSystemId",
                table: "StellarObjects");

            migrationBuilder.DropIndex(
                name: "IX_StellarObjects_ParentSystemId",
                table: "StellarObjects");

            migrationBuilder.CreateIndex(
                name: "IX_SingleObjectSystems_CenterObjectId",
                table: "SingleObjectSystems",
                column: "CenterObjectId",
                unique: true,
                filter: "[CenterObjectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SingleObjectSystems_StellarObjects_CenterObjectId",
                table: "SingleObjectSystems",
                column: "CenterObjectId",
                principalTable: "StellarObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
