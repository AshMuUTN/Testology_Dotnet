using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Repositories.Score;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Persistence.Repositories.Score
{
    public class GroupRepository : BaseRepository, IGroupRepository
    {
        public GroupRepository(AppDbContext context) : base(context)
        {
        }

        public void Add(Group group)
        {
            _context.Groups.Add(group);
        }

        public async Task Delete(int groupId)
        {
            var group = await _context.Groups.Where(g => g.Id == groupId).FirstOrDefaultAsync();
            group.DeletedAt = System.DateTime.Now;

            _context.Groups.Attach(group);
            _context.Entry(group).Property(t => t.DeletedAt).IsModified = true;
        }

        public async Task<IEnumerable<Group>> ListAsync(int subtestId)
        {
            return await _context.Groups
                .Where(g => g.SubtestId == subtestId && g.DeletedAt == null)
                .ToListAsync();
        }

        public void Update(Group group)
        {
            _context.Groups.Update(group);
        }
    }
}