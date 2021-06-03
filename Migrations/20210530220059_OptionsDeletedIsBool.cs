using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Testology_Dotnet.Migrations
{
    public partial class OptionsDeletedIsBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Options");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Options",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Options");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Options",
                type: "timestamp without time zone",
                nullable: true);
        }
    }
}
