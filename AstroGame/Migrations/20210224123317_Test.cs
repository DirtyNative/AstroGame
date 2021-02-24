using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarObject_StellarSystem_ParentId",
                table: "StellarObject");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystem_MultiObjectSystems_MultiObjectSystemId",
                table: "StellarSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystem_StellarSystem_ParentId",
                table: "StellarSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystem_StellarSystem_StellarSystemId",
                table: "StellarSystem");

            migrationBuilder.DropTable(
                name: "Moons");

            migrationBuilder.DropTable(
                name: "Planets");

            migrationBuilder.DropTable(
                name: "SingleObjectSystems");

            migrationBuilder.DropTable(
                name: "SolarSystems");

            migrationBuilder.DropTable(
                name: "Stars");

            migrationBuilder.DropTable(
                name: "MultiObjectSystems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StellarSystem",
                table: "StellarSystem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StellarObject",
                table: "StellarObject");

            migrationBuilder.RenameTable(
                name: "StellarSystem",
                newName: "StellarSystems");

            migrationBuilder.RenameTable(
                name: "StellarObject",
                newName: "StellarObjects");

            migrationBuilder.RenameColumn(
                name: "StellarSystemId",
                table: "StellarSystems",
                newName: "CenterObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystem_StellarSystemId",
                table: "StellarSystems",
                newName: "IX_StellarSystems_CenterObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystem_ParentId",
                table: "StellarSystems",
                newName: "IX_StellarSystems_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystem_MultiObjectSystemId",
                table: "StellarSystems",
                newName: "IX_StellarSystems_MultiObjectSystemId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarObject_ParentId",
                table: "StellarObjects",
                newName: "IX_StellarObjects_ParentId");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "StellarSystems",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "(newid())");

            migrationBuilder.AddColumn<string>(
                name: "StellarSystemType",
                table: "StellarSystems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "StellarObjects",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "(newid())");

            migrationBuilder.AddColumn<int>(
                name: "AverageTemperate",
                table: "StellarObjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AverageTemperature",
                table: "StellarObjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DistanceToCenter",
                table: "StellarObjects",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasAtmosphere",
                table: "StellarObjects",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasRings",
                table: "StellarObjects",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Moon_DistanceToCenter",
                table: "StellarObjects",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Moon_HasRings",
                table: "StellarObjects",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanetType",
                table: "StellarObjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Planet_AverageTemperature",
                table: "StellarObjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StarType",
                table: "StellarObjects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StellarObjectType",
                table: "StellarObjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StellarSystems",
                table: "StellarSystems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StellarObjects",
                table: "StellarObjects",
                column: "Id");

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
                name: "FK_StellarSystems_StellarSystems_MultiObjectSystemId",
                table: "StellarSystems",
                column: "MultiObjectSystemId",
                principalTable: "StellarSystems",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarObjects_StellarSystems_ParentId",
                table: "StellarObjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_StellarObjects_CenterObjectId",
                table: "StellarSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_StellarSystems_MultiObjectSystemId",
                table: "StellarSystems");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystems_StellarSystems_ParentId",
                table: "StellarSystems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StellarSystems",
                table: "StellarSystems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StellarObjects",
                table: "StellarObjects");

            migrationBuilder.DropColumn(
                name: "StellarSystemType",
                table: "StellarSystems");

            migrationBuilder.DropColumn(
                name: "AverageTemperate",
                table: "StellarObjects");

            migrationBuilder.DropColumn(
                name: "AverageTemperature",
                table: "StellarObjects");

            migrationBuilder.DropColumn(
                name: "DistanceToCenter",
                table: "StellarObjects");

            migrationBuilder.DropColumn(
                name: "HasAtmosphere",
                table: "StellarObjects");

            migrationBuilder.DropColumn(
                name: "HasRings",
                table: "StellarObjects");

            migrationBuilder.DropColumn(
                name: "Moon_DistanceToCenter",
                table: "StellarObjects");

            migrationBuilder.DropColumn(
                name: "Moon_HasRings",
                table: "StellarObjects");

            migrationBuilder.DropColumn(
                name: "PlanetType",
                table: "StellarObjects");

            migrationBuilder.DropColumn(
                name: "Planet_AverageTemperature",
                table: "StellarObjects");

            migrationBuilder.DropColumn(
                name: "StarType",
                table: "StellarObjects");

            migrationBuilder.DropColumn(
                name: "StellarObjectType",
                table: "StellarObjects");

            migrationBuilder.RenameTable(
                name: "StellarSystems",
                newName: "StellarSystem");

            migrationBuilder.RenameTable(
                name: "StellarObjects",
                newName: "StellarObject");

            migrationBuilder.RenameColumn(
                name: "CenterObjectId",
                table: "StellarSystem",
                newName: "StellarSystemId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystems_ParentId",
                table: "StellarSystem",
                newName: "IX_StellarSystem_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystems_MultiObjectSystemId",
                table: "StellarSystem",
                newName: "IX_StellarSystem_MultiObjectSystemId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarSystems_CenterObjectId",
                table: "StellarSystem",
                newName: "IX_StellarSystem_StellarSystemId");

            migrationBuilder.RenameIndex(
                name: "IX_StellarObjects_ParentId",
                table: "StellarObject",
                newName: "IX_StellarObject_ParentId");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "StellarSystem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(newid())",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "StellarObject",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(newid())",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StellarSystem",
                table: "StellarSystem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StellarObject",
                table: "StellarObject",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Moons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AverageTemperate = table.Column<int>(type: "int", nullable: false),
                    DistanceToCenter = table.Column<double>(type: "float", nullable: false),
                    HasRings = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moons_StellarObject_Id",
                        column: x => x.Id,
                        principalTable: "StellarObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MultiObjectSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiObjectSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiObjectSystems_StellarSystem_Id",
                        column: x => x.Id,
                        principalTable: "StellarSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AverageTemperature = table.Column<int>(type: "int", nullable: false),
                    DistanceToCenter = table.Column<double>(type: "float", nullable: false),
                    HasAtmosphere = table.Column<bool>(type: "bit", nullable: false),
                    HasRings = table.Column<bool>(type: "bit", nullable: false),
                    PlanetType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planets_StellarObject_Id",
                        column: x => x.Id,
                        principalTable: "StellarObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SingleObjectSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    CenterObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleObjectSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleObjectSystems_StellarObject_CenterObjectId",
                        column: x => x.CenterObjectId,
                        principalTable: "StellarObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SingleObjectSystems_StellarSystem_Id",
                        column: x => x.Id,
                        principalTable: "StellarSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AverageTemperature = table.Column<int>(type: "int", nullable: false),
                    StarType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stars_StellarObject_Id",
                        column: x => x.Id,
                        principalTable: "StellarObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolarSystems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolarSystems_MultiObjectSystems_Id",
                        column: x => x.Id,
                        principalTable: "MultiObjectSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SingleObjectSystems_CenterObjectId",
                table: "SingleObjectSystems",
                column: "CenterObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarObject_StellarSystem_ParentId",
                table: "StellarObject",
                column: "ParentId",
                principalTable: "StellarSystem",
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
