﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210618234017_GroupsDefaultValue")]
    partial class GroupsDefaultValue
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<float>("NumberAnswer")
                        .HasColumnType("real");

                    b.Property<int?>("OptionId")
                        .HasColumnType("integer");

                    b.Property<int>("ProtocolId")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<string>("TextAnswer")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OptionId");

                    b.HasIndex("ProtocolId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Auth.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Auth.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Auth.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Path")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Deleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsCorrect")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<float>("Number")
                        .HasColumnType("real");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Protocol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("TestId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Protocols");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("DivisionId")
                        .HasColumnType("integer");

                    b.Property<int?>("ImageId")
                        .HasColumnType("integer");

                    b.Property<int>("SubtestId")
                        .HasColumnType("integer");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.HasIndex("ImageId");

                    b.HasIndex("SubtestId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Score.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("SubtestId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubtestId");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Score.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<float>("DefaultValue")
                        .HasColumnType("real");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int?>("SubtestId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubtestId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Score.GroupScoreFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int>("OptionId")
                        .HasColumnType("integer");

                    b.Property<int>("Rank")
                        .HasColumnType("integer");

                    b.Property<int>("ScoreFilterId")
                        .HasColumnType("integer");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("OptionId");

                    b.HasIndex("ScoreFilterId");

                    b.ToTable("GroupScoreFilters");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Score.QuestionScoreFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("From")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("Rank")
                        .HasColumnType("integer");

                    b.Property<int>("ScoreFilterId")
                        .HasColumnType("integer");

                    b.Property<int?>("To")
                        .HasColumnType("integer");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.Property<bool>("isForCorrectAnswers")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("ScoreFilterId");

                    b.ToTable("QuestionScoreFilters");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Score.ScoreFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsForGroups")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsForQuestions")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsForSubtests")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("ScoreFilters");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Score.SubtestScoreFilter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Rank")
                        .HasColumnType("integer");

                    b.Property<int>("ScoreFilterId")
                        .HasColumnType("integer");

                    b.Property<int>("SubtestId")
                        .HasColumnType("integer");

                    b.Property<float>("Value")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ScoreFilterId");

                    b.HasIndex("SubtestId");

                    b.ToTable("SubtestScoreFilters");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Subtest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("character varying(3000)");

                    b.Property<bool>("IsCalculable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsScorable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("TestId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Subtests");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Created_at")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(3000)
                        .HasColumnType("character varying(3000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Answer", b =>
                {
                    b.HasOne("Testology_Dotnet.Domain.Models.Option", "Option")
                        .WithMany("Answers")
                        .HasForeignKey("OptionId");

                    b.HasOne("Testology_Dotnet.Domain.Models.Protocol", "Protocol")
                        .WithMany("Answers")
                        .HasForeignKey("ProtocolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Testology_Dotnet.Domain.Models.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Option");

                    b.Navigation("Protocol");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Auth.UserRole", b =>
                {
                    b.HasOne("Testology_Dotnet.Domain.Models.Auth.Role", "Role")
                        .WithMany("UsersRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Testology_Dotnet.Domain.Models.Auth.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Option", b =>
                {
                    b.HasOne("Testology_Dotnet.Domain.Models.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Protocol", b =>
                {
                    b.HasOne("Testology_Dotnet.Domain.Models.Test", "Test")
                        .WithMany("Protocols")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Question", b =>
                {
                    b.HasOne("Testology_Dotnet.Domain.Models.Score.Division", "Division")
                        .WithMany("Questions")
                        .HasForeignKey("DivisionId");

                    b.HasOne("Testology_Dotnet.Domain.Models.Image", "Image")
                        .WithMany("Questions")
                        .HasForeignKey("ImageId");

                    b.HasOne("Testology_Dotnet.Domain.Models.Subtest", "Subtest")
                        .WithMany("Questions")
                        .HasForeignKey("SubtestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");

                    b.Navigation("Image");

                    b.Navigation("Subtest");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Score.Division", b =>
                {
                    b.HasOne("Testology_Dotnet.Domain.Models.Subtest", "Subtest")
                        .WithMany("Divisions")
                        .HasForeignKey("SubtestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subtest");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Score.Group", b =>
                {
                    b.HasOne("Testology_Dotnet.Domain.Models.Subtest", "Subtest")
                        .WithMany("Groups")
                        .HasForeignKey("SubtestId");

                    b.Navigation("Subtest");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Score.GroupScoreFilter", b =>
                {
                    b.HasOne("Testology_Dotnet.Domain.Models.Score.Group", "Group")
                        .WithMany("GroupScoreFilters")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Testology_Dotnet.Domain.Models.Option", "Option")
                        .WithMany("GroupScoreFilters")
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Testology_Dotnet.Domain.Models.Score.ScoreFilter", "ScoreFilter")
                        .WithMany("GroupScoreFilters")
                        .HasForeignKey("ScoreFilterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Option");

                    b.Navigation("ScoreFilter");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Score.QuestionScoreFilter", b =>
                {
                    b.HasOne("Testology_Dotnet.Domain.Models.Question", "Question")
                        .WithMany("QuestionScoreFilters")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Testology_Dotnet.Domain.Models.Score.ScoreFilter", "ScoreFilter")
                        .WithMany("QuestionScoreFilters")
                        .HasForeignKey("ScoreFilterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("ScoreFilter");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Score.SubtestScoreFilter", b =>
                {
                    b.HasOne("Testology_Dotnet.Domain.Models.Score.ScoreFilter", "ScoreFilter")
                        .WithMany("SubtestScoreFilters")
                        .HasForeignKey("ScoreFilterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Testology_Dotnet.Domain.Models.Subtest", "Subtest")
                        .WithMany("SubtestScoreFilters")
                        .HasForeignKey("SubtestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ScoreFilter");

                    b.Navigation("Subtest");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Subtest", b =>
                {
                    b.HasOne("Testology_Dotnet.Domain.Models.Test", "Test")
                        .WithMany("Subtests")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Test");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Test", b =>
                {
                    b.HasOne("Testology_Dotnet.Domain.Models.Auth.User", "User")
                        .WithMany("Tests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Auth.Role", b =>
                {
                    b.Navigation("UsersRole");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Auth.User", b =>
                {
                    b.Navigation("Tests");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Image", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Option", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("GroupScoreFilters");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Protocol", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Options");

                    b.Navigation("QuestionScoreFilters");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Score.Division", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Score.Group", b =>
                {
                    b.Navigation("GroupScoreFilters");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Score.ScoreFilter", b =>
                {
                    b.Navigation("GroupScoreFilters");

                    b.Navigation("QuestionScoreFilters");

                    b.Navigation("SubtestScoreFilters");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Subtest", b =>
                {
                    b.Navigation("Divisions");

                    b.Navigation("Groups");

                    b.Navigation("Questions");

                    b.Navigation("SubtestScoreFilters");
                });

            modelBuilder.Entity("Testology_Dotnet.Domain.Models.Test", b =>
                {
                    b.Navigation("Protocols");

                    b.Navigation("Subtests");
                });
#pragma warning restore 612, 618
        }
    }
}
