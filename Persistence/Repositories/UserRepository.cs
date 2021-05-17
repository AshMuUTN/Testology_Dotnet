using System.Linq;
using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Auth;
using Testology_Dotnet.Domain.Repositories.Auth;
using Testology_Dotnet.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Testology_Dotnet.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user, ApplicationRole[] userRoles)
        {
            var roleNames = userRoles.Select(r => r.ToString()).ToList();
            var roles = await _context.Roles.Where(r => roleNames.Contains(r.Name)).ToListAsync();

            foreach(var role in roles)
            {
                user.UserRoles.Add(new UserRole { RoleId = role.Id });
            }
               
            _context.Users.Add(user);
        }

        public void UpdatePassword(User user)
        {      
            _context.Users.Attach(user);
            _context.Entry(user).Property(x => x.Password).IsModified = true;
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.UserRoles)
                                       .ThenInclude(ur => ur.Role)
                                       .SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}