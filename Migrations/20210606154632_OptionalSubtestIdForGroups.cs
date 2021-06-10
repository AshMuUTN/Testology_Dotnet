using Microsoft.EntityFrameworkCore.Migrations;

namespace Testology_Dotnet.Migrations
{
    public partial class OptionalSubtestIdForGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Subtests_SubtestId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "SubtestId",
                table: "Groups",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Subtests_SubtestId",
                table: "Groups",
                column: "SubtestId",
                principalTable: "Subtests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Subtests_SubtestId",
                table: "Groups");

            migrationBuilder.AlterColumn<int>(
                name: "SubtestId",
                table: "Groups",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Subtests_SubtestId",
                table: "Groups",
                column: "SubtestId",
                principalTable: "Subtests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
