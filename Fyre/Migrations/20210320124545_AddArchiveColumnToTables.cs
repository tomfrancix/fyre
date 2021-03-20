using Microsoft.EntityFrameworkCore.Migrations;

namespace Fyre.Console.Migrations
{
    public partial class AddArchiveColumnToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Archived",
                table: "Lists",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Archived",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Archived",
                table: "Lists");
        }
    }
}
