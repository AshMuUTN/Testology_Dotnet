using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Models.Auth;
using Testology_Dotnet.Domain.Models.Score;

namespace Testology_Dotnet.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
         public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Subtest> Subtests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Protocol> Protocols { get; set; }
        public DbSet<Answer> Answers { get; set; }
        
        //------------ SCORE attributes ----------------//
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupScoreFilter> GroupScoreFilters { get; set; }
        public DbSet<QuestionScoreFilter> QuestionScoreFilters { get; set; }
        public DbSet<SubtestScoreFilter> SubtestScoreFilters { get; set; }
         public DbSet<ScoreFilter> ScoreFilters { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
            
            builder.Entity<Test>().ToTable("Tests");
            builder.Entity<Test>().HasKey(p => p.Id);
            builder.Entity<Test>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Test>().Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Entity<Test>().Property(p => p.Description).IsRequired().HasMaxLength(3000);
            builder.Entity<Test>().Property(p => p.Created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Entity<Test>().HasOne(p => p.User).WithMany(p => p.Tests);

            builder.Entity<Subtest>().ToTable("Subtests");
            builder.Entity<Subtest>().HasKey(p => p.Id);
            builder.Entity<Subtest>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Subtest>().Property(p => p.Name).IsRequired().HasMaxLength(255);
            builder.Entity<Subtest>().Property(p => p.Description).IsRequired().HasMaxLength(3000);
            builder.Entity<Subtest>().Property(p => p.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Entity<Subtest>().Property(p => p.IsCalculable).HasDefaultValue(false);
            builder.Entity<Subtest>().Property(p => p.IsScorable).HasDefaultValue(false);
            builder.Entity<Subtest>().HasOne(p => p.Test).WithMany(p => p.Subtests);
            builder.Entity<Subtest>().HasMany(p => p.Divisions).WithOne(p => p.Subtest);
            builder.Entity<Subtest>().HasMany(p => p.Groups).WithOne(p => p.Subtest);

            builder.Entity<Question>().ToTable("Questions");
            builder.Entity<Question>().HasKey(p => p.Id);
            builder.Entity<Question>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Question>().Property(p => p.Text).IsRequired().HasMaxLength(255);
            builder.Entity<Question>().HasOne(p => p.Subtest).WithMany(p => p.Questions);
            builder.Entity<Question>().HasMany(p => p.Options).WithOne(p => p.Question);
            builder.Entity<Question>().HasOne(p => p.Image).WithMany(p => p.Questions);
            builder.Entity<Question>().HasMany(p => p.Answers).WithOne(p => p.Question);

            builder.Entity<Option>().ToTable("Options");
            builder.Entity<Option>().HasKey(p => p.Id);
            builder.Entity<Option>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Option>().HasOne(p => p.Question).WithMany(p => p.Options).HasForeignKey(p => p.QuestionId);
            builder.Entity<Option>().Property(p => p.IsCorrect).HasDefaultValue(false);
            builder.Entity<Option>().HasMany(p => p.GroupScoreFilters).WithOne(p => p.Option);
            builder.Entity<Option>().HasMany(p => p.Answers).WithOne(p => p.Option);

            builder.Entity<Image>().ToTable("Images");
            builder.Entity<Image>().HasKey(p => p.Id);
            builder.Entity<Image>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Image>().HasMany(p => p.Questions).WithOne(p => p.Image);

            builder.Entity<Protocol>().ToTable("Protocols");
            builder.Entity<Protocol>().HasKey(p => p.Id);
            builder.Entity<Protocol>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Protocol>().HasMany(p => p.Answers).WithOne(p => p.Protocol);
            builder.Entity<Protocol>().HasOne(p => p.Test).WithMany(p => p.Protocols);
            builder.Entity<Protocol>().Property(p => p.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Entity<Answer>().ToTable("Answers");
            builder.Entity<Answer>().HasKey(p => p.Id);
            builder.Entity<Answer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Answer>().HasOne(p => p.Question).WithMany(p => p.Answers);
            builder.Entity<Answer>().HasOne(p => p.Option).WithMany(p => p.Answers);
            builder.Entity<Answer>().HasOne(p => p.Protocol).WithMany(p => p.Answers);

            //--------------------SCORE ----------------------------------//
            
            builder.Entity<Division>().ToTable("Divisions");
            builder.Entity<Division>().HasKey(p => p.Id);
            builder.Entity<Division>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Division>().HasMany(p => p.Questions).WithOne(p => p.Division);
            builder.Entity<Division>().HasOne(p => p.Subtest).WithMany(p => p.Divisions);

            builder.Entity<Group>().ToTable("Groups");
            builder.Entity<Group>().HasKey(p => p.Id);
            builder.Entity<Group>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Group>().HasMany(p => p.GroupScoreFilters).WithOne(p => p.Group);
            builder.Entity<Group>().HasOne(p => p.Subtest).WithMany(p => p.Groups);

            builder.Entity<GroupScoreFilter>().ToTable("GroupScoreFilters");
            builder.Entity<GroupScoreFilter>().HasKey(p => p.Id);
            builder.Entity<GroupScoreFilter>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<GroupScoreFilter>().Property(p => p.GroupId).IsRequired();
            builder.Entity<GroupScoreFilter>().Property(p => p.ScoreFilterId).IsRequired();
            builder.Entity<GroupScoreFilter>().HasOne(p => p.Group).WithMany(p => p.GroupScoreFilters);
            builder.Entity<GroupScoreFilter>().HasOne(p => p.ScoreFilter).WithMany(p => p.GroupScoreFilters);
            builder.Entity<GroupScoreFilter>().HasOne(p => p.Option).WithMany(p => p.GroupScoreFilters);

            builder.Entity<QuestionScoreFilter>().ToTable("QuestionScoreFilters");
            builder.Entity<QuestionScoreFilter>().HasKey(p => p.Id);
            builder.Entity<QuestionScoreFilter>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<QuestionScoreFilter>().Property(p => p.QuestionId).IsRequired();
            builder.Entity<QuestionScoreFilter>().Property(p => p.ScoreFilterId).IsRequired();
            builder.Entity<QuestionScoreFilter>().HasOne(p => p.Question).WithMany(p => p.QuestionScoreFilters);
            builder.Entity<QuestionScoreFilter>().HasOne(p => p.ScoreFilter).WithMany(p => p.QuestionScoreFilters);

            builder.Entity<SubtestScoreFilter>().ToTable("SubtestScoreFilters");
            builder.Entity<SubtestScoreFilter>().HasKey(p => p.Id);
            builder.Entity<SubtestScoreFilter>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<SubtestScoreFilter>().Property(p => p.SubtestId).IsRequired();
            builder.Entity<SubtestScoreFilter>().Property(p => p.ScoreFilterId).IsRequired();
            builder.Entity<SubtestScoreFilter>().HasOne(p => p.Subtest).WithMany(p => p.SubtestScoreFilters);
            builder.Entity<SubtestScoreFilter>().HasOne(p => p.ScoreFilter).WithMany(p => p.SubtestScoreFilters);

            builder.Entity<ScoreFilter>().ToTable("ScoreFilters");
            builder.Entity<ScoreFilter>().HasKey(p => p.Id);
            builder.Entity<ScoreFilter>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ScoreFilter>().HasMany(p => p.SubtestScoreFilters).WithOne(p => p.ScoreFilter);
            builder.Entity<ScoreFilter>().HasMany(p => p.QuestionScoreFilters).WithOne(p => p.ScoreFilter);
            builder.Entity<ScoreFilter>().HasMany(p => p.GroupScoreFilters).WithOne(p => p.ScoreFilter);
        }
    }
}