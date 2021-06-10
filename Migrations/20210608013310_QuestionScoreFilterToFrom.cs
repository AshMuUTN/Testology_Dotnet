using Microsoft.EntityFrameworkCore.Migrations;

namespace Testology_Dotnet.Migrations
{
    public partial class QuestionScoreFilterToFrom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "From",
                table: "QuestionScoreFilters",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "To",
                table: "QuestionScoreFilters",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isForCorrectAnswers",
                table: "QuestionScoreFilters",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "QuestionScoreFilters");

            migrationBuilder.DropColumn(
                name: "To",
                table: "QuestionScoreFilters");

            migrationBuilder.DropColumn(
                name: "isForCorrectAnswers",
                table: "QuestionScoreFilters");
        }
    }
}
