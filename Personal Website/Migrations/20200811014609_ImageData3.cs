using Microsoft.EntityFrameworkCore.Migrations;

namespace Personal_Website.Migrations
{
    public partial class ImageData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageHeight",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ImageWidth",
                table: "Modules");

            migrationBuilder.AddColumn<string>(
                name: "ImageCSS",
                table: "Modules",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageCSS",
                table: "Modules");

            migrationBuilder.AddColumn<int>(
                name: "ImageHeight",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageWidth",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
