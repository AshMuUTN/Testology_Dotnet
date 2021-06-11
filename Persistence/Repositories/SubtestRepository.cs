using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Testology_Dotnet.Domain.Models;
using Testology_Dotnet.Domain.Models.Auth;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Persistence.Contexts;

namespace Testology_Dotnet.Persistence.Repositories
{
    public class SubtestRepository : BaseRepository, ISubtestRepository
    {
        public SubtestRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Subtest>> ListAsync(int testId)
        {
            return await _context.Subtests.Where(s => s.TestId == testId && s.DeletedAt == null).ToListAsync();
        }

        public void Add(Subtest test)
        {    
            _context.Subtests.Add(test);
        }

        public void Update(Subtest test)
        {    
            _context.Subtests.Update(test);
        }

        public async Task Delete(int subtestId)
        {
            var subtest = await _context.Subtests.Where(s => s.Id == subtestId).FirstOrDefaultAsync();
            subtest.DeletedAt = System.DateTime.Now;

            _context.Subtests.Attach(subtest);
            _context.Entry(subtest).Property(s => s.DeletedAt).IsModified = true;
        }
    }
}