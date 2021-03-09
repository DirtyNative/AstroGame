using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class ChangedPropName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstLevelNumber",
                table: "Stars",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "FirstLevelNumber",
                table: "Planets",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "SecondLevelNumber",
                table: "Moons",
                newName: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Stars",
                newName: "FirstLevelNumber");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Planets",
                newName: "FirstLevelNumber");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Moons",
                newName: "SecondLevelNumber");
        }
    }
}
