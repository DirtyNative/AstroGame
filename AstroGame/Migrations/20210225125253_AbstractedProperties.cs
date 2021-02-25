using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class AbstractedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystem_MultiObjectSystems_MultiObjectSystemId",
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

            migrationBuilder.DropIndex(
                name: "IX_StellarSystem_StellarSystemId",
                table: "StellarSystem");

            migrationBuilder.RenameColumn(
                name: "StellarSystemId",
                table: "StellarSystem",
                newName: "CenterObjectId");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "StellarSystem",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "(newid())");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "StellarSystem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<double>(
                name: "Scale",
                table: "StellarObject",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "StellarObject",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "(newid())");

            migrationBuilder.AddColumn<double>(
                name: "AverageDistanceToCenter",
                table: "StellarObject",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AverageTemperature",
                table: "StellarObject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "AxialTilt",
                table: "StellarObject",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "StellarObject",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "HasAtmosphere",
                table: "StellarObject",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasRings",
                table: "StellarObject",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanetType",
                table: "StellarObject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Planet_AxialTilt",
                table: "StellarObject",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Planet_HasRings",
                table: "StellarObject",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Planet_PrefabName",
                table: "StellarObject",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Planet_Scale",
                table: "StellarObject",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StarType",
                table: "StellarObject",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Star_AxialTilt",
                table: "StellarObject",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Star_PrefabName",
                table: "StellarObject",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Star_Scale",
                table: "StellarObject",
                type: "float",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StellarSystem_CenterObjectId",
                table: "StellarSystem",
                column: "CenterObjectId",
                unique: true,
                filter: "[CenterObjectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystem_StellarObject_CenterObjectId",
                table: "StellarSystem",
                column: "CenterObjectId",
                principalTable: "StellarObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystem_StellarSystem_MultiObjectSystemId",
                table: "StellarSystem",
                column: "MultiObjectSystemId",
                principalTable: "StellarSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystem_StellarObject_CenterObjectId",
                table: "StellarSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_StellarSystem_StellarSystem_MultiObjectSystemId",
                table: "StellarSystem");

            migrationBuilder.DropIndex(
                name: "IX_StellarSystem_CenterObjectId",
                table: "StellarSystem");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "StellarSystem");

            migrationBuilder.DropColumn(
                name: "AverageDistanceToCenter",
                table: "StellarObject");

            migrationBuilder.DropColumn(
                name: "AverageTemperature",
                table: "StellarObject");

            migrationBuilder.DropColumn(
                name: "AxialTilt",
                table: "StellarObject");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "StellarObject");

            migrationBuilder.DropColumn(
                name: "HasAtmosphere",
                table: "StellarObject");

            migrationBuilder.DropColumn(
                name: "HasRings",
                table: "StellarObject");

            migrationBuilder.DropColumn(
                name: "PlanetType",
                table: "StellarObject");

            migrationBuilder.DropColumn(
                name: "Planet_AxialTilt",
                table: "StellarObject");

            migrationBuilder.DropColumn(
                name: "Planet_HasRings",
                table: "StellarObject");

            migrationBuilder.DropColumn(
                name: "Planet_PrefabName",
                table: "StellarObject");

            migrationBuilder.DropColumn(
                name: "Planet_Scale",
                table: "StellarObject");

            migrationBuilder.DropColumn(
                name: "StarType",
                table: "StellarObject");

            migrationBuilder.DropColumn(
                name: "Star_AxialTilt",
                table: "StellarObject");

            migrationBuilder.DropColumn(
                name: "Star_PrefabName",
                table: "StellarObject");

            migrationBuilder.DropColumn(
                name: "Star_Scale",
                table: "StellarObject");

            migrationBuilder.RenameColumn(
                name: "CenterObjectId",
                table: "StellarSystem",
                newName: "StellarSystemId");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "StellarSystem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(newid())",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<double>(
                name: "Scale",
                table: "StellarObject",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "StellarObject",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(newid())",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
                    CenterObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleObjectSystems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleObjectSystems_StellarObject_CenterObjectId",
                        column: x => x.CenterObjectId,
                        principalTable: "StellarObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_StellarSystem_StellarSystemId",
                table: "StellarSystem",
                column: "StellarSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleObjectSystems_CenterObjectId",
                table: "SingleObjectSystems",
                column: "CenterObjectId",
                unique: true,
                filter: "[CenterObjectId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StellarSystem_MultiObjectSystems_MultiObjectSystemId",
                table: "StellarSystem",
                column: "MultiObjectSystemId",
                principalTable: "MultiObjectSystems",
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
