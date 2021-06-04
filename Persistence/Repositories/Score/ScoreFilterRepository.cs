using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Repositories.Score;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Persistence.Repositories.Score
{
    public class ScoreFilterRepository : BaseRepository, IScoreFilterRepository
    {
        public ScoreFilterRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ScoreFilter>> ListAsync()
        {
            return await _context.ScoreFilters.ToListAsync();
        }
    }
}