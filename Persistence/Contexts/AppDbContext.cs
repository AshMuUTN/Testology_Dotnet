using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Models.Auth;

namespace Testology_Dotnet.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
         public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Test> Tests { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
            
            builder.Entity<Test>().ToTable("Tests");
            builder.Entity<Test>().HasKey(p => p.Id);
            builder.Entity<Test>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Test>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Test>().Property(p => p.Description).IsRequired().HasMaxLength(3000);
            builder.Entity<Test>().Property(p => p.Created_at).HasDefaultValueSql("CURRENT_TIMESTAMP");
            //builder.Entity<Test>().HasOne(p => p.Test).WithMany(p => p.Tests);
        }
    }
}