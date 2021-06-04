using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Repositories.Score;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Persistence.Repositories.Score
{
    public class SubtestScoreFilterRepository : BaseRepository, ISubtestScoreFilterRepository
    {
        public SubtestScoreFilterRepository(AppDbContext context) : base(context)
        {
        }

        public void Add(SubtestScoreFilter subtestScoreFilter)
        {
            _context.SubtestScoreFilters.Add(subtestScoreFilter);
        }

        public async Task Delete(int subtestScoreFilterId)
        {
            var subtestScoreFilter = await _context.SubtestScoreFilters.Where(t => t.Id == subtestScoreFilterId).FirstOrDefaultAsync();
            subtestScoreFilter.DeletedAt = System.DateTime.Now;

            _context.SubtestScoreFilters.Attach(subtestScoreFilter);
            _context.Entry(subtestScoreFilter).Property(t => t.DeletedAt).IsModified = true;
        }

        public async Task<IEnumerable<SubtestScoreFilter>> ListAsync()
        {
            return await _context.SubtestScoreFilters.ToListAsync();
        }

        public void Update(SubtestScoreFilter subtestScoreFilter)
        {
            _context.SubtestScoreFilters.Update(subtestScoreFilter);
        }
    }
}