using Microsoft.EntityFrameworkCore.Migrations;

namespace Testology_Dotnet.Migrations
{
    public partial class IsCalculableIsScorable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<bool>(
                name: "IsCalulable",
                table: "Subtests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsScorable",
                table: "Subtests",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCalulable",
                table: "Subtests");

            migrationBuilder.DropColumn(
                name: "IsScorable",
                table: "Subtests");
        }
    }
}
