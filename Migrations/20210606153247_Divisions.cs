using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Testology_Dotnet.Migrations
{
    public partial class Divisions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Groups_GroupId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "GroupId",
                table: "Questions",
                newName: "DivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_GroupId",
                table: "Questions",
                newName: "IX_Questions_DivisionId");

            migrationBuilder.AddColumn<int>(
                name: "SubtestId",
                table: "Groups",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SubtestId = table.Column<int>(type: "integer", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Divisions_Subtests_SubtestId",
                        column: x => x.SubtestId,
                        principalTable: "Subtests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_SubtestId",
                table: "Groups",
                column: "SubtestId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_SubtestId",
                table: "Divisions",
                column: "SubtestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Subtests_SubtestId",
                table: "Groups",
                column: "SubtestId",
                principalTable: "Subtests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Divisions_DivisionId",
                table: "Questions",
                column: "DivisionId",
                principalTable: "Divisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Subtests_SubtestId",
                table: "Groups");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Divisions_DivisionId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropIndex(
                name: "IX_Groups_SubtestId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "SubtestId",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "DivisionId",
                table: "Questions",
                newName: "GroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_DivisionId",
                table: "Questions",
                newName: "IX_Questions_GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Groups_GroupId",
                table: "Questions",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
