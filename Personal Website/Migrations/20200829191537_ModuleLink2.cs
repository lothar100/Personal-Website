using Microsoft.EntityFrameworkCore.Migrations;

namespace Personal_Website.Migrations
{
    public partial class ModuleLink2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkGlyph",
                table: "Modules",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkGlyph",
                table: "Modules");
        }
    }
}
