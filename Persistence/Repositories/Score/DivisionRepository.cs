using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models.Score;
using Testology_Dotnet.Domain.Repositories.Score;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Persistence.Repositories.Score
{
    public class DivisionRepository : BaseRepository, IDivisionRepository
    {
        public DivisionRepository(AppDbContext context) : base(context)
        {
        }

        public void Add(Division division)
        {
            _context.Divisions.Add(division);
        }

        public async Task Delete(int divisionId)
        {
            var division = await _context.Divisions.Where(d => d.Id == divisionId).FirstOrDefaultAsync();
            division.DeletedAt = System.DateTime.Now;

            _context.Divisions.Attach(division);
            _context.Entry(division).Property(t => t.DeletedAt).IsModified = true;
        }

        public async Task<IEnumerable<Division>> ListAsync(int subtestId)
        {
            return await _context.Divisions.Where(d => d.SubtestId == subtestId && d.DeletedAt == null).ToListAsync();
        }

        public void Update(Division division)
        {
            _context.Divisions.Update(division);
        }
    }
}