using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models;

namespace Testology_Dotnet.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<User> Users { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<Test>().ToTable("Tests");
            builder.Entity<Test>().HasKey(p => p.Id);
            builder.Entity<Test>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Test>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Test>().Property(p => p.Description).IsRequired().HasMaxLength(3000);
            builder.Entity<Test>().Property(p => p.Created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Entity<Test>().HasOne(p => p.User).WithMany(p => p.Tests);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Password).IsRequired();
            builder.Entity<User>().HasMany(p => p.Tests).WithOne(p => p.User).HasForeignKey(p => p.UserId);
        }
    }
}