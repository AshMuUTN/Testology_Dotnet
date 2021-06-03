using Microsoft.EntityFrameworkCore.Migrations;

namespace Testology_Dotnet.Migrations
{
    public partial class RenameIsCalculable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCalulable",
                table: "Subtests",
                newName: "IsCalculable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsCalculable",
                table: "Subtests",
                newName: "IsCalulable");
        }
    }
}
