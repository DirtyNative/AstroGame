using Microsoft.EntityFrameworkCore.Migrations;

namespace AstroGame.Api.Migrations
{
    public partial class RemovedOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Stars");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Moons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Order",
                table: "Stars",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Order",
                table: "Planets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Order",
                table: "Moons",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
