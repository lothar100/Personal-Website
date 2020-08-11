using Microsoft.EntityFrameworkCore.Migrations;

namespace Personal_Website.Migrations
{
    public partial class ImageData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Modules");

            migrationBuilder.AddColumn<int>(
                name: "ImageCount",
                table: "Modules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageHeight",
                table: "Modules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Modules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageWidth",
                table: "Modules",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageCount",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ImageHeight",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Modules");

            migrationBuilder.DropColumn(
                name: "ImageWidth",
                table: "Modules");

            migrationBuilder.AddColumn<string>(
                name: "ImageData",
                table: "Modules",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
