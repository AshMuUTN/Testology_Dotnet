using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Testology_Dotnet.Migrations
{
    public partial class ScoreModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Questions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoreFilters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsForQuestions = table.Column<bool>(type: "boolean", nullable: false),
                    IsForSubtests = table.Column<bool>(type: "boolean", nullable: false),
                    IsForGroups = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreFilters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupScoreFilters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    ScoreFilterId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupScoreFilters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupScoreFilters_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupScoreFilters_ScoreFilters_ScoreFilterId",
                        column: x => x.ScoreFilterId,
                        principalTable: "ScoreFilters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionScoreFilters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<int>(type: "integer", nullable: false),
                    ScoreFilterId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionScoreFilters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionScoreFilters_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionScoreFilters_ScoreFilters_ScoreFilterId",
                        column: x => x.ScoreFilterId,
                        principalTable: "ScoreFilters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubtestScoreFilters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    SubtestId = table.Column<int>(type: "integer", nullable: false),
                    ScoreFilterId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubtestScoreFilters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubtestScoreFilters_ScoreFilters_ScoreFilterId",
                        column: x => x.ScoreFilterId,
                        principalTable: "ScoreFilters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubtestScoreFilters_Subtests_SubtestId",
                        column: x => x.SubtestId,
                        principalTable: "Subtests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_GroupId",
                table: "Questions",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupScoreFilters_GroupId",
                table: "GroupScoreFilters",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupScoreFilters_ScoreFilterId",
                table: "GroupScoreFilters",
                column: "ScoreFilterId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionScoreFilters_QuestionId",
                table: "QuestionScoreFilters",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionScoreFilters_ScoreFilterId",
                table: "QuestionScoreFilters",
                column: "ScoreFilterId");

            migrationBuilder.CreateIndex(
                name: "IX_SubtestScoreFilters_ScoreFilterId",
                table: "SubtestScoreFilters",
                column: "ScoreFilterId");

            migrationBuilder.CreateIndex(
                name: "IX_SubtestScoreFilters_SubtestId",
                table: "SubtestScoreFilters",
                column: "SubtestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Groups_GroupId",
                table: "Questions",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Groups_GroupId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "GroupScoreFilters");

            migrationBuilder.DropTable(
                name: "QuestionScoreFilters");

            migrationBuilder.DropTable(
                name: "SubtestScoreFilters");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "ScoreFilters");

            migrationBuilder.DropIndex(
                name: "IX_Questions_GroupId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Questions");
        }
    }
}
