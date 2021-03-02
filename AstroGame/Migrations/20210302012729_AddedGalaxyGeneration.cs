using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class AddedGalaxyGeneration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MultiObjectSystems_StellarSystem_Id",
                table: "MultiObjectSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_SingleObjectSystems_StellarSystem_Id",
                table: "SingleObjectSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_SolarSystems_MultiObjectSystems_Id",
                table: "SolarSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystem_MultiObjectSystems_MultiObjectSystemId",
                table: "StellarSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystem_StellarSystem_ParentId",
                table: "StellarSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystem_StellarSystem_StellarSystemId",
                table: "StellarSystem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StellarSystem",
                table: "StellarSystem");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "StellarSystem");

            migrationBuilder.RenameTable(
                name: "StellarSystem",
                newName: "StellarSystems");

            migrationBuilder.RenameColumn(
                name: "StellarSystemId",
                table: "StellarSystems",
                newName: "SolarSystemId1");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystem_StellarSystemId",
                table: "StellarSystems",
                newName: "IX_StellarSystems_SolarSystemId1");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystem_ParentId",
                table: "StellarSystems",
                newName: "IX_StellarSystems_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystem_MultiObjectSystemId",
                table: "StellarSystems",
                newName: "IX_StellarSystems_MultiObjectSystemId");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "SolarSystems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "SingleObjectSystems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "MultiObjectSystems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentId",
                table: "StellarSystems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GalaxyId",
                table: "StellarSystems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MultiObjectSystemId1",
                table: "StellarSystems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SingleObjectSystemId",
                table: "StellarSystems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SolarSystemId",
                table: "StellarSystems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StellarSystems",
                table: "StellarSystems",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Galaxies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galaxies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Galaxies_StellarSystems_Id",
                        column: x => x.Id,
                        principalTable: "StellarSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystems_GalaxyId",
                table: "StellarSystems",
                column: "GalaxyId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystems_MultiObjectSystemId1",
                table: "StellarSystems",
                column: "MultiObjectSystemId1");

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystems_SingleObjectSystemId",
                table: "StellarSystems",
                column: "SingleObjectSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystems_SolarSystemId",
                table: "StellarSystems",
                column: "SolarSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_MultiObjectSystems_StellarSystems_Id",
                table: "MultiObjectSystems",
                column: "Id",
                principalTable: "StellarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleObjectSystems_StellarSystems_Id",
                table: "SingleObjectSystems",
                column: "Id",
                principalTable: "StellarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolarSystems_StellarSystems_Id",
                table: "SolarSystems",
                column: "Id",
                principalTable: "StellarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystems_Galaxies_GalaxyId",
                table: "StellarSystems",
                column: "GalaxyId",
                principalTable: "Galaxies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystems_MultiObjectSystems_MultiObjectSystemId",
                table: "StellarSystems",
                column: "MultiObjectSystemId",
                principalTable: "MultiObjectSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystems_MultiObjectSystems_MultiObjectSystemId1",
                table: "StellarSystems",
                column: "MultiObjectSystemId1",
                principalTable: "MultiObjectSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystems_SingleObjectSystems_SingleObjectSystemId",
                table: "StellarSystems",
                column: "SingleObjectSystemId",
                principalTable: "SingleObjectSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystems_SolarSystems_SolarSystemId",
                table: "StellarSystems",
                column: "SolarSystemId",
                principalTable: "SolarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystems_SolarSystems_SolarSystemId1",
                table: "StellarSystems",
                column: "SolarSystemId1",
                principalTable: "SolarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystems_StellarSystems_ParentId",
                table: "StellarSystems",
                column: "ParentId",
                principalTable: "StellarSystems",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MultiObjectSystems_StellarSystems_Id",
                table: "MultiObjectSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_SingleObjectSystems_StellarSystems_Id",
                table: "SingleObjectSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_SolarSystems_StellarSystems_Id",
                table: "SolarSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_Galaxies_GalaxyId",
                table: "StellarSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_MultiObjectSystems_MultiObjectSystemId",
                table: "StellarSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_MultiObjectSystems_MultiObjectSystemId1",
                table: "StellarSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_SingleObjectSystems_SingleObjectSystemId",
                table: "StellarSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_SolarSystems_SolarSystemId",
                table: "StellarSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_SolarSystems_SolarSystemId1",
                table: "StellarSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_StellarSystems_ParentId",
                table: "StellarSystems");

            migrationBuilder.DropTable(
                name: "Galaxies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StellarSystems",
                table: "StellarSystems");

            migrationBuilder.DropIndex(
                name: "IX_StellarSystems_GalaxyId",
                table: "StellarSystems");

            migrationBuilder.DropIndex(
                name: "IX_StellarSystems_MultiObjectSystemId1",
                table: "StellarSystems");

            migrationBuilder.DropIndex(
                name: "IX_StellarSystems_SingleObjectSystemId",
                table: "StellarSystems");

            migrationBuilder.DropIndex(
                name: "IX_StellarSystems_SolarSystemId",
                table: "StellarSystems");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "SolarSystems");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "SingleObjectSystems");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "MultiObjectSystems");

            migrationBuilder.DropColumn(
                name: "GalaxyId",
                table: "StellarSystems");

            migrationBuilder.DropColumn(
                name: "MultiObjectSystemId1",
                table: "StellarSystems");

            migrationBuilder.DropColumn(
                name: "SingleObjectSystemId",
                table: "StellarSystems");

            migrationBuilder.DropColumn(
                name: "SolarSystemId",
                table: "StellarSystems");

            migrationBuilder.RenameTable(
                name: "StellarSystems",
                newName: "StellarSystem");

            migrationBuilder.RenameColumn(
                name: "SolarSystemId1",
                table: "StellarSystem",
                newName: "StellarSystemId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystems_SolarSystemId1",
                table: "StellarSystem",
                newName: "IX_StellarSystem_StellarSystemId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystems_ParentId",
                table: "StellarSystem",
                newName: "IX_StellarSystem_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystems_MultiObjectSystemId",
                table: "StellarSystem",
                newName: "IX_StellarSystem_MultiObjectSystemId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParentId",
                table: "StellarSystem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "StellarSystem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StellarSystem",
                table: "StellarSystem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MultiObjectSystems_StellarSystem_Id",
                table: "MultiObjectSystems",
                column: "Id",
                principalTable: "StellarSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SingleObjectSystems_StellarSystem_Id",
                table: "SingleObjectSystems",
                column: "Id",
                principalTable: "StellarSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolarSystems_MultiObjectSystems_Id",
                table: "SolarSystems",
                column: "Id",
                principalTable: "MultiObjectSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystem_MultiObjectSystems_MultiObjectSystemId",
                table: "StellarSystem",
                column: "MultiObjectSystemId",
                principalTable: "MultiObjectSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystem_StellarSystem_ParentId",
                table: "StellarSystem",
                column: "ParentId",
                principalTable: "StellarSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystem_StellarSystem_StellarSystemId",
                table: "StellarSystem",
                column: "StellarSystemId",
                principalTable: "StellarSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
