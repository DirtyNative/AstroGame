using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class OverhauledObjectSortingSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAtmosphere",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "HasClouds",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "HasRings",
                table: "Moons");

            migrationBuilder.RenameColumn(
                name: "HasRings",
                table: "Planets",
                newName: "HasHabitableAtmosphere");

            migrationBuilder.AddColumn<long>(
                name: "FirstLevelNumber",
                table: "Stars",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SystemNumber",
                table: "SolarSystems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FirstLevelNumber",
                table: "Planets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "SecondLevelNumber",
                table: "Moons",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstLevelNumber",
                table: "Stars");

            migrationBuilder.DropColumn(
                name: "SystemNumber",
                table: "SolarSystems");

            migrationBuilder.DropColumn(
                name: "FirstLevelNumber",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "SecondLevelNumber",
                table: "Moons");

            migrationBuilder.RenameColumn(
                name: "HasHabitableAtmosphere",
                table: "Planets",
                newName: "HasRings");

            migrationBuilder.AddColumn<bool>(
                name: "HasAtmosphere",
                table: "Planets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasClouds",
                table: "Planets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasRings",
                table: "Moons",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
