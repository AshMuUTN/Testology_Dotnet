using Microsoft.EntityFrameworkCore.Migrations;

namespace Testology_Dotnet.Migrations
{
    public partial class GroupScoreFilterOption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OptionId",
                table: "GroupScoreFilters",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GroupScoreFilters_OptionId",
                table: "GroupScoreFilters",
                column: "OptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupScoreFilters_Options_OptionId",
                table: "GroupScoreFilters",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupScoreFilters_Options_OptionId",
                table: "GroupScoreFilters");

            migrationBuilder.DropIndex(
                name: "IX_GroupScoreFilters_OptionId",
                table: "GroupScoreFilters");

            migrationBuilder.DropColumn(
                name: "OptionId",
                table: "GroupScoreFilters");
        }
    }
}
