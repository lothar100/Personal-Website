using Microsoft.EntityFrameworkCore.Migrations;

namespace Personal_Website.Migrations
{
    public partial class ModuleLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Modules");

            migrationBuilder.AddColumn<string>(
                name: "LinkId",
                table: "Modules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkText",
                table: "Modules",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkId",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "LinkText",
                table: "Modules");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
