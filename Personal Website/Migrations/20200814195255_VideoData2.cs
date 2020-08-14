using Microsoft.EntityFrameworkCore.Migrations;

namespace Personal_Website.Migrations
{
    public partial class VideoData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoCSS",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "VideoHeight",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "VideoWidth",
                table: "Modules");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoCSS",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoHeight",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoWidth",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
