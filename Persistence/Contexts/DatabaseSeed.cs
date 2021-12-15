using System.Collections.Generic;
using System.Linq;
using Testology_Dotnet.Domain.Models.Auth;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Security.Hashing;

namespace Testology_Dotnet.Persistence.Contexts
{
    /// <summary>
    /// EF Core already supports database seeding throught overriding "OnModelCreating", but I decided to create a separate seed class to avoid 
    /// injecting IPasswordHasher into AppDbContext.
    /// To understand how to use database seeding into DbContext classes, check this link: https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding
    /// </summary>
    public class DatabaseSeed
    {
        public static void Seed(AppDbContext context, IPasswordHasher passwordHasher)
        {
            context.Database.EnsureCreated();
            
            if (context.Roles.Count() == 0)
            {

                var roles = new List<Role>
                {
                new Role { Name = ApplicationRole.Common.ToString() },
                new Role { Name = ApplicationRole.Administrator.ToString() },
                new Role { Name = ApplicationRole.PasswordReovery.ToString() }
                };

                context.Roles.AddRange(roles);
                context.SaveChanges();
            }

            if (context.Users.Count() == 0)
            {
                var users = new List<User>
                {
                    new User { Email = "admin@admin.com", Password = passwordHasher.HashPassword("12345678") },
                    new User { Email = "common@common.com", Password = passwordHasher.HashPassword("12345678") },
                };

                users[0].UserRoles.Add(new UserRole
                {
                    RoleId = context.Roles.SingleOrDefault(r => r.Name == ApplicationRole.Administrator.ToString()).Id
                });

                users[1].UserRoles.Add(new UserRole
                {
                    RoleId = context.Roles.SingleOrDefault(r => r.Name == ApplicationRole.Common.ToString()).Id
                });

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            if (context.ScoreFilters.Count() == 0)
            {
                var scoreFilters = new List<ScoreFilter>
                {
                    new ScoreFilter { Description = "arbitrary", IsForQuestions = true, IsForGroups = true, IsForSubtests = false },
                    new ScoreFilter { Description = "count members", IsForQuestions = false, IsForGroups = true, IsForSubtests = false },
                    new ScoreFilter { Description = "add value", IsForQuestions = true, IsForGroups = true, IsForSubtests = true },
                    new ScoreFilter { Description = "add value of", IsForQuestions = true, IsForGroups = false, IsForSubtests = true },
                    new ScoreFilter { Description = "multiply value", IsForQuestions = true, IsForGroups = true, IsForSubtests = true },
                    new ScoreFilter { Description = "multiply value of", IsForQuestions = true, IsForGroups = false, IsForSubtests = true },
                    new ScoreFilter { Description = "divide value", IsForQuestions = true, IsForGroups = true, IsForSubtests = true },
                    new ScoreFilter { Description = "divide value of", IsForQuestions = true, IsForGroups = false, IsForSubtests = true },
                    new ScoreFilter { Description = "range", IsForQuestions = true, IsForGroups = false, IsForSubtests = false },
                    new ScoreFilter { Description = "self", IsForQuestions = true, IsForGroups = false, IsForSubtests = false }, 
                    new ScoreFilter { Description = "max", IsForQuestions = false, IsForGroups = false, IsForSubtests = true }
                };


                context.ScoreFilters.AddRange(scoreFilters);
                context.SaveChanges();
            }

            if (context.Groups.Count() == 0)
            {
                var groups = new List<Group>
                {
                    new Group { Description = "Correct" },
                    new Group { Description = "Incorrect" },
                    new Group { Description = "Present" },
                    new Group { Description = "Absent" }
                };


                context.Groups.AddRange(groups);
                context.SaveChanges();
            }
        }
    }
}