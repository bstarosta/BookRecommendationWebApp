using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookRecommendationWebApp.Migrations
{
    public partial class ChangeBookImageStorage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "ImageFile",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFile",
                table: "Books");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Books",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
