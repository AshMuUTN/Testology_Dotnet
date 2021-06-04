using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Repositories.Score;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Persistence.Repositories.Score
{
    public class GroupScoreFilterRepository : BaseRepository, IGroupScoreFilterRepository
    {
        public GroupScoreFilterRepository(AppDbContext context) : base(context)
        {
        }

        public void Add(GroupScoreFilter groupScoreFilter)
        {
            _context.GroupScoreFilters.Add(groupScoreFilter);
        }

        public async Task Delete(int groupScoreFilterId)
        {
            var groupScoreFilter = await _context.GroupScoreFilters.Where(t => t.Id == groupScoreFilterId).FirstOrDefaultAsync();
            groupScoreFilter.DeletedAt = System.DateTime.Now;

            _context.GroupScoreFilters.Attach(groupScoreFilter);
            _context.Entry(groupScoreFilter).Property(t => t.DeletedAt).IsModified = true;
        }

        public async Task<IEnumerable<GroupScoreFilter>> ListAsync()
        {
            return await _context.GroupScoreFilters.ToListAsync();
        }

        public void Update(GroupScoreFilter groupScoreFilter)
        {
            _context.GroupScoreFilters.Update(groupScoreFilter);
        }
    }
}