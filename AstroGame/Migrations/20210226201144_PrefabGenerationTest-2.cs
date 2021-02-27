using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class PrefabGenerationTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarObject_SingleObjectSystems_ParentSystemId",
                table: "StellarObject");

            migrationBuilder.DropIndex(
                name: "IX_StellarObject_ParentSystemId",
                table: "StellarObject");

            migrationBuilder.CreateIndex(
                name: "IX_SingleObjectSystems_CenterObjectId",
                table: "SingleObjectSystems",
                column: "CenterObjectId",
                unique: true,
                filter: "[CenterObjectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SingleObjectSystems_StellarObject_CenterObjectId",
                table: "SingleObjectSystems",
                column: "CenterObjectId",
                principalTable: "StellarObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SingleObjectSystems_StellarObject_CenterObjectId",
                table: "SingleObjectSystems");

            migrationBuilder.DropIndex(
                name: "IX_SingleObjectSystems_CenterObjectId",
                table: "SingleObjectSystems");

            migrationBuilder.CreateIndex(
                name: "IX_StellarObject_ParentSystemId",
                table: "StellarObject",
                column: "ParentSystemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObject_SingleObjectSystems_ParentSystemId",
                table: "StellarObject",
                column: "ParentSystemId",
                principalTable: "SingleObjectSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
