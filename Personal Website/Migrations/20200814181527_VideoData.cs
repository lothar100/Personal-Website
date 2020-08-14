using Microsoft.EntityFrameworkCore.Migrations;

namespace Personal_Website.Migrations
{
    public partial class VideoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoCSS",
                table: "Modules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoHeight",
                table: "Modules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoSrc",
                table: "Modules",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoWidth",
                table: "Modules",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoCSS",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "VideoHeight",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "VideoSrc",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "VideoWidth",
                table: "Modules");
        }
    }
}
