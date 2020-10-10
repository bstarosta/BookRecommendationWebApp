using Microsoft.EntityFrameworkCore.Migrations;

namespace BookRecommendationWebApp.Migrations
{
    public partial class ChangePreferenceValueType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Preference",
                table: "UserPreferences",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Preference",
                table: "UserPreferences",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
