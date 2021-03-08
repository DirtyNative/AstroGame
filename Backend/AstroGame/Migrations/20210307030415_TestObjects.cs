using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class TestObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moons_StellarObject_Id",
                table: "Moons");

            migrationBuilder.DropForeignKey(
                name: "FK_Planets_StellarObject_Id",
                table: "Planets");

            migrationBuilder.DropForeignKey(
                name: "FK_SingleObjectSystems_StellarObject_CenterObjectId",
                table: "SingleObjectSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_Stars_StellarObject_Id",
                table: "Stars");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_StellarObject_StellarObjectId",
                table: "StellarObjectResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StellarObject",
                table: "StellarObject");

            migrationBuilder.RenameTable(
                name: "StellarObject",
                newName: "StellarObjects");

            migrationBuilder.AddColumn<double>(
                name: "Multiplier",
                table: "StellarObjectResources",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StellarObjects",
                table: "StellarObjects",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Moons_StellarObjects_Id",
                table: "Moons",
                column: "Id",
                principalTable: "StellarObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_StellarObjects_Id",
                table: "Planets",
                column: "Id",
                principalTable: "StellarObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleObjectSystems_StellarObjects_CenterObjectId",
                table: "SingleObjectSystems",
                column: "CenterObjectId",
                principalTable: "StellarObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stars_StellarObjects_Id",
                table: "Stars",
                column: "Id",
                principalTable: "StellarObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_StellarObjects_StellarObjectId",
                table: "StellarObjectResources",
                column: "StellarObjectId",
                principalTable: "StellarObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moons_StellarObjects_Id",
                table: "Moons");

            migrationBuilder.DropForeignKey(
                name: "FK_Planets_StellarObjects_Id",
                table: "Planets");

            migrationBuilder.DropForeignKey(
                name: "FK_SingleObjectSystems_StellarObjects_CenterObjectId",
                table: "SingleObjectSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_Stars_StellarObjects_Id",
                table: "Stars");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjectResources_StellarObjects_StellarObjectId",
                table: "StellarObjectResources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StellarObjects",
                table: "StellarObjects");

            migrationBuilder.DropColumn(
                name: "Multiplier",
                table: "StellarObjectResources");

            migrationBuilder.RenameTable(
                name: "StellarObjects",
                newName: "StellarObject");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StellarObject",
                table: "StellarObject",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Moons_StellarObject_Id",
                table: "Moons",
                column: "Id",
                principalTable: "StellarObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_StellarObject_Id",
                table: "Planets",
                column: "Id",
                principalTable: "StellarObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleObjectSystems_StellarObject_CenterObjectId",
                table: "SingleObjectSystems",
                column: "CenterObjectId",
                principalTable: "StellarObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stars_StellarObject_Id",
                table: "Stars",
                column: "Id",
                principalTable: "StellarObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObjectResources_StellarObject_StellarObjectId",
                table: "StellarObjectResources",
                column: "StellarObjectId",
                principalTable: "StellarObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
