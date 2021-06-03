using Microsoft.EntityFrameworkCore.Migrations;

namespace Testology_Dotnet.Migrations
{
    public partial class NumberOptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Number",
                table: "Options",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Options");
        }
    }
}
